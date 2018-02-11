using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class SemesterManager
    {
        private SemesterGateway aSemesterGateway;

        public SemesterManager()
        {
            aSemesterGateway = new SemesterGateway();
        }

        public List<Semester> GetAllSemestersManager()
        {
            return aSemesterGateway.GetAllSemesters();
        }
    }
}