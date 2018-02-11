using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models.ViewModel
{
    public class CourseAssignTeacherViewModel
    {
        public int DepartmentId { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CourseDepartmentId { get; set; }
        public int CourseSemesterId { get; set; }

        public int SemesterId { get; set; }
        public string SemesterName { get; set; }

        public int CourseAssignTeacherTeacherId { get; set; }
        public int CourseAssignTeacherCourseId { get; set; }
        

    }
}