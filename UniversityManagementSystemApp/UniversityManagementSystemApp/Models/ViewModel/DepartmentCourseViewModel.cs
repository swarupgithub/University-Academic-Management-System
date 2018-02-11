using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models.ViewModel
{
    public class DepartmentCourseViewModel
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public string StudentRenNo { get; set; }
        public int CourseId { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }

    }
}