using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherManager _teacherManager;
        private DesignationManager _designationManager;
        private DepartmentManager _departmentManager;

        public TeacherController()
        {
            _teacherManager=new TeacherManager();
            _designationManager=new DesignationManager();
            _departmentManager=new DepartmentManager();
        }
      

        public ActionResult Index()
        {
            ViewBag.designations = _designationManager.GetAllDesignationsManager();
          
            ViewBag.departments = _departmentManager.GetAllDepartmentsManager();

          
            return View();
        }

        [HttpPost]
        public ActionResult Index(Teacher aTeacher)
        {
           
              
                ViewBag.designations = _designationManager.GetAllDesignationsManager();

                ViewBag.departments = _departmentManager.GetAllDepartmentsManager();
              
                ViewBag.message = _teacherManager.InsertTeacher(aTeacher);

            return View();
        }
    }
}