using System.Linq;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Database.Repositories;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;

namespace EASV.CS20B.FW.WorkScheduleProject.Database.Security.Authentication
{
    public interface IUserAuthenticator
    {
        bool Login(string username, string password, out string token);
        bool CreateUser(string username, string password, string role);
    }


    public class UserAuthenticator : IUserAuthenticator
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationHelper _authenticationHelper;

        public UserAuthenticator(IUserRepository userRepository, IAuthenticationHelper authenticationHelper)
        {
            _userRepository = userRepository;
            _authenticationHelper = authenticationHelper;
        }

        public bool Login(string username, string password, out string token)
        {
            User user = _userRepository.GetUserByName(username);

            //Did we not find a user with the given username?
            if (user == null)
            {
                token = null;
                return false;
            }

            //Was the correct password not given?
            if (!_authenticationHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                token = null;
                return false;
            }

            token = _authenticationHelper.GenerateToken(user);
            return true;        }

        public bool CreateUser(string username, string password, string role)
        {
            var user = _userRepository.GetUsers().FirstOrDefault(u => u.Name == username);

            //Does already contain a user with the given username?
            if (user != null)
                return false;

            byte[] salt;
            byte[] passwordHash;
            _authenticationHelper.CreatePasswordHash(password, out passwordHash, out salt);

            user = new User()
            {
                Name = username,
                Role = role,
                PasswordHash = passwordHash,
                PasswordSalt = salt
            };

            _userRepository.CreateUser(user);

            return true;        }
    }

    public class UserAuthConfig
    {
        public IAuthenticationHelper authenticationHelper{get; set;}
        public UserRepository userRepository { get; set; }
    }
}