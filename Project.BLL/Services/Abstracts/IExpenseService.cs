using Project.BLL.Models.DTO_s.AppUser;
using Project.BLL.Models.DTO_s.Expense;
using Project.BLL.Models.ViewModels.Expense;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services.Abstracts
{
	public interface IExpenseService
	{
		Task<Expense> AddNewExpenseAsync(AddExpenseDTO expense);
		Task<int> UpdateExpenseAsync(UpdateExpenseDTO expense, int expenseID);
		Task<bool> DeleteExpenseAsync(int id);
		Task<Expense> FindExpenseAsync(int id);	
		Task<IEnumerable<ListExpenseDTO>> GetAllExpensesAsync();

		Task<IEnumerable<ListExpenseDirectorVM>> GetCompanyExpensesAsync(int companyID);

	}
}
