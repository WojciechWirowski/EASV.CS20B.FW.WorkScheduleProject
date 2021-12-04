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
        public List<Record> GetAllRecords()
        {
            var selectQuery = _ctx.Records.Select(recordEntity => new Record()
            {
                Id = recordEntity.Id,
               Date = recordEntity.Date,
               TimeIn = recordEntity.TimeIn,
               TimeOut = recordEntity.TimeOut,
               UserId = recordEntity.UserId
            });
            return selectQuery.ToList();
        }

        public Record CreateRecord(Record record)
        {
            RecordEntity recordEntity = new RecordEntity
            {
                Id = record.Id,
                Date = record.Date,
                TimeIn = record.TimeIn,
                TimeOut = record.TimeOut,
                UserId = record.UserId
            };
            _ctx.Records.Add(recordEntity);
            _ctx.SaveChanges();
            return record;
        }

        public Record Modify(Record record)
        {
            RecordEntity recordEntity = new RecordEntity
            {
                Id = record.Id,
                Date = record.Date,
                TimeIn = record.TimeIn,
                TimeOut = record.TimeOut,
                UserId = record.UserId
            };
            _ctx.Records.Update(recordEntity);
            _ctx.SaveChanges();
            return record;
        }
        
        public Record Delete(int id)
        {
            var entity = _ctx.Records.Remove(new RecordEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new Record
            {
                Id = entity.Id,
                Date = entity.Date,
                TimeIn = entity.TimeIn,
                TimeOut = entity.TimeOut,
                UserId = entity.UserId
            };
        }

        public Record GetById(int id)
        {
            var selectQuery = _ctx.Records.Select(recordEntity => new Record
            {
                Id = recordEntity.Id,
                Date = recordEntity.Date,
                TimeIn = recordEntity.TimeIn,
                TimeOut = recordEntity.TimeOut,
                UserId = recordEntity.UserId
            }).FirstOrDefault(r => r.Id == id);
            return selectQuery;
        }
    }
}