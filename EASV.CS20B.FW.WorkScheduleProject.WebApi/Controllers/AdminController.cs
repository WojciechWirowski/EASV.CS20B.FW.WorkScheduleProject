using System;
using System.Collections.Generic;
using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using EASV.CS20B.FW.WorkScheduleProject.Core.Models;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Controllers{
    
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _service;

        public AdminController(IUserService productService)
        {
            _service = productService;
        }
        
        [HttpGet]
        public ActionResult<UserDto[]> GetAllProduct_ReturnArray()
        {
            try
            {
                var products = _service.GetUsers();
                var productDtos = new List<UserDto>();
                foreach (var product in products)
                {
                    productDtos.Add(new UserDto()
                    {
                        Id = product.Id,
                        Name = product.Name
                    });
                }   
                return Ok(productDtos.ToArray());

            }
            catch (Exception e)
            {
                return StatusCode(500, "System problems occured");
            }
            
        }

        [HttpGet("{id}")]
        public User GetById(int id)
        {
            return _service.GetUserById(id);
        }

        [HttpPost]
        public ActionResult<User> CreateProduct([FromBody] UserDto dto)
        {
            try
            {
                var user = new User
                {
                    Id = dto.Id,
                    Name = dto.Name
                };
                return Ok($"User{_service.CreateUser(user)} created...");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        { 
            _service.RemoveUser(id);
        }

        [HttpPut]
        public void UpdateUser(User user)
        { 
            _service.UpdateUser(user);
        }

    }
}