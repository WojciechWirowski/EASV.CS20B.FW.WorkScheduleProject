using System.Collections.Generic;
using System.Linq;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Database.Entities;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Repositories
{
    public class RecordsRepository
    {
        private readonly ScheduleApplicationContext _ctx;

        public RecordsRepository(ScheduleApplicationContext ctx)
        {
            _ctx = ctx;
        }
        public List<WorkingRecord> GetAllRecords()
        {
            var selectQuery = _ctx.Records.Select(recordEntity => new WorkingRecord()
            {
                Id = recordEntity.Id,
                EmployeeId = recordEntity.EmployeeId,
                CheckInTime = recordEntity.CheckInTime,
                CheckOutTime = recordEntity.CheckOutTime
            });
            return selectQuery.ToList();
        }

        public WorkingRecord CreateRecord(WorkingRecord record)
        {
            RecordEntity recordEntity = new RecordEntity
            {
                Id = record.Id,
                EmployeeId = record.EmployeeId,
                CheckInTime = record.CheckInTime,
                CheckOutTime = record.CheckOutTime
            };
            _ctx.Records.Add(recordEntity);
            _ctx.SaveChanges();
            return record;
        }

        public WorkingRecord Modify(WorkingRecord record)
        {
            RecordEntity recordEntity = new RecordEntity
            {
                Id = record.Id,
                EmployeeId = record.EmployeeId,
                CheckInTime = record.CheckInTime,
                CheckOutTime = record.CheckOutTime
            };
            _ctx.Records.Update(recordEntity);
            _ctx.SaveChanges();
            return record;
        }
        
        public WorkingRecord Delete(int id)
        {
            var entity = _ctx.Records.Remove(new RecordEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new WorkingRecord
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                CheckInTime = entity.CheckInTime,
                CheckOutTime = entity.CheckOutTime
            };
        }

        public WorkingRecord GetById(int id)
        {
            var selectQuery = _ctx.Records.Select(recordEntity => new WorkingRecord
            {
                Id = recordEntity.Id,
                EmployeeId = recordEntity.EmployeeId,
                CheckInTime = recordEntity.CheckInTime,
                CheckOutTime = recordEntity.CheckOutTime
            }).FirstOrDefault(r => r.Id == id);
            return selectQuery;
        }
    }
}