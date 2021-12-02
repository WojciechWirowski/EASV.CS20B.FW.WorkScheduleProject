using System;

namespace EASV.CS20B.FW.WorkScheduleProject.Core.Models
{
    public class WorkingRecord
    {
        public int? Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public TimeSpan WorkingHours { get; set; }
        
    }
}