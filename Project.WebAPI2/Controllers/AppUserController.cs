using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Models.DTO_s.AppUser;
using Project.BLL.Services;
using Project.BLL.Services.Abstracts;
using Project.Models.Concrete;
using Project.Models.Enums;

namespace Project.WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AppUserController(IAppUserService appUserService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("KullanicilariGoster")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _appUserService.GetAllAppUsersAsync();

            return Ok(users);
        }

        [HttpPost("DirectorEkle")]
        public async Task<IActionResult> AddDirector(AddDirectorDTO addDirectorDTO)
        {

            var appUser = await _appUserService.AddNewDirectorAsync(addDirectorDTO);

            if (appUser == null)
            {
                return BadRequest("olusum basarisiz.");
            }


            return Ok(appUser);
        }

		[HttpPost("EmployeeEkle")]
		public async Task<IActionResult> AddEmployee(AddEmployeeDTO addEmployeeDTO)
		{

			var appUser = await _appUserService.AddNewEmployeeAsync(addEmployeeDTO);

			if (appUser == null)
			{
				return BadRequest("olusum basarisiz.");
			}


			return Ok(appUser);
		}

		[HttpPut("KullaniciGuncelle/{id}")]
        public async Task<IActionResult> UpdateUser(UpdateAppUserDTO appUserDto,int id)
        {
            var result = await _appUserService.UpdateUserAsync(appUserDto,id);

            if (result == 0)
            {
                return BadRequest("update basarisiz.");
            }

            return Ok(result);
        }
        [HttpDelete("KullaniciSil/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _appUserService.DeleteUserAsync(id);

            if (!result)
            {
                return BadRequest("silme basarisiz.");
            }

            return Ok(result);
        }
        [HttpGet("KullaniciBul/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _appUserService.FindUserAsync(id);

            if (user == null)
            {
                return BadRequest("kullanici bulunamadi.");
            }

            return Ok(user);
        }

        [HttpGet("KullaniciDetayBilgileri/{id}")]
        public async Task<IActionResult> GetUserDetail(int id)
        {
            var user = await _appUserService.GetProfileDetailAsync(id);

            if(user == null)
            {
                return BadRequest("User Not Found!");
            }

            return Ok(user);
        }

        [HttpGet("KullaniciRolleri/{id}")]
        public async Task<IActionResult> GetUserRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var role = await _userManager.GetRolesAsync(user);

            return Ok(role);
        }

		[HttpGet("SirketYoneticisiSayisi")]
		public async Task<int> DirectorCount()
		{
            var directors = await _appUserService.GetAllDirectorsAsync();

			return directors.Count();
		}

		[HttpGet("PersonelSayisi")]
		public async Task<int> EmployeeCount()
		{
            var employees = await _userManager.GetUsersInRoleAsync("Employee");

            return employees.Count();
		}

		[HttpGet("SirketYoneticileriniGetir")]
        public async Task<IActionResult> ListDirectors()
        {
            var directors = await _appUserService.GetAllDirectorsAsync();

            return Ok(directors);
        }

        [HttpGet("MailGirisiKullaniciBul/{email}")]
        public async Task<IActionResult> GetUserWithEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return Ok(user);
        }


		[HttpGet("KullaniciBulJobVeMeslek/{id}")]
		public async Task<IActionResult> GetUserWithJobAndDepartment(int id)
		{
			var user = await _appUserService.GetProfileInfoAsync(id);

			if (user == null)
			{
				return BadRequest("kullanici bulunamadi.");
			}

			return Ok(user);
		}




	}
}
