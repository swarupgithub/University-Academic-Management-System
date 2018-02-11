using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class CourseController : Controller
    {
        private CourseManager _courseManager;
        private DepartmentManager _departmentManager;
        private SemesterManager _semesterManager;

        public CourseController()
        {
            _courseManager=new CourseManager();
            _departmentManager=new DepartmentManager();
            _semesterManager=new SemesterManager();
        }
        //
        // GET: /Course/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.departments = _departmentManager.GetAllDepartmentsManager();
           
            ViewBag.semester = _semesterManager.GetAllSemestersManager();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Course course)
        {
         
            ViewBag.departments = _departmentManager.GetAllDepartmentsManager();
         
            ViewBag.semester = _semesterManager.GetAllSemestersManager();

            ViewBag.message = _courseManager.InsertCourse(course);
            return View();
        }
	}
}