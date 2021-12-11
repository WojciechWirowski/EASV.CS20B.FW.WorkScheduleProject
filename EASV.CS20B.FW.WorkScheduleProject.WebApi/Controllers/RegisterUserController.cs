using EASV.CS20B.FW.WorkScheduleProject.Database.Security.Authentication;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IUserAuthenticator _userAuthenticator;
        private readonly ILogger<RegisterUserController> _logger;

        public RegisterUserController(IUserAuthenticator userAuthenticator, ILogger<RegisterUserController> logger)
        {
            _userAuthenticator = userAuthenticator;
            _logger = logger;
        }

        // POST: api/Login
        [Route(nameof(Post))]
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUser model)
        {
            string username = model.Username;
            string password = model.Password;
            string role = model.Role;

            if (_userAuthenticator.CreateUser(username, password, role))
            {
                //Authentication succesful
                return Ok($"User{username} created succesfully");
            }
            else
            {
                return Problem("Could not create user with name: " + username);
            }
        }
    }
}