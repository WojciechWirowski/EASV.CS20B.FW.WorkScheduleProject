using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Core.IServices
{
    public interface IWorkingRecordService
    {
        /// <summary>
        /// The employee do the check in
        /// </summary>
        /// <param name="workingRecord">
        /// Id: null.
        /// EmployeeId: the user id who are check in
        /// CheckIn: check in time
        /// CheckOut: null
        /// </param>
        /// <returns>the new record of one employee at one day.</returns>
        WorkingRecord CheckIn(WorkingRecord workingRecord);
        
        /// <summary>
        /// the employee do the check out
        /// </summary>
        /// <param name="workingRecord">
        /// Id: the record unique number
        /// CheckOut: the time of check out
        /// </param>
        /// <returns>completed check in check out record </returns>
        WorkingRecord CheckOut(WorkingRecord workingRecord);
        
        /// <summary>
        /// modify the record
        /// </summary>
        /// <param name="workingRecord"></param>
        /// <returns></returns>
        WorkingRecord Modify(WorkingRecord workingRecord);
        
        /// <summary>
        /// remove a record
        /// </summary>
        /// <param name="workingRecord"></param>
        /// <returns></returns>
        WorkingRecord Delete(WorkingRecord workingRecord);
        List<WorkingRecord> GetAll();
        WorkingRecord GetById(WorkingRecord workingRecord);
        List<WorkingRecord> GetByEmployeeId(WorkingRecord workingRecord);
        List<WorkingRecord> GetByDate(WorkingRecord workingRecord);
    }
}