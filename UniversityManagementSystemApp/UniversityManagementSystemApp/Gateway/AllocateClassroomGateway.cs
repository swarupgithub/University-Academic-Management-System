using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.WebPages;
using Org.BouncyCastle.Asn1.Cms;
using UniversityManagementSystemApp.Models;
using UniversityManagementSystemApp.Models.ViewModel;

namespace UniversityManagementSystemApp.Gateway
{
    public class AllocateClassroomGateway
    {
        private string conString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;

        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _query;

        public AllocateClassroomGateway()
        {
            _connection = new SqlConnection(conString);
        }


        public int SaveAllocateClassroomInfo(AllocateClassroom allocateClassroom)
        {
            _query = "INSERT INTO AllocateClassroom(CourseId,RoomId,DayId,AllocateFromDate,AllocateToDate) values(@CourseId, @RoomId,@DayId,@AllocateFromDate,@AllocateToDate)";


            _command = new SqlCommand(_query, _connection);


            TimeSpan time = new TimeSpan();
            time.ToString();
            //cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            //cmd.Parameters.AddWithValue("@Time", Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));

            _command.Parameters.AddWithValue("@CourseId", allocateClassroom.CourseId);
            _command.Parameters.AddWithValue("@RoomId", allocateClassroom.RoomId);
            _command.Parameters.AddWithValue("@DayId", allocateClassroom.DayId);
            _command.Parameters.AddWithValue("@AllocateFromDate", allocateClassroom.AllocateFromDate.ToString("HH:mm:ss"));
            _command.Parameters.AddWithValue("@AllocateToDate", Convert.ToDateTime(allocateClassroom.AllocateToDate.ToString("HH:mm:ss")));


            _connection.Open();

            int rowAffect = _command.ExecuteNonQuery();

            _connection.Close();

            return rowAffect;
        }

        public List<ClassRoomScheduleViewModel> GetAllSchdules()
        {
            string query = "SELECT * FROM ClassRoomScheduleViewModel";

            _command = new SqlCommand(query, _connection);

            _connection.Open();

            _reader = _command.ExecuteReader();

            List<ClassRoomScheduleViewModel> classRoomScheduleViewModels = new List<ClassRoomScheduleViewModel>();

            while (_reader.Read())
            {
                ClassRoomScheduleViewModel classRoomSchedule = new ClassRoomScheduleViewModel();

                classRoomSchedule.CourseCode = _reader["CourseCode"].ToString();
                classRoomSchedule.CourseName = _reader["CourseName"].ToString();
                classRoomSchedule.RoomNo = _reader["RoomNo"].ToString();
                classRoomSchedule.DayName = _reader["DayName"].ToString();
                classRoomSchedule.AllocateFromDate = _reader["AllocateFromDate"].ToString();
                classRoomSchedule.AllocateToDate = _reader["AllocateToDate"].ToString();

                if (classRoomSchedule.RoomNo.IsEmpty())
                {
                    classRoomSchedule.RoomNo = "Not scheduled Yet";
                }

                classRoomSchedule.DeptId = Convert.ToInt32(_reader["depId"]);

                classRoomScheduleViewModels.Add(classRoomSchedule);
            }

            _reader.Close();

            _connection.Close();


            return classRoomScheduleViewModels;
        }

        public bool IsExistTime(AllocateClassroom allocateClassroom)
        {
            _query = "SELECT * FROM AllocateClassroom WHERE DayId = @DayId AND RoomId = @RoomId AND @AllocateFromDate < AllocateToDate AND AllocateFromDate < @AllocateToDate";

            _command = new SqlCommand(_query, _connection);

            _command.Parameters.AddWithValue("@DayId", allocateClassroom.DayId);
            _command.Parameters.AddWithValue("@RoomId", allocateClassroom.RoomId);
            _command.Parameters.AddWithValue("@AllocateFromDate", allocateClassroom.AllocateFromDate.ToString("HH:mm:ss"));
            _command.Parameters.AddWithValue("@AllocateToDate", allocateClassroom.AllocateToDate.ToString("HH:mm:ss"));

            _connection.Open();

            _reader = _command.ExecuteReader();

            bool isExist = _reader.HasRows;

            _reader.Close();


            _connection.Close();

            return isExist;
        }
    }
}