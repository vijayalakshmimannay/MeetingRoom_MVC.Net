using MeetingRoom1.Models;
using System;
using System.Collections.Generic;

namespace MeetingRoom1.Repository
{
    public interface IEmployeeRL 
    {
        public EmployeeModel AddEmployee(EmployeeModel employee);
        public string UserLogin(LoginModel loginModel);
        public IEnumerable<MeetingRoomModel> GetAllMeetingRooms();
        public RequestModel AddRequest(RequestModel employee, int UserId, int MeetingRoom_Id);



    }
}
