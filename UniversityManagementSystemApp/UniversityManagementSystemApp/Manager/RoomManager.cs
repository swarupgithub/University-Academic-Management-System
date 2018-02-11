using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class RoomManager
    {
        private RoomGateway aRoomGateway;

        public RoomManager()
        {
            aRoomGateway = new RoomGateway();
        }

        public List<Room> GetAllRoomsManager()
        {
            return aRoomGateway.GetAllRooms();
        }
    }
}