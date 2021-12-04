using System.Collections.Generic;
using System.IO;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _repo;

        public RecordService(IRecordRepository _recordRepository)
        {
            _repo = _recordRepository ?? throw new InvalidDataException("The Repository can not be null");
        }

        public List<Record> GetAllRecords()
        {
           return _repo.GetAllRecords();
        }

        public Record CreateRecord(Record record)
        {
            return _repo.CreateRecord(record);
        }

        public Record Modify(Record record)
        {
            return _repo.Modify(record);
        }

        public Record Delete(int id)
        {
            return _repo.Delete(id);
        }

        public Record GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}