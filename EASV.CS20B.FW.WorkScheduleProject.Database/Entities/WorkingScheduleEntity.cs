namespace EASV.CS20B.FW.WorkScheduleProject.Database.Entities
{
    public class WorkingScheduleEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int WeekDay { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        
    }
}