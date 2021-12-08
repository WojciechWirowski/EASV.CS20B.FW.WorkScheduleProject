using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;
using EASV.CS20B.FW.WorkScheduleProject.Domain.Services;
using Moq;
using Xunit;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Test.ServiceTest.WorkingScheduleServiceTest
{
    public class WorkingScheduleServiceGetScheduleTest
    {
        private readonly Mock<IWorkingScheduleRepository> _workingScheduleRepository;
        private readonly WorkingScheduleService _workingScheduleService;

        public WorkingScheduleServiceGetScheduleTest()
        {
            var userRepository = new Mock<IUserRepository>();
            _workingScheduleRepository = new Mock<IWorkingScheduleRepository>();
            _workingScheduleService = new WorkingScheduleService(userRepository.Object, _workingScheduleRepository.Object);
        }

        [Fact]
        public void WorkingScheduleServiceGetScheduleByMonth_ParaDateTimeYearMonth_ReturnListOfScheduleInAllMonth()
        {
            var workingSchedules = new List<WorkingSchedule>();
            _workingScheduleRepository
                .Setup(service => service.GetScheduleByDate(It.IsAny<DateTime>()))
                .Returns(workingSchedules);
            
            var scheduleByMonth = _workingScheduleService.GetScheduleByMonth(new DateTime(2021, 12, 1));
            Assert.Equal(workingSchedules,scheduleByMonth);
        }
    }
}