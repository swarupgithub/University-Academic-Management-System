using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;

namespace UniversityManagementSystemApp.Controllers
{
    public class UnassignCoursesController : Controller
    {
        private UnassignCoursesManager _unassignCoursesManager;

        public UnassignCoursesController()
        {
            _unassignCoursesManager = new UnassignCoursesManager();
        }

        //
        // GET: /UnassignCourses/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string unassain)
        {
            ViewBag.message = _unassignCoursesManager.UnAssignCousesManager();
            return View();
        }
	}
}