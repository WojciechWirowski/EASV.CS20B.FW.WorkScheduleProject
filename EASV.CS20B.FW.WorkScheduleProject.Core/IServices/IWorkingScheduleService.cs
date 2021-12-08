using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Core.IServices
{
    public interface IWorkingScheduleService
    {
        WorkingSchedule Create(WorkingSchedule workingSchedule);
        WorkingSchedule Modify(WorkingSchedule workingSchedule);
        WorkingSchedule Delete(WorkingSchedule workingSchedule);
        List<WorkingSchedule> GetAll();
        List<WorkingSchedule> GetScheduleByEmployeeId(int employeeId);
        List<WorkingSchedule> GetScheduleByDate(DateTime date);
        List<WorkingSchedule> GetScheduleByMonth(DateTime addMonths);
    }
}