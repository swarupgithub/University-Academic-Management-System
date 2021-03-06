﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class StudentResult
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Write the Student Registration Id")]
        public int StudentRegId { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }


        public string Department { get; set; }

        [Required(ErrorMessage = "Please Write the Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Write the Grade")]
        public int GradeId { get; set; }
    }
}