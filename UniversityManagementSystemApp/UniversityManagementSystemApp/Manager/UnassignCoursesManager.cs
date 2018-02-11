using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;

namespace UniversityManagementSystemApp.Manager
{
    public class UnassignCoursesManager
    {
        private UnassignCoursesGateway _unassignCoursesGateway;

        public UnassignCoursesManager()
        {
            _unassignCoursesGateway = new UnassignCoursesGateway();
        }

        public string UnAssignCousesManager()
        {
            int rowAffect = _unassignCoursesGateway.UnAssignCourses();
            return rowAffect > 0 ? "Save Successful" : "Save Failed";
        }
    }
}