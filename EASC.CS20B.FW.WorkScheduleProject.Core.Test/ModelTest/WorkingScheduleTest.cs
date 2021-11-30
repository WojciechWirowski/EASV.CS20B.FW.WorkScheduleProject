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
                
            }
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveStartTime()
        {
            
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveEndTime()
        {
            
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveWeekDay()
        {
            
        }

        #endregion
    }

    public class WorkingSchedule
    {
        public int Id { get; set; }
    }
}