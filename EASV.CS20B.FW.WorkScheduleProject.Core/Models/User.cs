namespace EASV.CS20B.FW.WorkScheduleProject.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public byte[]? PasswordHash { get; set; }
        public string Role { get; set; }
        public byte[] PasswordSalt { get; set; }
    }

    public enum Role
    {
        Admin,
        Employee
    }
}