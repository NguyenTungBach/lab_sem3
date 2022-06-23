using LabSem3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using LabSem3.Models;
using LabSem3.Enum;

namespace LabSem3.Controllers
{
    public class DocumentController : Controller
    {
        private LabSem3Context db;
        public DocumentController()
        {
            db = new LabSem3Context();
        }
        // GET: Documet
        public ActionResult Index()
        {
            var listDocument = db.Document.ToList();
            return View(listDocument);
        }

        // GET: Documet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documet/Create
        public ActionResult Create()
        {
            ViewBag.Equipments = db.Equipments.ToList();
            return View();
        }

        // POST: Documet/Create
        [HttpPost]
        public ActionResult Create(Document document)
        {
            try
            {
                // TODO: Add insert logic here
                document.Status = ((int)DocumentStatusEnum.AVAILABLE);
                document.CreatedAt = DateTime.Now;
                db.Document.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Documet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Equipment = db.Equipments.ToList();
            return View(document);
        }

        // POST: Documet/Edit/5
        [HttpPost]
        public ActionResult Edit(Document document)
        {
            try
            {
                // TODO: Add update logic here
                var DocumnetEdit = db.Document.Find(document.Id);
                DocumnetEdit.Title = document.Title;
                DocumnetEdit.Detail = document.Detail;
                DocumnetEdit.Status = document.Status;
                DocumnetEdit.UpdatedAt = DateTime.Now;
                DocumnetEdit.EquipmentId = document.EquipmentId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Documet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Document document = db.Document.Find(id);
                db.Document.Remove(document);
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
