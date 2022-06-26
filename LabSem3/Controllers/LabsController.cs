using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using PagedList;
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



        // GET: Labs
        public ActionResult Index(int? page, int? status, string startTime, string endTime,int? departmentId)
        {
            var labs = db.Labs.Include(l => l.Account).Include(l => l.Department);
            if (startTime != null && startTime != "")
            {
                var startDateTime0000 = DateTime.Parse(startTime);
                labs = labs.Where(s => s.CreatedAt >= startDateTime0000);
            }
            if (endTime != null && endTime != "")
            {
                var endDateTime2359 = DateTime.Parse(endTime).AddDays(1).AddTicks(-1);
                labs = labs.Where(s => s.CreatedAt <= endDateTime2359);
            }
            if(departmentId!= null)
            {
                labs = labs.Where(s => s.DepartmentId == departmentId);
            }
            if(status != null)
            {
                labs = labs.Where(s => s.Status == status);
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.Department = db.Departments.ToList();
            ViewBag.StartTime = startTime;
            ViewBag.EndTime = endTime;
            ViewBag.DepartmentId = departmentId;
            ViewBag.Status = status;
            return View(labs.ToList().ToPagedList(pageNumber,pageSize));
        }

        // GET: Labs/Details/5
        public ActionResult Details(string search, int? status,int? typeEquipment,int? id, int? page,string startTime, string endTime)
        {
            var listEquipment = db.Equipments.Where(s => s.LabId == id).AsQueryable();
            if (search != null && search.Length > 0)
            {
                listEquipment = listEquipment.Where(s => s.Name.Contains(search));
            }
            if(status != null)
            {
                listEquipment = listEquipment.Where(s => s.Status == status);
            }
            if(typeEquipment != null){
                listEquipment = listEquipment.Where(s => s.TypeEquipmentId == typeEquipment);
            }
            if (startTime != null && startTime != "")
            {
                var startDateTime0000 = DateTime.Parse(startTime);
                listEquipment = listEquipment.Where(s => s.CreatedAt >= startDateTime0000);
            }
            if (endTime != null && endTime != "")
            {
                var endDateTime2359 = DateTime.Parse(endTime).AddDays(1).AddTicks(-1);
                listEquipment = listEquipment.Where(s => s.CreatedAt <= endDateTime2359);
            }
            if (id == null && id != 4)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab lab = db.Labs.Find(id);
            if (lab == null)
            {
                return HttpNotFound();
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.TypeEquipments = db.TypeEquipments.ToList();
            ViewBag.Search = search;
            ViewBag.Status = status;
            ViewBag.StartTime = startTime;
            ViewBag.EndTime = endTime;
            ViewBag.Type = typeEquipment;
            ViewBag.Equipments = listEquipment.ToList().ToPagedList(pageNumber, pageSize);
            //ViewBag.Equipments = lab.Equipments.ToPagedList(pageNumber, pageSize);
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
            lab.CreatedAt = DateTime.Now;
            lab.UpdatedAt = DateTime.Now;
            lab.Status = (int)LabStatusEnum.ACTIVE;
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
        public ActionResult Edit(int? id, int? page, string search, int? status, int? typeEquipment, string startTime, string endTime)
        {
            var listEquipment = db.Equipments.Where(s => s.LabId == id).AsQueryable();
            if (search != null && search.Length > 0)
            {
                listEquipment = listEquipment.Where(s => s.Name.Contains(search));
            }
            if (status != null)
            {
                listEquipment = listEquipment.Where(s => s.Status == status);
            }
            if (typeEquipment != null)
            {
                listEquipment = listEquipment.Where(s => s.TypeEquipmentId == typeEquipment);
            }
            if (startTime != null && startTime != "")
            {
                var startDateTime0000 = DateTime.Parse(startTime);
                listEquipment = listEquipment.Where(s => s.CreatedAt >= startDateTime0000);
            }
            if (endTime != null && endTime != "")
            {
                var endDateTime2359 = DateTime.Parse(endTime).AddDays(1).AddTicks(-1);
                listEquipment = listEquipment.Where(s => s.CreatedAt <= endDateTime2359);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab lab = db.Labs.Find(id);
            if (lab == null)
            {
                return HttpNotFound();
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.TypeEquipments = db.TypeEquipments.ToList();
            ViewBag.Search = search;
            ViewBag.Status = status;
            ViewBag.StartTime = startTime;
            ViewBag.EndTime = endTime;
            ViewBag.Type = typeEquipment;
            ViewBag.Equipments = listEquipment.ToList().ToPagedList(pageNumber, pageSize);
            ViewBag.AccountId = new SelectList(db.Users, "Id", "Email", lab.AccountId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", lab.DepartmentId);
            return View(lab);
        }

       
        [HttpPost]
        public JsonResult UpdatedStatus(int id,int status)
        {
            Equipment equipment = db.Equipments.Find(id);
            equipment.Status = status;
            db.SaveChanges();
            return Json("Save sucesss!!");
        }

        // POST: Labs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,CreatedAt,UpdatedAt,DeletedAt,DepartmentId,EquipmentId,AccountId,ScheduleId")] Lab lab)
        {
            var lab1 = db.Labs.Find(lab.Id);
            lab1.UpdatedAt = DateTime.Now;
            lab1.Status = lab.Status;
            lab1.DepartmentId = lab1.DepartmentId;
            db.SaveChanges();
            ViewBag.AccountId = new SelectList(db.Users, "Id", "Email", lab.AccountId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", lab.DepartmentId);
            return Redirect("/Labs/Index");
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
