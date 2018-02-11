using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Manager
{
    public class CourseManager
    {
        private CourseGateway _courseGateway;

        public CourseManager()
        {
            _courseGateway=new CourseGateway();
        }

        public string InsertCourse(Course course)
        {
            bool checkCodeExist = _courseGateway.IsExistCourseCode(course);

            bool checkNameExist = _courseGateway.IsExistCourseName(course);


            if (checkCodeExist == true && checkNameExist == true)
            {
                return ("Course Code & Name both already exists");
            }

            if (checkCodeExist == true)
            {
                return ("Course Code already exists");
            }

            if (checkNameExist == true)
            {
                return ("Course Name already exists");
            }

            int rowAffect = _courseGateway.SaveCourseInfo(course);
            return rowAffect > 0 ? "Save Successful" : "Save Failed";
        }

        public List<Course> GetAllCoursesManager()
        {
            return _courseGateway.GetAllCourses();
        }

        public List<DepartmentCourseViewModel> GetCoursesUnderDeptManager(int registrationId)
        {
            return _courseGateway.GetCoursesUnderDept(registrationId);
        }

        public List<Course> GetAllCoursesByCourseIdManager(int id)
        {
            return _courseGateway.GetAllCoursesByCourseId(id);
        }
    }
}