using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementSystemApp.Gateway
{
    public class UnallocateRoomsGateway
    {
        private string conString =
            WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _query;

        public UnallocateRoomsGateway()
        {
            _connection = new SqlConnection(conString);
        }

        public int UnAllocateRooms()
        {
            _query = "UPDATE AllocateClassroom SET IsActive = 0";


            _command = new SqlCommand(_query, _connection);

            _connection.Open();

            int rowAffect = _command.ExecuteNonQuery();

            _connection.Close();

            return rowAffect;
        }
    }
}