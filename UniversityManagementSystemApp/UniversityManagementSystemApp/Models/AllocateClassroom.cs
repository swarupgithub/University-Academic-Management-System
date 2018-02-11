using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class AllocateClassroom
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int DayId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AllocateFromDate { get; set; }

        [DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime AllocateToDate { get; set; }
    }
}