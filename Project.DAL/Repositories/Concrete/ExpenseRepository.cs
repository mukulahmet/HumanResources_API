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
	public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
	{
		public ExpenseRepository(AppDBContext dbContext) : base(dbContext)
		{
		}
	}
}
