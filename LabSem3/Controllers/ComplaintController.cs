using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabSem3.Data;
using LabSem3.Models;
using LabSem3.Models.ViewModel;
using PagedList;

namespace LabSem3.Controllers
{
    public class ComplaintController : Controller
    {
        private LabSem3Context db;

        public ComplaintController()
        {
            db = new LabSem3Context();
        }
        // GET: Complaint
        public ActionResult Index(int? page)
        {
            var result2 = db.Complaints.OrderBy(s => s.Id).AsQueryable();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(result2.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ComplaintWaiting(int? page)
        {
            ViewBag.UserAll = db.Users.ToList();
            var result2 = db.Complaints.OrderBy(s => s.Id).AsQueryable().Where(s => s.Status == 0);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(result2.ToPagedList(pageNumber, pageSize));
        }

        // GET: Complaint/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Complaint/Create
        public ActionResult Create()
        {
            ViewBag.TypeComplaints = db.TypeComplaints.ToList();
            return View();
        }

        // POST: Complaint/Create
        [HttpPost]
        public ActionResult Create(ComplaintViewModel complaintViewModel)
        {
            var newComPlaint = new Complaint(complaintViewModel)
            {
                AccountId = "81e0dd67-52b9-4cdf-a1f1-e65a40ccc9d7"
            };

            db.Complaints.Add(newComPlaint);
            var result = db.SaveChanges();
            if (result == 1)
            {
                return Redirect("Index");
            }
            else
            {
                return View("Faile");
            }
        }

        // GET: Complaint/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Complaint/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Complaint/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Complaint/Delete/5
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
