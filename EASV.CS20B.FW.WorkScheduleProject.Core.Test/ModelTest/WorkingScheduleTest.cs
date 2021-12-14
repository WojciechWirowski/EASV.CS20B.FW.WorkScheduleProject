using System;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using Xunit;

namespace EASV.CS20B.FW.WorkScheduleProject.ModelTest
{
    public class WorkingScheduleTest
    {
        #region Initialize
        // tests if there is a working schedule
        [Fact]
        public void WorkingSchedule_CanBeInitialize()
        {
            var workingSchedule = new WorkingSchedule();
            Assert.NotNull(workingSchedule);
        }
        //tests if working schedule should have id
        [Fact]
        public void WorkingSchedule_ShouldHaveId()
        {
            var workingSchedule = new WorkingSchedule()
            {
                Id = 1
            };
            Assert.Equal(1,workingSchedule.Id);

        }
        //tests if working schedule should have day
        [Fact]
        public void WorkingSchedule_ShouldHaveDay()
        {
            var workingSchedule = new WorkingSchedule()
            {
                WeekDay = DayOfWeek.Monday
            };
            Assert.Equal(DayOfWeek.Monday, workingSchedule.WeekDay);
        }
        //tests if working schedule should have start time
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
        //tests if working schedule should have end time
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