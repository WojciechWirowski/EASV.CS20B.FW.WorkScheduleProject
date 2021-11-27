using System.Collections.Generic;
using System.IO;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Services
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository userRepository)
        {
            _repo = userRepository ?? throw new InvalidDataException("The Repository can not be null");
        }

        public List<User> GetUsers()
        {
            return _repo.GetUsers();
        }

        public User CreateUser(User user)
        {
            return _repo.CreateUser(user);
        }

        public User GetUserById(int id)
        {
            return _repo.GetUserById(id);
        }

        public User RemoveUser(int id)
        {
            return _repo.RemoveUser(id);
        }

        public User UpdateUser(User user)
        {
            return _repo.UpdateUser(user);
        }
    }
}