using System;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using Moq;
using Xunit;

namespace EASC.CS20B.FW.WorkScheduleProject.Core.Test.IServicesTest
{
    public class IWorkingScheduleServiceTest
    {
        
        /// <summary>
        /// make a Mock interface to test the method should be call
        /// </summary>
        private readonly Mock<IWorkingScheduleService> _workingScheduleService;

        public IWorkingScheduleServiceTest()
        {
            _workingScheduleService = new Mock<IWorkingScheduleService>();
        }

        
        /// <summary>
        /// Test the object of Interface is available to be initialized
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_IsAvailable()
        {
            var mock = new Mock<IWorkingScheduleService>();
            Assert.NotNull(mock.Object);
        }

        #region MethodTest

        /// <summary>
        /// Test the create method pass in the working schedule where come from front end
        /// and return a working schedule object from repository
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_Create_ParaWorkingSchedule_ReturnWorkingSchedule()
        {
            // Arrange
            // make a fake schedule for employee 1
            var workingSchedule = new WorkingSchedule()
            {
                EmployeeId = 1,
                WeekDay = DayOfWeek.Monday,
                StartTime = new TimeSpan(15,0,0),
                EndTime = new TimeSpan(21,0,0)
            };
            
            // setup mock method pass in the schedule and return the schedul
            _workingScheduleService
                .Setup(service => service.Create(workingSchedule))
                .Returns(workingSchedule);
            
            // Act
            // Actually call the method
            var schedule = _workingScheduleService.Object.Create(workingSchedule);
            
            // Assert
            // Test the method
            Assert.Equal(workingSchedule,schedule);
        }

        
        
        #endregion
    }

    public interface IWorkingScheduleService
    {
        WorkingSchedule Create(WorkingSchedule workingSchedule);
    }
}