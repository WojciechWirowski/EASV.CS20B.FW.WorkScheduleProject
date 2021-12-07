using System;
using System.Collections.Generic;
using System.Linq;
using EASC.CS20B.FW.WorkScheduleProject.ModelTest;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Database.Entities;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Repositories
{
    public class WorkingScheduleRepository
    {
        // private readonly ScheduleApplicationContext _ctx;
        // private List<WorkingScheduleEntity> _scheduleEntities;
        //
        // public WorkingScheduleRepository(ScheduleApplicationContext ctx)
        // {
        //     _ctx = ctx;
        // }
        //
        // public List<WorkingSchedule> GetAll()
        // {
        //     var selectQuery = _ctx.WorkingSchedules.Select(scheduleEntity => new WorkingSchedule
        //     {
        //         Id = scheduleEntity.Id,
        //         EmployeeId = scheduleEntity.EmployeeId,
        //         WeekDay = scheduleEntity.WeekDay,
        //         StartTime = scheduleEntity.StartTime,
        //         EndTime = scheduleEntity.EndTime
        //     });
        //     return selectQuery.ToList();
        // }
        // public WorkingSchedule Create(WorkingSchedule workingSchedule)
        // {
        //     WorkingScheduleEntity workingScheduleEntity = new WorkingScheduleEntity
        //     {
        //         Id = workingSchedule.Id,
        //         EmployeeId = workingSchedule.EmployeeId,
        //         WeekDay = workingSchedule.WeekDay,
        //         StartTime = workingSchedule.StartTime,
        //         EndTime = workingSchedule.EndTime
        //     };
        //     _ctx.WorkingSchedules.Add(workingScheduleEntity);
        //     _ctx.SaveChanges();
        //     return workingSchedule;
        // }
        // public WorkingSchedule Modify(WorkingSchedule workingSchedule)
        // {
        //     var entity = new WorkingScheduleEntity()
        //     {
        //         Id = workingSchedule.Id,
        //         EmployeeId = workingSchedule.EmployeeId,
        //         WeekDay = workingSchedule.WeekDay,
        //         StartTime = workingSchedule.StartTime,
        //         EndTime = workingSchedule.EndTime
        //     };
        //     _ctx.WorkingSchedules.Update(entity);
        //     _ctx.SaveChanges();
        //     return workingSchedule;
        // }
        //
        // public WorkingSchedule Delete(int id)
        // {
        //     var entity = _ctx.WorkingSchedules.Remove(new WorkingScheduleEntity {Id = id}).Entity;
        //     _ctx.SaveChanges();
        //     return new WorkingSchedule
        //     {
        //         Id = entity.Id,
        //         EmployeeId = entity.EmployeeId,
        //         WeekDay = entity.WeekDay,
        //         StartTime = entity.StartTime,
        //         EndTime = entity.EndTime
        //     };
        // }
        //
        // public List<WorkingSchedule> GetScheduleByEmployeeId(int employeeId)
        // {
        //     return _ctx.WorkingSchedules.Select(workingScheduleEntity => new WorkingSchedule
        //     {
        //         Id = workingScheduleEntity.Id,
        //         EmployeeId = workingScheduleEntity.EmployeeId,
        //         WeekDay = workingScheduleEntity.WeekDay,
        //         StartTime = workingScheduleEntity.StartTime,
        //         EndTime = workingScheduleEntity.EndTime
        //     }).Where(s => s.Id == employeeId).ToList();
        // }
    }
}