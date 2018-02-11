using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class GradeManager
    {
        private GradeGateway aGradeGateway;

        public GradeManager()
        {
            aGradeGateway = new GradeGateway();
        }

        public List<Grade> GetAllGradesManager()
        {
            return aGradeGateway.GetAllGrades();
        }
    }
}