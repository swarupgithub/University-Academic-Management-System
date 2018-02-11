using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;

namespace UniversityManagementSystemApp.Manager
{
    public class UnallocateRoomsManager
    {
        private UnallocateRoomsGateway _unallocateRoomsGateway;

        public UnallocateRoomsManager()
        {
            _unallocateRoomsGateway = new UnallocateRoomsGateway();
        }
        public string UnAssignCousesManager()
        {
            int rowAffect = _unallocateRoomsGateway.UnAllocateRooms();
            return rowAffect > 0 ? "Save Successful" : "Save Failed";
        }
    }
}