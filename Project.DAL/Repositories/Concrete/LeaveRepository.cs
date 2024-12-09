using Microsoft.EntityFrameworkCore.Query;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstract;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concrete
{
	public class LeaveRepository : BaseRepository<Leave>, ILeaveRepository
	{
		public LeaveRepository(AppDBContext dbContext) : base(dbContext)
		{
		}
	}
}
