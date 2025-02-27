using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrueNote.Application.Models;
using TrueNote.Application.Services;
using TrueNote.Contracts.Responses;

namespace TrueNote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDto request)
        {
            var user = await _authService.RegisterAsync(request.UserName, request.Password);

            if (user is null)
            {
                return BadRequest("Username already exists.");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserDto request)
        {
            var token = await _authService.LoginAsync(request.UserName, request.Password);

            if (token is null)
            {
                return BadRequest("Invalid username or password.");
            }

            return Ok(token);
        }
    }
}
