using System;
using EASV.CS20B.FW.WorkScheduleProject.Security.Authentication;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IUserAuthenticator _userAuthenticator;
        //creates user Authenticator
        public LoginController(IUserAuthenticator userAuthenticator)
        {
            _userAuthenticator = userAuthenticator;
        }
        //HttpPost request to login
        [AllowAnonymous]
        [HttpPost(nameof(Post))]
        public ActionResult<UserDto> Post([FromBody] LoginInput model)
        {
            try
            {
                if (_userAuthenticator.Login(model.Username, model.Password, out string userToken, out string role, out int id))
                {
                    //Authentication successful
                    return Ok(new UserDto()
                    {
                        Name = model.Username,
                        Token = userToken,
                        Role = role,
                        Id = id
                    });
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Contact administrator");
            }

            return Unauthorized("Unknown username and password combination");
        }
    }
}