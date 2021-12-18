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
        //constructor creates the database
        public RecordsRepository(ScheduleApplicationContext ctx)
        {
            _ctx = ctx;
        }
        //gets all records
        public List<WorkingRecord> GetAllRecords()
        {
            var selectQuery = _ctx.Records.Select(recordEntity => new WorkingRecord()
            {
                Id = recordEntity.Id,
                EmployeeId = recordEntity.EmployeeId,
                CheckInTime = recordEntity.CheckInTime,
                CheckOutTime = recordEntity.CheckOutTime,
                WorkingHours = new TimeSpan(recordEntity.WorkingHours)
            });
            return selectQuery.ToList();
        }
        //creates working record
        public WorkingRecord Create(WorkingRecord record)
        {
            RecordEntity recordEntity = new RecordEntity
            {
                EmployeeId = record.EmployeeId,
                CheckInTime = record.CheckInTime,
            };
            _ctx.Records.Add(recordEntity);
            _ctx.SaveChanges();
            return record;
        }
        //updates working record
        public WorkingRecord Modify(WorkingRecord record)
        {
            RecordEntity recordEntity = new RecordEntity
            {
                Id = record.Id,
                EmployeeId = record.EmployeeId,
                CheckInTime = record.CheckInTime,
                CheckOutTime = record.CheckOutTime,
                WorkingHours = record.WorkingHours.Ticks
            };
            _ctx.Records.Update(recordEntity);
            _ctx.SaveChanges();
            return record;
        }
        //deletes working record by id
        public WorkingRecord Delete(int? id)
        {
            var entity = _ctx.Records.Remove(new RecordEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new WorkingRecord
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                CheckInTime = entity.CheckInTime,
                CheckOutTime = entity.CheckOutTime,
                WorkingHours = new TimeSpan(entity.WorkingHours)
            };
        }
        //gets working record by id
        public WorkingRecord GetById(int? id)
        {
            var selectQuery = _ctx.Records.Select(recordEntity => new WorkingRecord
            {
                Id = recordEntity.Id,
                EmployeeId = recordEntity.EmployeeId,
                CheckInTime = recordEntity.CheckInTime,
                CheckOutTime = recordEntity.CheckOutTime,
                WorkingHours = new TimeSpan(recordEntity.WorkingHours)
            }).FirstOrDefault(r => r.Id == id);
            return selectQuery;
        }
        //gets working record by employee id
        public List<WorkingRecord> GetByEmployeeId(int id)
        {
            var selectQuery = _ctx.Records.Select(recordEntity => new WorkingRecord
            {
                Id = recordEntity.Id,
                EmployeeId = recordEntity.EmployeeId,
                CheckInTime = recordEntity.CheckInTime,
                CheckOutTime = recordEntity.CheckOutTime,
                WorkingHours = new TimeSpan(recordEntity.WorkingHours)
            }).Where(w => w.EmployeeId == id).ToList();
            return selectQuery;
        }
        //Gets working record by date
        public List<WorkingRecord> GetByDate(DateTime dateTime)
        {
            return _ctx.Records.Select(recordEntity => new WorkingRecord
            {
                Id = recordEntity.Id,
                CheckInTime = recordEntity.CheckInTime,
                CheckOutTime = recordEntity.CheckOutTime,
                EmployeeId = recordEntity.EmployeeId,
                WorkingHours = new TimeSpan(recordEntity.WorkingHours)
            }).Where(r => r.CheckInTime.Date == dateTime.Date).ToList();
        }

        public WorkingRecord GetByEmployeeIdAndDate(DateTime workingRecordCheckInTime, int employeeId)
        {
            return _ctx.Records
                .Select(recordEntity => new WorkingRecord
                {
                    Id = recordEntity.Id,
                    CheckInTime = recordEntity.CheckInTime,
                    CheckOutTime = recordEntity.CheckOutTime,
                    EmployeeId = recordEntity.EmployeeId,
                    WorkingHours = new TimeSpan(recordEntity.WorkingHours)
                })
                .OrderBy(order => order.Id)
                .Last(r
                    => (r.EmployeeId == employeeId) 
                       && (r.CheckInTime.Date.Equals(workingRecordCheckInTime.Date)));
        }
    }
}