using EASV.CS20B.FW.WorkScheduleProject.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }
    }
}