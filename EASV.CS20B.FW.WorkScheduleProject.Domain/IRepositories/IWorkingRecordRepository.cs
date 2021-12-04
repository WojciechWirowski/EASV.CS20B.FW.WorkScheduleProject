using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories
{
    public interface IWorkingRecordRepository
    {
        WorkingRecord Create(WorkingRecord workingRecord);
    }
}