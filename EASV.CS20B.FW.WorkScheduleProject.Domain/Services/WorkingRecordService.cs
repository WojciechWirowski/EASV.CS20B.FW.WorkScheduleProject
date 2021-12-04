using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Services
{
    public class WorkingRecordService: IWorkingRecordService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWorkingRecordRepository _workingRecordRepository;

        public WorkingRecordService(IUserRepository userRepository, IWorkingRecordRepository workingRecordRepository)
        {
            _userRepository = userRepository;
            _workingRecordRepository = workingRecordRepository;
        }

        public WorkingRecord CheckIn(WorkingRecord workingRecord)
        {
            var userById = _userRepository.GetUserById(workingRecord.EmployeeId);
            if (userById == null)
            {
                throw new Exception(" .... ");
            }
            workingRecord.CheckIn = DateTime.Now;

            return _workingRecordRepository.Create(workingRecord);

        }

        public WorkingRecord CheckOut(WorkingRecord workingRecord)
        {
            // if the employee log in and then check in
            // a new record will be create and store an id somewhere
            // what ever the user log out or not. the id will be save
            // if the user press check out then a new check out time will be create and insert into the record of id
            
            throw new NotImplementedException();
            
            
            // check in 
            // CheckIn()
            // Repo.Create() -> WorkingRecord
            // check out
            // WorkingRecord -> add checkout time.

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
        WorkingRecord Get(WorkingRecord workingRecord);
    }
}