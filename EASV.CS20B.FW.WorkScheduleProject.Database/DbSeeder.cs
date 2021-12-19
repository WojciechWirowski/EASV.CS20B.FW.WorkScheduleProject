using System;
using System.Linq;
using System.Text;
using EASV.CS20B.FW.WorkScheduleProject.Database.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EASV.CS20B.FW.WorkScheduleProject.Database
{
    public class DbSeeder
    {
        private readonly ScheduleApplicationContext _context;

        public DbSeeder(ScheduleApplicationContext context)
        {
            _context = context;
        }

        public void SeedDevelopment()
        {
             _context.Database.EnsureDeleted();
             _context.Database.EnsureCreated();
            Users();
            WorkingSchedule();
        }

        public void WorkingSchedule()
        {
            _context.WorkingSchedules.Add(new WorkingScheduleEntity {Id = 1, EmployeeId = 1, StartTime = new DateTime(1,1,1,15,0,0), EndTime = new DateTime(1,1,1,20,0,0), WeekDay = DayOfWeek.Monday});
            _context.WorkingSchedules.Add(new WorkingScheduleEntity {Id = 2, EmployeeId = 1, StartTime = new DateTime(1,1,1,15,0,0), EndTime = new DateTime(1,1,1,20,0,0), WeekDay = DayOfWeek.Tuesday});
            _context.WorkingSchedules.Add(new WorkingScheduleEntity {Id = 3, EmployeeId = 1, StartTime = new DateTime(1,1,1,15,0,0), EndTime = new DateTime(1,1,1,20,0,0), WeekDay = DayOfWeek.Wednesday});
            _context.WorkingSchedules.Add(new WorkingScheduleEntity {Id = 4, EmployeeId = 1, StartTime = new DateTime(1,1,1,15,0,0), EndTime = new DateTime(1,1,1,20,0,0), WeekDay = DayOfWeek.Thursday});
            _context.WorkingSchedules.Add(new WorkingScheduleEntity {Id = 5, EmployeeId = 1, StartTime = new DateTime(1,1,1,15,0,0), EndTime = new DateTime(1,1,1,20,0,0), WeekDay = DayOfWeek.Friday});
            _context.WorkingSchedules.Add(new WorkingScheduleEntity {Id = 6, EmployeeId = 1, StartTime = new DateTime(1,1,1,15,0,0), EndTime = new DateTime(1,1,1,20,0,0), WeekDay = DayOfWeek.Saturday});
            _context.WorkingSchedules.Add(new WorkingScheduleEntity {Id = 7, EmployeeId = 1, StartTime = new DateTime(1,1,1,15,0,0), EndTime = new DateTime(1,1,1,20,0,0), WeekDay = DayOfWeek.Sunday});

        }

    
        public void Users()
        {
            var hash1 =
                "0x1DBFD06E68C3B863A4D7797D22351202B60D0D38FBA5F11680DC4C9CAEB30B57D1C6AF1741D5DF67585F857E1BB295DCBF01AD14601CD0ED36C7EB32565923AB;";
            var salt1 = "0x9C9DE5FF2C9F9E122451FC4611BD189CC75DE5D05096D4182793600BAD156FFAF906B00BF2594422A44CC9335A357C56FBC26A13422CA0521C6FC680C52A2480C58C57ED40317B5C8EFA5211CE9F3E316EE02E0A46B446A17081EEBF0D294017524847C4C3F97A19052083FE9F5DB9711F822FCE7F724184FF3CB135B3D876F3";
            _context.Users.Add(new() {Id = 2, Name = "admin", Password = "admin", Role = "admin", PasswordHash = Encoding.ASCII.GetBytes(hash1) , PasswordSalt = Encoding.ASCII.GetBytes(salt1)});
            var hash2 = "0x0C05C1C07C072EA0CB37A402C6EA583542561B69FFBC13EC6A49500970924BE48FB8B0ADFD63AC8841B77EA63102983720872FE0DD6EAA592B5C57A5B963EC25";
            var salt2 = "0x934C15AD64849E38EEA0DE7CCE29D415A0123E224C9E1EC44CEDE7078F23316745973601A1DAC77F43CF3123E8C5019A6CEE4C5392B8B07B672D116DC8607A5B600E7969EF6987D369BE44AF39CCA68446F65AB5FDF5A34B688CDC793DED6AD903FF87F4DD16C5D4BF83103B2C3DA9E3C14C6761E56AF16ADC961346A58188B1";
            _context.Users.Add(new() {Id = 1, Name = "user", Password = "user", Role = "user", PasswordHash = Encoding.ASCII.GetBytes(hash2) , PasswordSalt = Encoding.ASCII.GetBytes(salt2)});
        }

        public void SeedProduction()
        {
            _context.Database.EnsureCreated();
            var count = _context.Users.Count();
            if (count == 0)
            {
                var hash1 =
                    "0x1DBFD06E68C3B863A4D7797D22351202B60D0D38FBA5F11680DC4C9CAEB30B57D1C6AF1741D5DF67585F857E1BB295DCBF01AD14601CD0ED36C7EB32565923AB;";
                var salt1 = "0x9C9DE5FF2C9F9E122451FC4611BD189CC75DE5D05096D4182793600BAD156FFAF906B00BF2594422A44CC9335A357C56FBC26A13422CA0521C6FC680C52A2480C58C57ED40317B5C8EFA5211CE9F3E316EE02E0A46B446A17081EEBF0D294017524847C4C3F97A19052083FE9F5DB9711F822FCE7F724184FF3CB135B3D876F3";
                _context.Users.Add(new() {Id = 2, Name = "admin", Password = "admin", Role = "admin", PasswordHash = Encoding.ASCII.GetBytes(hash1) , PasswordSalt = Encoding.ASCII.GetBytes(salt1)});
                var hash2 = "0x0C05C1C07C072EA0CB37A402C6EA583542561B69FFBC13EC6A49500970924BE48FB8B0ADFD63AC8841B77EA63102983720872FE0DD6EAA592B5C57A5B963EC25";
                var salt2 = "0x934C15AD64849E38EEA0DE7CCE29D415A0123E224C9E1EC44CEDE7078F23316745973601A1DAC77F43CF3123E8C5019A6CEE4C5392B8B07B672D116DC8607A5B600E7969EF6987D369BE44AF39CCA68446F65AB5FDF5A34B688CDC793DED6AD903FF87F4DD16C5D4BF83103B2C3DA9E3C14C6761E56AF16ADC961346A58188B1";
                _context.Users.Add(new() {Id = 1, Name = "user", Password = "user", Role = "user", PasswordHash = Encoding.ASCII.GetBytes(hash2) , PasswordSalt = Encoding.ASCII.GetBytes(salt2)});
                _context.SaveChanges();
            }
        }
    }
}