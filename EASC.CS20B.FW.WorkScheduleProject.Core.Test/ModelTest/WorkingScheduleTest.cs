using System;
using System.Collections.Generic;
using Xunit;

namespace EASC.CS20B.FW.WorkScheduleProject.ModelTest
{
    public class WorkingScheduleTest
    {
        #region Initialize

        [Fact]
        public void WorkingSchedule_CanBeInitialize()
        {
            var workingSchedule = new WorkingSchedule();
            Assert.NotNull(workingSchedule);
        }

        [Fact]
        public void WorkingSchedule_ShouldHaveId()
        {
            var workingSchedule = new WorkingSchedule()
            {
                Id = 1
            };
            Assert.Equal(1,workingSchedule.Id);

        }

        [Fact]
        public void WorkingSchedule_ShouldHaveEmployeesID()
        {
            var workingSchedule = new WorkingSchedule()
            {
                EmployeeId = 1
            };
            Assert.Equal(1,workingSchedule.EmployeeId);
        }
        
        
        [Fact]
        public void WorkingSchedule_ShouldHaveWeekDay()
        {
            var workingSchedule = new WorkingSchedule()
            {
                WeekDay = WeekDay.Monday
            };
            Assert.Equal(WeekDay.Monday,workingSchedule.WeekDay);
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveStartTime()
        {
            var workingSchedule = new WorkingSchedule()
            {
                StartTime = 17
            };
            Assert.Equal(17,workingSchedule.StartTime);
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveEndTime()
        {
            var workingSchedule = new WorkingSchedule()
            {
                EndTime = 21
            };
            Assert.Equal(21,workingSchedule.EndTime);
        }
        

        #endregion
    }

    public enum WeekDay
    {
        Monday,
        TuesDay,
        WednesDay
    }


    public class WorkingSchedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public WeekDay WeekDay { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}