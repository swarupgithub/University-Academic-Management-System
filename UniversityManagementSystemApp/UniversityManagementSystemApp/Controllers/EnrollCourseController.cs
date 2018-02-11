using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        private CourseManager _courseManager;
        private DepartmentManager _departmentManager;
        private SemesterManager _semesterManager;
        private EnrollCourseManager aEnrollCourseManager;
        

        public EnrollCourseController()
        {
            _courseManager = new CourseManager();
            _departmentManager = new DepartmentManager();
            _semesterManager = new SemesterManager();
            aEnrollCourseManager = new EnrollCourseManager();
        }
        //
        // GET: /EnrollCourse/

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.regNos = aEnrollCourseManager.GetAllStudentRegNo();

           // ViewBag.semester = _semesterManager.GetAllSemestersManager();
            ViewBag.courses = _courseManager.GetAllCoursesManager();
            
            return View();

        }

        [HttpPost]
        public ActionResult Index(EnrollCourse aEnrollCourse)
        {
            ViewBag.regNos = aEnrollCourseManager.GetAllStudentRegNo();

            //ViewBag.courses = _courseManager.GetAllCoursesManager();

           

            ViewBag.message = aEnrollCourseManager.SaveEnrollCourseManager(aEnrollCourse);

            return View();
        }

        public JsonResult GetDetailsByStudentId(int registrationId)
        {
            var details = aEnrollCourseManager.GetStudentDetailsManager(registrationId);

            return Json(details);

        }
        public JsonResult GetAllCourseByDept(int registrationId)
        {
            //var courses = _courseManager.GetCoursesUnderDeptManager(department);

            var courses = _courseManager.GetCoursesUnderDeptManager(registrationId);
            ViewBag.courses = _courseManager.GetCoursesUnderDeptManager(registrationId);
            return Json(courses);
            //var courses = _courseManager.GetCoursesUnderDeptManager();

            //var coursesList = courses.Where(x => x.DeptName.ToString() == department.ToString()).ToList();
            //return Json(coursesList);
        }
	}
}