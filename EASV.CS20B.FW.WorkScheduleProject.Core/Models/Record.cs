using System;

namespace EASV.CS20B.FW.WorkScheduleProject.Core.Models
{
    public class Record
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TimeIn { get; set; }
        public int TimeOut { get; set; }
        public int UserId { get; set; }
    }
}