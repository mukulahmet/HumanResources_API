using Project.BLL.Models.DTO_s;
using Project.BLL.Models.DTO_s.Department;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services.Abstracts
{
    public interface IDepartmentService
    {
        Task<IEnumerable<ListDepartmentDTO>> GetAllDepartmentAsync();
        Task<Department> AddDepartmentAsync(AddDepartmentDTO department);
        Task<bool> DeleteDepartmentAsync(int id);
        Task<Department> FindDepartmentAsync(int id);
        Task<int> UpdateDepartmentAsync(int id, UpdateDepartmentDTO department);
    }
}
