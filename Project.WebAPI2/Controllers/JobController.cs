using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Models.DTO_s.Job;
using Project.BLL.Services;
using Project.BLL.Services.Abstracts;
using Project.Models.Concrete;

namespace Project.WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("IsleriGetir")]
        public async Task<IActionResult> ListAllJobAsync()
        {
            var jobs = await _jobService.GetAllJobAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindJobAsync(int id)
        {
            var job = await _jobService.FindJobAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> AddJobAsync(AddJobDTO job)
        {
            if (job == null)
            {
                return BadRequest();
            }
            var createdJob = await _jobService.AddJobAsync(job);
            return Ok(createdJob);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobAsync(int id, UpdateJobDTO job)
        {
            if (job == null)
            {
                return BadRequest();
            }
            var result = await _jobService.UpdateJobAsync(job,id);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobAsync(int id)
        {
            var result = await _jobService.DeleteJobAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
