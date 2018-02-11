using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway aDepartmentGateway;

        public DepartmentManager()
        {
            aDepartmentGateway = new DepartmentGateway();
        }


        public string SaveDeptInfoManager(Department aDepartment)
        {
            bool checkCodeExist = aDepartmentGateway.IsExistDeptCode(aDepartment);

            bool checkNameExist = aDepartmentGateway.IsExistDeptName(aDepartment);


            if (checkCodeExist == true && checkNameExist == true)
            {
                return ("Depertment Code & Name both already exists");
            }

            if (checkCodeExist == true)
            {
                return ("Depertment Code already exists");
            }

            if (checkNameExist == true)
            {
                return ("Depertment Name already exists");
            }

            int rowAffect = aDepartmentGateway.SaveDeptInfo(aDepartment);

            return rowAffect > 0 ? "Save successfully" : "Save failed";
        }

        public List<Department> GetAllDepartmentsManager()
        {
            return aDepartmentGateway.GetAllDepartmentss();
        }

        public string GetDeptCode(int id)
        {
            string deptCode = aDepartmentGateway.GetDeptCodeForRegGateway(id);
            return deptCode;
        }
    }
}