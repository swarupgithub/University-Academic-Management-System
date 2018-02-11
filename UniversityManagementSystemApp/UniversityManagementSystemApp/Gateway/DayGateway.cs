using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class DayGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public DayGateway()
        {
            connection = new SqlConnection(conString);
        }

        public List<Day> GetAllDays()
        {
            string query = "SELECT * FROM Day";

            command = new SqlCommand(query, connection);


            connection.Open();

            reader = command.ExecuteReader();

            List<Day> days = new List<Day>();

            while (reader.Read())
            {
                Day aDay= new Day();

                aDay.Id = Convert.ToInt32(reader["Id"]);
                aDay.DayName = reader["DayName"].ToString();

                days.Add(aDay);
            }

            reader.Close();

            connection.Close();


            return days;
        }
    }
}