using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class CourseAssignTeacherController : Controller
    {
        private CourseAssignTeacherManager _courseAssignTeacherManager;

        private DepartmentManager _departmentManager;
        private TeacherManager _teacherManager;
        private CourseManager _courseManager;

        public CourseAssignTeacherController()
        {
            _courseAssignTeacherManager = new CourseAssignTeacherManager();

            _departmentManager = new DepartmentManager();
            _teacherManager = new TeacherManager();
            _courseManager = new CourseManager();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartmentsManager();

            return View();
        }

        [HttpPost]
        public ActionResult Index(int departmentId,CourseAssignTeacher aCourseAssignTeacher)
        {
            ViewBag.Departments = _departmentManager.GetAllDepartmentsManager();

            ViewBag.message = _courseAssignTeacherManager.InsertDetails(aCourseAssignTeacher);

            return View();
        }

        public JsonResult GetAllTeachersByDepartmentId(int departmentId)
        {
            var teachers = _teacherManager.GetAllTeachersManager();

            var teachersList = teachers.Where(x => x.DepartmentId == departmentId).ToList();

            return Json(teachersList);
        }

        public JsonResult GetAllCoursesByDepartmentId(int departmentId)
        {
            var courses = _courseManager.GetAllCoursesManager();

            var coursesList = courses.Where(x => x.DepartmentId == departmentId).ToList();

            return Json(coursesList);
        }
        public JsonResult GetCreditsByTeacherId(int teacherId)
        {
            int credit = _teacherManager.GetAllTeachersByTeacherId(teacherId);

            return Json(credit);
        }

        public JsonResult GetRemainingCreditsByTeacherId(int teacherId)
        {
            string remainingCredit = _courseAssignTeacherManager.GetRemainingCreditByTeacherId(teacherId).ToString();

            return Json(remainingCredit);
        }

        public JsonResult GetDetailsByCourseId(int courseId)
        {
            var details = _courseManager.GetAllCoursesByCourseIdManager(courseId);

            return Json(details);
        }


        [HttpGet]
        public ActionResult ViewCourseStatics()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartmentsManager();

            return View();
        }

        [HttpPost]
        public ActionResult ViewCourseStatics(int departmentId)
        {
            ViewBag.Departments = _departmentManager.GetAllDepartmentsManager();

            return View();
        }

        public JsonResult GetAllViewCourseStaticsByDepartmentId(int departmentId)
        {
            var allStatics = _courseAssignTeacherManager.GetAllCoursesStatics();

            var allStaticsList = allStatics.Where(x => x.DepartmentId == departmentId).ToList();

            return Json(allStaticsList);
        }
        
	}
}