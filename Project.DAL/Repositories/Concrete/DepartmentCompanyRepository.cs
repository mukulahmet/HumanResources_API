using Project.DAL.Context;
using Project.DAL.Repositories.Abstract;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concrete
{
    public class DepartmentCompanyRepository : BaseRepository<DepartmentCompany>,ICompanyDepartmentRepository
    {
        public DepartmentCompanyRepository(AppDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> HardDelete(DepartmentCompany departmentCompany)
        {
            _dbSet.Remove(departmentCompany);
            

            return await _dbContext.SaveChangesAsync() > 0 ? true:false;
        }
    }
}
