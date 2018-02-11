using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class TeacherGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _query;

        public TeacherGateway()
        {
            _connection=new SqlConnection(conString);
        }
        public int SaveTeacherInfo(Teacher aTeacher)
        {
            _query = "INSERT INTO Teacher(TeacherName , TeacherAddress,TeacherEmail,TeacherContactNo,DesignationId,DepartmentId,CreditToTaken) values(@TeacherName, @TeacherAddress,@TeacherEmail,@TeacherContactNo,@DesignationId,@DepartmentId,@CreditToTaken)";

            
            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@TeacherName", aTeacher.TeacherName);
            _command.Parameters.AddWithValue("@TeacherAddress",aTeacher.TeacherAddress );
            _command.Parameters.AddWithValue("@TeacherEmail", aTeacher.TeacherEmail);
            _command.Parameters.AddWithValue("@TeacherContactNo", aTeacher.TeacherContactNo);
            _command.Parameters.AddWithValue("@DesignationId",aTeacher.DesignationId );
            _command.Parameters.AddWithValue("@DepartmentId", aTeacher.DepartmentId);
            _command.Parameters.AddWithValue("@CreditToTaken",aTeacher.CreditToTaken);

            _connection.Open();

            int rowAffect = _command.ExecuteNonQuery();

            _connection.Close();

            return rowAffect;
        }
        public bool IsExistTeacherEmail(Teacher emailExist)
        {
            _query = "SELECT * FROM Teacher WHERE TeacherEmail = @TeacherEmail AND Id <> @Id ";
            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@TeacherEmail", emailExist.TeacherEmail);
            _command.Parameters.AddWithValue("@Id", emailExist.Id);


            _connection.Open();

            _reader = _command.ExecuteReader();

            bool isExist = _reader.HasRows;

            _reader.Close();


            _connection.Close();

            return isExist;
        }

        public List<Teacher> GetAllTeachers()
        {
            string query = "SELECT * FROM Teacher";

            _command = new SqlCommand(query, _connection);


            _connection.Open();

            _reader = _command.ExecuteReader();

            List<Teacher> teachers = new List<Teacher>();

            while (_reader.Read())
            {
                Teacher aTeacher = new Teacher();

                aTeacher.Id = Convert.ToInt32(_reader["Id"]);
                aTeacher.TeacherName = _reader["TeacherName"].ToString();
                aTeacher.DepartmentId = Convert.ToInt32(_reader["DepartmentId"]);

                teachers.Add(aTeacher);
            }

            _reader.Close();

            _connection.Close();


            return teachers;
        }


        public int GetAllTeachersByTeacherId(int id)
        {
            string query = "SELECT CreditToTaken FROM Teacher WHERE ID = @Id";
            _command = new SqlCommand(query, _connection);
            _command.Parameters.AddWithValue("@Id", id);
            _connection.Open();
            _reader = _command.ExecuteReader();
            _reader.Read();
            int credit = Convert.ToInt32(_reader["CreditToTaken"]);
            _reader.Close();
            _connection.Close();
            return credit;
        }

        
    }
}