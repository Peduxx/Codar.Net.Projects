using System.Collections.Generic;
using Codar.Net.Users.Controllers.Models.Request;
using Codar.Net.Users.Models;
using Codar.Net.Users.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Codar.Net.Users.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "AdminUser")]
        public IActionResult CreateUser([FromBody] UserRequest userRequest)
        {
            _userService.Save(userRequest);

            return StatusCode(202, "User has been sucessfully created!");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ShowUsers()
        {
            IEnumerable<User> users = _userService.GetAll();

            return StatusCode(202, users);
        }
        
        [HttpPut]
        [Route("[action]/{id:int}")]
        public IActionResult EditUser([FromRoute] int id, [FromBody] UserRequest updateUserRequest)
        {
            _userService.EditUser(id, updateUserRequest);
            
            return StatusCode(202, "User updated!");
        }
        
        [HttpDelete]
        [Route("[action]/{id:int}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            _userService.DeleteUser(id);

            return StatusCode(202, "User deleted!");
        }
    }
}