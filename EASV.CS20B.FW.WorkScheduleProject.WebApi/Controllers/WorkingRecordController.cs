using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Controllers
{
    //[Route("[controller]")]
    //[Authorize]
    //[ApiController]
    public class WorkingRecordController : ControllerBase
    {
        private readonly IWorkingRecordService _service;
        //creating a working record service
        public WorkingRecordController(IWorkingRecordService service)
        {
            _service = service;
        }
        //HttpGet request to get all records
        [HttpGet("~/get all records")]
        public ActionResult<WorkingRecordDto> GetAllRecords()
        {
            try
            {
                var records = _service.GetAll();
                var workingRecordDtoList = new List<WorkingRecordDto>();
                foreach (var record in records)
                {
                    workingRecordDtoList.Add(new WorkingRecordDto()
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
        //HttpGet request to get working record by id
        [HttpGet("{id}")]
        public WorkingRecordDto GetById(int id)
        {
            var workingRecord = _service.GetById(new WorkingRecord{Id = id});
            return new WorkingRecordDto()
            {
                Id = workingRecord.Id
            };
        }
        //HttpGet request to get records by date
        [HttpGet("~/get records by date")]
        public ActionResult<WorkingRecordDto> GetByDate(DateTime dateTime)
        {
            try
            {
                var records = _service.GetByDate(dateTime);
                var workingRecordDtoList = new List<WorkingRecordDto>();
                foreach (var record in records)
                {
                    workingRecordDtoList.Add(new WorkingRecordDto
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
        //HttpGet request to get records by employee id
        [HttpGet("~/get records by employeeId")]
        public ActionResult<WorkingRecordDto> GetByEmployeeId(int id)
        {
            try
            {
                var records = _service.GetByEmployeeId(id);
                var workingRecordDtoList = new List<WorkingRecordDto>();
                foreach (var record in records)
                {
                    workingRecordDtoList.Add(new WorkingRecordDto()
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
        //HttpPost request to create a record
        [HttpPost(nameof(CheckIn))]
        public ActionResult<WorkingRecordDto> CheckIn([FromBody] WorkingRecordDto dto)
        {
            try
            {
                var record = new WorkingRecord
                {
                   EmployeeId = dto.EmployeeId,
                    CheckInTime = dto.CheckInTime
                };
                var workingRecord = _service.CheckIn(record);
                var workingRecordDto = new WorkingRecordDto()
                {
                    Id = workingRecord.Id,
                    EmployeeId = workingRecord.EmployeeId,
                    CheckInTime = workingRecord.CheckInTime,
                    CheckOutTime = workingRecord.CheckOutTime,
                    WorkingHours = workingRecord.WorkingHours
                };
                return Ok($"Check In Success: {workingRecordDto} ");
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
        
        [HttpPost(nameof(CheckOut))]
        public ActionResult<WorkingRecordDto> CheckOut([FromBody] WorkingRecordDto dto)
        {
            try
            {
                var record = new WorkingRecord
                {
                    Id = dto.Id,
                    CheckOutTime = dto.CheckOutTime
                };
                var workingRecord = _service.CheckOut(record);
                var workingRecordDto = new WorkingRecordDto()
                {
                    Id = workingRecord.Id,
                    EmployeeId = workingRecord.EmployeeId,
                    CheckInTime = workingRecord.CheckInTime,
                    CheckOutTime = workingRecord.CheckOutTime,
                    WorkingHours = workingRecord.WorkingHours
                };
                return Ok($"Check Out Success: {workingRecordDto}");
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
        
        
        //HttpDelete request to delete working record by id
        [HttpDelete("{id}")]
        public WorkingRecordDto Delete(int id)
        {
            var workingRecord = _service.Delete(new WorkingRecord {Id = id});
            return new WorkingRecordDto() { Id = workingRecord.Id };
        }
        //HttpPut request to update working record
        [HttpPut]
        public WorkingRecordDto Modify(WorkingRecordDto workingRecordDto)
        {
            var workingRecord = new WorkingRecord()
            {
                Id = workingRecordDto.Id,
                EmployeeId = workingRecordDto.EmployeeId,
                CheckInTime = workingRecordDto.CheckInTime,
                CheckOutTime = workingRecordDto.CheckOutTime,
                WorkingHours = workingRecordDto.WorkingHours
            };
            var modify = _service.Modify(workingRecord);
            return new WorkingRecordDto()
            {
                Id = workingRecord.Id,
                EmployeeId = modify.EmployeeId,
                CheckInTime = modify.CheckInTime,
                CheckOutTime = modify.CheckOutTime,
                WorkingHours = modify.WorkingHours
            };
        }
        
        
    }
}