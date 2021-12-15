using System;
using System.Linq;
using EASV.CS20B.FW.WorkScheduleProject.Database.Entities;

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
            // _context.Database.EnsureDeleted();
            // _context.Database.EnsureCreated();
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
            _context.Users.Add(new UserEntity {Id = 1, Name = "George", Password = "1234", Role = "admin"});
            _context.Users.Add(new UserEntity {Id = 2, Name = "Bill", Password = "1234", Role = "user"});
            _context.Users.Add(new UserEntity {Id = 3, Name = "Charlie", Password = "1234", Role = "user"});
            _context.Users.Add(new UserEntity {Id = 4, Name = "Jackie", Password = "1234", Role = "user"});
            _context.Users.Add(new UserEntity {Id = 5, Name = "Andrew", Password = "1234", Role = "user"});
            _context.Users.Add(new UserEntity {Id = 6, Name = "Lilly", Password = "1234", Role = "user"});
        }

        public void SeedProduction()
        {
            _context.Database.EnsureCreated();
            var count = _context.Users.Count();
            if (count == 0)
            {
                _context.Users.Add(new UserEntity {Id = 1, Name = "George", Role = "admin"});
                _context.Users.Add(new UserEntity {Id = 2, Name = "Bill", Role = "user"});
                _context.Users.Add(new UserEntity {Id = 3, Name = "Charlie", Role = "user"});
                _context.Users.Add(new UserEntity {Id = 4, Name = "Jackie", Role = "user"});
                _context.Users.Add(new UserEntity {Id = 5, Name = "Andrew", Role = "user"});
                _context.Users.Add(new UserEntity {Id = 6, Name = "Lilly", Role = "user"});
                _context.SaveChanges();
            }
        }
    }
}