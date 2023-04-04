using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models;
using WebApplication1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser(User user)
        {
            UserToken userResult = await _userService.RegisterUser(user);
            if (userResult != null)
            {
              return Ok(userResult);
            }
            else { return BadRequest(); }
        }

        [HttpPost("LoginUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginUser(User user)
        {
            UserToken userResult = await _userService.LoginUser(user);
            if (userResult!= null)
            {
                return Ok(userResult);
            }
            else { return BadRequest(); }
            
        }

        [Authorize]
        [HttpGet("GetUser/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(string Id)
        {
            User user= await _userService.GetUser(Id);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }


        }

        [Authorize]
        [HttpPatch("UpdateUser/{Id}")]
        public Task<User> UpdateUser(User user, string Id)
        {
            return null;
        }


        [HttpGet("UserNameAvailable/{userName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserNameAvailable(string userName)
        {
            bool check =  await _userService.UserNameAvailable(userName);
            if( check)
            {
                return Ok(check);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("EmailAvailable/{email}")]
        public async Task<bool> EmailAvailable(string email)
        {
            return await _userService.UserNameAvailable(email);
        }
    }
}
