namespace EASV.CS20B.FW.WorkScheduleProject.Database.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}