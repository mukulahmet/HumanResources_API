using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.BLL.Models.DTO_s.Job;
using Project.BLL.Services.Abstracts;
using Project.DAL.Repositories.Abstract;
using Project.DAL.Repositories.Concrete;
using Project.Models.Concrete;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project.BLL.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<Job> AddJobAsync(AddJobDTO job)
        {
            Job newJob = new Job();
            _mapper.Map(job, newJob);

            return await _jobRepository.AddAsync(newJob);
        }

        public async Task<bool> DeleteJobAsync(int id)
        {
            return await _jobRepository.DeleteAsync(id);
        }

        public async Task<Job> FindJobAsync(int id)
        {
            return await _jobRepository.FindAsync(id);
        }

        public async Task<IEnumerable<ListJobDTO>> GetAllJobAsync()
        {
            List<ListJobDTO> jobList = new List<ListJobDTO>();

            var jobs =await _jobRepository.GetAllAsync();
            _mapper.Map(jobs, jobList);
            return jobList;
        }

        public async Task<int> UpdateJobAsync(UpdateJobDTO job,int id)
        {
            var updateJob = await _jobRepository.FindAsync(id);

            updateJob.JobName= job.JobName;

            return await _jobRepository.UpdateAsync(updateJob);
        }


    }
}
