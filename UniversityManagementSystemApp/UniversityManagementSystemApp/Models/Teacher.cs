using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide name!")]

        public string TeacherName { get; set; }

        public string TeacherAddress { get; set; }
        [Required(ErrorMessage = "Please provide a Email!")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Please provide valide email")]
        
        public string TeacherEmail { get; set; }

        [Required(ErrorMessage = "Please provide a Contact no!")]

        [RegularExpression(@"^([0-9\(\)\/\+ \-]*)$",ErrorMessage = "Invalid Contact NO")]
       
        public string TeacherContactNo { get; set; }
        [Required(ErrorMessage = "Please Select Designation!")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please Select Department!")]
        public int DepartmentId { get; set; }
         [Required(ErrorMessage = "Please Enter Credit You Want to take!")]
        [Range(1,18)]
        public int CreditToTaken { get; set; }

        public int RemainingCredit { get; set; }

    }
}