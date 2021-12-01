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

        private readonly WorkingSchedule _workingSchedule;

        public IWorkingScheduleServiceTest()
        {
            _workingScheduleService = new Mock<IWorkingScheduleService>();

            // make a fake schedule for employee 1 as example
            _workingSchedule = new WorkingSchedule()
            {
                EmployeeId = 1,
                WeekDay = DayOfWeek.Monday,
                StartTime = new TimeSpan(15, 0, 0),
                EndTime = new TimeSpan(21, 0, 0)
            };

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
            // get the new working schedule form constructor

            // setup mock method pass in the schedule and return the schedul
            _workingScheduleService
                .Setup(service => service.Create(_workingSchedule))
                .Returns(_workingSchedule);

            // Act
            // Actually call the method
            var schedule = _workingScheduleService.Object.Create(_workingSchedule);

            // Assert
            // Test the method
            Assert.Equal(_workingSchedule, schedule);
        }

        /// <summary>
        /// Test the modify method for change the record for working schedule.
        /// parameter should be new Object working schedule record from front end
        /// Return the new object from repository
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_Modify_ParaWorkingSchedule_ReturnWorkingSchedule()
        {
            // Arrange 

            _workingScheduleService
                .Setup(service => service.Modify(_workingSchedule))
                .Returns(_workingSchedule);

            // Act
            var newSchedule = _workingScheduleService.Object.Modify(_workingSchedule);

            // Assert
            Assert.Equal(_workingSchedule, newSchedule);
        }


        /// <summary>
        /// Test the delete method should be call
        /// pass in the working schedule should be remove
        /// return the removed working schedule
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_Delete_ParaWorkingSchedule_ReturnWorkingSchedule()
        {
            _workingScheduleService
                .Setup(service => service.Delete(_workingSchedule))
                .Returns(_workingSchedule);

            var schedule = _workingScheduleService.Object.Delete(_workingSchedule);

            Assert.Equal(_workingSchedule, schedule);
        }

        [Fact]
        public void IWorkingScheduleService_GetAllWorkingSchedule_ReturnListOfWorkingSchedule()
        {
            
        }
        
        
        /// <summary>
        /// this test the use one employee id can get all the working schedule by one employee
        /// ********** NOTICE !!!!! *****
        /// also can filter the result by week day, date from start time (sorting on month etc.).
        ///
        /// But here we don't need to thinking how to implement it. just make the necessary method.
        /// we will implement it in service class 
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetWorkingScheduleByEmployeeID_ReturnListOfWorkingSchedule()
        {
            
        }


        #endregion
    }

    public interface IWorkingScheduleService
    {
        WorkingSchedule Create(WorkingSchedule workingSchedule);
        WorkingSchedule Modify(WorkingSchedule workingSchedule);
        WorkingSchedule Delete(WorkingSchedule workingSchedule);
    }
}