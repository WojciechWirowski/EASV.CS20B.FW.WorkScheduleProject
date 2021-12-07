using System;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
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
        public void WorkingSchedule_ShouldHaveDay()
        {
            var workingSchedule = new WorkingSchedule()
            {
                WeekDay = DayOfWeek.Monday
            };
            Assert.Equal(DayOfWeek.Monday, workingSchedule.WeekDay);
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveStartTime()
        {
            var dateTime = new DateTime(2021,12,1,15,0,0);
            var workingSchedule = new WorkingSchedule
            {
                StartTime = dateTime
            };
            Assert.Equal(dateTime, workingSchedule.StartTime);
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveEndTime()
        {
            var dateTime = new DateTime(2021,12,1,21,0,0);
            var workingSchedule = new WorkingSchedule
            {
                EndTime = dateTime
            };
            Assert.Equal(dateTime, workingSchedule.EndTime);
        }
    

        #endregion
    }
}