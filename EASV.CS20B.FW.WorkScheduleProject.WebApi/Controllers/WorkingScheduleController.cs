using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkingSchedule = EASV.CS20B.FW.WorkScheduleProject.Core.Models.WorkingSchedule;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class WorkingScheduleController : ControllerBase
    {
        private readonly IWorkingScheduleService _service;

        public WorkingScheduleController(IWorkingScheduleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<WorkingScheduleDto[]> GetAllScheduledDays()
        {
            try
            {
                var schedules = _service.GetAll();
                var workingScheduleDtoList = new List<WorkingScheduleDto>();
                foreach (var schedule in schedules)
                {
                    workingScheduleDtoList.Add(new WorkingScheduleDto
                    {
                        Id = schedule.Id,
                        EmployeeId = schedule.EmployeeId,
                        EndTime = schedule.EndTime,
                        StartTime = schedule.StartTime,
                        WeekDay = schedule.WeekDay
                    });
                }

                return Ok(workingScheduleDtoList.ToArray());

            }
            catch (Exception)
            {
                return StatusCode(500, "System problems occured");
            }
        }
        
        [HttpGet("{id}")]
        public List<WorkingSchedule> GetByEmployeeId(int id)
        {
            return _service.GetScheduleByEmployeeId(id);
        }
        
        [Route(nameof(Post))]
        [HttpPost]
        public ActionResult<WorkingScheduleDto> Post([FromBody] WorkingScheduleDto dto)
        {
            try
            {
                var schedule = new WorkingSchedule
                {
                    EmployeeId = dto.EmployeeId,
                    EndTime = dto.EndTime,
                    StartTime = dto.StartTime,
                    WeekDay = dto.WeekDay
                };
                return Ok($"Schedule day{_service.Create(schedule)} created...");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public void DeleteSchedule(int id)
        {
            _service.Delete(new WorkingSchedule{Id = id});
        }

        [HttpPut]
        public void UpdateSchedule(WorkingSchedule schedule)
        { 
            _service.Modify(schedule);
        }
    }
}