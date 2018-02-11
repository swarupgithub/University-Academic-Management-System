using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        private DepartmentManager aDepartmentManager;

        public DepartmentController()
        {
            aDepartmentManager = new DepartmentManager();
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Department aDepartment)
        {
            ViewBag.message = aDepartmentManager.SaveDeptInfoManager(aDepartment);

            return View();
        }


        public ActionResult ViewAllDepartment()
        {
            ViewBag.allDepartment = aDepartmentManager.GetAllDepartmentsManager();

            return View();
        }

	}
}