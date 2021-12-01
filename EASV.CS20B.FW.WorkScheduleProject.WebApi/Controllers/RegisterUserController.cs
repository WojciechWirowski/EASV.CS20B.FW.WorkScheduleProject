using EASV.CS20B.FW.WorkScheduleProject.Database.Security.Authentication;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi.Controllers
{
    [Route("api/[controller]")]
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

            if (_userAuthenticator.CreateUser(username, password))
            {
                //Authentication succesful
                return Ok();
            }
            else
            {
                return Problem("Could not create user with name: " + username);
            }
        }
    }
}