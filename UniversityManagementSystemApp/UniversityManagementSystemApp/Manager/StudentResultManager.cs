using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Manager
{
    public class StudentResultManager
    {

        private StudentResultGateway aStudentResultGateway;

        public StudentResultManager()
        {
           aStudentResultGateway = new StudentResultGateway();
        }

        public string SaveResultManager(StudentResult aStudentResult)
       {
           bool resultExist = aStudentResultGateway.IsExistResult(aStudentResult);

           if (resultExist == true)
           {
               return ("This Course Result is already saved");
           }
            
            int rowAffect = aStudentResultGateway.SaveResultGateway(aStudentResult);
           return rowAffect > 0 ? "Save Successful" : "Save Failed";
       }
        public List<StudentCourseGradeViewModel> GetResultById(int registrationId)
        {
            return aStudentResultGateway.GetResultByIdGateway(registrationId);
        }

    }
}