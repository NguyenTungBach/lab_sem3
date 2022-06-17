using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LabSem3.Data;
using LabSem3.Enum;
using LabSem3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LabSem3.Controllers
{
    public class LabsController : Controller
    {
        private UserManager<Account> userManager; //Bên database
        private RoleManager<IdentityRole> roleManager; //Bên database
        private LabSem3Context db;

        public LabsController()
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

        // GET: Labs
        public ActionResult Index()
        {
            var labs = db.Labs.Include(l => l.Account).Include(l => l.Department);
            return View(labs.ToList());
        }

        // GET: Labs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab lab = db.Labs.Find(id);
            if (lab == null)
            {
                return HttpNotFound();
            }
            return View(lab);
        }

        // GET: Labs/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: Labs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status,CreatedAt,UpdatedAt,DeletedAt,DepartmentId,EquipmentId,AccountId,ScheduleId")] Lab lab)
        {
            if (ModelState.IsValid)
            {
                db.Labs.Add(lab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Users, "Id", "Email", lab.AccountId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", lab.DepartmentId);
            return View(lab);
        }

        // GET: Labs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab lab = db.Labs.Find(id);
            if (lab == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Users, "Id", "Email", lab.AccountId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", lab.DepartmentId);
            return View(lab);
        }

        // POST: Labs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,CreatedAt,UpdatedAt,DeletedAt,DepartmentId,EquipmentId,AccountId,ScheduleId")] Lab lab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Users, "Id", "Email", lab.AccountId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", lab.DepartmentId);
            return View(lab);
        }

        // GET: Labs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab lab = db.Labs.Find(id);
            if (lab == null)
            {
                return HttpNotFound();
            }
            return View(lab);
        }

        // POST: Labs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lab lab = db.Labs.Find(id);
            db.Labs.Remove(lab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
