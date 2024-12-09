using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstract;
using Project.Models.Concrete;

namespace Project.DAL.Repositories.Concrete
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
