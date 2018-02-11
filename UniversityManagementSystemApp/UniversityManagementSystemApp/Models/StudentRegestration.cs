using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class StudentRegestration
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide name!")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please provide a Email!")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Please provide valide email")]
        public string StudentEmail { get; set; }

        [Required(ErrorMessage = "Please provide a Contact no!")]
        [RegularExpression(@"^([0-9\(\)\/\+ \-]*)$", ErrorMessage = "Invalid Contact NO")]
        [MaxLength(11)]
        public string StudentContactNo { get; set; }

        [Required(ErrorMessage = "Please Select Date!")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please Select Adress!")]
        public string StudentAdress { get; set; }

        [Required(ErrorMessage = "Please Select Department!")]
        public string DepartmentId { get; set; }

        public string DeptCode { get; set; }

        public string RegNo { get; set; }
        public int Roll { get; set; }

    }
}