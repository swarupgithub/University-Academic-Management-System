using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Manager
{
    public class CourseAssignTeacherManager
    {
        private CourseAssignTeacherGateway _courseAssignTeacherGateway;
        private TeacherGateway _teacherGateway;


        public CourseAssignTeacherManager()
        {
            _courseAssignTeacherGateway = new CourseAssignTeacherGateway();
            _teacherGateway = new TeacherGateway();
        }

        public string InsertDetails(CourseAssignTeacher aCourseAssignTeacher)
        {
            bool assignExist = _courseAssignTeacherGateway.IsExistAssign(aCourseAssignTeacher);

            if (assignExist == true)
            {
                return ("This Course is already assigned");
            }
            int rowAffect = _courseAssignTeacherGateway.SaveCourseAssignTeacherInfo(aCourseAssignTeacher);
            return rowAffect > 0 ? "Save Successful" : "Save Failed";
        }

        public List<CourseAssignTeacherViewModel> GetAllCoursesStatics()
        {
            return _courseAssignTeacherGateway.GetAllCoursesStatics();
        }

        public int GetRemainingCreditByTeacherId(int id)
        {
            int creditToTaken = _teacherGateway.GetAllTeachersByTeacherId(id);
            int remainingCredit = 0;
            int sumOfRemainingCredit = _courseAssignTeacherGateway.GetSumAssainCreeditByTeacherId(id);

            if (sumOfRemainingCredit == 0)
            {
                remainingCredit = creditToTaken;
            }
            else
            {
                remainingCredit = creditToTaken - sumOfRemainingCredit; 
            }
            

            return remainingCredit;

        }
    }
}