using System;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using Xunit;
using Xunit.Abstractions;

namespace EASC.CS20B.FW.WorkScheduleProject.ModelTest
{
    /// <summary>
    /// This class is making for Test Driven Development.
    /// Testing for Core/Models/WorkingSchedule.
    /// </summary>
    public class WorkingScheduleTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly WorkingSchedule _workingSchedule;

        public WorkingScheduleTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _workingSchedule = new WorkingSchedule()
            {
                Id = 1,
                EmployeeId = 1,
                WeekDay = DayOfWeek.Monday,
                StartTime = new TimeSpan(15, 0, 0),
                EndTime = new TimeSpan(20, 0, 0)
            };
        }

        
        #region Initial
        
        /// <summary>
        /// Test WorkingSchedule can be initialized
        /// if the object is not null.
        /// then that means we instantiation the object.
        /// </summary>
        [Fact]
        public void WorkingSchedule_CanBeInitialized()
        {
            var workingSchedule = new WorkingSchedule();
            Assert.NotNull(workingSchedule);
        }

        
        /// <summary>
        /// Test the object workingSchedule have property Id.
        /// And can be assigned a value as int.
        /// </summary>
        [Fact]
        public void WorkingSchedule_ShouldHaveId()
        {
            var workingSchedule = new WorkingSchedule()
            {
                Id = 1
            };
            Assert.Equal(1,workingSchedule.Id);

        }

        /// <summary>
        /// Test about have the employee id property.
        /// and can be assigned a value as int.
        /// </summary>
        [Fact]
        public void WorkingSchedule_ShouldHaveEmployeesID()
        {
            var workingSchedule = new WorkingSchedule()
            {
                EmployeeId = 1
            };
            Assert.Equal(1,workingSchedule.EmployeeId);
        }
        
        
        /// <summary>
        /// Test about the working schedule should have property as WeekDay type.
        /// and can assigned as a weekday
        /// </summary>
        [Fact]
        public void WorkingSchedule_ShouldHaveWeekDay()
        {
            var dateTime = new DateTime();
            var workingSchedule = new WorkingSchedule()
            {
                WeekDay = DayOfWeek.Monday
            };
            Assert.Equal(DayOfWeek.Monday,workingSchedule.WeekDay);
        }
        
        /// <summary>
        /// Test about the start time and can assigned as a double
        /// Here we use the system package DateTime.
        /// And then insert the hour number. and minute number, return the Time Span.
        /// 
        /// </summary>
        
        [Fact]
        public void WorkingSchedule_ShouldHaveStartTime()
        {
            var timeOfDay = new DateTime().AddHours(15).AddMinutes(30).TimeOfDay;
            var workingSchedule = new WorkingSchedule()
            {
                StartTime = timeOfDay
            };
            // here add a test out put helper to measure the right input time is the right out put tiem
            _testOutputHelper.WriteLine(timeOfDay.ToString());
            Assert.Equal(timeOfDay,workingSchedule.StartTime);
        }
        
        /// <summary>
        /// Same as before. Just this is the finish time.
        /// </summary>
        [Fact]
        public void WorkingSchedule_ShouldHaveEndTime()
        {
            var timeOfDay = new DateTime().AddHours(20).AddMinutes(30).TimeOfDay;
            var workingSchedule = new WorkingSchedule()
            {
                EndTime = timeOfDay
            };
            Assert.Equal(timeOfDay,workingSchedule.EndTime);
        }
        
        #endregion
        
        #region Update

        /// <summary>
        /// This area test about all the property in the working schedule can be update a new value.
        /// </summary>
        [Fact]
        public void WorkingSchedule_Id_CanBeUpdate()
        {
            _workingSchedule.Id = 2;
            Assert.Equal(2,_workingSchedule.Id);
        }

        
        [Fact]
        public void WorkingSchedule_EmployeeId_CanBeUpdate()
        {
            _workingSchedule.EmployeeId = 2;
            Assert.Equal(2,_workingSchedule.EmployeeId);
        }
        
        [Fact]
        public void WorkingSchedule_WeekDay_CanBeUpdate()
        {
            _workingSchedule.WeekDay = DayOfWeek.Friday;
            Assert.Equal(DayOfWeek.Friday,_workingSchedule.WeekDay);
        }
        
        [Fact]
        public void WorkingSchedule_StartTime_CanBeUpdate()
        {
            _workingSchedule.StartTime = TimeSpan.MinValue;
            Assert.Equal(TimeSpan.MinValue,_workingSchedule.StartTime);
        }
        
        [Fact]
        public void WorkingSchedule_EndTime_CanBeUpdate()
        {
            _workingSchedule.EndTime = TimeSpan.MaxValue;
            Assert.Equal(TimeSpan.MaxValue,_workingSchedule.EndTime);
        }
        
        #endregion
    }
}
