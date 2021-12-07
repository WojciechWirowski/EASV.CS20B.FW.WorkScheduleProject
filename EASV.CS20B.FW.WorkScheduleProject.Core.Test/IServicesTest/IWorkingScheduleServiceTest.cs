using System;
using System.Collections.Generic;
using EASC.CS20B.FW.WorkScheduleProject.Core.Test.IServicesTest;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using Moq;
using Xunit;

namespace EASV.CS20B.FW.WorkScheduleProject.IServicesTest
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
                StartTime = new DateTime().AddHours(15),
                EndTime = new DateTime(21, 0, 0)
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

            // setup mock method pass in the schedule and return the schedule
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
                .Setup(service => service.Delete(1))
                .Returns(_workingSchedule);

            var schedule = _workingScheduleService.Object.Delete(1);

            Assert.Equal(_workingSchedule, schedule);
        }

        /// <summary>
        /// this is test for GetAll method return list 
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetAllWorkingSchedule_ReturnListOfWorkingSchedule()
        {
            var workingSchedules = new List<WorkingSchedule>();
            _workingScheduleService
                .Setup(service => service.GetAll())
                .Returns(workingSchedules);

            var schedules = _workingScheduleService.Object.GetAll();    
            
            Assert.Equal(schedules,workingSchedules);
        }
        
        
        /// <summary>
        /// this test the use one employee id can get all the working schedule by one employee
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetWorkingScheduleByEmployeeID_ReturnListOfWorkingSchedule()
        {
            var workingSchedules = new List<WorkingSchedule>();
            var employeeId = 1;
            _workingScheduleService
                .Setup(service => service.GetScheduleByEmployeeId(employeeId))
                .Returns(workingSchedules);
            var scheduleByEmployeeId = _workingScheduleService.Object.GetScheduleByEmployeeId(employeeId);
            Assert.Equal(scheduleByEmployeeId,workingSchedules);
        }
        
        /// <summary>
        /// Test get the working schedule by date,
        /// parameter is the date.
        /// return list of schedule on all the employee who working at that date
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetWorkingScheduleByDate_ReturnListOfWorkingSchedule()
        {
            var workingSchedules = new List<WorkingSchedule>();
            var date = new DateTime(2021,12,1);
            _workingScheduleService
                .Setup(service => service.GetScheduleByDate(date))
                .Returns(workingSchedules);
            var scheduleByDate = _workingScheduleService.Object.GetScheduleByDate(date);
            Assert.Equal(scheduleByDate,workingSchedules);
        }

        /// <summary>
        /// Test the service search working schedule by month.
        /// parameter is month number
        /// return all employee all the month working schedule
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetWorkingScheduleByMonth_ReturnListOfWorkingSchedule()
        {
            var workingSchedules = new List<WorkingSchedule>();
            var addMonths = new DateTime().AddMonths(12);
            _workingScheduleService
                .Setup(service => service.GetScheduleByMonth(addMonths))
                .Returns(workingSchedules);
            var scheduleByMonth = _workingScheduleService.Object.GetScheduleByMonth(addMonths);
            Assert.Equal(scheduleByMonth,workingSchedules);
        }
        
        // ********** NOTICE !!!!! *****
        // We can make more method for this service later if we need....
        // So far i think it is enough....
        // --------------- old note ------------------
        // also can filter the result by week day, date from start time
        // (sorting on month etc.).
        // But here we don't need to thinking how to implement it. just make the necessary method.
        // we will implement it in service class
        #endregion
        
    }
}