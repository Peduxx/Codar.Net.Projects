using System.Collections.Generic;
using System.Threading.Tasks;
using Codar.Net.Users.Controllers.Models.Request;
using Codar.Net.Users.Models;
using Codar.Net.Users.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Codar.Net.Users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserLoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var token = _userService.Login(loginRequest);

            return Ok(token);
        }
    }
}
