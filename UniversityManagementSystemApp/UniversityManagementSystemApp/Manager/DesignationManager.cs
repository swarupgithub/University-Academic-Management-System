using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class DesignationManager
    {
        private DesignationGateway aDesignationGateway;

        public DesignationManager()
        {
            aDesignationGateway = new DesignationGateway();
        }

        public List<Designation> GetAllDesignationsManager()
        {
            return aDesignationGateway.GetAllDesignations();
        }
    }
}