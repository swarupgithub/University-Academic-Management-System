using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Manager
{
    public class AllocateClassroomManager
    {
        private AllocateClassroomGateway _allocateClassroomGateway;

        public AllocateClassroomManager()
        {
            _allocateClassroomGateway = new AllocateClassroomGateway();
        }
        public string AllocateClassroominfoSave(AllocateClassroom allocateClassroom)
        {
            bool checkTimeExist = _allocateClassroomGateway.IsExistTime(allocateClassroom);

            if (checkTimeExist == true)
            {
                return ("Already class is assaigned in this room in that time");
            }
            int rowAffect = _allocateClassroomGateway.SaveAllocateClassroomInfo(allocateClassroom);
            return rowAffect > 0 ? "Save Successful" : "Save Failed";
        }

        public List<ClassRoomScheduleViewModel> GetAllSchedulessManager()
        {
            return _allocateClassroomGateway.GetAllSchdules();
        }
    }
}