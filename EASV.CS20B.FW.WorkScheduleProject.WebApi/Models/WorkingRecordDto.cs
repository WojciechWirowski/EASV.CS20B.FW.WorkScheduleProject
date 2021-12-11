using System;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Models
{
    public class WorkingRecordDto
    {
        public int? Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public TimeSpan WorkingHours { get; set; }
    }
}