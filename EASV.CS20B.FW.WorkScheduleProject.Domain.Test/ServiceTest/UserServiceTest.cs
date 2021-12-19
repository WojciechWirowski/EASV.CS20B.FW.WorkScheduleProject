using System.Collections.Generic;
using System.IO;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.Domain.IRepositories;
using EASV.CS20B.FW.WorkScheduleProject.Domain.Services;
using Moq;
using Xunit;

namespace EASV.CS20B.FW.WorkScheduleProject.Domain.Test.ServiceTest
{
    public class UserServiceTest
    {
   private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService _userService;
        private readonly List<User> _users;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);

            _users = new List<User>();
            _users.Add(new User()
            {
                Id = 1,
                Name = "User1"
            });
            _users.Add(new User()
            {
                Id = 2,
                Name = "User2"
            });
            _users.Add(new User()
            {
                Id = 3,
                Name = "User3"
            });
        }

        #region Initialization Test
    
        [Fact]
        public void UserService_CanBeInitialized()
        {
            // Assert
            Assert.NotNull(_userService);
        }
    
        [Fact]
        public void UserService_ImplementInterface()
        {
            // Assert
            Assert.True(_userService is IUserService);
            
        }
        #endregion

        #region Dependency Injection Test

        [Fact]
        public void UserService_DI_IRepository_NotNull()
        {
            // Assert
            Assert.NotNull(_userRepositoryMock);
            Assert.NotNull(_userService);
            
        }

        [Fact]
        public void UserService_DI_IRepository_IsNull_ThrowsException()
        {
            // Arrange
            // Act
            var invalidDataException = Assert.Throws<InvalidDataException>(() => new UserService(null));
            
            // Assert
            Assert.Equal("The Repository can not be null", invalidDataException.Message);
        }

        #endregion

        #region Service Test

        [Fact]
        public void UserService_Add_ParameterUser_ReturnUser()
        {
            // Arrange
            var user = new User()
            {
                Id = 4,
                Name = "User4"
            };
            _userRepositoryMock.Setup(repository => repository.CreateUser(user))
                .Returns(user);
            
            // Act
            var actual = _userService.CreateUser(user);
            
            // Assert
            Assert.Equal(user,actual);
        }


        [Fact]
        public void UserService_GetAll_NoParameter_ReturnListOfUser()
        {
            // Arrange
            _userRepositoryMock.Setup(repository => repository.GetUsers())
                .Returns(_users);
            // Act
            var actual = _userService.GetUsers();
            // Assert
            Assert.Equal(_users,actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void UserService_GetById_ParameterId_ReturnUser(int id)
        {
            // Arrange
            var find = _users.Find(user => user.Id == id);
            _userRepositoryMock.Setup(repository => repository.GetUserById(id))
                .Returns(find);
            // Act
            var actual = _userService.GetUserById(id);
            // Assert
            Assert.Equal(find,actual);
            
        }

        [Theory]
        [InlineData(1, "name1")]
        [InlineData(2, "name2")]
        [InlineData(3, "name3")]
        public void UserService_Modify_ParameterUser_ReturnUser(int id, string name)
        {
            // Arrange
            var changeUser = new User()
            {
                Id = id,
                Name = name
            };
            
            _userRepositoryMock.Setup(repository => repository.UpdateUser(changeUser))
                .Returns(changeUser);
            // Act
            var actual = _userService.UpdateUser(changeUser);
            // Assert
            Assert.Equal(changeUser,actual);
            
        }

        [Fact]
        public void UserService_Delete_ParameterUser_ReturnUser()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = "name"
            };
            _userRepositoryMock.Setup(repository => repository.GetUserById((int) user.Id))
                .Returns(user);
            _userRepositoryMock.Setup(repository => repository.RemoveUser((int) user.Id))
                .Returns(user);
            // Act
            var actual = _userService.RemoveUser((int) user.Id);
            // Assert
            Assert.Equal(user,actual);
        }
        
        
        #endregion
    }
}