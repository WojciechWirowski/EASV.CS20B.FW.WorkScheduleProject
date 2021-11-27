using System.Collections.Generic;
using System.Linq;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Database.Entities;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ScheduleApplicationContext _ctx;
        private List<UserEntity> _users = new List<UserEntity>();

        public UserRepository(ScheduleApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public List<User> GetUsers()
        {
            var selectQuery = _ctx.Users.Select(userEntity => new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name
            });
            return selectQuery.ToList();
        }

        public User CreateUser(User user)
        {
            UserEntity userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name
            };
            _ctx.Users.Add(userEntity);
            _ctx.SaveChanges();
            return user;
        }

        public User GetUserById(int id)
        {
            return _ctx.Users.Select(userEntity => new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name
            }).FirstOrDefault(u => u.Id == id);
        }

        public User RemoveUser(int id)
        {
            var entity = _ctx.Users.Remove(new UserEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new User
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public User UpdateUser(User user)
        {
            var entity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name
            };
            _ctx.Users.Update(entity);
            _ctx.SaveChanges();
            return user;
        }
    }
}