using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class StudentRegistrationController : Controller
    {

        private DepartmentManager _departmentManager;
        private StudentRegistrationManager _studentRegistrationManager;
        //
        // GET: /StudentRegistration/

        public StudentRegistrationController()
        {
            _departmentManager = new DepartmentManager();
            _studentRegistrationManager = new StudentRegistrationManager();
        }
        public ActionResult Index()
        {
            ViewBag.departments = _departmentManager.GetAllDepartmentsManager();

            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentRegestration aStudentRegestration)
        {

            ViewBag.departments = _departmentManager.GetAllDepartmentsManager();

            ViewBag.message = _studentRegistrationManager.SaveStudentRegistration(aStudentRegestration);

            return View();
        }
        public JsonResult GetDeptForRegNo(int departmentId)
        {
            string deptCode = _departmentManager.GetDeptCode(departmentId);

            return Json(deptCode);
        }
	}
}