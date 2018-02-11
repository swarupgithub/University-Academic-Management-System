using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class SemesterGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SemesterGateway()
        {
            connection = new SqlConnection(conString);
        }

        public List<Semester> GetAllSemesters()
        {
            string query = "SELECT * FROM Semester ORDER BY Id ASC";

            command = new SqlCommand(query, connection);


            connection.Open();

            reader = command.ExecuteReader();

            List<Semester> semesters = new List<Semester>();

            while (reader.Read())
            {
                Semester aSemester= new Semester();

                aSemester.Id = Convert.ToInt32(reader["Id"]);
                aSemester.SemesterName = reader["SemesterName"].ToString();

                semesters.Add(aSemester);
            }

            reader.Close();

            connection.Close();


            return semesters;
        }
    }
}