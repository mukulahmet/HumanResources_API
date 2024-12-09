using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Models.DTO_s;
using Project.BLL.Models.DTO_s.Company;
using Project.BLL.Services.Abstracts;

namespace Project.WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("SirketleriGetir")]
        public async Task<IActionResult> ListAllCompanies()
        {
            var companies = await _companyService.GetAllCompanyAsync();
            return Ok(companies);
        }

        [HttpGet("SirketSayisi")]
        public async Task<int> CompanyCount()
        {
            var companies = await _companyService.GetAllCompanyAsync();

            return companies.Count();
        }


		[HttpPost("SirketEkle")]
        public async Task<IActionResult> AddCompany(AddCompanyDTO addCompany)
        {
            return Ok(await _companyService.AddCompanyAsync(addCompany));
        }

        [HttpDelete("SirketSil/{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            return Ok(await (_companyService.DeleteCompanyAsync(id)));
        }

        [HttpGet("IncludeUserVeDepartment/{id}")]
        public async Task<IActionResult> FindCompanyWithID(int id)
        {
            return Ok(await _companyService.FindCompanyWithID(id));
        }

        [HttpPut("SirketGuncelle/{id}")]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyDTO updateCompany, int id)
        {
            return Ok(await _companyService.UpdateCompanyAsync(updateCompany, id));
        }

        [HttpGet("SirketGetir/{id}")]
        public async Task<IActionResult> GetCompanyDetail(int id)
        {
            return Ok(await _companyService.GetCompanyDetailAsync(id));
        }
    }
}
