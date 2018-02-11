using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class LoginGateway
    {
         private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public LoginGateway()
        {
            connection = new SqlConnection(conString);
        }

        public bool IsUser(Login aLogin)
        {
            query = "Select * From [User] Where UserName=@d1 And Password=@d2";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@d1", aLogin.UserName);
            command.Parameters.AddWithValue("@d2", aLogin.Password);
            connection.Open();

            reader = command.ExecuteReader();
            bool isUser = reader.HasRows;
            reader.Close();

            connection.Close();
            return isUser;
        }

    }
}