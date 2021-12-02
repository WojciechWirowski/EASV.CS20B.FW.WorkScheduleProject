using System;
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
            var dateTime = new DateTime();
            var workingSchedule = new WorkingSchedule()
            {
                WeekDay = 1
            };
            Assert.Equal(1, workingSchedule.WeekDay);
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveStartTime()
        {
            var hour = 15;
            var workingSchedule = new WorkingSchedule
            {
                StartTime = 15
            };
            Assert.Equal(15, workingSchedule.StartTime);
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveEndTime()
        {
            var hour = 15;
            var workingSchedule = new WorkingSchedule
            {
                EndTime = 15
            };
            Assert.Equal(15, workingSchedule.EndTime);
        }
    

        #endregion
    }

    public class WorkingSchedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int WeekDay { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        
    }
}