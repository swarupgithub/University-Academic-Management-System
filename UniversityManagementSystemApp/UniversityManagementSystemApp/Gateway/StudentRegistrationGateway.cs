using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class StudentRegistrationGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _query;

        public StudentRegistrationGateway()
        {
            _connection=new SqlConnection(conString);
        }

        public int SaveStudentInfo(StudentRegestration aStudentRegestration)
        {
            _query = "INSERT INTO StudentRegistration(StudentName, StudentEmail, StudentContactNo, RegistrationDate, StudentAddress, DepartmentId, StudentRegNo, Roll) values(@StudentName, @StudentEmail, @StudentContactNo, @RegistrationDate, @StudentAddress, @DepartmentId, @StudentRegNo, @Roll)";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@StudentName", aStudentRegestration.StudentName);
            _command.Parameters.AddWithValue("@StudentEmail", aStudentRegestration.StudentEmail);
            _command.Parameters.AddWithValue("@StudentContactNo", aStudentRegestration.StudentContactNo);
            _command.Parameters.AddWithValue("@RegistrationDate", aStudentRegestration.Date);
            _command.Parameters.AddWithValue("@StudentAddress", aStudentRegestration.StudentAdress);
            _command.Parameters.AddWithValue("@DepartmentId", aStudentRegestration.DepartmentId);
            _command.Parameters.AddWithValue("@StudentRegNo", aStudentRegestration.RegNo);
            _command.Parameters.AddWithValue("@Roll", aStudentRegestration.Roll);

            _connection.Open();

            int rowAffect = _command.ExecuteNonQuery();

            _connection.Close();

            return rowAffect;
        }

        public bool IsExistStudentEmail(StudentRegestration emailExist)
        {
            _query = "SELECT * FROM StudentRegistration WHERE StudentEmail = @StudentEmail AND Id <> @Id ";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@StudentEmail", emailExist.StudentEmail);
            _command.Parameters.AddWithValue("@Id", emailExist.Id);
            _connection.Open();

            _reader = _command.ExecuteReader();

            bool isExist = _reader.HasRows;

            _reader.Close();

            _connection.Close();

            return isExist;
        }

       

        public int AutoIncrementRoll(StudentRegestration aStudentRegestration)
        {
            int roll = 0;
            _query = "SELECT MAX(Roll) FROM StudentRegistration WHERE DepartmentId = @DepartmenntId";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@DepartmenntId", aStudentRegestration.DepartmentId);
            // _command = new SqlCommand(_query, _connection);
            _connection.Open();

            if (Convert.IsDBNull(_command.ExecuteScalar()))
            {
                roll = 1;
            }
            else
            {
                roll = (int)(_command.ExecuteScalar());
                roll += 1;
            }

            _command.Dispose();
            _connection.Close();
            return roll;
        }
        public int GetIdForYear()
        {
            int idno = 0;
            _query = "SELECT MAX(Id) FROM StudentRegistration";
            _command = new SqlCommand(_query, _connection);
            _connection.Open();

            if (Convert.IsDBNull(_command.ExecuteScalar()))
            {
                idno = 0;
            }
            else
            {
                idno = (int)(_command.ExecuteScalar());
                
            }

            _command.Dispose();
            _connection.Close();
            return idno;
        }
        public DateTime GetYear(int id)
        {
            
            _query = "SELECT RegistrationDate FROM StudentRegistration WHERE Id = @Id";
            _command = new SqlCommand(_query, _connection);
            _command.Parameters.AddWithValue("@Id", id);
            _connection.Open();
            _reader = _command.ExecuteReader();
            _reader.Read();

            string strDate = _reader["RegistrationDate"].ToString();

            DateTime date = (Convert.ToDateTime(strDate.ToString()));
            _reader.Close();
            _connection.Close();
            return date;
        }
        public void MakeEmptyRoll(StudentRegestration aStudentRegestration, int rowCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                _query = "INSERT INTO StudentRegistration(Roll) values(@Roll)";
                _command = new SqlCommand(_query, _connection);

                _command.Parameters.AddWithValue("@Roll", null);

                _connection.Open();

                _command.ExecuteNonQuery();

                _connection.Close();
            }

        }

        public List<StudentRegestration> GetAllStudentRegistrations()
        {
            string query = "SELECT * FROM StudentRegistration";

            _command = new SqlCommand(query, _connection);

            _connection.Open();

            _reader = _command.ExecuteReader();

            List<StudentRegestration> studentRegestrations = new List<StudentRegestration>();

            while (_reader.Read())
            {
                StudentRegestration aStudentRegestration = new StudentRegestration();

                aStudentRegestration.Id = Convert.ToInt32(_reader["Id"]);
                aStudentRegestration.RegNo = _reader["StudentRegNo"].ToString();
                //aDepartment.DeptName = reader["DeptName"].ToString();

                studentRegestrations.Add(aStudentRegestration);
            }

            _reader.Close();

            _connection.Close();


            return studentRegestrations;
            
        }
        public List<StudentRegestration> GetStudentDetailsById(int id)
        {
            string query = "SELECT * FROM EnrollCourseViewModel WHERE Id=@Id";

            _command = new SqlCommand(query, _connection);

            _command.Parameters.AddWithValue("@Id", id);
            _connection.Open();

            _reader = _command.ExecuteReader();

            List<StudentRegestration> studentRegestrations = new List<StudentRegestration>();

            while (_reader.Read())
            {
                StudentRegestration aStudentRegestration = new StudentRegestration();

                aStudentRegestration.Id = Convert.ToInt32(_reader["Id"]);
                aStudentRegestration.RegNo = _reader["StudentRegNo"].ToString();
                aStudentRegestration.StudentName = _reader["StudentName"].ToString();
                aStudentRegestration.StudentEmail = _reader["StudentEmail"].ToString();
                aStudentRegestration.DeptCode = _reader["DeptName"].ToString();

                studentRegestrations.Add(aStudentRegestration);
            }

            _reader.Close();

            _connection.Close();


            return studentRegestrations;
            
        }
    }

}

