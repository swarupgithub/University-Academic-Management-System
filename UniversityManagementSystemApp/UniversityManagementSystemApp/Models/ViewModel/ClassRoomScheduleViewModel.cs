using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models.ViewModel
{
    public class ClassRoomScheduleViewModel
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int DayId { get; set; }
        public string DayName { get; set; }
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string AllocateFromDate { get; set; }
        public string AllocateToDate { get; set; }
    }
}