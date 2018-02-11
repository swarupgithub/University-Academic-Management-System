using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class DesignationGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public DesignationGateway()
        {
            connection = new SqlConnection(conString);
        }

        public List<Designation> GetAllDesignations()
        {
            string query = "SELECT * FROM Designation";

            command = new SqlCommand(query, connection);


            connection.Open();

            reader = command.ExecuteReader();

            List<Designation> designations = new List<Designation>();

            while (reader.Read())
            {
                Designation aDesignation= new Designation();

                aDesignation.Id = Convert.ToInt32(reader["Id"]);
                aDesignation.DesignationName = reader["DesignationName"].ToString();

                designations.Add(aDesignation);
            }

            reader.Close();

            connection.Close();


            return designations;
        }
    }
}