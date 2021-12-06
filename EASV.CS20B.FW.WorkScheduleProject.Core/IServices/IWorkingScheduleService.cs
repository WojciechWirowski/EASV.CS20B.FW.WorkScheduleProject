using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASC.CS20B.FW.WorkScheduleProject.Core.Test.IServicesTest
{
    public interface IWorkingScheduleService
    {
        /// <summary>
        /// Create a working schedule for one employee at one day.
        /// </summary>
        /// <param name="workingSchedule">
        /// Id: null.
        /// EmployeeId: which employee's working schedule.
        /// WeekDay: which weekDay employee should working.
        /// StartTime: need to set up the date and time.
        /// </param>
        /// <returns>the new schedule</returns>
        WorkingSchedule Create(WorkingSchedule workingSchedule);
        
        /// <summary>
        /// modify the schedule for one employee at one day
        /// </summary>
        /// <param name="workingSchedule"></param>
        /// <returns>the schedule be modify</returns>
        WorkingSchedule Modify(WorkingSchedule workingSchedule);
        /// <summary>
        /// remove one schedule
        /// </summary>
        /// <param name="workingSchedule"></param>
        /// <returns>the schedule be delete</returns>
        WorkingSchedule Remove(WorkingSchedule workingSchedule);
        
        /// <summary>
        /// get all working schedule for all employee and all the date
        /// </summary>
        /// <returns>the list of working schedule</returns>
        List<WorkingSchedule> GetAll();
        
        /// <summary>
        /// get one schedule by id 
        /// </summary>
        /// <param name="id">the unique key</param>
        /// <returns>the schedule of this id</returns>
        WorkingSchedule GetScheduleById(int id);
        
        /// <summary>
        /// get one schedule by employee id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        List<WorkingSchedule> GetScheduleByEmployeeId(int employeeId);
        
        /// <summary>
        /// get list of schedule by start date
        /// </summary>
        /// <param name="date">the date of the start time</param>
        /// <returns>all list of the schedule by the date</returns>
        List<WorkingSchedule> GetScheduleByDate(DateTime date);
        
        /// <summary>
        /// get list of schedule by month
        /// </summary>
        /// <param name="yearAndMonth">the months number</param>
        /// <returns>list of schedule in this month</returns>
        List<WorkingSchedule> GetScheduleByMonth(DateTime yearAndMonth);
    }
}