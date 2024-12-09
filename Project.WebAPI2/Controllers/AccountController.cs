using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Models.DTO_s.Password;
using Project.Models.Concrete;

namespace Project.WebAPI2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;

		public AccountController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpPost("GeneratePasswordSetToken")]
		public async Task<IActionResult> GeneratePasswordSetToken([FromBody] string email)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user == null)
			{
				return NotFound();
			}

			var token = await _userManager.GeneratePasswordResetTokenAsync(user);
			return Ok(new { Token = token });
		}

		[HttpPost("SetPassword")]
		public async Task<IActionResult> SetPassword([FromBody] ResetPasswordModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				return NotFound();
			}

			var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
			if (result.Succeeded)
			{
				return Ok("Password set successfully.");
			}

			return BadRequest(result.Errors);
		}
	}
}
