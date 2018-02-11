using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway _teacherGateway;

        public TeacherManager()
        {
            _teacherGateway=new TeacherGateway();
        }

        public string InsertTeacher(Teacher aTeacher)
        {
            bool emailExist = _teacherGateway.IsExistTeacherEmail(aTeacher);

            if (emailExist == true)
            {
                return ("Teacher Email already exists");
            }
            int rowAffect = _teacherGateway.SaveTeacherInfo(aTeacher);
            return rowAffect > 0 ? "Save Successful" : "Save Failed";
        }

        public List<Teacher> GetAllTeachersManager()
        {
            return _teacherGateway.GetAllTeachers();
        }

        public int GetAllTeachersByTeacherId(int id)
        {
            return _teacherGateway.GetAllTeachersByTeacherId(id);
        }
        

       
    }
}