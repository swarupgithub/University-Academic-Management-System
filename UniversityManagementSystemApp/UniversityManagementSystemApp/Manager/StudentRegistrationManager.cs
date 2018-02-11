using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class StudentRegistrationManager
    {
         private StudentRegistrationGateway _studentRegistrationGateway;

        private int number = 1;
        private int rowAffect;
         public StudentRegistrationManager()
        {
            _studentRegistrationGateway = new StudentRegistrationGateway();
        }

         public string SaveStudentRegistration(StudentRegestration aStudentRegestration)
        {
            bool emailExist = _studentRegistrationGateway.IsExistStudentEmail(aStudentRegestration);
            if (emailExist == true)
            {
                return ("Student Email already exists");
            }



            //RegNoIncreamentManager(aStudentRegestration);

             string regNo = aStudentRegestration.DeptCode;

             //int idYear = _studentRegistrationGateway.GetIdForYear();
             //DateTime previousDate = _studentRegistrationGateway.GetYear(idYear);
             //String previousYear = previousDate.Year.ToString();

             //String currentDate = DateTime.Now.ToString();
             //DateTime currentDateValue = (Convert.ToDateTime(currentDate.ToString()));
             //String currentYear = currentDateValue.Year.ToString();

             //if (Convert.ToInt32(previousYear) < Convert.ToInt32(currentYear))
             //{
             //    _studentRegistrationGateway.MakeEmptyRoll(aStudentRegestration,idYear);
             //}

                number = _studentRegistrationGateway.AutoIncrementRoll(aStudentRegestration);
                aStudentRegestration.Roll = number;

                String sDate = DateTime.Now.ToString();

                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

                String yy = datevalue.Year.ToString();

                String generateRegNo = Convert.ToString(regNo + "-" + yy + "-" + number.ToString("D5"));

                aStudentRegestration.RegNo = generateRegNo;

                rowAffect = _studentRegistrationGateway.SaveStudentInfo(aStudentRegestration);
                return rowAffect > 0 ? "Save Successful" : "Save Failed";
           
        }



    }
}