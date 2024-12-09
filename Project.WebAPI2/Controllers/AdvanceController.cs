using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Models.DTO_s.Advance;
using Project.BLL.Services.Abstracts;
using Project.Models.Concrete;

namespace Project.WebAPI2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdvanceController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IAdvanceService _advanceService;
        private readonly UserManager<AppUser> _userManager;

        public AdvanceController(IMapper mapper, IAdvanceService advanceService, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _advanceService = advanceService;
            _userManager = userManager;
        }

        [HttpPost("AdvanceEkle")]
		public async Task<IActionResult> AddAdvance(AddAdvanceDTO addAdvanceDTO)
		{
			var user = await _userManager.FindByIdAsync(addAdvanceDTO.AppUserID.ToString());

			// Advance Amount can't be bigger than userSalary * 3
			if(addAdvanceDTO.Amount > (user.Salary * 3))
			{
				return BadRequest($"Advance Amount Can't Be Bigger Than {(user.Salary * 3)}");
			}

			var advance = await _advanceService.AddNewAdvanceAsync(addAdvanceDTO);

			if (advance == null)
			{
				return BadRequest("olusum basarisiz.");
			}

			return Ok(advance);
		}

		[HttpPut("AdvanceGuncelle/{id}")]
		public async Task<IActionResult> UpdateAdvance(UpdateAdvanceDTO updateAdvanceDTO, int id)
		{
			var advance = await _advanceService.UpdateAdvanceAsync(updateAdvanceDTO, id);

			if (advance == 0)
			{
				return BadRequest("guncelleme basarisiz.");
			}

			return Ok(advance);
		}

		[HttpDelete("AdvanceSil/{id}")]
		public async Task<IActionResult> DeleteAdvance(int id)
		{
			var advance = await _advanceService.DeleteAdvanceAsync(id);

			if (advance == false)
			{
				return BadRequest("silme basarisiz.");
			}

			return Ok(advance);
		}

		[HttpGet("AdvanceGetir/{id}")]
		public async Task<IActionResult> GetAdvance(int id)
		{
			var advance = await _advanceService.FindAdvanceAsync(id);

			if (advance == null)
			{
				return BadRequest("bulunamadi.");
			}

			return Ok(advance);
		}

		[HttpGet("AdvanceListele")]
		public async Task<IActionResult> GetAdvances()
		{
			var advances = await _advanceService.GetAllAdvancesAsync();

			return Ok(advances);
		}

		[HttpGet("KullaniciAdvanceleri/{userID}")]
		public async Task<IActionResult> GetUserAdvances(int userID)
		{
			var userAdvances = await _advanceService.FindUserAdvanceAsync(userID);

			return Ok(userAdvances);
		}

		[HttpGet("SirketeAitAdvanceler/{companyID}")]
		public async Task<IActionResult> GetCompanyAdvances(int companyID)
		{
			return Ok(await _advanceService.GetCompanyAdvancesAsync(companyID));
		}


	}
}
