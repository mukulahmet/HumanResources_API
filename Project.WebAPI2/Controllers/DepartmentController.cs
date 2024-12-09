using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.BLL.Models.DTO_s.Department;
using Project.BLL.Models.DTO_s.Job;
using Project.BLL.Services;
using Project.BLL.Services.Abstracts;

namespace Project.WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Department/GetDepartments
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> ListAllDepartmentsAsync()
        {
            var departments = await _departmentService.GetAllDepartmentAsync();
            return Ok(departments);
        }

        // GET: api/Department/FindDepartment{5}
        [HttpGet("FindDepartment/{id}")]
        public async Task<IActionResult> FindDepartmentAsync(int id)
        {
            var department = await _departmentService.FindDepartmentAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // POST: api/Department/AddDepartment
        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartmentAsync(AddDepartmentDTO addDepartment)
        {
            var createdDepartment = await _departmentService.AddDepartmentAsync(addDepartment);
            return Ok(createdDepartment);
        }

        // PUT: api/Department/UpdateDepartmemt{5}
        [HttpPut("UpdateDepartment/{id}")]
        public async Task<IActionResult> UpdateDepartmentAsync(int id, UpdateDepartmentDTO updateDepartment)
        {
            var result = await _departmentService.UpdateDepartmentAsync(id, updateDepartment);
            return Ok(result);
        }

        // DELETE: api/Department/DeleteDepartment{5}
        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartmentAsync(int id)
        {
            var department = await _departmentService.DeleteDepartmentAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }
    }
}
