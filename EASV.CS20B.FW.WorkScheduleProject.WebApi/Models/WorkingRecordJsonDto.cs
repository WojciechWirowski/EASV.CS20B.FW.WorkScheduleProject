using System;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Models
{
    public class WorkingRecordJsonDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
    }
}