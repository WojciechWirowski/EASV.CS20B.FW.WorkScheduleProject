using System;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;
using EASV.CS20B.FW.WorkScheduleProject.Domain.Services;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Test.ServiceTest
{
    public class WorkingRecordServiceTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IWorkingRecordRepository> _workingRecordRepoMock;
        private readonly WorkingRecordService _workingRecordService;
        
        public WorkingRecordServiceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _userRepositoryMock = new Mock<IUserRepository>();
            _workingRecordRepoMock = new Mock<IWorkingRecordRepository>();
            _workingRecordService = new WorkingRecordService(_userRepositoryMock.Object,_workingRecordRepoMock.Object);
        }

        [Fact]
        public void WorkingRecordService_CheckIn()
        {
            var workingRecord = new WorkingRecord()
            {
                Id = 1,
                EmployeeId = 1,
                
            };

            var workingRecord2 = new WorkingRecord()
            {
                Id = 1,
                EmployeeId = 1,
                CheckIn = DateTime.Now
            };
       
            
            _userRepositoryMock.Setup(repository => repository.GetUserById(workingRecord.Id))
                .Returns(new User());
            
            _workingRecordRepoMock.Setup(repository => repository.Create(workingRecord))
                .Returns(workingRecord2);
            
            var checkIn = _workingRecordService.CheckIn(workingRecord);

            
            Assert.Equal(workingRecord2.CheckIn,checkIn.CheckIn);
        }
    }
}