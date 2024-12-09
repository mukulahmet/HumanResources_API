using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstract
{
    public interface ICompanyDepartmentRepository : IBaseRepository<DepartmentCompany>
    {
        Task<bool> HardDelete(DepartmentCompany departmentCompany);
    }
}
