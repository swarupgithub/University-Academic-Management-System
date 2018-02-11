using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class RoomGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public RoomGateway()
        {
            connection = new SqlConnection(conString);
        }

        public List<Room> GetAllRooms()
        {
            string query = "SELECT * FROM Room";

            command = new SqlCommand(query, connection);


            connection.Open();

            reader = command.ExecuteReader();

            List<Room> rooms = new List<Room>();

            while (reader.Read())
            {
                Room aRoom= new Room();

                aRoom.Id = Convert.ToInt32(reader["Id"]);
                aRoom.RoomNo = reader["RoomNo"].ToString();

                rooms.Add(aRoom);
            }

            reader.Close();

            connection.Close();


            return rooms;
            ;
        }
    }
}