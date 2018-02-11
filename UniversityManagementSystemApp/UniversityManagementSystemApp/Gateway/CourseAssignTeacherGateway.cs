using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Gateway
{
    public class CourseAssignTeacherGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _query;
        public CourseAssignTeacherGateway()
        {
            _connection=new SqlConnection(conString);
        }


        public int SaveCourseAssignTeacherInfo(CourseAssignTeacher aCourseAssignTeacher)
        {
            _query = "INSERT INTO CourseAssignTeacher(TeacherId ,CourseId) values(@TeacherId, @CourseId)";


            _command = new SqlCommand(_query, _connection);


            _command.Parameters.AddWithValue("@TeacherId", aCourseAssignTeacher.TeacherId);
            _command.Parameters.AddWithValue("@CourseId", aCourseAssignTeacher.CourseId);
          

            _connection.Open();

            int rowAffect = _command.ExecuteNonQuery();

            _connection.Close();

            return rowAffect;
        }

        public List<CourseAssignTeacherViewModel> GetAllCoursesStatics()
        {
            string query = "SELECT * FROM CourseAssignTeacherViewModel";

            _command = new SqlCommand(query, _connection);

            _connection.Open();

            _reader = _command.ExecuteReader();

            List<CourseAssignTeacherViewModel> courseAssignTeacherViewModels = new List<CourseAssignTeacherViewModel>();

            while (_reader.Read())
            {
                CourseAssignTeacherViewModel assignTeacherViewModel = new CourseAssignTeacherViewModel();

                assignTeacherViewModel.CourseCode = _reader["CourseCode"].ToString();
                assignTeacherViewModel.CourseName = _reader["CourseName"].ToString();
                assignTeacherViewModel.SemesterName = _reader["SemesterName"].ToString();
                assignTeacherViewModel.TeacherName = _reader["TeacherName"].ToString();
               
                if (assignTeacherViewModel.TeacherName.IsEmpty())
                {
                    assignTeacherViewModel.TeacherName = "Not Assigned To";
                }
                
                assignTeacherViewModel.DepartmentId = Convert.ToInt32(_reader["Id"]);

                courseAssignTeacherViewModels.Add(assignTeacherViewModel);
            }

            _reader.Close();

            _connection.Close();


            return courseAssignTeacherViewModels;
        }



        public int GetSumAssainCreeditByTeacherId(int id)
        {

            int credit = 0;
           


                string query = "SELECT sum(Credit) as sumCredit from CourseAssignTeacherViewModel where teachId = @Id";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                _reader = _command.ExecuteReader();




                _reader.Read();

                if (_reader["sumCredit"].ToString().IsEmpty())
                {
                    credit = 0;
                }
                else
                {
                    credit = Convert.ToInt32(_reader["sumCredit"]);
                }

                

                _reader.Close();

                _connection.Close();
            

            


            return credit;
        }

        public bool IsExistAssign(CourseAssignTeacher assignExist)
        {
            _query = "SELECT * FROM CourseAssignTeacher WHERE TeacherId = @TeacherId AND CourseId = @CourseId";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@TeacherId", assignExist.TeacherId);
            _command.Parameters.AddWithValue("@CourseId", assignExist.CourseId);

            _connection.Open();

            _reader = _command.ExecuteReader();

            bool isExist = _reader.HasRows;

            _reader.Close();


            _connection.Close();

            return isExist;
        }
    }
}