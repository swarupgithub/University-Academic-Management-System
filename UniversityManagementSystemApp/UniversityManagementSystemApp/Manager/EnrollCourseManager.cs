using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Manager
{
    public class EnrollCourseManager
    {
       private CourseGateway _courseGateway;
       private StudentRegistrationGateway aStudentRegistrationGateway;
        private EnrollCourseGateway aEnrollCourseGateway;

       public EnrollCourseManager()
        {
            _courseGateway = new CourseGateway();
            aStudentRegistrationGateway = new StudentRegistrationGateway();
            aEnrollCourseGateway = new EnrollCourseGateway();
           

        }

       public string SaveEnrollCourseManager(EnrollCourse aEnrollCourse)
       {
           bool enrollExist = aEnrollCourseGateway.IsExistEnroll(aEnrollCourse);

           if (enrollExist == true)
           {
               return ("Course is already enrolled");
           }

           int rowAffect = aEnrollCourseGateway.SaveEnrollCourseGateway(aEnrollCourse);
           return rowAffect > 0 ? "Save Successful" : "Save Failed";
       }

       public List<StudentRegestration> GetAllStudentRegNo()
       {
           return aStudentRegistrationGateway.GetAllStudentRegistrations();
       }

       public List<StudentRegestration> GetStudentDetailsManager(int registrationId)
       {
           return aStudentRegistrationGateway.GetStudentDetailsById(registrationId);
       }
        public List<Course> GetAllCoursesByCourseIdManager(int id)
        {
            return _courseGateway.GetAllCoursesByCourseId(id);
        }

        public List<StudentCourseViewModel> GetCoursesByStudentIdManager(int registrationId)
        {
            return aEnrollCourseGateway.GetCoursesByStudentIdGateway(registrationId);
        }
    }
}