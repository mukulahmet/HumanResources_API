using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.BLL.Models.DTO_s.Job;
using Project.Models.Concrete;

namespace Project.BLL.Services.Abstracts
{
    public interface IJobService
    {
        Task<IEnumerable<ListJobDTO>> GetAllJobAsync();
        Task<Job> AddJobAsync(AddJobDTO job);
        Task<bool> DeleteJobAsync(int id);
        Task<Job> FindJobAsync(int id);
        Task<int> UpdateJobAsync(UpdateJobDTO job,int id);
    }
}
