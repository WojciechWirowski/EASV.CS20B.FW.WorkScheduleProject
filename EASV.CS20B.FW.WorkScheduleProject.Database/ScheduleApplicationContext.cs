using EASV.CS20B.FW.WorkScheduleProject.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EASV.CS20B.FW.WorkScheduleProject.Database
{
    public class ScheduleApplicationContext : DbContext
    {
        public ScheduleApplicationContext(DbContextOptions<ScheduleApplicationContext> opt) : base(opt)
        {
        }
        
        public virtual DbSet<UserEntity> Users { get; set; }
    }
}