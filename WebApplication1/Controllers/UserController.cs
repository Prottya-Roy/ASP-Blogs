using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost("RegisterUser")]
        public async Task<string> RegisterUser(User user)
        {
            return await _userService.RegisterUser(user);
        }

        [HttpPost("LoginUser")]
        public Task<IActionResult> LoginUser(User user)
        {
            return null;
        }

        [HttpGet("GetUser/{Id}")]
        public async Task<User> GetUser(string Id)
        {
            return await _userService.GetUser(Id);
        }

        [HttpPatch("UpdateUser/{Id}")]
        public Task<User> UpdateUser(User user, string Id)
        {
            return null;
        }
        [HttpGet("UserNameAvailable/{userName}")]
        public async Task<bool> UserNameAvailable(string userName)
        {
            return await _userService.UserNameAvailable(userName);
        }

        [HttpGet("EmailAvailable/{email}")]
        public async Task<bool> EmailAvailable(string email)
        {
            return await _userService.UserNameAvailable(email);
        }
    }
}
