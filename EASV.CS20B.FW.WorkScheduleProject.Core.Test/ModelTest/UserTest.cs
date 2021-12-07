using System;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using Xunit;

namespace EASC.CS20B.FW.WorkScheduleProject.ModelTest
{
    public class UserTest
    {
         #region Initial
        
        /// <summary>
        /// Test User can be initialized
        /// if the object is not null.
        /// then that means we instantiation the object.
        /// </summary>
        [Fact]
        public void User_CanBeInitialized()
        {
            var user = new User();
            Assert.NotNull(user);
        }

        
        /// <summary>
        /// Test the object User have property Id.
        /// And can be assigned a value as int.
        /// </summary>
        [Fact]
        public void User_ShouldHaveId()
        {
            var user = new User()
            {
                Id = 1
            };
            Assert.Equal(1,user.Id);

        }

        /// <summary>
        /// Test about have the name property.
        /// and can be assigned a value as string.
        /// </summary>
        [Fact]
        public void User_ShouldHaveName()
        {
            var user = new User()
            {
                Name = "UserName"
            };
            Assert.Equal("UserName",user.Name);
        }
        
        
        /// <summary>
        /// Test about user should have property string password and it can be null.
        /// </summary>
        [Fact]
        public void User_ShouldHavePassword_CanBeNull()
        {
            var user = new User()
            {
                Password = null
            };
            Assert.Null(user.Password);
            user.Password = "";
            Assert.True(user.Password is string);

        }

        [Fact]
        public void User_ShouldHaveRole_AsEnum()
        {
            var user = new User()
            {
                Role = Role.Admin.ToString()
            };
            user.Role = Role.Employee.ToString();
            Assert.Equal(Role.Employee.ToString(), user.Role.ToString());
        }
        
        #endregion
    }
}