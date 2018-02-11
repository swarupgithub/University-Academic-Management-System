using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models.ViewModel
{
    public class StudentCourseGradeViewModel
    {
        public int Id { get; set; }
        public int StdRegId { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }


        public string Department { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public  int CourseId { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
    }
}