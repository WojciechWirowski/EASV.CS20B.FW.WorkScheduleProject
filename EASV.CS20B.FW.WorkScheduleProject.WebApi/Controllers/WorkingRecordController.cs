using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class WorkingRecordController : ControllerBase
    {
        private readonly IWorkingRecordService _service;

        public WorkingRecordController(IWorkingRecordService service)
        {
            _service = service;
        }

        [HttpGet("~/get all records")]
        public ActionResult<WorkingRecordDto> GetAllRecords()
        {
            try
            {
                var records = _service.GetAll();
                var workingRecordDtoList = new List<WorkingRecord>();
                foreach (var record in records)
                {
                    workingRecordDtoList.Add(new WorkingRecord
                    {
                        Id = record.Id,
                        EmployeeId = record.EmployeeId,
                        CheckInTime = record.CheckInTime,
                        CheckOutTime = record.CheckOutTime,
                        WorkingHours = record.WorkingHours
                    });
                }

                return Ok(workingRecordDtoList.ToArray());

            }
            catch (Exception)
            {
                return StatusCode(500, "System problems occured");
            }
        }

        [HttpGet("{id}")]
        public WorkingRecord GetById(int id)
        {
            return _service.GetById(new WorkingRecord{Id = id});
        }

        [HttpGet("~/get records by date")]
        public ActionResult<WorkingRecordDto> GetByDate(DateTime dateTime)
        {
            try
            {
                var records = _service.GetByDate(dateTime);
                var workingRecordDtoList = new List<WorkingRecord>();
                foreach (var record in records)
                {
                    workingRecordDtoList.Add(new WorkingRecord
                    {
                        Id = record.Id,
                        EmployeeId = record.EmployeeId,
                        CheckInTime = record.CheckInTime,
                        CheckOutTime = record.CheckOutTime,
                        WorkingHours = record.WorkingHours
                    });
                }

                return Ok(workingRecordDtoList.ToArray());

            }
            catch (Exception)
            {
                return StatusCode(500, "System problems occured");
            }
        }
        
        [HttpGet("~/get records by employeeId")]
        public ActionResult<WorkingRecordDto> GetByDate(int id)
        {
            try
            {
                var records = _service.GetByEmployeeId(id);
                var workingRecordDtoList = new List<WorkingRecord>();
                foreach (var record in records)
                {
                    workingRecordDtoList.Add(new WorkingRecord
                    {
                        Id = record.Id,
                        EmployeeId = record.EmployeeId,
                        CheckInTime = record.CheckInTime,
                        CheckOutTime = record.CheckOutTime,
                        WorkingHours = record.WorkingHours
                    });
                }

                return Ok(workingRecordDtoList.ToArray());

            }
            catch (Exception)
            {
                return StatusCode(500, "System problems occured");
            }
        }

        [HttpPost]
        public ActionResult<WorkingRecord> CheckIn([FromBody] WorkingRecordDto dto)
        {
            try
            {
                var record = new WorkingRecord
                {
                    CheckInTime = dto.CheckInTime,
                   CheckOutTime = dto.CheckOutTime,
                   EmployeeId = dto.EmployeeId
                };
                return Ok($"Schedule day{_service.CheckIn(record)} created...");
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
        public WorkingRecord Delete(int id)
        {
            return _service.Delete(new WorkingRecord {Id = id});
        }

        [HttpPut]
        public WorkingRecord Modify(WorkingRecord workingRecord)
        {
           return _service.Modify(workingRecord);
        }
        
        
    }
}