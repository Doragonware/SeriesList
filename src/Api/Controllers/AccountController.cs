using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Dtos;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// <see cref="IAuthService"/> to use for managing series.
        /// </summary>
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;


        public AccountController(IAuthService authService, IConfiguration configuration)
        {
            if (authService == null)
                throw new ArgumentNullException(nameof(authService));

            _authService = authService;
            _configuration = configuration;
        }


        [Route("[controller]/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            userRegisterDto.Username = userRegisterDto.Username.ToLower();

            if (await _authService.UserExists(userRegisterDto.Username))
                return BadRequest("Username already exists");

            User userToCreate = new User
            {
                Username = userRegisterDto.Username
            };

            await _authService.Register(userToCreate, userRegisterDto.Password);

            return Ok();
        }

        [Route("[controller]/login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            User user = await _authService.Login(userLoginDto.Username.ToLower(), userLoginDto.Password);

            if (user == null)
                return Unauthorized();

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

    }
}