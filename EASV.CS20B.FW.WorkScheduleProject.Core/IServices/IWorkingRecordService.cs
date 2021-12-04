using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Core.IServices
{
    public interface IWorkingRecordService
    {
        WorkingRecord CheckIn(WorkingRecord workingRecord);
        WorkingRecord CheckOut(WorkingRecord workingRecord);
        WorkingRecord Modify(WorkingRecord workingRecord);
        WorkingRecord Delete(WorkingRecord workingRecord);
        List<WorkingRecord> GetAll();
        WorkingRecord GetById(int id);
        List<WorkingRecord> GetByEmployeeId(int employeeId);
        List<WorkingRecord> GetByDate(DateTime dateTime);
    }
}