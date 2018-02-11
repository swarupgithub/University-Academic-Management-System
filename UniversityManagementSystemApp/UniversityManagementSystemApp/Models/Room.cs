using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int IsActiveRoom { get; set; }
    }
}