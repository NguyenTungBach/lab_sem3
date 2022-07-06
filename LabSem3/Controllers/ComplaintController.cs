using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index(string SupportID, string keyWord, int? statusCheck,  int? page) {
            
            var result2 = db.Complaints.OrderBy(s => s.Id).AsQueryable();

            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            if (!User.IsInRole("ADMIN"))
            {
                var userID = User.Identity.GetUserId();
                if (User.IsInRole(RoleEnum.INSTRUCTOR.ToString()) || User.IsInRole(RoleEnum.TECHNICAL_STAFF.ToString()))
                {
                    result2 = result2.Where(s => s.SupportedId.Equals(userID));
                }
                else
                {
                    result2 = result2.Where(s => s.AccountId == userID);
                }
            }

            if (SupportID != null && SupportID.Length >0)
            {
                result2 = result2.Where(s => s.SupportedId.Equals(SupportID));
            }

            if (!string.IsNullOrEmpty(keyWord))
            {
                result2 = result2.Where(s => s.Title.Contains(keyWord) || s.Detail.Contains(keyWord));
            }

            if (statusCheck != -1 && statusCheck != null)
            {
                result2 = result2.Where(s => s.Status == statusCheck);
            }

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
            var listTechnicalStaff = new List<Account>();
            var listInstructor = new List<Account>();
            foreach (var user in db.Users.ToList())
            {
                var checkRole = userManager.GetRoles(user.Id).ToList();
                foreach (var role in checkRole)
                {
                    if (role == RoleEnum.TECHNICAL_STAFF.ToString())
                    {
                        listTechnicalStaff.Add(user);
                    }

                    if (role == RoleEnum.INSTRUCTOR.ToString())
                    {
                        listInstructor.Add(user);
                    }
                }
            }

            ViewBag.listTechnicalStaff = listTechnicalStaff;
            ViewBag.listInstructor = listInstructor;

            ViewBag.UserAll = db.Users.ToList();
            var result2 = db.Complaints.OrderBy(s => s.Id).AsQueryable().Where(s => s.Status == 4);
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
                var typeComplaint = db.TypeComplaints.Find(processComplaint.TypeComplaintId);

                var message = "Id Complaint: " + "\n" + comPlaintId + "\n"
                               + "Title: " + "\n" + processComplaint.Title + "\n"
                               + "Detail: " + "\n" + processComplaint.Detail + "\n";

                SendEmail(supporter.Email, typeComplaint.Name, message);
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
                var password = "btdrbyurmfvacqcc";
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
            return View();
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

                //var message = "Id Complaint: " + "\n" + newComPlaint.Id + "\n"
                //               + "Title: " + "\n" + newComPlaint.Title + "\n"
                //               + "Detail: " + "\n" + newComPlaint.Detail + "\n";

                var message = System.IO.File.ReadAllText(Server.MapPath("~/TemplateMail/CreateComplaintMail.html"));
                message = message.Replace("{{Id}}", newComPlaint.Id.ToString());
                message = message.Replace("{{typeComplaintName}}", typeComplaint.Name);
                message = message.Replace("{{Title}}", newComPlaint.Title);
                message = message.Replace("{{Detail}}", newComPlaint.Detail);
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
            return View(db.Complaints.Find(id));
        }

        [Authorize(Roles = "ADMIN,INSTRUCTOR,TECHNICAL_STAFF")]
        // POST: Complaint/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Complaint complaintNew)
        {
            var findComplaint = db.Complaints.Find(id);
            findComplaint = complaintNew;
            db.Complaints.AddOrUpdate(findComplaint);
            var result = db.SaveChanges();
            if (result == 1)
            {
                var typeComplaint = db.TypeComplaints.Find(findComplaint.TypeComplaintId);
                TempData["Success"] = "Edit Complaint "+ typeComplaint.Name + " Success";
                return Redirect("/Complaint/Index");
            }
            else
            {
                TempData["False"] = "Edit Complaint False";
                return View("Error");
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
