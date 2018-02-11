using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Write the Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Please Provide the Code Name between 2 to 7 Character")]
        public string DeptCode { get; set; }


        [Required(ErrorMessage = "Please Write the Department Name")]      
        public string DeptName { get; set; }
    }
}