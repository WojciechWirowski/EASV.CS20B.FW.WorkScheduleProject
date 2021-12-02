using System;
using System.Collections.Generic;
using System.IO;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Test.ServiceTest
{
    public class WorkingRecordServiceTest
    {
        private readonly Mock<IWorkingRecordRepository> _workingRecordRepository;
        private readonly WorkingRecordService _workingRecordService;

        public WorkingRecordServiceTest(ITestOutputHelper testOutputHelper)
        {
            _workingRecordRepository = new Mock<IWorkingRecordRepository>();
            _workingRecordService = new WorkingRecordService(_workingRecordRepository.Object);
        }

        #region Initial

        /// <summary>
        /// test we have a working record service class
        /// </summary>
        [Fact]
        public void WorkingRecordService_CanBeInitial()
        {
            Assert.NotNull(_workingRecordService);
        }

        /// <summary>
        /// make sure the WorkingRecord implement IWorkingRecord
        /// </summary>
        [Fact]
        public void WorkingRecordService_IsImplementInterface()
        {
            Assert.True(_workingRecordService is IWorkingRecordService);
        }

        /// <summary>
        /// test if the DI Repository is null
        /// then throw an InvalidDataException with right message
        /// </summary>
        [Fact]
        public void WorkingRecordService_WithNullWorkingRecordRepository_ThrowInValidDataException_WithMessage()
        {
            var invalidDataException = Assert.Throws<InvalidDataException>(
                () => new WorkingRecordService(null)
            );
            Assert.Equal("The working record repository can not be null",invalidDataException.Message);
        }

        #endregion

        #region CheckInMethodTest

        /// <summary>
        /// Test the check in method.
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
        
        [Fact]
        public void WorkingRecordService_CheckIn_ParaIdShouldBeNull_ThrowException()
        {
            var workingRecord = new WorkingRecord()
            {
                Id = 1
            };

            var invalidDataException 
                = Assert.Throws<InvalidDataException>(
                    () => _workingRecordService
                        .CheckIn(workingRecord));
            
            Assert.Equal("Id should be null when create a new record in service. ",invalidDataException.Message);
            
        }

        #endregion

        

    }
    

    public class WorkingRecordService:IWorkingRecordService
    {
        private readonly IWorkingRecordRepository _workingRecordRepository;

        public WorkingRecordService(IWorkingRecordRepository workingRecordRepository)
        {
            _workingRecordRepository 
                = workingRecordRepository ?? 
                  throw new InvalidDataException(
                      "The working record repository can not be null");
        }

        public WorkingRecord CheckIn(WorkingRecord workingRecord)
        {
            if (workingRecord.Id != null)
                throw new InvalidDataException("Id should be null when create a new record in service. ");
            return _workingRecordRepository.Create(workingRecord);
        }

        public WorkingRecord CheckOut(WorkingRecord workingRecord)
        {
            throw new NotImplementedException();
        }

        public WorkingRecord Modify(WorkingRecord workingRecord)
        {
            throw new NotImplementedException();
        }

        public WorkingRecord Delete(WorkingRecord workingRecord)
        {
            throw new NotImplementedException();
        }

        public List<WorkingRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public WorkingRecord GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<WorkingRecord> GetByEmployeeId(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<WorkingRecord> GetByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }

    public interface IWorkingRecordRepository
    {
        WorkingRecord Create(WorkingRecord workingRecord);
    }
}