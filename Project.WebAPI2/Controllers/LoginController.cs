using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.BLL.Services.Abstracts;
using Project.Models.Concrete;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebAPI2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IAppUserService _appUserService;
		private readonly IMapper _mapper;
		private IConfiguration _config;
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;


		public LoginController(IAppUserService appUserService, IMapper mapper, IConfiguration config, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_appUserService = appUserService;
			_mapper = mapper;
			_config = config;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
		{
			if (loginDTO == null)
			{
				return BadRequest("Invalid client request");
			}

			var user = await _appUserService.ValidateUserAsync(loginDTO.Email, loginDTO.Password);
			if (user != null)
			{
				var tokenString = GenerateJWT(user);
				return Ok(new LoginResponseDTO { Token = tokenString });
			}
			else
			{
				return Unauthorized();
			}
		}

		[HttpGet("CikisYap")]
		public async Task<bool> SignOut()
		{
			await _signInManager.SignOutAsync();
			return true;
		}

		private string GenerateJWT(AppUser user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


			var userRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault();

			var claims = new List<Claim>
	{
		new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
		new Claim("UserId", user.Id.ToString()),
		new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		new Claim(ClaimTypes.Role, userRole)
	};

			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddHours(8),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}


		public class LoginDTO
		{
			public string Email { get; set; }
			public string Password { get; set; }
		}

		public class LoginResponseDTO
		{
			public string Token { get; set; }
		}
	}
}