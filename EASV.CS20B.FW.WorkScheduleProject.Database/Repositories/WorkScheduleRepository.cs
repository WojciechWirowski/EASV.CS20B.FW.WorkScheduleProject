using System;
using System.Collections.Generic;
using System.Linq;
using EASV.CS20B.FW.WorkScheduleProject.Database.Entities;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Repositories
{
    public class WorkingScheduleRepository : IWorkingScheduleRepository
    {
        private readonly ScheduleApplicationContext _ctx;
        //constructor creates the database
        public WorkingScheduleRepository(ScheduleApplicationContext ctx)
        {
            _ctx = ctx;
        }
        //gets working schedule by employee id and day of week
        public WorkingSchedule GetWorkingScheduleByEmployeeIdAndDayOfWeek(WorkingSchedule workingSchedule)
        {
            var selectQuery = _ctx.WorkingSchedules.Select(scheduleEntity => new WorkingSchedule
            {
                Id = scheduleEntity.Id,
                EmployeeId = scheduleEntity.EmployeeId,
                WeekDay = scheduleEntity.WeekDay,
                StartTime = scheduleEntity.StartTime,
                EndTime = scheduleEntity.EndTime
            }).FirstOrDefault(schedule =>
                schedule.EmployeeId == workingSchedule.EmployeeId && schedule.WeekDay == workingSchedule.WeekDay);
            return selectQuery;
        }
        //Gets all working schedules
        public List<WorkingSchedule> GetAll()
        {
            var selectQuery = _ctx.WorkingSchedules.Select(scheduleEntity => new WorkingSchedule
            {
                Id = scheduleEntity.Id,
                EmployeeId = scheduleEntity.EmployeeId,
                WeekDay = scheduleEntity.WeekDay,
                StartTime = scheduleEntity.StartTime,
                EndTime = scheduleEntity.EndTime
            });
            return selectQuery.ToList();
        }
        //creates working schedule
        public WorkingSchedule Create(WorkingSchedule workingSchedule)
        {
            WorkingScheduleEntity workingScheduleEntity = new WorkingScheduleEntity
            {
                Id = workingSchedule.Id,
                EmployeeId = workingSchedule.EmployeeId,
                WeekDay = workingSchedule.WeekDay,
                StartTime = workingSchedule.StartTime,
                EndTime = workingSchedule.EndTime
            };
            _ctx.WorkingSchedules.Add(workingScheduleEntity);
            _ctx.SaveChanges();
            return workingSchedule;
        }
        //gets working schedule by employee id
        public List<WorkingSchedule> GetWorkingScheduleByEmployeeId(int employeeId){
            return _ctx.WorkingSchedules.Select(workingScheduleEntity => new WorkingSchedule
            {
                Id = workingScheduleEntity.Id,
                EmployeeId = workingScheduleEntity.EmployeeId,
                WeekDay = workingScheduleEntity.WeekDay,
                StartTime = workingScheduleEntity.StartTime,
                EndTime = workingScheduleEntity.EndTime
            }).Where(s => s.EmployeeId == employeeId).ToList();
        }
        //gets working schedule by date
        public List<WorkingSchedule> GetScheduleByDate(DateTime date)
        {
            {
                DayOfWeek dayOfWeek = date.DayOfWeek;
                return _ctx.WorkingSchedules.Select(workingScheduleEntity => new WorkingSchedule
                {
                    Id = workingScheduleEntity.Id,
                    EmployeeId = workingScheduleEntity.EmployeeId,
                    WeekDay = workingScheduleEntity.WeekDay,
                    StartTime = workingScheduleEntity.StartTime,
                    EndTime = workingScheduleEntity.EndTime
                }).Where(s => s.WeekDay == dayOfWeek).ToList();
            }
        }
        //Gets working schedule by id
        public WorkingSchedule GetScheduleById(WorkingSchedule workingSchedule)
        {
            var selectQuery = _ctx.WorkingSchedules.Select(scheduleEntity => new WorkingSchedule
            {
                Id = scheduleEntity.Id,
                EmployeeId = scheduleEntity.EmployeeId,
                WeekDay = scheduleEntity.WeekDay,
                StartTime = scheduleEntity.StartTime,
                EndTime = scheduleEntity.EndTime
            }).FirstOrDefault(schedule =>
                schedule.Id == workingSchedule.Id);
            return selectQuery;
        }
        //updates the working schedule
        public WorkingSchedule Modify(WorkingSchedule workingSchedule)
        {
            var entity = new WorkingScheduleEntity()
            {
                Id = workingSchedule.Id,
                EmployeeId = workingSchedule.EmployeeId,
                WeekDay = workingSchedule.WeekDay,
                StartTime = workingSchedule.StartTime,
                EndTime = workingSchedule.EndTime
            };
            _ctx.WorkingSchedules.Update(entity);
            _ctx.SaveChanges();
            return workingSchedule;
        }
        //Deletes the working schedule
        public WorkingSchedule Delete(WorkingSchedule workingSchedule)
        {
            var entity = _ctx.WorkingSchedules.Remove(new WorkingScheduleEntity {Id = workingSchedule.Id}).Entity;
            _ctx.SaveChanges();
            return new WorkingSchedule
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                WeekDay = entity.WeekDay,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime
            };
        }
    }
}