using System;
using System.IO;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;
using EASV.CS20B.FW.WorkScheduleProject.Domain.Services;
using Moq;
using Xunit;
using Range = Moq.Range;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Test.ServiceTest.WorkingRecordServiceTest
{
    /// <summary>
    /// This class is testing about working record service check in method.
    /// </summary>
    public class WorkingRecordServiceCheckInTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IWorkingRecordRepository> _workingRecordRepository;
        private readonly WorkingRecordService _workingRecordService;

        public WorkingRecordServiceCheckInTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _workingRecordRepository = new Mock<IWorkingRecordRepository>();
            _workingRecordService = new WorkingRecordService(_workingRecordRepository.Object, _userRepository.Object);

            // Setup the mock object when we invoke the userRepository.GetUserById
            // in the range 1-4 (which means the employee id is in this range)
            // return a new user (which means not null)
            _userRepository
                .Setup(
                    repository => repository
                        .GetUserById(It.IsInRange(1,4,Range.Inclusive)))
                .Returns(new User());
        }
        
        /// <summary>
        /// check it call the right repository method and only once
        /// check it return right object.
        /// </summary>
        [Fact]
        public void WorkingRecordService_CheckIn_ParaWorkingRecord_ReturnNewRecord()
        {
            // Arrange
            // make a record
            var expected = new WorkingRecord()
            {
                EmployeeId = 1,
                CheckIn = DateTime.Now
            };
            
            // setup the repository mock return the record
            _workingRecordRepository
                .Setup(repository => repository.Create(expected))
                .Returns(expected);
            
            // Act
            // call the method and get the return
            var actual = _workingRecordService.CheckIn(expected);
            
            // Assert
            // verify the repository method only invoke once
            _workingRecordRepository
                .Verify(repository => repository.Create(expected), Times.Once);
            // assert equal
            Assert.Equal(expected,actual);
        }
        
        /// <summary>
        /// This is test the working record id should be null
        /// because if we pass in an id into repository,
        /// then it will be mass the database. 
        /// </summary>
        [Fact]
        public void WorkingRecordService_CheckIn_ParaId_ShouldBeNull_ThrowException()
        {
            var workingRecord = new WorkingRecord()
            {
                Id = 1
            };

            var invalidDataException 
                = Assert.Throws<InvalidDataException>(
                    () => _workingRecordService
                        .CheckIn(workingRecord));
            
            Assert.Equal("Id should be null when create a new record in service.",invalidDataException.Message);
            
        }
        
        [Fact]
        public void WorkingRecordService_CheckIn_ParaEmployeeId_NotExist_ThrowException()
        {
            var workingRecord = new WorkingRecord()
            {
                EmployeeId = 8
            };

            var invalidDataException 
                = Assert.Throws<InvalidDataException>(
                    () => _workingRecordService
                        .CheckIn(workingRecord));
            
            Assert.Equal("EmployeeId should be exist.",invalidDataException.Message);
        }

        /// <summary>
        /// This test is testing if the input employee id is smaller 1 then throw exception.
        /// </summary>
        /// <param name="id"> Employee Id</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WorkingRecordService_CheckIn_ParaEmployeeId_ShouldBiggerThanZero_ThrowException(int id)
        {
            var workingRecord = new WorkingRecord()
            {
                EmployeeId = id
            };

            var invalidDataException 
                = Assert.Throws<InvalidDataException>(
                    () => _workingRecordService
                        .CheckIn(workingRecord));
            
            Assert.Equal("EmployeeId should be bigger than 0 when create a new record in service.",invalidDataException.Message);
        }
    }
}