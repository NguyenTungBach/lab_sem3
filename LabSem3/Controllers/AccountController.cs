using LabSem3.Data;
using LabSem3.Enum;
using LabSem3.Models;
using LabSem3.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
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

        public async Task<bool> Register(string Username, string Password)
        {
            Account user = new Account()
            {
                UserName = Username
            };
            
            var result = await userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            {
                var queryUser = db.Users.AsQueryable().Where(userFind => userFind.UserName.Contains(Username)).FirstOrDefault();
                Debug.WriteLine("Tìm user có name là: ", Username);
                Debug.WriteLine("Tạo quyền User cho user có id là: ", queryUser.Id);
                if (queryUser == null)
                {
                    ViewBag.ErrorNull = "Không tìm thấy khi queryUser";
                    Debug.WriteLine("Tạo quyền User cho user có id là: ", queryUser.Id);
                }
                var check = await AddUserToRoleAsync(queryUser.Id, RoleEnum.STUDENT.ToString());
                if (check)
                {
                    return true;
                }
                else
                {
                    ViewBag.Errors = "Lỗi tạo quyền";
                    System.Diagnostics.Debug.WriteLine("Lỗi tạo quyền");
                    return false;
                }
            }
            else
            {
                ViewBag.Errors = result.Errors;
                System.Diagnostics.Debug.WriteLine("Lỗi đăng ký là ", result.Errors);
                return false;
            }
        }

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

        // GET: Account
        public async Task<ActionResult> Index(string UserName, int? page)
        {
            var account = userManager.Users.Include(l => l.Department).Include(l => l.Roles).OrderBy(s => s.Id).AsQueryable();

            if (UserName != null && UserName.Length > 0)
            {
                account = account.Where(s => s.UserName.Contains(UserName));
            }

            ViewBag.UserName = UserName;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(account.ToPagedList(pageNumber, pageSize));
        }

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

            //var listUserByRole = new List<string>();
            //foreach (var user in listUser)
            //{
            //    var checkRole = userManager.GetRoles(user.Id).ToList();
            //    foreach (var role in checkRole)
            //    {
            //        if(role == RoleEnum.ADMIN.ToString())
            //        {
            //            listUserByRole.Add(user.UserName);
            //        }
            //    }
            //}
            //ViewBag.AccountByRole = listUserByRole;

            return View(account);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            ViewBag.Role = db.Roles.ToList();
            return View();
        }

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

                    Account account = new Account()
                    {
                        UserName = accountViewModel.UserName,
                        Status = 1,
                        CreatedAt = DateTime.Now
                    };

                    db.Users.Add(account);
                    db.SaveChanges();


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
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var account = db.Users.Find(id);
            var accountViewModel = new AccountViewModel(account);
            ViewBag.Role = db.Roles.ToList();
            ViewBag.RoleAccounts = userManager.GetRoles(id).ToList();
            return View(accountViewModel);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditPostAsync(string Id, string UserName, string Password, string Role)
        {
            if (ModelState.IsValid)
            {
                
                var token = await userManager.GeneratePasswordResetTokenAsync(Id);
                await userManager.ResetPasswordAsync(Id, token, Password);

                var checkRoles = Role.Split(',');
                var roleList = db.Roles.ToList();

                foreach (var role in roleList)
                {
                    int check = 0;
                    foreach (var checkRole in checkRoles)
                    {
                        if (role.Name.Equals(checkRole))
                        {
                            userManager.AddToRole(Id, role.Name);
                            check = 1;
                            break;
                        }
                    }
                    if(check == 0)
                    {
                        userManager.RemoveFromRole(Id, role.Name);
                    }
                }

                //db.Users.AddOrUpdate
                //    db.Entry(lab).State = EntityState.Modified;
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
            }
            //ViewBag.Role = db.Roles.ToList();
            //ViewBag.RoleAccounts = userManager.GetRoles(id).ToList();
            TempData["Success"] = "Update Account Success";
            return RedirectToAction("Index");
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
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
