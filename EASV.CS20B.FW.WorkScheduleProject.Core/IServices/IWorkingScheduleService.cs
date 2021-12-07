using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASC.CS20B.FW.WorkScheduleProject.Core.Test.IServicesTest
{
    public interface IWorkingScheduleService
    {
        WorkingSchedule Create(WorkingSchedule workingSchedule);
        WorkingSchedule Modify(WorkingSchedule workingSchedule);
        WorkingSchedule Delete(int workingSchedule);
        List<WorkingSchedule> GetAll();
        List<WorkingSchedule> GetScheduleByEmployeeId(int employeeId);
        List<WorkingSchedule> GetScheduleByDate(DateTime date);
        List<WorkingSchedule> GetScheduleByMonth(DateTime addMonths);
    }
}