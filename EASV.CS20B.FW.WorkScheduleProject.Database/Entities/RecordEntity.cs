using System;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Entities
{
    public class RecordEntity
    {
        public int? Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public long WorkingHours { get; set; }
    }
}