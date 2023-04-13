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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserToken))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> LoginUser(User user)
        {
            UserToken userResult = await _userService.LoginUser(user);
            if (userResult== null)
            {
                return BadRequest("Invalid Username");
            }
            else if(userResult.Token== null) { return NotFound(userResult._id); }
            else { return Ok(userResult); }
            
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
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type=typeof(string))]
        public async Task<IActionResult> UserNameAvailable(string userName)
        {
            string check =  await _userService.UserNameAvailable(userName);
            if(check== "Username available")
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(check);
            }
        }

        [HttpGet("EmailAvailable/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> EmailAvailable(string email)
        {
            string check= await _userService.EmailAvailable(email);
            if (check == "Email available")
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(check);
            }
        }
    }
}
