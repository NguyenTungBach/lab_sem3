using LabSem3.Data;
using LabSem3.Enum;
using LabSem3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<ActionResult> Register(string Username, string Password)
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
                    return View("ViewSuccess");
                }
                else
                {
                    ViewBag.Errors = "Lỗi tạo quyền";
                    System.Diagnostics.Debug.WriteLine("Lỗi tạo quyền");
                    return View("ViewError");
                }
            }
            else
            {
                ViewBag.Errors = result.Errors;
                System.Diagnostics.Debug.WriteLine("Lỗi đăng ký là ", result.Errors);
                return View("ViewError");
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
        public ActionResult Index(string UserName, int? page)
        {
            var account = db.Users.Include(l => l.Department).OrderBy(s => s.Id).AsQueryable();
            
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var account = db.Users.Find(id);
            return View(account);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(lab).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View();
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
