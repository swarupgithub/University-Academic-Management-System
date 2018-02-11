using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class DepartmentGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public DepartmentGateway()
        {
            connection = new SqlConnection(conString);
        }

        public int SaveDeptInfo(Department aDepartment)
        {
            query = "INSERT INTO Department(DeptCode , DeptName) values(@DeptCode, @DeptName)";

            
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DeptCode", aDepartment.DeptCode);
            command.Parameters.AddWithValue("@DeptName", aDepartment.DeptName);

            connection.Open();

            int rowAffect = command.ExecuteNonQuery();

            connection.Close();

            return rowAffect;
        }

        public bool IsExistDeptCode(Department codeExist)
        {
            query = "SELECT * FROM Department WHERE DeptCode = @DeptCode AND Id <> @Id ";

            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DeptCode", codeExist.DeptCode);
            command.Parameters.AddWithValue("@Id", codeExist.Id);


            connection.Open();

            reader = command.ExecuteReader();

            bool isExist = reader.HasRows;

            reader.Close();


            connection.Close();

            return isExist;
        }

        public bool IsExistDeptName(Department nameExist)
        {
            query = "SELECT * FROM Department WHERE DeptName = @DeptName AND Id <> @Id ";

            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DeptName", nameExist.DeptName);
            command.Parameters.AddWithValue("@Id", nameExist.Id);


            connection.Open();

            reader = command.ExecuteReader();

            bool isExist = reader.HasRows;

            reader.Close();


            connection.Close();

            return isExist;
        }

        public List<Department> GetAllDepartmentss()
        {
            string query = "SELECT * FROM Department";

            command = new SqlCommand(query, connection);


            connection.Open();

            reader = command.ExecuteReader();

            List<Department> departments = new List<Department>();

            while (reader.Read())
            {
                Department aDepartment = new Department();

                aDepartment.Id = Convert.ToInt32(reader["Id"]);
                aDepartment.DeptCode = reader["DeptCode"].ToString();
                aDepartment.DeptName = reader["DeptName"].ToString();

                departments.Add(aDepartment);
            }

            reader.Close();

            connection.Close();


            return departments;
        }

        public string GetDeptCodeForRegGateway(int id)
        {
            query = "SELECT DeptCode FROM Department WHERE Id = @Id";

            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            connection.Open();

            reader = command.ExecuteReader();

            reader.Read();
            string dept = reader["DeptCode"].ToString();

            reader.Close();

            connection.Close();

            return dept;
        }
    }
}