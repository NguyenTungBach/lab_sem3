using LabSem3.Data;
using LabSem3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LabSem3.Controllers
{
    public class EquipmentController : Controller
    {
        private LabSem3Context db;
        public EquipmentController()
        {
            db = new LabSem3Context();
        }

        // GET: Equipment
        public ActionResult Index()
        {
            var listEquipment = db.Equipments.ToList();
            return View(listEquipment);
        }

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

        // GET: Equipment/Create
        public ActionResult Create()
        {
            ViewBag.Lab = db.Labs.ToList();
            ViewBag.TypeEquipment = db.TypeEquipments.ToList();
            return View();
        }

        // POST: Equipment/Create
        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            try
            {
                // TODO: Add insert logic here

                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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

        // POST: Equipment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Equipment equipment = db.Equipments.Find(id);
                db.Equipments.Remove(equipment);
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
