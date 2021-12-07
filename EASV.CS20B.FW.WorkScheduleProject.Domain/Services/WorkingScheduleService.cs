using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var scheduleByEmployeeId 
                = _workingScheduleRepository
                    .GetWorkingScheduleByEmployeeId(workingSchedule.EmployeeId);
            
            var schedulesOfThisEmployeeAtThisDay
                = scheduleByEmployeeId
                    .FindAll(date => workingSchedule.StartTime.Date == date.StartTime.Date)
                    .ToList();
            
            if (schedulesOfThisEmployeeAtThisDay != null)
                throw new InvalidDataException("This employee have set a schedule on this time.");
            
            return _workingScheduleRepository.Create(workingSchedule);
        }

        public WorkingSchedule Modify(WorkingSchedule workingSchedule)
        {
            return _workingScheduleRepository.Modify(workingSchedule);
        }

      

        public WorkingSchedule Delete(int? id)
        {
            return _workingScheduleRepository.Delete(id);
        }

        public List<WorkingSchedule> GetAll()
        {
            return _workingScheduleRepository.GetAll();
        }

        public WorkingSchedule GetScheduleById(int id)
        {
            return _workingScheduleRepository.ReadScheduleById(id);
        }

        public List<WorkingSchedule> GetScheduleByEmployeeId(int employeeId)
        {
            return _workingScheduleRepository.GetWorkingScheduleByEmployeeId(employeeId);
        }

        public List<WorkingSchedule> GetScheduleByDate(DateTime date)
        {
            return _workingScheduleRepository.GetScheduleByDate(date);
        }

        public List<WorkingSchedule> GetScheduleByMonth(DateTime yearAndMonth)
        {
            var workingSchedules = new List<WorkingSchedule>();
            
            var daysInMonth = DateTime.DaysInMonth(yearAndMonth.Year, yearAndMonth.Month);
            
            for (int i = 0; i < daysInMonth; i++)
            {
                var dateTime = yearAndMonth.AddDays(i + 1);
                var scheduleByDate = GetScheduleByDate(dateTime);
                workingSchedules.AddRange(scheduleByDate);
            }

            return workingSchedules;
        }
    }
}