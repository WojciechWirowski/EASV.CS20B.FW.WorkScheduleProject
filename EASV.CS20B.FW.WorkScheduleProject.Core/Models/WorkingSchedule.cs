using System;

namespace EASV.CS20B.FW.WorkScheduleProject.Core.Models
{
    public class WorkingSchedule
    {
        /// <summary>
        /// The ID property is serials number for each record of working schedule
        /// </summary>
        public int? Id { get; set; }
        
        /// <summary>
        /// The EmployeeId is personal unique number of each employee
        /// </summary>
        public int EmployeeId { get; set; }
        
        /// <summary>
        /// The WeekDay type is an enum class contain all the 7 days in a week
        /// This Enum class is be contain in the system package.
        /// </summary>
        public DayOfWeek WeekDay { get; set; }
        
        
        /// <summary>
        /// The start time is one specific employee in one specific day show be start work at which time
        /// </summary>
        public DateTime StartTime { get; set; }
       
        /// <summary>
        /// The end time is one specific employee in one specific day show be finish work at which time
        /// </summary>
        public TimeSpan EndTime { get; set; }

    }
}