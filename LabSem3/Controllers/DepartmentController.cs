using LabSem3.Data;
using LabSem3.Enum;
using LabSem3.Models;
using LabSem3.Models.ViewModel.DepartmentViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LabSem3.Controllers
{
    public class DepartmentController : Controller
    {
        private UserManager<Account> userManager; //Bên database
        private RoleManager<IdentityRole> roleManager; //Bên database
        private LabSem3Context db;

        public DepartmentController()
        {
            db = new LabSem3Context();
            UserStore<Account> userStore = new UserStore<Account>(db); // create, update, delete giống UserModel
            userManager = new UserManager<Account>(userStore); // giống Service, xử lý các vấn đề liên quan đến logic
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(db); // create, update, delete giống UserModel
            roleManager = new RoleManager<IdentityRole>(roleStore); // giống Service, xử lý các vấn đề liên quan đến logic

        }

        [Authorize(Roles = "ADMIN")]
        // GET: Department
        public async Task<ActionResult> Index(string Name, int? page, int? LabSearch, string HodSearch, string InstructorSearch, string StartTime, string EndTime)
        {
            var department = db.Departments.OrderBy(s => s.Id).AsQueryable();
            ViewBag.RoleList = db.Roles.ToList();

            if (Name != null && Name.Length > 0)
            {
                department = department.Where(s => s.Name.Contains(Name));
            }
            if (LabSearch != null)
            {
                department = department.Where(s => s.LabId == LabSearch);
            }
            if (HodSearch != null && HodSearch.Length > 0)
            {
                department = department.Where(s => s.Hod.Id.Contains(HodSearch));
            }
            
            if (StartTime != null && StartTime != "")
            {
                var startDateTime0000 = DateTime.Parse(StartTime);
                department = department.Where(s => s.CreatedAt >= startDateTime0000);
            }
            if (EndTime != null && EndTime != "")
            {
                var endDateTime2359 = DateTime.Parse(EndTime).AddDays(1).AddTicks(-1);
                department = department.Where(s => s.CreatedAt <= endDateTime2359);
            }


            ViewBag.Name = Name;
            ViewBag.HodSearch = HodSearch;
            ViewBag.LabSearch = LabSearch;
            ViewBag.StartTime = StartTime;
            ViewBag.EndTime = EndTime;
            var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList(); ;
            var roleHOD = db.Roles.Where(s => s.Name.Contains(RoleEnum.HOD.ToString())).FirstOrDefault();
            ViewBag.HodList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleHOD.Id))).ToList();
            ViewBag.LabList = db.Labs.ToList();
            

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(department.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "ADMIN,HOD")]
        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var department = db.Departments.Find(id);
            return View(department);
        }

        [Authorize(Roles = "ADMIN")]
        // GET: Department/Create
        public ActionResult Create()
        {
            var roleHOD = db.Roles.Where(s => s.Name.Contains(RoleEnum.HOD.ToString())).FirstOrDefault();
            ViewBag.AccountsHOD = db.Users.Include(l => l.Roles)
                .Where(s => s.Roles.Any(c => c.RoleId.Contains(roleHOD.Id)) && s.Department.Name == null)
                .ToList();

            return View();
        }

        [Authorize(Roles = "ADMIN")]
        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(DepartmentCreateViewModel departmentCreateViewModel)
        {
            var checkName = db.Departments.Where(s => s.Name.Equals(departmentCreateViewModel.Name)).FirstOrDefault();
            if(checkName != null)
            {
                TempData["False"] = "Department Exist";
                return RedirectToAction("Index");
            }

            var findHod = db.Users.Find(departmentCreateViewModel.HodId);
            if(findHod == null)
            {
                TempData["False"] = "Not found Hod";
                return RedirectToAction("Index");
            }

            var department = new Department()
            {
                Name = departmentCreateViewModel.Name,
                Location = departmentCreateViewModel.Location,
                Hod = findHod,
                CreatedAt = DateTime.Now,
                Status = ((int)DepartmentStatusEnum.ACTIVE)
            };
            db.Departments.AddOrUpdate(department);
            db.SaveChanges();
            TempData["Success"] = "Create Department " + department.Name + "Success";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "ADMIN")]
        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.Labs = db.Labs.ToList();
            DepartmentEditViewModel departmentEditViewModel = new DepartmentEditViewModel(department);
            //var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            //ViewBag.AccountsINSTRUCTOR = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();
            var roleHOD = db.Roles.Where(s => s.Name.Contains(RoleEnum.HOD.ToString())).FirstOrDefault();
            ViewBag.AccountsHOD = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleHOD.Id))).ToList();

            return View(departmentEditViewModel);
        }

        [Authorize(Roles = "ADMIN")]
        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DepartmentEditViewModel departmentEditViewModel)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var findHod = db.Users.Find(departmentEditViewModel.HodId);
            if (findHod == null)
            {
                TempData["False"] = "Not found Hod";
                return RedirectToAction("Index");
            }
            var department = db.Departments.Find(id);
            if (department.Hod.Id.Equals(departmentEditViewModel.HodId))
            {

            }
            else
            {
                var checkHod = db.Departments.Where(s => s.Hod.Id.Equals(departmentEditViewModel.HodId)).ToList();
                if (checkHod.Count >= 1)
                {
                    TempData["False"] = "Hod has manager another department";
                    return RedirectToAction("Index");
                }
            }
            
            department.Name = departmentEditViewModel.Name;
            department.Location = departmentEditViewModel.Location;
            department.Hod = findHod;
            department.LabId = departmentEditViewModel.LabId;
            department.UpdatedAt = DateTime.Now;
            department.Status = departmentEditViewModel.Status;
            db.Departments.AddOrUpdate(department);
            db.SaveChanges();
            TempData["Success"] = "Update Account Success";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "ADMIN")]
        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Department/Delete/5

        [Authorize(Roles = "ADMIN")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteDepartment(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            department.Status = ((int)DepartmentStatusEnum.INACTIVE);
            department.DeletedAt = DateTime.Now;
            db.Departments.AddOrUpdate(department);
            db.SaveChanges();
            TempData["Success"] = "Delete Department Success";
            return RedirectToAction("Index");
           
        }
    }
}
