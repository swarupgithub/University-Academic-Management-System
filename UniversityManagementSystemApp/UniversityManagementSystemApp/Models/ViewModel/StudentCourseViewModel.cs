using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models.ViewModel
{
    public class StudentCourseViewModel
    {
        public int Id { get; set; }
        public int StudentRegId { get; set; }
        public DateTime EnrollDate { get; set; }
        public string CourseCode { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

    }
}