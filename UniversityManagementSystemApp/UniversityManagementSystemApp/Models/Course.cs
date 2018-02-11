using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class Course
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please Select Course Code!")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Code must be at least five (5) characters long.")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Please Select Course Name!")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Please Select Course Credit!")]
       
        [Range(0.5,5.0,ErrorMessage = "Credit Should be Between 0.5 to 5.0")]
        public int Credit { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Select a Department!")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select a Semester!")]
        public int SemesterId { get; set; }
    }
}