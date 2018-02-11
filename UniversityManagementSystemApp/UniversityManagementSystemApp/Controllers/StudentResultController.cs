using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;

namespace UniversityManagementSystemApp.Controllers
{
    public class StudentResultController : Controller
    {
        //
        // GET: /StudentResult/
        private CourseManager _courseManager;
        private DepartmentManager _departmentManager;
        private SemesterManager _semesterManager;
        private EnrollCourseManager aEnrollCourseManager;
       
        private GradeManager aGradeManager;
        private StudentResultManager aStudentResultManager;

        public StudentResultController()
        {
            _courseManager = new CourseManager();
            _departmentManager = new DepartmentManager();
            _semesterManager = new SemesterManager();
            aEnrollCourseManager = new EnrollCourseManager();
            aGradeManager = new GradeManager();
            aStudentResultManager = new StudentResultManager();
        }
        //
        // GET: /EnrollCourse/

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.regNos = aEnrollCourseManager.GetAllStudentRegNo();
            ViewBag.grades = aGradeManager.GetAllGradesManager();
            
            return View();

        }

        [HttpPost]
        public ActionResult Index(StudentResult aStudentResult)
        {
            ViewBag.regNos = aEnrollCourseManager.GetAllStudentRegNo();
            ViewBag.grades = aGradeManager.GetAllGradesManager();
            ViewBag.message = aStudentResultManager.SaveResultManager(aStudentResult);

            return View();
        }

        public JsonResult GetDetailsByStudentId(int registrationId)
        {
            var details = aEnrollCourseManager.GetStudentDetailsManager(registrationId);

            return Json(details);

        }
        public JsonResult GetCoursesByStudentId(int registrationId)
        {
            var courses = aEnrollCourseManager.GetCoursesByStudentIdManager(registrationId);

            return Json(courses);
        }


        [HttpGet]
        public ActionResult ViewResult()
        {
            ViewBag.regNos = aEnrollCourseManager.GetAllStudentRegNo();
            //ViewBag.Results = aStudentResultManager.GetResultById(registrationId);
            return View();
        }

        [HttpPost]
        public ActionResult ViewResult(int registrationId)
        {
            //ViewBag.Departments = _departmentManager.GetAllDepartmentsManager();
            
            ViewBag.regNos = aEnrollCourseManager.GetAllStudentRegNo();
            return View();
        }

        public JsonResult ViewResultStudent(int registrationId)
        {
            var results = aStudentResultManager.GetResultById(registrationId);

            return Json(results);

        }


        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Student_Result.pdf");
            }
        }

        //public JsonResult GetAllViewCourseStaticsByDepartmentId(int departmentId)
        //{
        //    var allStatics = _courseAssignTeacherManager.GetAllCoursesStatics();

        //    var allStaticsList = allStatics.Where(x => x.DepartmentId == departmentId).ToList();

        //    return Json(allStaticsList);
        //}
        
	}
}