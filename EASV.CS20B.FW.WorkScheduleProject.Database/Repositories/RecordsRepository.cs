using System;
using System.Collections.Generic;
using System.Linq;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Database.Entities;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Repositories
{
    public class RecordsRepository :IWorkingRecordRepository
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

        public WorkingRecord Create(WorkingRecord record)
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

        public List<WorkingRecord> GetByEmployeeId(int id)
        {
            var selectQuery = _ctx.Records.Select(recordEntity => new WorkingRecord
            {
                Id = recordEntity.Id,
                EmployeeId = recordEntity.EmployeeId,
                CheckInTime = recordEntity.CheckInTime,
                CheckOutTime = recordEntity.CheckOutTime
            }).Where(w => w.EmployeeId == id).ToList();
            return selectQuery;
        }

        public List<WorkingRecord> GetByDate(DateTime dateTime)
        {
            return _ctx.Records.Select(recordEntity => new WorkingRecord
            {
                Id = recordEntity.Id,
                CheckInTime = recordEntity.CheckInTime,
                CheckOutTime = recordEntity.CheckOutTime,
                EmployeeId = recordEntity.EmployeeId,
                WorkingHours = recordEntity.WorkingHours
            }).Where(r => r.CheckInTime.ToString("yy-MM-dd") == dateTime.ToString("yy-MM-dd")).ToList();
        }
    }
}