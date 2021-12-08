using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User CreateUser(User user);
        User GetUserById(int id);
        User RemoveUser(int id);
        User UpdateUser(User user);
        User GetUserByName(string name);
    }
}