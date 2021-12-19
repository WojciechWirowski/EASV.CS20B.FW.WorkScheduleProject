using EASV.CS20B.FW.WorkScheduleProject.Security.Authentication;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IUserAuthenticator _userAuthenticator;

        //creates userAuthenticator and logger
        public RegisterUserController(IUserAuthenticator userAuthenticator, ILogger<RegisterUserController> logger)
        {
            _userAuthenticator = userAuthenticator;
        }
        //HttpPost request to create a user
        // POST: api/Login
        [Route(nameof(Post))]
        [HttpPost]
        public ActionResult<UserDto> Post([FromBody] RegisterUser model)
        {
            string username = model.Username;
            string password = model.Password;
            string role = model.Role;

            if (_userAuthenticator.CreateUser(username, password, role))
            {
                //Authentication succesful
                return Ok(new UserDto()
                {
                    Name = username
                });
            }
            else
            {
                return Problem("Could not create user with name: " + username);
            }
        }
    }
}