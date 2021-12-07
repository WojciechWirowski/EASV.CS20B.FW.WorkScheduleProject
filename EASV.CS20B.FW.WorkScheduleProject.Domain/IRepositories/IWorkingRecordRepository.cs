using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories
{
    public interface IWorkingRecordRepository
    {
        WorkingRecord Create(WorkingRecord workingRecord);
        
        public List<WorkingRecord> GetAllRecords();

        public WorkingRecord Modify(WorkingRecord record);
        
        public WorkingRecord Delete(int? id);
        

        public WorkingRecord GetById(int? id);

        public List<WorkingRecord> GetByEmployeeId(int id);
        List<WorkingRecord> GetByDate(DateTime dateTime);
    }
}