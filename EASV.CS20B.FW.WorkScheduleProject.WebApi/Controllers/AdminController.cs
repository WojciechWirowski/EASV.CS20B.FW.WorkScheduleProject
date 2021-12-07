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
        //I dont know if this class is necessary
        public AdminController(IUserService productService) {}
    }
}