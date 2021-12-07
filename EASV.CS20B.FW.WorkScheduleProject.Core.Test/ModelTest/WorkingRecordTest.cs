using System;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using Xunit;

namespace EASC.CS20B.FW.WorkScheduleProject.ModelTest
{
    /// <summary>
    /// This class is testing about the WorkingRecord of employee check in and check out.
    /// include the Id of record, employee Id, check in date time. check out date time and working hours per day.
    /// 
    /// </summary>
    public class WorkingRecordTest
    {
        #region Initial

        [Fact]
        public void WorkingRecord_CanBeInitial()
        {
            var workingRecord = new WorkingRecord();
            Assert.NotNull(workingRecord);
        }

        [Fact]
        public void WorkingRecord_HaveId()
        {
            var workingRecord = new WorkingRecord()
            {
                Id = 1
            };
            Assert.Equal(1,workingRecord.Id);
        }

        [Fact]
        public void WorkingRecord_HaveEmployeeId()
        {
            var workingRecord = new WorkingRecord()
            {
                EmployeeId = 1
            };
            Assert.Equal(1,workingRecord.EmployeeId);
        }

        [Fact]
        public void WorkingRecord_HaveCheckInTime()
        {
            var dateTime = DateTime.Now;
            var workingRecord = new WorkingRecord()
            {
                CheckInTime = dateTime
            };
            Assert.Equal(dateTime,workingRecord.CheckInTime);
        }

        [Fact]
        public void WorkingRecord_HaveCheckOutTime()
        {
            var dateTime = DateTime.Now;
            var workingRecord = new WorkingRecord()
            {
                CheckOutTime = dateTime
            };  
            Assert.Equal(dateTime,workingRecord.CheckOutTime);
        }

        [Fact]
        public void WorkingRecord_HaveWorkingHours()
        {
            var timeSpan = new TimeSpan(5,0,0);
            var workingRecord = new WorkingRecord()
            {
                WorkingHours = timeSpan
            };
            Assert.Equal(timeSpan,workingRecord.WorkingHours);
        }
        #endregion 
    }
}