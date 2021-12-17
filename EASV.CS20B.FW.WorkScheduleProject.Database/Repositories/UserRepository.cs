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
        //constructor creates the database
        public UserRepository(ScheduleApplicationContext ctx)
        {
            _ctx = ctx;
        }
        //gets all users
        public List<User> GetUsers()
        {
            var selectQuery = _ctx.Users.Select(userEntity => new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Role = userEntity.Role
            });
            return selectQuery.ToList();
        }
        //creates users
        public User CreateUser(User user)
        {
            UserEntity userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,
                Password = user.Password,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };
            _ctx.Users.Add(userEntity);
            _ctx.SaveChanges();
            return user;
        }
        //gets user by id
        public User GetUserById(int id)
        {
            return _ctx.Users.Select(userEntity => new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Role = userEntity.Role,
                Password = userEntity.Password,
                PasswordHash = userEntity.PasswordHash,
                PasswordSalt = userEntity.PasswordSalt
            }).FirstOrDefault(u => u.Id == id);
        }
        //gets user by name
        public User GetUserByName(string name)
        {
            return _ctx.Users.Select(userEntity => new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Role = userEntity.Role,
                Password = userEntity.Password,
                PasswordHash = userEntity.PasswordHash,
                PasswordSalt = userEntity.PasswordSalt
            }).FirstOrDefault(u => u.Name == name);
        }
        //deletes user by id
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
        //updates user
        public User UpdateUser(User user)
        {
            var oldUser = GetUserById(user.Id);
            var entity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,
                // here is a problem 
                // because this way only update the password. but not generate new hash..
                Password = user.Password,
                PasswordHash = oldUser.PasswordHash,
                PasswordSalt = oldUser.PasswordSalt
            };
            _ctx.Users.Update(entity);
            _ctx.SaveChanges();
            return user;
        }
    }
}