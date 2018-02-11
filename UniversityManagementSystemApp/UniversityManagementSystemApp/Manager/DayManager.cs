using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class DayManager
    {
        private DayGateway aDayGateway;

        public DayManager()
        {
            aDayGateway = new DayGateway();
        }

        public List<Day> GetAllDaysManager()
        {
            return aDayGateway.GetAllDays();
        }
    }
}