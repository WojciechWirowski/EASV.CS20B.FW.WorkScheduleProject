using System;
using System.Collections.Generic;
using System.IO;
using EASC.CS20B.FW.WorkScheduleProject.Core.Test.IServicesTest;
using EASV.CS20B.FW.WorkScheduleProject.Core.ExceptionMessage;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Services
{
    public class WorkingScheduleService: IWorkingScheduleService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWorkingScheduleRepository _workingScheduleRepository;

        public WorkingScheduleService(IUserRepository userRepository, IWorkingScheduleRepository workingScheduleRepository)
        {
            _userRepository 
                = userRepository ?? throw new Exception(DiCanNotNullExceptionMessage.UserRepositoryCanNotNull);
            _workingScheduleRepository
                = workingScheduleRepository ?? throw new Exception(DiCanNotNullExceptionMessage.WorkingScheduleRepositoryCanNotNull);
        }

        public WorkingSchedule Create(WorkingSchedule workingSchedule)
        {
            if (workingSchedule.Id != null) 
                throw new InvalidDataException("The Id should not be set up.");
            
            if (_userRepository.GetUserById(workingSchedule.EmployeeId) == null)
                throw new InvalidDataException("The employee are not exist. ");
            
            if (workingSchedule.StartTime != null)
                throw new InvalidDataException("This employee have set a schedule on this time.");
            
            return _workingScheduleRepository.Create(workingSchedule);
        }

        public WorkingSchedule Modify(WorkingSchedule workingSchedule)
        {
            return _workingScheduleRepository.Modify(workingSchedule);
        }

        public WorkingSchedule Delete(int id)
        {
            return _workingScheduleRepository.Delete(id);
        }

        public List<WorkingSchedule> GetAll()
        {
            return _workingScheduleRepository.GetAll();
        }

        public List<WorkingSchedule> GetScheduleByEmployeeId(int employeeId)
        {
            return _workingScheduleRepository.GetWorkingScheduleByEmployeeId(employeeId);
        }

        public List<WorkingSchedule> GetScheduleByDate(DateTime date)
        {
            return _workingScheduleRepository.GetScheduleByDate(date);
        }

        public List<WorkingSchedule> GetScheduleByMonth(DateTime addMonths)
        {
            throw new NotImplementedException();
        }
    }
}