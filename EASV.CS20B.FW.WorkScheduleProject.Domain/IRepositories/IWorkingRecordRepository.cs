using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories
{
    public interface IWorkingRecordRepository
    {
        WorkingRecord Create(WorkingRecord workingRecord);
        public WorkingRecord Update(WorkingRecord record);
        public WorkingRecord Delete(int id);
        public List<WorkingRecord> ReadAll();
        public WorkingRecord ReadById(int id);
        public WorkingRecord ReadByEmployeeId(int id);
        public WorkingRecord ReadByDate(DateTime dateTime);
    }
}