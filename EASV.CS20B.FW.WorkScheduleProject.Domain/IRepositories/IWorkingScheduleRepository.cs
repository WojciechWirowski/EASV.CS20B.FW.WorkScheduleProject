using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories
{
    public interface IWorkingScheduleRepository
    {
        WorkingSchedule Create(WorkingSchedule workingSchedule);
        WorkingSchedule Update(WorkingSchedule workingSchedule);
        WorkingSchedule Delete(WorkingSchedule workingSchedule);
        List<WorkingSchedule> ReadALl();
        WorkingSchedule ReadScheduleById(int id);
        List<WorkingSchedule> ReadScheduleByEmployeeId(int id);
        List<WorkingSchedule> ReadScheduleByDate(DateTime date);
    }
}