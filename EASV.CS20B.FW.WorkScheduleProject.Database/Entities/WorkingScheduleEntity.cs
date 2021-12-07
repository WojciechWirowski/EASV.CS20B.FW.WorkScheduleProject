using System;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Entities
{
    public class WorkingScheduleEntity
    {
        public int? Id { get; set; }
        public int EmployeeId { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
    }
}