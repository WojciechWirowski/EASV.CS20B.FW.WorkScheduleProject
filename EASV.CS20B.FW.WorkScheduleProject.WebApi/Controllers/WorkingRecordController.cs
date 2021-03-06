using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class WorkingRecordController : ControllerBase
    {
        private readonly IWorkingRecordService _service;
        //creating a working record service
        public WorkingRecordController(IWorkingRecordService service)
        {
            _service = service;
        }
        
        /// <summary>
        /// Get all WorkingRecord as an array
        /// </summary>
        /// <returns>ActionResult working record</returns>
        [HttpGet(nameof(GetAllRecords))]
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
        [HttpGet(nameof(GetById))]
        public WorkingRecordDto GetById(int id)
        {
            var workingRecord = _service.GetById(new WorkingRecord{Id = id});
            return new WorkingRecordDto()
            {
                Id = workingRecord.Id
            };
        }
        //HttpGet request to get records by date
        [HttpGet(nameof(GetByDate))]
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
        [HttpGet(nameof(GetByEmployeeId))]
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
        [HttpGet(nameof(CheckIn))]
        public ActionResult<WorkingRecordDto> CheckIn(int id)
        {
            try
            {
                var record = new WorkingRecord
                {
                   EmployeeId = id,
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
                return Ok(workingRecordDto);
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
        
        [HttpGet(nameof(CheckOut))]
        public ActionResult<WorkingRecordDto> CheckOut(int id)
        {
            try
            {
                var record = new WorkingRecord
                {
                    EmployeeId = id,
                    CheckInTime = DateTime.Today,
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
                return Ok(workingRecordDto);
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
        [HttpDelete(nameof(Delete))]
        public WorkingRecordDto Delete(int id)
        {
            var workingRecord = _service.Delete(new WorkingRecord {Id = id});
            return new WorkingRecordDto() { Id = workingRecord.Id };
        }
        
        //HttpPut request to update working record
        [HttpPut(nameof(Modify))]
        public WorkingRecordDto Modify(WorkingRecordJsonDto workingRecordJsonDto)
        {
            var workingRecord = new WorkingRecord()
            {
                Id = workingRecordJsonDto.Id,
                EmployeeId = workingRecordJsonDto.EmployeeId,
                CheckInTime = DateTime.Parse(workingRecordJsonDto.CheckInTime),
                CheckOutTime = DateTime.Parse(workingRecordJsonDto.CheckOutTime)
            };
            var modify = _service.Modify(workingRecord);
            return new WorkingRecordDto()
            {
                Id = modify.Id,
                EmployeeId = modify.EmployeeId,
                CheckInTime = modify.CheckInTime,
                CheckOutTime = modify.CheckOutTime,
                WorkingHours = modify.WorkingHours
            };
        }
        
        
    }
}