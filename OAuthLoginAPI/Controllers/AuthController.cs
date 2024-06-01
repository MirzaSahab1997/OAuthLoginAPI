using Microsoft.AspNetCore.Mvc;
using OAuthLoginAPI.Domain.DTOs;
using OAuthLoginAPI.Helper;
using OAuthLoginAPI.Models;

namespace OAuthLoginAPI.Controllers
{
    [Route("OAuth/Api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _secret;

        public AuthController(IConfiguration configuration)
        {
            _secret = configuration.GetValue<string>("JwtSecretKey");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = StaticUserData.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            var token = JwtTokenGenerator.GenerateToken(user, _secret);

            return Ok(new AuthResponse
            {
                Token = token,
                Roles = user.Roles,
                AccessibleRegions = user.AccessibleRegions
            });
        }
    }
}
