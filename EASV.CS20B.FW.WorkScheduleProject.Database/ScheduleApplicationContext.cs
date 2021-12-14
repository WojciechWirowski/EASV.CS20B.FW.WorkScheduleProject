using EASV.CS20B.FW.WorkScheduleProject.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EASV.CS20B.FW.WorkScheduleProject.Database
{
    public class ScheduleApplicationContext : DbContext
    {
        public ScheduleApplicationContext(DbContextOptions<ScheduleApplicationContext> opt) : base(opt)
        {
        }
        //adding the models to the DBContext
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<RecordEntity> Records { get; set; }
        public virtual DbSet<WorkingScheduleEntity> WorkingSchedules { get; set; }
    }
}