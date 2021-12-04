using System;
using System.Collections.Generic;
using System.IO;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Services
{
    public class WorkingRecordService: IWorkingRecordService
    {
        private readonly IWorkingRecordRepository _workingRecordRepository;
        private IUserRepository _userRepository;

        public WorkingRecordService(IWorkingRecordRepository workingRecordRepository, IUserRepository userRepository)
        {
            _workingRecordRepository 
                = workingRecordRepository ?? 
                  throw new InvalidDataException(
                      "The working record repository can not be null");
            _userRepository 
                = userRepository ??
                  throw new InvalidDataException(
                      "The user repository can not be null");
        }

        

        public WorkingRecord CheckIn(WorkingRecord workingRecord)
        {
            if (workingRecord.Id != null)
                throw new InvalidDataException("Id should be null when create a new record in service.");
            if (workingRecord.EmployeeId <= 0)
                throw new InvalidDataException(
                    "EmployeeId should be bigger than 0 when create a new record in service.");
            if (_userRepository.GetUserById(workingRecord.EmployeeId) == null)
                throw new InvalidDataException("EmployeeId should be exist.");
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
}