using System;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Models
{
    public class WorkingScheduleDto
    {
       
        public int? Id { get; set; }
        
        public int EmployeeId { get; set; }
        
        public DayOfWeek WeekDay { get; set; }
        
        public DateTime StartTime { get; set; }
      
        public DateTime EndTime { get; set; }
    }

    public enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}