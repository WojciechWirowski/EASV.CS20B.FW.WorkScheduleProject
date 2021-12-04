using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories
{
    public interface IRecordRepository
    {
        public List<Record> GetAllRecords();

        public Record CreateRecord(Record record);

        public Record Modify(Record record);
        
        public Record Delete(int id);
        

        public Record GetById(int id);
    }
}