using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class GradeGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public GradeGateway()
        {
            connection = new SqlConnection(conString);
        }

        public List<Grade> GetAllGrades()
        {
            string query = "SELECT * FROM Grade";

            command = new SqlCommand(query, connection);


            connection.Open();

            reader = command.ExecuteReader();

            List<Grade> grades = new List<Grade>();

            while (reader.Read())
            {
                Grade aGrade= new Grade();

                aGrade.Id = Convert.ToInt32(reader["Id"]);
                aGrade.GradeName = reader["GradeName"].ToString();

                grades.Add(aGrade);
            }

            reader.Close();

            connection.Close();


            return grades;
        }
    }
}