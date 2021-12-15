using System;
using System.Security.Authentication;
using EASV.CS20B.FW.WorkScheduleProject.Database.Security.Authentication;
using EASV.CS20B.FW.WorkScheduleProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]

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
        public IActionResult Post([FromBody] LoginInput model)
        {
            try
            {
                string userToken;
                string role;
                if (_userAuthenticator.Login(model.Username, model.Password, out userToken, out role))
                {
                    //Authentication successful
                    return Ok(new
                    {
                        username = model.Username,
                        token = userToken,
                        role = role
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Contact administrator");
            }

            return Unauthorized("Unknown username and password combination");
        }
    }
}