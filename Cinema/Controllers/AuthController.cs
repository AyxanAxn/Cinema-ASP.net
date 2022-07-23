using Cinema.Models;
using Cinema.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cinema.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // Check if the email already exists
            var user_exists = await _userManager.FindByEmailAsync(requestDto.Email);
            if (user_exists != null)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Email already exists"
                    }
                });
            }
            // Create a user
            var new_user = new IdentityUser()
            {
                Email = requestDto.Email,
                UserName = requestDto.Name
            };
            var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);
            if (!is_created.Succeeded)
            {
                return BadRequest(new AuthResult
                {
                    Errors = new List<string>()
                    {
                        "Server error"
                    },
                    Result = false
                });
            }
            // Create new token
            var token = GenerateNewToken(new_user);
            return Ok(new AuthResult
            {
                Result = true,
                Token = token
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResult { 
                    Errors = new List<string>
                    {
                        "Invalid Payload"
                    },
                    Result = false
                });
            }
            // Check if the user exists
            var existing_user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (existing_user == null)
            {
                return BadRequest(new AuthResult
                {
                    Errors = new List<string>
                    {
                        "Invalid Payload"
                    },
                    Result = false
                });
            }
            var isCorrect = await _userManager.CheckPasswordAsync(existing_user, loginRequest.Password);
            if (!isCorrect)
            {
                return BadRequest(new AuthResult
                {
                    Errors = new List<string>
                    {
                        "Invalid Crefentials"
                    },
                    Result = false
                });
            }
            var jwtToken = GenerateNewToken(existing_user);
            return Ok(new AuthResult
            {
                Token = jwtToken,
                Result = true
            });
        }


        private string GenerateNewToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
