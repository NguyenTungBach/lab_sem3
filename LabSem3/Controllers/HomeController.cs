using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabSem3.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "ADMIN,HOD,INSTRUCTOR,TECHNICAL_STAFF,STUDENT")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}