using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories
{
    public interface IWorkingScheduleRepository
    {
        WorkingSchedule Create(WorkingSchedule workingSchedule);
        WorkingSchedule GetWorkingScheduleByEmployeeIdAndDayOfWeek(WorkingSchedule workingSchedule);
        WorkingSchedule Modify(WorkingSchedule workingSchedule);
        WorkingSchedule Delete(WorkingSchedule workingSchedule);
        List<WorkingSchedule> GetAll();
        List<WorkingSchedule> GetWorkingScheduleByEmployeeId(int employeeId);
        List<WorkingSchedule> GetScheduleByDate(DateTime date);
        WorkingSchedule GetScheduleById(WorkingSchedule workingSchedule);
    }
}