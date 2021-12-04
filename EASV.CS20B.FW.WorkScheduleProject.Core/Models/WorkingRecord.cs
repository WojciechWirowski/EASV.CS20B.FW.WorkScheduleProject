using System;

namespace EASV.CS20B.FW.WorkScheduleProject.Core.Models
{
    public class WorkingRecord
    {
        public int? Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public TimeSpan WorkingHours { get; set; }
        
        
    }
}