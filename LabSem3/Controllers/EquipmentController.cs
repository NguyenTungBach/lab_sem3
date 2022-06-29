using LabSem3.Data;
using LabSem3.Enum;
using LabSem3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity.Migrations;

namespace LabSem3.Controllers
{
    public class EquipmentController : Controller
    {
        private LabSem3Context db;
        public EquipmentController()
        {
            db = new LabSem3Context();
        }

        [Authorize(Roles = "Admin,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        // GET: Equipment
        public ActionResult Index(int? TypeEquipmentCheck, int? labIdCheck, string Search, int? statusCheck,  int? page, string StartTime, string EndTime)
        {
            
            var listEquipment = db.Equipments.OrderBy(s=> s.Id).AsQueryable();
            if (Search != null && Search.Length > 0)
            {
                listEquipment = listEquipment.Where(s => s.Name.Contains(Search));
            }
            if (StartTime != null && StartTime != "")
            {
                var startDateTime0000 = DateTime.Parse(StartTime);
                listEquipment = listEquipment.Where(s => s.CreatedAt >= startDateTime0000);
            }
            if (EndTime != null && EndTime != "")
            {
                var endDateTime2359 = DateTime.Parse(EndTime).AddDays(1).AddTicks(-1);
                listEquipment = listEquipment.Where(s => s.CreatedAt <= endDateTime2359);
            }
            if (statusCheck != -1 && statusCheck != null)
            {
                listEquipment = listEquipment.Where(s => s.Status == statusCheck);
            }
            if (labIdCheck != null)
            {
                listEquipment = listEquipment.Where(s => s.LabId == labIdCheck);
            }
            if(TypeEquipmentCheck != null)
            {
                listEquipment = listEquipment.Where(s => s.TypeEquipmentId == TypeEquipmentCheck);
            }

            ViewBag.TypeEquipmentList = db.TypeEquipments.ToList();
            ViewBag.LabList = db.Labs.ToList();
            ViewBag.statusCheck = statusCheck;
            ViewBag.labIdCheck = labIdCheck;
            ViewBag.TypeEquipmentCheck = TypeEquipmentCheck;
            ViewBag.Search = Search;
            ViewBag.StartTime = StartTime;
            ViewBag.EndTime = EndTime;
            int PageSize = 10;
            int PageNumber = (page ?? 1);

            return View(listEquipment.ToPagedList(PageNumber, PageSize)); ;
        }
        /*db.Equipments.Where(x => x.Name.StartsWith(search) || search == null).ToPagedList(k ?? 1, 3)*/

        [Authorize(Roles = "Admin,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        // GET: Equipment/Details/5
        public ActionResult Details(int? id)    
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        [Authorize(Roles = "Admin")]
        // GET: Equipment/Create
        public ActionResult Create()
        {
            ViewBag.Lab = db.Labs.ToList();
            ViewBag.TypeEquipment = db.TypeEquipments.ToList();
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: Equipment/Create
        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            try
            {
                // TODO: Add insert logic here
                equipment.Status = ((int)DocumentStatusEnum.AVAILABLE);
                equipment.CreatedAt = DateTime.Now;
                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Equipment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lab = db.Labs.ToList();
            ViewBag.TypeEquipment = db.TypeEquipments.ToList();
            return View(equipment);

        }

        [Authorize(Roles = "Admin")]
        // POST: Equipment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Equipment equipment)
        {
            try
            {
                // TODO: Add update logic here
                var Eupdate = db.Equipments.Find(equipment.Id);
                Eupdate.Name = equipment.Name;
                Eupdate.Status = equipment.Status;
                Eupdate.LabId = equipment.LabId;
                Eupdate.TypeEquipmentId = equipment.TypeEquipmentId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Equipment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        [Authorize(Roles = "Admin")]
        // POST: Equipment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Equipment equipment = db.Equipments.Find(id);
                equipment.Status = ((int)EquipmentStatusEnum.BAD);
                //db.Equipments.Remove(equipment);
                db.Equipments.AddOrUpdate(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
