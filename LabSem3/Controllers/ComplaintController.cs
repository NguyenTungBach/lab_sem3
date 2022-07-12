using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using LabSem3.Data;
using LabSem3.Enum;
using LabSem3.Models;
using LabSem3.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;

namespace LabSem3.Controllers
{
    public class ComplaintController : Controller
    {
        private UserManager<Account> userManager; //Bên database
        private RoleManager<IdentityRole> roleManager; //Bên database
        private LabSem3Context db;
        private static string AccountEmailSend = "bachntth2010055@fpt.edu.vn";
        private static string AccountNameSend = "MEGA LAB";

        public ComplaintController()
        {
            db = new LabSem3Context();
            UserStore<Account> userStore = new UserStore<Account>(db); // create, update, delete giống UserModel
            userManager = new UserManager<Account>(userStore); // giống Service, xử lý các vấn đề liên quan đến logic
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(db); // create, update, delete giống UserModel
            roleManager = new RoleManager<IdentityRole>(roleStore); // giống Service, xử lý các vấn đề liên quan đến logic
        }

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        // GET: Complaint
        public ActionResult Index(int? TypeComplaintCheck, string SupportID, string keyWord, int? statusCheck,  int? page) {
            
            var result2 = db.Complaints.OrderBy(s => s.Id).AsQueryable();

            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            if (!User.IsInRole("ADMIN") || !User.IsInRole("HOD"))
            {
                var userID = User.Identity.GetUserId();
                if (User.IsInRole(RoleEnum.INSTRUCTOR.ToString()) || User.IsInRole(RoleEnum.TECHNICAL_STAFF.ToString()))
                {
                    result2 = result2.Where(s => s.SupportedId.Equals(userID));
                }
                if(User.IsInRole(RoleEnum.STUDENT.ToString()))
                {
                    result2 = result2.Where(s => s.AccountId == userID);
                }
            }

            if (SupportID != null  && SupportID.Length >0)
            {
                if (SupportID.Equals("1"))
                {
                    result2 = result2.Where(s => s.SupportedId.Equals(null));
                }
                else
                {
                    result2 = result2.Where(s => s.SupportedId.Equals(SupportID));
                }
            }



            if (!string.IsNullOrEmpty(keyWord))
            {
                result2 = result2.Where(s => s.Title.Contains(keyWord) || s.Detail.Contains(keyWord));
            }

            if (statusCheck != -1 && statusCheck != null)
            {
                result2 = result2.Where(s => s.Status == statusCheck);
            }
            if (TypeComplaintCheck != null)
            {
                result2 = result2.Where(s => s.TypeComplaintId == TypeComplaintCheck);
            }
            ViewBag.TypeComplaintList = db.TypeComplaints.ToList();
            ViewBag.TypeComplaintCheck = TypeComplaintCheck;
            ViewBag.statusCheck = statusCheck;
            ViewBag.SupportID = SupportID;
            var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            var roleTECHNICAL = db.Roles.Where(s => s.Name.Contains(RoleEnum.TECHNICAL_STAFF.ToString())).FirstOrDefault();
            ViewBag.Support = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id) || c.RoleId.Contains(roleTECHNICAL.Id))).ToList(); ;

            ViewBag.keyWord = keyWord;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(result2.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "ADMIN,HOD")]
        public ActionResult ComplaintWaiting(int? page)
        {
            //var listTechnicalStaff = new List<Account>();
            //var listInstructor = new List<Account>();
            //foreach (var user in db.Users.ToList())
            //{
            //    var checkRole = userManager.GetRoles(user.Id).ToList();
            //    foreach (var role in checkRole)
            //    {
            //        if (role == RoleEnum.TECHNICAL_STAFF.ToString())
            //        {
            //            listTechnicalStaff.Add(user);
            //        }

            //        if (role == RoleEnum.INSTRUCTOR.ToString())
            //        {
            //            listInstructor.Add(user);
            //        }
            //    }
            //}

            //ViewBag.listTechnicalStaff = listTechnicalStaff;
            //ViewBag.listInstructor = listInstructor;

            var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            ViewBag.listInstructor = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();

            var roleTECHNICAL_STAFF = db.Roles.Where(s => s.Name.Contains(RoleEnum.TECHNICAL_STAFF.ToString())).FirstOrDefault();
            ViewBag.listTechnicalStaff = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleTECHNICAL_STAFF.Id))).ToList();

            ViewBag.UserAll = db.Users.ToList();
            var result2 = db.Complaints.OrderBy(s => s.Id).Include(s => s.TypeComplaint).AsQueryable().Where(s => s.Status == 4);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(result2.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AssignPeople(int comPlaintId, string StaffId)
        {
            try
            {
                var processComplaint = db.Complaints.Find(comPlaintId);
                processComplaint.Status = 2;
                processComplaint.SupportedId = StaffId;
                var supporter = db.Users.Find(StaffId);
                var accountComplaint = db.Users.Find(processComplaint.AccountId);
                var typeComplaint = db.TypeComplaints.Find(processComplaint.TypeComplaintId);
                
                var message = System.IO.File.ReadAllText(Server.MapPath("~/TemplateMail/AssignComplaintMail.html"));
                message = message.Replace("{{Id}}", processComplaint.Id.ToString());
                message = message.Replace("{{TypeComplaintName}}", typeComplaint.Name);
                message = message.Replace("{{SupporterUserName}}", supporter.UserName);
                message = message.Replace("{{AccountComplaint}}", accountComplaint.UserName);
                message = message.Replace("{{Title}}", processComplaint.Title);
                message = message.Replace("{{Detail}}", processComplaint.Detail);

                if (processComplaint.EquipmentId !=null)
                {
                    var EquipmentFind = db.Equipments.Find(processComplaint.EquipmentId);
                    message = message.Replace("{{EquipmentId}}", processComplaint.EquipmentId.ToString());
                    message = message.Replace("{{EquipmentName}}", EquipmentFind.Name);
                }
                else
                {
                    message = message.Replace("{{EquipmentId}}", "NO");
                    message = message.Replace("{{EquipmentName}}", "NO");
                }
                
                var checkStatus = "";
                foreach (var item in EnumHelper.GetSelectList(typeof(LabSem3.Enum.ComplaintStatusEnum)))
                {
                    if (processComplaint.Status == Int32.Parse(item.Value))
                    {
                        checkStatus = item.Text;
                    }
                }
                message = message.Replace("{{Status}}", checkStatus);


                var messageForAccount = System.IO.File.ReadAllText(Server.MapPath("~/TemplateMail/HaveAssignComplaintMail.html"));
                messageForAccount = messageForAccount.Replace("{{Id}}", processComplaint.Id.ToString());
                messageForAccount = messageForAccount.Replace("{{TypeComplaintName}}", typeComplaint.Name);
                messageForAccount = messageForAccount.Replace("{{SupporterUserName}}", supporter.UserName);
                messageForAccount = messageForAccount.Replace("{{AccountComplaint}}", accountComplaint.UserName);
                messageForAccount = messageForAccount.Replace("{{Title}}", processComplaint.Title);
                messageForAccount = messageForAccount.Replace("{{Detail}}", processComplaint.Detail);
                
                if (processComplaint.EquipmentId != null)
                {
                    var EquipmentFind = db.Equipments.Find(processComplaint.EquipmentId);
                    messageForAccount = messageForAccount.Replace("{{EquipmentId}}", processComplaint.EquipmentId.ToString());
                    messageForAccount = messageForAccount.Replace("{{EquipmentName}}", EquipmentFind.Name);

                }
                else
                {
                    messageForAccount = messageForAccount.Replace("{{EquipmentId}}", "NO");
                    messageForAccount = messageForAccount.Replace("{{EquipmentName}}", "NO");
                }

                var checkStatusForAccount = "";
                foreach (var item in EnumHelper.GetSelectList(typeof(LabSem3.Enum.ComplaintStatusEnum)))
                {
                    if (processComplaint.Status == Int32.Parse(item.Value))
                    {
                        checkStatusForAccount = item.Text;
                    }
                }
                messageForAccount = messageForAccount.Replace("{{Status}}", checkStatusForAccount);

                SendEmail(supporter.Email, typeComplaint.Name, message);
                SendEmail(accountComplaint.Email, typeComplaint.Name, messageForAccount);
                TempData["Success"] = "Assign Account " + supporter.UserName + " Success";
                db.SaveChanges();
                return Redirect("/Complaint/ComplaintWaiting");
            } catch(Exception ex)
            {
                TempData["False"] = "Assign Account False: "  + ex;
                return Redirect("/Complaint/ComplaintWaiting");
            }

        }

        public bool SendEmail(string receiver, string subject, string message)
        {
            try
            {
                var senderEmail = new MailAddress(AccountEmailSend, AccountNameSend);
                var receiverEmail = new MailAddress(receiver, "ReceiverTest");
                var password = "qjkfuhxgpvuzymex";
                var sub = subject;
                var body = message;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                return true;

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some Error" + ex;
                return false;
            }
            return false;
        }


        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        // GET: Complaint/Details/5
        public ActionResult Details(int id)
        {
            var complaintDetail = db.Complaints.Find(id);
            return View(complaintDetail);
        }

        [Authorize(Roles = "HOD,STUDENT")]
        // GET: Complaint/Create
        public ActionResult Create()
        {
            ViewBag.TypeComplaints = db.TypeComplaints.ToList();
            return View();
        }

        [Authorize(Roles = "HOD,STUDENT")]
        // POST: Complaint/Create
        [HttpPost]
        public ActionResult Create(ComplaintViewModel complaintViewModel)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            var newComPlaint = new Complaint(complaintViewModel)
            {
                AccountId = User.Identity.GetUserId()
            };

            db.Complaints.Add(newComPlaint);
            var result = db.SaveChanges();
            if (result == 1)
            {
                var typeComplaint = db.TypeComplaints.Find(newComPlaint.TypeComplaintId);
                TempData["Success"] = "Create Complaint " + typeComplaint.Name + " Success";
                var accountComplaint = db.Users.Find(newComPlaint.AccountId);
                
                var message = System.IO.File.ReadAllText(Server.MapPath("~/TemplateMail/CreateComplaintMail.html"));
                message = message.Replace("{{Id}}", newComPlaint.Id.ToString());
                message = message.Replace("{{TypeComplaintName}}", typeComplaint.Name);
                message = message.Replace("{{AccountComplaint}}", accountComplaint.UserName);
                message = message.Replace("{{Title}}", newComPlaint.Title);

                if (newComPlaint.EquipmentId != null)
                {
                    var EquipmentFind = db.Equipments.Find(newComPlaint.EquipmentId);
                    message = message.Replace("{{EquipmentId}}", newComPlaint.EquipmentId.ToString());
                    message = message.Replace("{{EquipmentName}}", EquipmentFind.Name);

                }
                else
                {
                    message = message.Replace("{{EquipmentId}}", "NO");
                    message = message.Replace("{{EquipmentName}}", "NO");
                }


                message = message.Replace("{{Detail}}", newComPlaint.Detail);

                var checkStatus = "";
                foreach (var item in EnumHelper.GetSelectList(typeof(LabSem3.Enum.ComplaintStatusEnum)))
                {
                    if (newComPlaint.Status == Int32.Parse(item.Value))
                    {
                        checkStatus = item.Text;
                    }
                }

                message = message.Replace("{{Status}}", checkStatus);
                
                SendEmail(AccountEmailSend, typeComplaint.Name, message);
                return Redirect("Index");
            }
            else
            {
                TempData["False"] = "Create Complaint False";
                return Redirect("Index");
            }
        }

        [Authorize(Roles = "ADMIN,INSTRUCTOR,TECHNICAL_STAFF")]
        // GET: Complaint/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TypeComplaints = db.TypeComplaints.ToList();

            // Trường hợp người hỗ trợ
            var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            //ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();

            var roleTECHNICAL_STAFF = db.Roles.Where(s => s.Name.Contains(RoleEnum.TECHNICAL_STAFF.ToString())).FirstOrDefault();
            //ViewBag.Teachnical_StaffList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleTECHNICAL_STAFF.Id))).ToList();

            var roleADMIN = db.Roles.Where(s => s.Name.Contains(RoleEnum.ADMIN.ToString())).FirstOrDefault();
            //ViewBag.AdminList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleADMIN.Id))).ToList();


            var complaint = db.Complaints.Find(id);
            // check role, nếu complaint này có support với role là INSTRUCTOR hoặc Teachnical_Staff 
            if (complaint.Supporter != null)
            {
                if (!User.Identity.GetUserId().Equals(complaint.Supporter.Id))
                {
                    TempData["False"] = "You Can't edit this complaint";
                    return Redirect("/Complaint/Index");
                }
            }
                
            
            //if (complaint.TypeComplaint.TypeRole == "INSTRUCTOR")
            //{
            //    ViewBag.Supporters = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();
            //}
            //if (complaint.TypeComplaint.TypeRole == "TECHNICAL_STAFF")
            //{
            //    ViewBag.Supporters = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleTECHNICAL_STAFF.Id))).ToList();
            //}


            var editComplaint = new ComplaintEditViewModel()
            {
                Id = complaint.Id,
                Title = complaint.Title,
                Detail = complaint.Detail,
                Reason = complaint.Reason,
                Solution = complaint.Solution,
                Note = complaint.Note,
                AccountUserName = complaint.Account.UserName,
                Supporter = complaint.Supporter,
                EquipmentName = complaint.Equipment.Name,
                Status = complaint.Status,
                TypeComplaintId = complaint.TypeComplaint.Id,
                Thumbnail = complaint.Thumbnail
            };
            return View(editComplaint);
        }

        [Authorize(Roles = "ADMIN,INSTRUCTOR,TECHNICAL_STAFF")]
        // POST: Complaint/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ComplaintEditViewModel complaintNew)
        {
            if (ModelState.IsValid)
            {
                var findComplaint = db.Complaints.Find(id);
                findComplaint.Reason = complaintNew.Reason;
                findComplaint.Solution = complaintNew.Solution;
                findComplaint.Note = complaintNew.Note;
                findComplaint.Status = complaintNew.Status;
                findComplaint.UpdatedAt = DateTime.Now;
                db.Complaints.AddOrUpdate(findComplaint);
                var result = db.SaveChanges();
                if (result == 1)
                {
                    var typeComplaint = db.TypeComplaints.Find(findComplaint.TypeComplaintId);
                    TempData["Success"] = "Edit Complaint " + typeComplaint.Name + " Success";
                    var EquipmentFind = db.Equipments.Find(findComplaint.EquipmentId);
                    var message = System.IO.File.ReadAllText(Server.MapPath("~/TemplateMail/ProcessComplaintMail.html"));
                    message = message.Replace("{{Id}}", findComplaint.Id.ToString());
                    message = message.Replace("{{TypeComplaintName}}", typeComplaint.Name);
                    message = message.Replace("{{SupporterUserName}}", findComplaint.Supporter.UserName);
                    message = message.Replace("{{AccountComplaint}}", findComplaint.Account.UserName);
                    message = message.Replace("{{Title}}", findComplaint.Title);
                    message = message.Replace("{{Detail}}", findComplaint.Detail);
                    message = message.Replace("{{EquipmentId}}", findComplaint.EquipmentId.ToString());
                    message = message.Replace("{{EquipmentName}}", EquipmentFind.Name);
                    message = message.Replace("{{Reason}}", findComplaint.Reason);
                    message = message.Replace("{{Solution}}", findComplaint.Solution);
                    message = message.Replace("{{Note}}", findComplaint.Note);
                    
                    var checkStatus = "";
                    foreach (var item in EnumHelper.GetSelectList(typeof(LabSem3.Enum.ComplaintStatusEnum)))
                    {
                        if (findComplaint.Status == Int32.Parse(item.Value))
                        {
                            checkStatus = item.Text;
                        }
                    }

                    message = message.Replace("{{Status}}", checkStatus);

                    switch(typeComplaint.TypeRole)
                    {
                        case "GENERAL":
                            SendEmail(findComplaint.Account.Email, typeComplaint.Name, message);
                            break;
                        case "ADMIN":
                            SendEmail(findComplaint.Account.Email, typeComplaint.Name, message);
                            break;
                        default:
                            SendEmail(findComplaint.Account.Email, typeComplaint.Name, message);
                            SendEmail(findComplaint.Supporter.Email, typeComplaint.Name, message);
                            SendEmail(AccountEmailSend, typeComplaint.Name, message);
                            break;
                    };
                        

                    //if (typeComplaint.TypeRole == "GENERAL")
                    //{
                    //    SendEmail(findComplaint.Account.Email, typeComplaint.Name, message);
                    //}
                    //if (typeComplaint.TypeRole == "ADMIN")
                    //{
                    //    SendEmail(findComplaint.Account.Email, typeComplaint.Name, message);
                    //} 
                    //else
                    //{
                    //    SendEmail(findComplaint.Account.Email, typeComplaint.Name, message);
                    //    SendEmail(findComplaint.Supporter.Email, typeComplaint.Name, message);
                    //    SendEmail(AccountEmailSend, typeComplaint.Name, message);
                    //}

                    return Redirect("/Complaint/Index");
                }
                else
                {
                    TempData["False"] = "Edit Complaint False";
                    return Redirect("/Complaint/Index");
                }
            }
            else
            {
                TempData["False"] = "Invalid Complaint";
                return Redirect("/Complaint/Index");
            }

        }

        [Authorize(Roles = "ADMIN")]
        // GET: Complaint/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        // POST: Complaint/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
