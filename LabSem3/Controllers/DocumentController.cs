using LabSem3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using LabSem3.Models;
using LabSem3.Enum;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity.Migrations;

namespace LabSem3.Controllers
{
    public class DocumentController : Controller
    {
        private LabSem3Context db;
        public DocumentController()
        {
            db = new LabSem3Context();
        }

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        // GET: Documet
        public ActionResult Index(int? statusCheck, int? EquipmentId, int? TypeEquipmentCheck, string Search, int? page, string StartTime, string EndTime)
        {
            var listDocument = db.Document.OrderBy(s => s.Id).AsQueryable();
            if (Search != null && Search.Length > 0)
            {
                listDocument = listDocument.Where(s => s.Title.Contains(Search));
            }
            if (StartTime != null && StartTime != "")
            {
                var startDateTime0000 = DateTime.Parse(StartTime);
                listDocument = listDocument.Where(s => s.CreatedAt >= startDateTime0000);
            }
            if (EndTime != null && EndTime != "")
            {
                var endDateTime2359 = DateTime.Parse(EndTime).AddDays(1).AddTicks(-1);
                listDocument = listDocument.Where(s => s.CreatedAt <= endDateTime2359);
            }
            if (TypeEquipmentCheck != null)
            {
                listDocument = listDocument.Where(s => s.TypeEquipmentId == TypeEquipmentCheck);
            }
            if (statusCheck != -1 && statusCheck != null)
            {
                listDocument = listDocument.Where(s => s.Status == statusCheck);
            }
          
            ViewBag.statusCheck = statusCheck;
            ViewBag.TypeEquipmentList = db.TypeEquipments.ToList();
            ViewBag.StartTime = StartTime;
            ViewBag.EndTime = EndTime;        
            ViewBag.TypeEquipmentCheck = TypeEquipmentCheck;
            ViewBag.Search = Search;
            int Pagesize = 10;
            int Pagenumber = (page ?? 1);
            return View(listDocument.ToList().ToPagedList(Pagenumber, Pagesize));
        }

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        // GET: Documet/Details/5
        public ActionResult Details(int? id, int? page)
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

        [Authorize(Roles = "ADMIN")]
        // GET: Documet/Create
        public ActionResult Create()
        {
            ViewBag.TypeEquipments = db.TypeEquipments.ToList();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        // POST: Documet/Create
        [HttpPost]
        public ActionResult Create(Document document)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                document.Status = ((int)DocumentStatusEnum.AVAILABLE);
                document.CreatedAt = DateTime.Now;
                db.Document.Add(document);
                db.SaveChanges();
                TempData["Success"] = "Create " + document.Title + " Success ";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.TypeEquipments = db.TypeEquipments.ToList();
                TempData["False"] = "Invalid Create";
                return View(document);
            }
        }

        [Authorize(Roles = "ADMIN")]
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
            
            ViewBag.TypeEquipments = db.TypeEquipments.ToList();
            return View(document);
        }

        [Authorize(Roles = "ADMIN")]
        // POST: Documet/Edit/5
        [HttpPost]
        public ActionResult Edit(Document document)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                var DocumnetEdit = db.Document.Find(document.Id);
                DocumnetEdit.Title = document.Title;
                DocumnetEdit.Detail = document.Detail;
                DocumnetEdit.Status = document.Status;
                DocumnetEdit.UpdatedAt = DateTime.Now;
                DocumnetEdit.TypeEquipmentId = document.TypeEquipmentId;
                db.Document.AddOrUpdate(DocumnetEdit);
                db.SaveChanges();
                TempData["Success"] = "Edit " + document.Title + " Success ";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.TypeEquipments = db.TypeEquipments.ToList();
                return View(document);
            }
        }

        [Authorize(Roles = "ADMIN")]
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

        [Authorize(Roles = "ADMIN")]
        // POST: Documet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Document document = db.Document.Find(id);
                document.Status = ((int)DocumentStatusEnum.DISABLE);
                db.Document.AddOrUpdate(document);
                db.SaveChanges();
                TempData["Success"] = "Delete " + document.Title + " Success ";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
