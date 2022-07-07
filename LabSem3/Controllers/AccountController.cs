using LabSem3.Data;
using LabSem3.Enum;
using LabSem3.Models;
using LabSem3.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LabSem3.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<Account> userManager; //Bên database
        private RoleManager<IdentityRole> roleManager; //Bên database
        private LabSem3Context db;

        public AccountController()
        {
            db = new LabSem3Context();
            UserStore<Account> userStore = new UserStore<Account>(db); // create, update, delete giống UserModel
            userManager = new UserManager<Account>(userStore); // giống Service, xử lý các vấn đề liên quan đến logic
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(db); // create, update, delete giống UserModel
            roleManager = new RoleManager<IdentityRole>(roleStore); // giống Service, xử lý các vấn đề liên quan đến logic
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string UserName, string Password)
        {
            var user = await userManager.FindAsync(UserName, Password);
            Debug.WriteLine("user đăng nhập là ", user);
            if (user == null)
            {
                TempData["False"] = "Login False With " + UserName;
                return View("Login");
            }
            else
            {
                SignInManager<Account, string> signInManager = new SignInManager<Account, string>(userManager, Request.GetOwinContext().Authentication);
                await signInManager.SignInAsync(user, false, false);
                Session["userId"] = user.Id;

                return Redirect("/Account/Profile");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var checkDuplicateEmail = db.Users.ToList();
                foreach (var item in checkDuplicateEmail)
                {
                    if(item.Email == registerViewModel.Email)
                    {
                        TempData["False"] = "Duplicate Email";
                        return View();
                    }
                }

                Account user = new Account()
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    CreatedAt = DateTime.Now
                };

                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    TempData["Success"] = "Create Account Success, Please Login";
                    var queryUser = db.Users.AsQueryable().Where(userFind => userFind.UserName.Contains(registerViewModel.UserName)).FirstOrDefault();
                    //Debug.WriteLine("Tìm user có name là: ", Username);
                    //Debug.WriteLine("Tạo quyền User cho user có id là: ", queryUser.Id);
                    if (queryUser == null)
                    {
                        TempData["False"] = "Not found Account";
                        //Debug.WriteLine("Tạo quyền User cho user có id là: ", queryUser.Id);
                    }
                    var check = await AddUserToRoleAsync(queryUser.Id, RoleEnum.STUDENT.ToString());
                    if (check)
                    {
                        
                        return Redirect("/Account/Login");
                    }
                    else
                    {
                        TempData["False"] = "Not found Add Role please call Admin to help";
                        
                        return View();
                    }
                }
                else
                {
                    TempData["False"] = "Something Error when Register please call Admin to help: " + result.Errors;
                    //System.Diagnostics.Debug.WriteLine("Something Error ", result.Errors);
                    return View();
                }
            }
            else
            {
                TempData["False"] = "Register not valid";
                return View();
            }

            
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<bool> AddUserToRoleAsync(string UserId, string RoleName)
        {
            var user = db.Users.Find(UserId);
            var role = db.Roles.AsQueryable().Where(roleFind => roleFind.Name.Contains(RoleName)).FirstOrDefault();
            if (user == null || role == null)
            {
                return false;
            }
            var result = await userManager.AddToRoleAsync(user.Id, role.Name);
            //string roleName1 = "Admin";
            //string roleName2 = "User";
            ////var result = await userManager.AddToRoleAsync(userId, roleName);
            //var result = await userManager.AddToRolesAsync(userId, roleName1, roleName2); // Thêm nhiều Role cho 1 User
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                ViewBag.Errors = result.Errors;
                System.Diagnostics.Debug.WriteLine("Lỗi tạo quyền có lỗi là ", result.Errors);
                return false;
            }
        }

        [Authorize(Roles = "ADMIN")]
        // GET: Account
        public async Task<ActionResult> Index(string UserName, int? page, string RoleSearch, string StartTime, string EndTime)
        {
            var account = db.Users.Include(l => l.Department).Include(l => l.Roles).OrderBy(s => s.Id).AsQueryable();
            ViewBag.RoleList = db.Roles.ToList();

            if (UserName != null && UserName.Length > 0)
            {
                account = account.Where(s => s.UserName.Contains(UserName));
            }
            
            if (RoleSearch != null && RoleSearch.Length > 0)
            {
                account = account.Where(s => s.Roles.Any(c => c.RoleId.Contains(RoleSearch)));
            }

            if (StartTime != null && StartTime != "")
            {
                var startDateTime0000 = DateTime.Parse(StartTime);
                account = account.Where(s => s.CreatedAt >= startDateTime0000);
            }
            if (EndTime != null && EndTime != "")
            {
                var endDateTime2359 = DateTime.Parse(EndTime).AddDays(1).AddTicks(-1);
                account = account.Where(s => s.CreatedAt <= endDateTime2359);
            }

            
            ViewBag.UserName = UserName;
            ViewBag.RoleSearch = RoleSearch;
            ViewBag.StartTime = StartTime;
            ViewBag.EndTime = EndTime;

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(account.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        // GET: Account/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var account = db.Users.Find(id);
            ViewBag.Roles = userManager.GetRoles(id).ToList();

            var listUser = userManager.Users.ToList();

            return View(account);
        }

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        public ActionResult Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            var account = db.Users.Find(User.Identity.GetUserId());
            ViewBag.Roles = userManager.GetRoles(User.Identity.GetUserId()).ToList();

            var listUser = userManager.Users.ToList();

            return View(account);
        }

        [Authorize(Roles = "ADMIN")]
        // GET: Account/Create
        public ActionResult Create()
        {
            ViewBag.Role = db.Roles.ToList();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        // POST: Account/Create
        [HttpPost]
        public async Task<ActionResult> Create(AccountViewModel accountViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var checkRoles = accountViewModel.Role.Split(',');

                    var accountExist = db.Users.Where(accountFind => accountFind.UserName.Contains(accountViewModel.UserName)).FirstOrDefault();

                    if (accountExist != null)
                    {
                        TempData["False"] = "Create account " + accountViewModel.UserName + " false because account exist";
                        return RedirectToAction("Index");
                    }

                    var checkDuplicateEmail = db.Users.ToList();
                    foreach (var item in checkDuplicateEmail)
                    {
                        if (item.Email == accountViewModel.Email)
                        {
                            TempData["False"] = "Duplicate Email";
                            return RedirectToAction("Index");
                        }
                    }

                    Account account = new Account()
                    {
                        UserName = accountViewModel.UserName,
                        Email = accountViewModel.Email,
                        Status = 1,
                        CreatedAt = DateTime.Now
                    };
                    await userManager.CreateAsync(account, accountViewModel.Password);
                    

                    foreach (var role in checkRoles)
                    {
                        var checkRoleExist = db.Roles.Where(roleFind => roleFind.Name.Contains(role)).FirstOrDefault();
                        if (checkRoleExist == null)
                        {
                            TempData["False"] = "Create account flase because role " + checkRoleExist + " not exist";
                            return RedirectToAction("Index");
                        }
                    }

                    foreach (var role in checkRoles)
                    {
                        var check = await AddUserToRoleAsync(account.Id, role);
                        if (!check)
                        {
                            TempData["False"] = "Create account false because something error when add role ";
                            return RedirectToAction("Index");
                        }

                    }
                    
                    TempData["Success"] = "Create account " + accountViewModel.UserName + " success";
                    return RedirectToAction("Index");
                }
                //TempData["False"] = "Tạo tài khoản thành công";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["False"] = "Create Account False " + ex;
                return View();
            }
        }

        [Authorize(Roles = "ADMIN")]
        // GET: Account/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var account = db.Users.Find(id);
            var accountViewModel = new AccountEditViewModel(account);
            ViewBag.Role = db.Roles.ToList();
            ViewBag.RoleAccounts = userManager.GetRoles(id).ToList();
            
            return View(accountViewModel);
        }

        [Authorize(Roles = "ADMIN")]
        // POST: Account/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditPost(AccountEditViewModel accountEditViewModel)
        {
            if (ModelState.IsValid)
            {
                var checkRoles = accountEditViewModel.Role.Split(',');
                var roleList = db.Roles.ToList();

                foreach (var role in roleList)
                {
                    int check = 0;
                    foreach (var checkRole in checkRoles)
                    {
                        if (role.Name.Equals(checkRole))
                        {
                            userManager.AddToRole(accountEditViewModel.Id, role.Name);
                            check = 1;
                            break;
                        }
                    }
                    if(check == 0)
                    {
                        userManager.RemoveFromRole(accountEditViewModel.Id, role.Name);
                    }
                }
                Account account = db.Users.Find(accountEditViewModel.Id);
                if (account == null)
                {
                    return HttpNotFound();
                }
                account.UserName = accountEditViewModel.UserName;
                account.PhoneNumber = accountEditViewModel.PhoneNumber;
                account.Birthday = accountEditViewModel.Birthday;
                account.Thumbnail = accountEditViewModel.Thumbnail;
                account.FullName = accountEditViewModel.FullName;
                account.Email = accountEditViewModel.Email;
                account.Address = accountEditViewModel.Address;
                account.UpdatedAt = DateTime.Now;
                account.Status = accountEditViewModel.Status;
                db.Users.AddOrUpdate(account);
                db.SaveChanges();
            }
            //ViewBag.Role = db.Roles.ToList();
            //ViewBag.RoleAccounts = userManager.GetRoles(id).ToList();
            TempData["Success"] = "Update Account Success";
            return RedirectToAction("Index");
        }



        [Authorize(Roles = "ADMIN")]
        // GET: Account/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var account = db.Users.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        [Authorize(Roles = "ADMIN")]
        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ComfirmDeleteAccount(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var account = db.Users.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            account.Status = ((int)AccountStatusEnum.DISABLED);
            account.DeletedAt = DateTime.Now;
            db.Users.AddOrUpdate(account);
            db.SaveChanges();

            TempData["Success"] = "Delete Account Success";
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Account/Login");
        }

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        public ActionResult ChangeProfile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            var account = db.Users.Find(User.Identity.GetUserId());
            var changeProfileViewModel = new ChangeProfileViewModel(account);
            
            return View(changeProfileViewModel);
        }

        public ActionResult ComfirmChangeProfile(ChangeProfileViewModel changeProfileViewModel)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return HttpNotFound();
                }
                if (ModelState.IsValid)
                {
                    var account = db.Users.Find(User.Identity.GetUserId());
                    account.UserName = changeProfileViewModel.UserName;
                    account.PhoneNumber = changeProfileViewModel.PhoneNumber;
                    account.Birthday = changeProfileViewModel.Birthday;
                    account.FullName = changeProfileViewModel.FullName;
                    account.Email = changeProfileViewModel.Email;
                    account.Thumbnail = changeProfileViewModel.Thumbnail;
                    account.Address = changeProfileViewModel.Address;
                    db.Users.AddOrUpdate(account);
                    db.SaveChanges();

                    TempData["Success"] = "Change Profile Success";
                    return RedirectToAction("Profile");
                }
                else
                {
                    TempData["False"] = "Invalidate Change Profile";
                    return RedirectToAction("Profile");
                }
            }
            catch (Exception ex)
            {
                TempData["False"] = "Change Profile False: " + ex;
                return RedirectToAction("Profile");
            }
        }

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        public ActionResult ChangePassword()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            return View();
        }

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        [HttpPost]
        public ActionResult ChangePasswordComfirm(ChangePasswordViewModel changePasswordViewModel)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            try
            {
                
                var user = db.Users.Find(User.Identity.GetUserId());

                var result = userManager.ChangePassword(user.Id, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
                if (!result.Succeeded)
                {
                    TempData["False"] = "Change Old Password For Account " + user.UserName + " Wrong";
                    return Redirect("/Account/Profile");
                }
                //var result = userManager.ResetPasswordAsync(user.Id, token, changePasswordViewModel.Password);
                TempData["Success"] = "Change Password For Account " + user.UserName + " Success";
                return Redirect("/Account/Profile");
            }
            catch(Exception ex)
            {
                TempData["False"] = "Change Password For Account " + User.Identity.GetUserName() + " False: " + ex;
                return Redirect("/Account/Profile");
            }
        }

        public ActionResult RegisterNVQ()
        {
            return View();
        }
    }
}
