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
    public class CourseGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _query;

        public CourseGateway()
        {
            _connection=new SqlConnection(conString);
        }

        public int SaveCourseInfo(Course acourse)
        {
            _query = "INSERT INTO Course(CourseCode , CourseName,Credit,Description,DepartmentId,SemesterId) values(@CourseCode, @CourseName,@Credit,@Description,@DepartmentId,@SemesterId)";

            //_query = "INSERT INTO Course VALUES('"+acourse.CourseCode+"','"+acourse.CourseName+"','"+acourse.Credit+"','"+acourse.Description+"','"+acourse.DepartmentId+"','"+acourse.SemesterId+"')";
            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@CourseCode", acourse.CourseCode);
            _command.Parameters.AddWithValue("@CourseName", acourse.CourseName);
            _command.Parameters.AddWithValue("@Credit", acourse.Credit);
            _command.Parameters.AddWithValue("@Description", acourse.Description);
            _command.Parameters.AddWithValue("@DepartmentId", acourse.DepartmentId);
            _command.Parameters.AddWithValue("@SemesterId", acourse.SemesterId);

            _connection.Open();

            int rowAffect = _command.ExecuteNonQuery();

            _connection.Close();

            return rowAffect;
        }
        public bool IsExistCourseCode(Course codeExist)
        {
            _query = "SELECT * FROM Course WHERE CourseCode = @CourseCode AND Id <> @Id ";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@CourseCode", codeExist.CourseCode);
            _command.Parameters.AddWithValue("@Id", codeExist.Id);


            _connection.Open();

            _reader = _command.ExecuteReader();

            bool isExist = _reader.HasRows;

            _reader.Close();


            _connection.Close();

            return isExist;
        }
        public bool IsExistCourseName(Course nameExist)
        {
            _query = "SELECT * FROM Course WHERE CourseName = @CourseName AND Id <> @Id ";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@CourseName", nameExist.CourseName);
            _command.Parameters.AddWithValue("@Id", nameExist.Id);


            _connection.Open();

            _reader = _command.ExecuteReader();

            bool isExist = _reader.HasRows;

            _reader.Close();


            _connection.Close();

            return isExist;
        }


        public List<Course> GetAllCourses()
        {
            string query = "SELECT * FROM Course";

            _command = new SqlCommand(query, _connection);


            _connection.Open();

            _reader = _command.ExecuteReader();

            List<Course> courses = new List<Course>();

            while (_reader.Read())
            {
                Course aCourse = new Course();

                aCourse.Id = Convert.ToInt32(_reader["Id"]);
                aCourse.CourseCode = _reader["CourseCode"].ToString();
                aCourse.CourseName = _reader["CourseName"].ToString();
                aCourse.DepartmentId = Convert.ToInt32(_reader["DepartmentId"]);

                courses.Add(aCourse);
            }

            _reader.Close();

            _connection.Close();


            return courses;

        }
        public List<DepartmentCourseViewModel> GetCoursesUnderDept(int registrationId)
        {
            string query = "SELECT * FROM DepartmentCourseViewModel WHERE Id = @Id";

            _command = new SqlCommand(query, _connection);

            _command.Parameters.AddWithValue("@Id", registrationId);
            _connection.Open();

            _reader = _command.ExecuteReader();

            List<DepartmentCourseViewModel> departmentCourseViewModels = new List<DepartmentCourseViewModel>();

            while (_reader.Read())
            {
                DepartmentCourseViewModel aDepartmentCourseViewModel = new DepartmentCourseViewModel();

                aDepartmentCourseViewModel.Id = Convert.ToInt32(_reader["Id"]);
                aDepartmentCourseViewModel.CourseId = Convert.ToInt32(_reader["CourseId"]);
                aDepartmentCourseViewModel.CourseCode = _reader["CourseCode"].ToString();
                aDepartmentCourseViewModel.CourseName = _reader["CourseName"].ToString();
                aDepartmentCourseViewModel.DeptCode = _reader["DeptCode"].ToString();
                aDepartmentCourseViewModel.DeptName = _reader["DeptName"].ToString();

                departmentCourseViewModels.Add(aDepartmentCourseViewModel);
            }

            _reader.Close();

            _connection.Close();


            return departmentCourseViewModels;

        }

        public List<Course> GetAllCoursesByCourseId(int id)
        {
            string query = "SELECT CourseName,Credit FROM Course WHERE Id = @Id";

            _command = new SqlCommand(query, _connection);

            _command.Parameters.AddWithValue("@Id", id);
            _connection.Open();

            _reader = _command.ExecuteReader();

            List<Course> courses = new List<Course>();

            while (_reader.Read())
            {
                Course aCourse = new Course();

                aCourse.CourseName = _reader["CourseName"].ToString();
                aCourse.Credit = Convert.ToInt32(_reader["Credit"]);

                courses.Add(aCourse);
            }

            _reader.Close();

            _connection.Close();


            return courses;
        }
    }
}