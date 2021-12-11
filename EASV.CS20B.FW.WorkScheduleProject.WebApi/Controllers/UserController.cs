using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }
        
        [HttpGet]
        public ActionResult<UserDto[]> GetAllUsers()
        {
            try
            {
                var users = _service.GetUsers();
                var userDtoList = new List<UserDto>();
                foreach (var user in users)
                {
                    userDtoList.Add(new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Role = user.Role
                    });
                }   
                return Ok(userDtoList.ToArray());

            }
            catch (Exception)
            {
                return StatusCode(500, "System problems occured");
            }
            
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public User GetById(int id)
        {
            return _service.GetUserById(id);
        }
        
        // [HttpPost]
        // public ActionResult<User> CreateUser([FromBody] CreateUserDto dto)
        // {
        //     try
        //     {
        //         var user = new User
        //         {
        //             Id = dto.Id,
        //             Name = dto.Name
        //         };
        //         return Ok($"User{_service.CreateUser(user)} created...");
        //     }
        //     catch (ArgumentException argumentException)
        //     {
        //         return BadRequest(argumentException.Message);
        //     }
        //     catch (Exception e)
        //     {
        //         return StatusCode(500, e.Message);
        //     }
        // }
        
        [Authorize]
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        { 
            _service.RemoveUser(id);
        }

        [Authorize]
        [HttpPut]
        public void UpdateUser(CreateUserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Password = userDto.Password,
                Role = userDto.Role
            };
            _service.UpdateUser(user);
        }
        }
    }