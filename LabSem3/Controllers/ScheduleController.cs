using LabSem3.Data;
using LabSem3.Enum;
using LabSem3.Models;
using LabSem3.Models.ViewModel.ScheduleViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabSem3.Controllers
{
    public class ScheduleController : Controller
    {
        private LabSem3Context db;
        public ScheduleController()
        {
            db = new LabSem3Context();
        }
        // GET: Schedule
        public ActionResult Index()
        {
            var listSchedule = db.Schedules.ToList();
            return View(listSchedule);
        }

        // GET: Schedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            ViewBag.Labs = db.Labs.ToList();
            var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList(); ;
            return View();
        }

        // POST: Schedule/Create
        [HttpPost]
        public ActionResult Create(ScheduleCreateViewModel scheduleCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var startTime = scheduleCreateViewModel.StartTime;
                var endTime = scheduleCreateViewModel.EndTime;

                var scheduleDay = endTime.Subtract(startTime).Days + 1;
                if(scheduleDay <= 0)
                {
                    ViewBag.Labs = db.Labs.ToList();
                    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
                    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList(); ;
                    TempData["False"] = "End Date can't less than Start Date";
                    return View();
                }

                if(DateTime.Now.Subtract(startTime).Days + 1 <= 0)
                {
                    ViewBag.Labs = db.Labs.ToList();
                    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
                    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList(); ;
                    TempData["False"] = "Start Date can't less than Date Now";
                    return View();
                }

                if(scheduleCreateViewModel.InstructorId == null )
                {
                    ViewBag.Labs = db.Labs.ToList();
                    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
                    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList(); ;
                    TempData["False"] = "Instructor can't be null";
                    return View();
                }

                var checkSlots = scheduleCreateViewModel.SlotNumberArray.Split(',');

                for (int i = 0; i < scheduleDay; i++)
                {
                    var startDateTime0000 = DateTime.Parse(startTime.ToString());
                    var endDateTime2359 = DateTime.Parse(startTime.AddDays(i).AddTicks(-1).ToString());

                    var checkDuplicateDate = db.Schedules.Where(s => s.DateBoking >= startDateTime0000 && s.DateBoking <= endDateTime2359).FirstOrDefault();
                    if(checkDuplicateDate != null)
                    {
                        TempData["False"] = "Create Schedule False";
                        return RedirectToAction("Index");
                    }
                }

                for (int i = 0; i < scheduleDay; i++)
                {
                    foreach (var slot in checkSlots)
                    {
                        Schedule schedule = new Schedule()
                        {
                            DateBoking = startTime.AddDays(i),
                            SlotNumber = Int32.Parse(slot),
                            Status = ((int)ScheduleStatusEnum.AVAILABLE),
                            CreatedAt = DateTime.Now,
                            LabId = scheduleCreateViewModel.LabId,
                            InstructorId = scheduleCreateViewModel.InstructorId,
                        };
                        db.Schedules.AddOrUpdate(schedule);
                        db.SaveChanges();
                    }
                }
                TempData["Success"] = "Create Schedule " + scheduleCreateViewModel.StartTime + " - " + scheduleCreateViewModel.EndTime + " Success";
            }
            return RedirectToAction("Index");
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Schedule/Edit/5
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

        // GET: Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Schedule/Delete/5
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
