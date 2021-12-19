using System.IO;
using EASV.CS20B.FW.WorkScheduleProject.Core.ExceptionMessage;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;
using EASV.CS20B.FW.WorkScheduleProject.Domain.Services;
using Moq;
using Xunit;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Test.ServiceTest.WorkingRecordServiceTest
{
    /// <summary>
    /// This class is testing about initialize the working record service.
    /// </summary>
    public class WorkingRecordServiceInitialTest
    {
        private readonly Mock<IWorkingRecordRepository> _workingRecordRepository;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly WorkingRecordService _workingRecordService;

        public WorkingRecordServiceInitialTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _workingRecordRepository = new Mock<IWorkingRecordRepository>();
            _workingRecordService = new WorkingRecordService(_userRepository.Object,_workingRecordRepository.Object);
        }
        
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
            Assert.IsAssignableFrom<IWorkingRecordService>(_workingRecordService);
        }

        /// <summary>
        /// test if the DI Repository is null
        /// then throw an InvalidDataException with right message
        /// </summary>
        [Fact]
        public void WorkingRecordService_WithNullWorkingRecordRepository_ThrowInValidDataException_WithMessage()
        {
            var invalidDataException = Assert.Throws<InvalidDataException>(
                () => new WorkingRecordService(_userRepository.Object,null)
            );
            Assert.Equal("The working record repository can not be null",invalidDataException.Message);
        }
        
        /// <summary>
        /// test if the DI Repository is null
        /// then throw an InvalidDataException with right message
        /// </summary>
        [Fact]
        public void WorkingRecordService_WithNullUserRepository_ThrowInValidDataException_WithMessage()
        {
            var invalidDataException = Assert.Throws<InvalidDataException>(
                () => new WorkingRecordService(null,_workingRecordRepository.Object)
            );
            Assert.Equal(DiCanNotNullExceptionMessage.UserRepositoryCanNotNull,invalidDataException.Message);
        }
    }
}