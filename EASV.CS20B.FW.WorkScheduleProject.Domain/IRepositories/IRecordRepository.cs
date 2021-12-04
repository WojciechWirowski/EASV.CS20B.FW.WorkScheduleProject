using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories
{
    public interface IRecordRepository
    {
        public List<WorkingRecord> GetAllRecords();

        public WorkingRecord CreateRecord(WorkingRecord record);

        public WorkingRecord Modify(WorkingRecord record);
        
        public WorkingRecord Delete(int id);
        

        public WorkingRecord GetById(int id);

        public WorkingRecord GetByEmplyeeId(int id);
    }
}