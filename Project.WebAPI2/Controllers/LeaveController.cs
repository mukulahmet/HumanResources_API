using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Models.DTO_s.Leave;
using Project.BLL.Services.Abstracts;

namespace Project.WebAPI2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ILeaveService _leaveService;

		public LeaveController(IMapper mapper, ILeaveService leaveService)
		{
			_mapper = mapper;
			_leaveService = leaveService;
		}
		

		[HttpPost("LeaveEkle")]
		public async Task<IActionResult> AddLeave(AddLeaveDTO addLeaveDTO)
		{
			var leave = await _leaveService.AddNewLeaveAsync(addLeaveDTO);

			if (leave == null)
			{
				return BadRequest("olusum basarisiz.");
			}

			return Ok(leave);
		}

		[HttpPut("LeaveGuncelle/{id}")]
		public async Task<IActionResult> UpdateLeave(UpdateLeaveDTO updateLeaveDTO, int id)
		{
			var leave = await _leaveService.UpdateLeaveAsync(updateLeaveDTO, id);

			if (leave == 0)
			{
				return BadRequest("guncelleme basarisiz.");
			}

			return Ok(leave);
		}

		[HttpDelete("LeaveSil/{id}")]
		public async Task<IActionResult> DeleteLeave(int id)
		{
			var leave = await _leaveService.DeleteLeaveAsync(id);

			if (leave == false)
			{
				return BadRequest("silme basarisiz.");
			}

			return Ok(leave);
		}

		[HttpGet("LeaveListele")]
		public async Task<IActionResult> GetLeaves()
		{
			var leaves = await _leaveService.GetAllLeavesAsync();

			return Ok(leaves);
		}

		[HttpGet("LeaveBul/{id}")]
		public async Task<IActionResult> FindLeave(int id)
		{
			var leave = await _leaveService.FindLeaveAsync(id);

			if (leave == null)
			{
				return NotFound();
			}

			return Ok(leave);
		}

		[HttpGet("SirketeAitIzinler/{companyID}")]
		public async Task<IActionResult> FindCompanyLeaves(int companyID)
		{
			return Ok(await _leaveService.CompanyLeavesAsync(companyID));
		}

	}
}
