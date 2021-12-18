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
                      DiCanNotNullExceptionMessage.WorkingRecordRepositoryCanNotNull);
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
            
            workingRecord.CheckInTime = DateTime.Now;
            return _workingRecordRepository.Create(workingRecord);
        }

        public WorkingRecord CheckOut(WorkingRecord workingRecord)
        {
            var byEmployeeIdAndDate = _workingRecordRepository.GetByEmployeeIdAndDate(workingRecord.CheckInTime,workingRecord.EmployeeId);
            if (byEmployeeIdAndDate == null)
                throw new Exception("The working record are not exist.");
            byEmployeeIdAndDate.CheckOutTime = DateTime.Now;
            return _workingRecordRepository.Modify(byEmployeeIdAndDate);
        }

        public WorkingRecord Modify(WorkingRecord workingRecord)
        {
            return _workingRecordRepository.Modify(workingRecord);
        }

        public WorkingRecord Delete(WorkingRecord workingRecord)
        {
            return _workingRecordRepository.Delete(workingRecord.Id);
        }

        public List<WorkingRecord> GetAll()
        {
            return _workingRecordRepository.GetAllRecords();
        }

        public WorkingRecord GetById(WorkingRecord workingRecord)
        {
            return _workingRecordRepository.GetById(workingRecord.Id);
        }

        public List<WorkingRecord> GetByEmployeeId(int id)
        {
            return _workingRecordRepository.GetByEmployeeId(id); 
        }

        public List<WorkingRecord> GetByDate(DateTime date)
        {
            return _workingRecordRepository.GetByDate(date);
        }
    }
}