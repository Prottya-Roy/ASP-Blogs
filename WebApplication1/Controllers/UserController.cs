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
        public async Task<User> RegisterUser(User user)
        {
            return await _userService.RegisterUser(user);
        }

        [HttpPost("LoginUser")]
        public Task<IActionResult> LoginUser(User user)
        {
            return null;
        }

        [HttpGet("GetUser")]
        public async Task<User> GetUser(string Id)
        {
            return await _userService.GetUser(Id);
        }

        [HttpPatch("UpdateUser")]
        public Task<User> UpdateUser(string Id)
        {
            return null;
        }
    }
}
