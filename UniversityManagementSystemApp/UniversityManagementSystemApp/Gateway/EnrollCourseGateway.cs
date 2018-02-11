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
    public class EnrollCourseGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _query;

        public EnrollCourseGateway()
        {
            _connection=new SqlConnection(conString);
        }
        public int SaveEnrollCourseGateway(EnrollCourse aEnrollCourse)
        {
            _query = "INSERT INTO EnrollCourse(StudentRegId, CourseId, EnrollDate) values(@StudentRegId, @CourseId, @EnrollDate)";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@StudentRegId", aEnrollCourse.StudentRegId);
            _command.Parameters.AddWithValue("@CourseId", aEnrollCourse.CourseId);
            _command.Parameters.AddWithValue("@EnrollDate", aEnrollCourse.Date);

            _connection.Open();

            int rowAffect = _command.ExecuteNonQuery();

            _connection.Close();

            return rowAffect;
        }

        public List<StudentCourseViewModel> GetCoursesByStudentIdGateway(int registrationId)
        {
            string query = "SELECT * FROM StudentCourseViewModel WHERE StudentRegId= @StudentRegId";

            _command = new SqlCommand(query, _connection);

            _command.Parameters.AddWithValue("@StudentRegId", registrationId);
            _connection.Open();

            _reader = _command.ExecuteReader();

            List<StudentCourseViewModel> studentCourseViewModels = new List<StudentCourseViewModel>();

            while (_reader.Read())
            {
                StudentCourseViewModel aStudentCourseViewModel = new StudentCourseViewModel();

                aStudentCourseViewModel.Id = Convert.ToInt32(_reader["Id"]);
                aStudentCourseViewModel.StudentRegId = Convert.ToInt32(_reader["StudentRegId"]);
                aStudentCourseViewModel.CourseName = _reader["CourseName"].ToString();
                aStudentCourseViewModel.CourseId = Convert.ToInt32(_reader["CourseId"]);

                studentCourseViewModels.Add(aStudentCourseViewModel);
            }

            _reader.Close();

            _connection.Close();


            return studentCourseViewModels;
        }


        public bool IsExistEnroll(EnrollCourse regExist)
        {
            _query = "SELECT * FROM EnrollCourse WHERE StudentRegId = @StudentRegId AND CourseId = @CourseId";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@StudentRegId", regExist.StudentRegId);
            _command.Parameters.AddWithValue("@CourseId", regExist.CourseId);
           
            _connection.Open();

            _reader = _command.ExecuteReader();

            bool isExist = _reader.HasRows;

            _reader.Close();


            _connection.Close();

            return isExist;
        }
    }
}