using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;

namespace EASV.CS20B.FW.WorkScheduleProject.Core.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(int id);
        User CreateUser(User user);
        User RemoveUser(int id);
        User UpdateUser(User user);
    }
}