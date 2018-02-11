using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class AllocateClassroomController : Controller
    {

        private AllocateClassroomManager _allocateClassroomManager;
        private DepartmentManager _departmentManager;
        private CourseManager _courseManager;
        private DayManager _dayManager;
        private RoomManager _roomManager;

        public AllocateClassroomController()
        {
            _allocateClassroomManager = new AllocateClassroomManager();
            _departmentManager = new DepartmentManager();
            _courseManager = new CourseManager();
            _dayManager = new DayManager();
            _roomManager = new RoomManager();
        }
        //
        // GET: /AllocateClassroom/
        ////public ActionResult Index()
        ////{
        ////    return View();
        ////}
        /// 

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartmentsManager();
            ViewBag.Rooms = _roomManager.GetAllRoomsManager();
            ViewBag.Days = _dayManager.GetAllDaysManager();


            return View();
        }
        [HttpPost]
        public ActionResult Index(int departmentId, AllocateClassroom allocateClassroom)
        {
            ViewBag.Departments = _departmentManager.GetAllDepartmentsManager();

            ViewBag.Rooms = _roomManager.GetAllRoomsManager();
            ViewBag.Days = _dayManager.GetAllDaysManager();

            ViewBag.message = _allocateClassroomManager.AllocateClassroominfoSave(allocateClassroom);

            return View();
        }

        [HttpGet]
        public ActionResult ViewResult()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartmentsManager();

            return View();
        }

        [HttpPost]
        public ActionResult ViewResult(int departmentId)
        {
            ViewBag.Departments = _departmentManager.GetAllDepartmentsManager();

            return View();
        }

        public JsonResult GetAllschedulessByDepartmentId(int departmentId)
        {
            var schedules = _allocateClassroomManager.GetAllSchedulessManager();

            var schedulesList = schedules.Where(x => x.DeptId == departmentId).ToList();

            return Json(schedulesList);
        }


        public JsonResult GetAllCoursesByDepartmentId(int departmentId)
        {
            var courses = _courseManager.GetAllCoursesManager();

            var coursesList = courses.Where(x => x.DepartmentId == departmentId).ToList();

            return Json(coursesList);
        }
	}
}