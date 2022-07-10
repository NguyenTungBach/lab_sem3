using LabSem3.Data;
using LabSem3.Enum;
using LabSem3.Models;
using LabSem3.Models.ViewModel.ScheduleViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        [Obsolete]
        // GET: Schedule
        public ActionResult Index(int? DepartmentId, string Date)
        {
            var labs = db.Labs.Where(s => s.DepartmentId == 1);
            var dateNow = DateTime.Now.AddDays(1).Date;
            var listSchedules = db.Schedules.Where(s => s.Lab.DepartmentId == 1 && EntityFunctions.TruncateTime(s.DateBoking) == dateNow).Include(s=>s.Instructor).OrderBy(s => s.LabId).ThenBy(s => s.SlotNumber).ToList();
            if(DepartmentId != null && Date != null && Date != "")
            {
                var date = DateTime.Parse(Date).Date;
                listSchedules = db.Schedules.Where(s =>  s.Lab.DepartmentId == DepartmentId && EntityFunctions.TruncateTime(s.DateBoking) == date).Include(s => s.Instructor).OrderBy(s => s.LabId).ThenBy(s => s.SlotNumber).ToList();
                labs = db.Labs.Where(s => s.DepartmentId == DepartmentId);
            }
            ViewBag.Schedules = listSchedules;
            ViewBag.Labs = labs;
            ViewBag.Departments = db.Departments.ToList();
            return View();
        }

        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        // GET: Schedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        // GET: Schedule/Create
        public ActionResult Create()
        {
            ViewBag.Labs = db.Labs.ToList();
            var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        // POST: Schedule/Create
        [HttpPost]
        [Obsolete]
        public ActionResult Create(ScheduleCreateViewModel scheduleCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var startTime = scheduleCreateViewModel.StartTime.Date;
                var endTime = scheduleCreateViewModel.EndTime.Date;

                var scheduleDay = endTime.Subtract(startTime).Days + 1;

                var checkToday = DateTime.Now.Date;
                if(checkToday.Date == startTime)
                {
                    ViewBag.Labs = db.Labs.ToList();
                    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
                    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList(); ;
                    TempData["False"] = "Start Date can't today";
                    return View();
                }
                if(checkToday.Date > startTime)
                {
                    ViewBag.Labs = db.Labs.ToList();
                    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
                    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList(); ;
                    TempData["False"] = "Start Date can't less than Date Now";
                    return View();
                }
                if(startTime.Date > endTime)
                {
                    ViewBag.Labs = db.Labs.ToList();
                    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
                    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList(); ;
                    TempData["False"] = "Start Date can't more than End Time";
                    return View();
                }

                if (scheduleCreateViewModel.InstructorId == null )
                {
                    ViewBag.Labs = db.Labs.ToList();
                    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
                    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList(); ;
                    TempData["False"] = "Instructor can't be null";
                    return View();
                }

                var checkSlots = scheduleCreateViewModel.SlotNumberArray.Split(',');

                //for (int i = 0; i < scheduleDay; i++)
                //{
                //    var startDateTime0000 = DateTime.Parse(startTime.ToString());
                //    var endDateTime2359 = DateTime.Parse(startTime.AddDays(i).AddTicks(-1).ToString());

                //    var checkDuplicateDate = db.Schedules.Where(s => s.DateBoking >= startDateTime0000 && s.DateBoking <= endDateTime2359).FirstOrDefault();
                //    if(checkDuplicateDate != null)
                //    {
                //        TempData["False"] = "Create Schedule False Because Duplicate Date";
                //        return RedirectToAction("Index");
                //    }
                //}
                List<Schedule> list = new List<Schedule>();
                for (int i = 0; i < scheduleDay; i++)
                {
                    foreach (var slot in checkSlots)
                    {
                        var startTimeNew = startTime.AddDays(i).Date;
                        var scheduleDbs = db.Schedules.Where(s => EntityFunctions.TruncateTime(s.DateBoking)== startTimeNew && s.LabId == scheduleCreateViewModel.LabId).ToList();
                        if(scheduleDbs.Count > 0)
                        {
                            foreach( var schedule1 in scheduleDbs)
                            {
                                if (schedule1.SlotNumber == Int32.Parse(slot))
                                {
                                    TempData["False"] = "Create Schedule False Because Duplicate Date";
                                    list.Clear();
                                    return RedirectToAction("Index");
                                }
                                else
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
                                    list.Add(schedule);
                                }
                            }
                        }
                        else
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
                            list.Add(schedule);
                           
                        }
                    }
                }
                list.ForEach(s => db.Schedules.AddOrUpdate(s));
                db.SaveChanges();
                TempData["Success"] = "Create Schedule " + scheduleCreateViewModel.StartTime + " - " + scheduleCreateViewModel.EndTime + " Success";
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "ADMIN,INSTRUCTOR")]
        // GET: Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            var Schedule = db.Schedules.Find(id);
            var scheduleEditViewModel = new ScheduleEditViewModel() {
                DateBoking = Schedule.DateBoking,
                SlotNumber = Schedule.SlotNumber,
                LabId = Schedule.LabId,
                Status = Schedule.Status,
                InstructorId = Schedule.InstructorId
            };
            ViewBag.Labs = db.Labs.ToList();
            var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();
            
            return View(scheduleEditViewModel);
        }

        [Authorize(Roles = "ADMIN,INSTRUCTOR")]
        // POST: Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ScheduleEditViewModel scheduleEditViewModel)
        {
            //var checkToday = DateTime.Now.Subtract(scheduleEditViewModel.DateBoking).Days + 1;
            //if (checkToday == 1)
            //{
            //    ViewBag.Labs = db.Labs.ToList();
            //    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            //    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();
            //    TempData["False"] = "DateBoking Can't ToDay";
            //    return View();
            //}

            //if (checkToday < 1)
            //{
            //    ViewBag.Labs = db.Labs.ToList();
            //    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            //    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();
            //    TempData["False"] = "DateBoking Can't less than ToDay";
            //    return View();
            //}

            //var checkInstructor = db.Users.Find(scheduleEditViewModel.InstructorId);
            //if (checkInstructor == null)
            //{
            //    TempData["False"] = "Not Found Schedule";
            //    return RedirectToAction("Index");
            //}

            //if (checkInstructor.Id != scheduleEditViewModel.InstructorId)
            //{

            //}

            //var checkSlot = db.Schedules.Where(s => s.SlotNumber == scheduleEditViewModel.SlotNumber && s.DateBoking.Day == scheduleEditViewModel.DateBoking.Day).FirstOrDefault();
            //if (checkSlot != null)
            //{
            //    ViewBag.Labs = db.Labs.ToList();
            //    var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
            //    ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();
            //    TempData["False"] = "Duplicate Schedule";
            //    return View();
            //}
            var scheduleDbs = db.Schedules.Where(s => EntityFunctions.TruncateTime(s.DateBoking) == scheduleEditViewModel.DateBoking && s.LabId == scheduleEditViewModel.LabId && s.SlotNumber == scheduleEditViewModel.SlotNumber).FirstOrDefault();
            var checkToday = DateTime.Now.Date;
            if (checkToday > scheduleEditViewModel.DateBoking.Date)
            {
                ViewBag.Labs = db.Labs.ToList();
                var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
                ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();
                TempData["False"] = "DateBoking Can't less than Today";
                return View();
            }
            if (checkToday == scheduleEditViewModel.DateBoking.Date)
            {
                ViewBag.Labs = db.Labs.ToList();
                var roleINSTRUCTOR = db.Roles.Where(s => s.Name.Contains(RoleEnum.INSTRUCTOR.ToString())).FirstOrDefault();
                ViewBag.InstructorList = db.Users.Include(l => l.Roles).Where(s => s.Roles.Any(c => c.RoleId.Contains(roleINSTRUCTOR.Id))).ToList();
                TempData["False"] = "DateBoking Can't ToDay";
                return View();
            }
            if (scheduleDbs != null)
            {
                TempData["False"] = "Can't change schedule beacause duplicate slot";
                return RedirectToAction("Index");
            }
            else
            {
                var updateSchedule = db.Schedules.Find(id);
                updateSchedule.DateBoking = scheduleEditViewModel.DateBoking;
                updateSchedule.SlotNumber = scheduleEditViewModel.SlotNumber;
                updateSchedule.UpdatedAt = DateTime.Now;
                updateSchedule.LabId = scheduleEditViewModel.LabId;
                updateSchedule.Status = scheduleEditViewModel.Status;
                db.Schedules.AddOrUpdate(updateSchedule);
                db.SaveChanges();
                TempData["Success"] = "Edit sucesss !!";
                ViewBag.Labs = db.Labs.ToList();
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "ADMIN")]
        // GET: Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
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
