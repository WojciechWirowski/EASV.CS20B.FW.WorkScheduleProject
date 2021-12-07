using System;
using System.Collections.Generic;
using System.IO;
using EASV.CS20B.FW.WorkScheduleProject.Core.ExceptionMessage;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Services
{
    public class WorkingRecordService: IWorkingRecordService
    {
        private readonly IWorkingRecordRepository _workingRecordRepository;
        private IUserRepository _userRepository;

        public WorkingRecordService(IUserRepository userRepository, IWorkingRecordRepository workingRecordRepository)
        {
            _userRepository = userRepository ?? throw new InvalidDataException(DiCanNotNullExceptionMessage.UserRepositoryCanNotNull);
            _workingRecordRepository 
                = workingRecordRepository ?? 
                  throw new InvalidDataException(
                      "The working record repository can not be null");
        }

        

        public WorkingRecord CheckIn(WorkingRecord workingRecord)
        {
            // if the id is be set up then it will lead to a mistake in database
            if (workingRecord.Id != null)
                throw new InvalidDataException("Id should be null when create a new record in service.");
            
            // if employee id is smaller than 1 then that is not make sence
            if (workingRecord.EmployeeId <= 0)
                throw new InvalidDataException(
                    "EmployeeId should be bigger than 0 when create a new record in service.");
            
            // if the user id is not exist we can not let them check in
            if (_userRepository.GetUserById(workingRecord.EmployeeId) == null)
                throw new InvalidDataException("EmployeeId should be exist.");
            
            return _workingRecordRepository.Create(workingRecord);
        }

        public WorkingRecord CheckOut(WorkingRecord workingRecord)
        {
            var readById = _workingRecordRepository.ReadById(workingRecord.Id);
            if (readById == null)
                throw new Exception("The working record are not exist.");
            readById.CheckOutTime = workingRecord.CheckOutTime;
            return _workingRecordRepository.Update(readById);
        }

        public WorkingRecord Modify(WorkingRecord workingRecord)
        {
            return _workingRecordRepository.Update(workingRecord);
        }

        public WorkingRecord Delete(WorkingRecord workingRecord)
        {
            return _workingRecordRepository.Delete(workingRecord);
        }

        public List<WorkingRecord> GetAll()
        {
            return _workingRecordRepository.ReadAll();
        }

        public WorkingRecord GetById(WorkingRecord workingRecord)
        {
            return _workingRecordRepository.ReadById(workingRecord.Id);
        }

        public List<WorkingRecord> GetByEmployeeId(WorkingRecord workingRecord)
        {
            return _workingRecordRepository.ReadByEmployeeId(workingRecord.EmployeeId); 
        }

        public List<WorkingRecord> GetByDate(WorkingRecord workingRecord)
        {
            return _workingRecordRepository.ReadByDate(workingRecord.CheckInTime);
        }
    }
}