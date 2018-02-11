using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Gateway
{
    public class StudentResultGateway
    {
         private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _query;

        public StudentResultGateway()
        {
            _connection=new SqlConnection(conString);
        }
        public int SaveResultGateway(StudentResult aStudentResult)
        {
            _query = "INSERT INTO StudentResult(StudentRegId, CourseId, GradeId) values(@StudentRegId, @CourseId, @GradeId)";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@StudentRegId", aStudentResult.StudentRegId);
            _command.Parameters.AddWithValue("@CourseId", aStudentResult.CourseId);
            _command.Parameters.AddWithValue("@GradeId", aStudentResult.GradeId);

            _connection.Open();

            int rowAffect = _command.ExecuteNonQuery();

            _connection.Close();

            return rowAffect;
        }
        public List<StudentCourseGradeViewModel> GetResultByIdGateway(int registrationId)
        {
            string query = "SELECT * FROM StudentCourseGradeViewModel WHERE StdRegId = @StdRegId";
            _command = new SqlCommand(query, _connection);
            _command.Parameters.AddWithValue("@StdRegId", registrationId);
            _connection.Open();

            _reader = _command.ExecuteReader();

            List<StudentCourseGradeViewModel> studentCourseGradeViewModels = new List<StudentCourseGradeViewModel>();

            while (_reader.Read())
            {
                StudentCourseGradeViewModel aStudentCourseGradeViewModel = new StudentCourseGradeViewModel();

                aStudentCourseGradeViewModel.Id = Convert.ToInt32(_reader["Id"]);
                aStudentCourseGradeViewModel.CourseCode = _reader["CourseCode"].ToString();
                aStudentCourseGradeViewModel.CourseName = _reader["CourseName"].ToString();
                aStudentCourseGradeViewModel.GradeName = _reader["GradeName"].ToString();

                studentCourseGradeViewModels.Add(aStudentCourseGradeViewModel);
            }

            _reader.Close();

            _connection.Close();


            return studentCourseGradeViewModels;
        }


         public bool IsExistResult(StudentResult resultExist)
        {
            _query = "SELECT * FROM StudentResult WHERE StudentRegId = @StudentRegId AND CourseId = @CourseId";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@StudentRegId", resultExist.StudentRegId);
            _command.Parameters.AddWithValue("@CourseId", resultExist.CourseId);

            _connection.Open();

            _reader = _command.ExecuteReader();

            bool isExist = _reader.HasRows;

            _reader.Close();


            _connection.Close();

            return isExist;
        }
    }
}