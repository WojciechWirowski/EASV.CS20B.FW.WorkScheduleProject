using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using Moq;
using Xunit;

namespace EASV.CS20B.FW.WorkScheduleProject.IServicesTest
{
    public class IWorkingRecordTest
    {
        /// <summary>
        /// This is the test of interface of Record Service
        /// it is working for let the employee can check-in check-out, searching the record, calculate the working hours
        /// and the Administrator can modify the record. 
        /// </summary>
        private readonly Mock<IWorkingRecordService> _iWorkingRecordMock;

        public IWorkingRecordTest()
        {
            _iWorkingRecordMock = new Mock<IWorkingRecordService>();
        }

        [Fact]
        public void IWorkingRecordTest_IsAvailable()
        {
            var workingRecordService = _iWorkingRecordMock.Object;
            Assert.NotNull(workingRecordService);
        }

        #region Method

        /// <summary>
        /// This method is working for check-in interface method should be call
        /// the parameter is working record with employeeId and check-in time
        /// the repository will add an Id for it and return a working record with id, employee id, check-in time.
        /// rest check-out time and working hours will be null.
        /// </summary>
        [Fact]
        public void IWorkingRecordTest_CheckIn_ParaRecordContainEmployeeIDCheckIn_ReturnRecord()
        {
            var workingRecord = new WorkingRecord();
            _iWorkingRecordMock
                .Setup(service => service.CheckIn(workingRecord))
                .Returns(workingRecord);
            var checkIn = _iWorkingRecordMock.Object.CheckIn(workingRecord);
            Assert.Equal(checkIn,workingRecord);
        }

        /// <summary>
        /// This is testing check out interface method should be call
        /// the parameter is working record with id, employee id, check-in time.
        /// method will invoke search method from repository by id and get the record
        /// and then insert the check-out time and auto calculate the working hours
        /// </summary>
        [Fact]
        public void IWorkingRecordTest_CheckOut_ParaRecordContainIdCheckOut_ReturnRecord()
        {
            var workingRecord = new WorkingRecord();
            _iWorkingRecordMock
                .Setup(service => service.CheckOut(workingRecord))
                .Returns(workingRecord);
            var checkOut = _iWorkingRecordMock.Object.CheckOut(workingRecord);
            Assert.Equal(checkOut,workingRecord);

        }
        
        
        /// <summary>
        /// this method is working for modify the record if there is some situation like mistake.
        /// so only administrator have the right to modify it.
        /// the parameter is the new record with the id which record should be change.
        /// return new record.
        /// </summary>
        [Fact]
        public void IWorkingRecordTest_ModifyRecord_ParaRecord_ReturnRecord()
        {
            var workingRecord = new WorkingRecord();
            _iWorkingRecordMock
                .Setup(service => service.Modify(workingRecord))
                .Returns(workingRecord);
            var modify = _iWorkingRecordMock.Object.Modify(workingRecord);
            Assert.Equal(modify,workingRecord);

        }
        
        /// <summary>
        /// This is the delete the record, only administrator can do it.
        /// parameter is which record will be delete.
        /// return the record be delete
        /// </summary>
        [Fact]
        public void IWorkingRecordTest_DeleteRecord_ParaRecord_ReturnRecord()
        {
            var workingRecord = new WorkingRecord();
            _iWorkingRecordMock
                .Setup(service => service.Delete(workingRecord))
                .Returns(workingRecord);
            var delete = _iWorkingRecordMock.Object.Delete(workingRecord);
            Assert.Equal(delete,workingRecord);

        }
        
        /// <summary>
        /// This is test the working record of get all
        /// return all the record by a list.
        /// </summary>
        [Fact]
        public void IWorkingRecordTest_GetAll_ReturnListOfRecord()
        {
            var workingRecords = new List<WorkingRecord>();
            _iWorkingRecordMock
                .Setup(service => service.GetAll())
                .Returns(workingRecords);
            var all = _iWorkingRecordMock.Object.GetAll();
            Assert.Equal(all,workingRecords);

        }
        
        /// <summary>
        /// This is test get by id
        /// parameter is the record id which we want to search
        /// return the record
        /// </summary>
        [Fact]
        public void IWorkingRecordTest_GetById_ParaId_ReturnRecord()
        {
            var workingRecord = new WorkingRecord()
            {
                Id = 1
            };
            _iWorkingRecordMock
                .Setup(service => service.GetById(workingRecord))
                .Returns(workingRecord);
            var byId = _iWorkingRecordMock.Object.GetById(workingRecord);
            Assert.Equal(byId,workingRecord);

        }
        
        /// <summary>
        /// This is test get by employee id
        /// parameter is the id which employee we want to search
        /// return is the list of all record by the employee
        /// </summary>
        [Fact]
        public void IWorkingRecordTest_GetByEmployeeId_ParaRecord_ReturnListOfRecord()
        {
            var workingRecord = new WorkingRecord()
            {
                EmployeeId = 1
            };
            var expect = new List<WorkingRecord>();
            _iWorkingRecordMock
                .Setup(service => service.GetByEmployeeId(workingRecord.EmployeeId))
                .Returns(expect);
            var actual = _iWorkingRecordMock.Object.GetByEmployeeId(workingRecord.EmployeeId);
            Assert.Equal(actual,expect);

        }
        
        /// <summary>
        /// This is test to get record by date
        /// parameter is the date which day we want to search
        /// return the all employee record on the date.
        /// </summary>
        [Fact]
        public void IWorkingRecordTest_GetByDate_ParaDate_ReturnListOfRecord()
        {
            var dateTime = new DateTime(2021,12,1);
            var workingRecord = new WorkingRecord()
            {
                CheckInTime = dateTime
            };
            var workingRecords = new List<WorkingRecord>();
            _iWorkingRecordMock
                .Setup(service => service.GetByDate(workingRecord))
                .Returns(workingRecords);
            var byDate = _iWorkingRecordMock.Object.GetByDate(workingRecord);
            Assert.Equal(byDate,workingRecords);

        }
        #endregion
    }
}