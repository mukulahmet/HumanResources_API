using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Models.DTO_s.Expense;
using Project.BLL.Models.ViewModels.Expense;
using Project.BLL.Services.Abstracts;
using Project.DAL.Repositories.Abstract;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
	public class ExpenseService : IExpenseService
	{
		private readonly IMapper _mapper;
		private readonly IExpenseRepository _expenseRepository;
		public ExpenseService(IMapper mapper, IExpenseRepository expenseRepository)
		{
			_mapper = mapper;
			_expenseRepository = expenseRepository;
		}
		public async Task<Expense> AddNewExpenseAsync(AddExpenseDTO expense)
		{
			Expense expense1 = new Expense();
			_mapper.Map(expense, expense1);
			return await _expenseRepository.AddAsync(expense1);
		}

		public async Task<bool> DeleteExpenseAsync(int id)
		{
			return await _expenseRepository.DeleteAsync(id);
		}

		public async Task<Expense> FindExpenseAsync(int id)
		{
			return await _expenseRepository.FindAsync(id);
		}

		public async Task<IEnumerable<ListExpenseDTO>> GetAllExpensesAsync()
		{
			List<ListExpenseDTO> expenseList = new List<ListExpenseDTO>();
			var expenses = await _expenseRepository.GetAllAsync();
			_mapper.Map(expenses, expenseList);
			return expenseList;
		}

        public async Task<IEnumerable<ListExpenseDirectorVM>> GetCompanyExpensesAsync(int companyID)
        {
            var expenses = await _expenseRepository.ListeleAsync(
				select: x => new ListExpenseDirectorVM { FirstName = x.AppUser.Name, SecondFirstName = x.AppUser.SecondName, LastName = x.AppUser.LastName, SecondLastName = x.AppUser.SecondLastName, Amount = x.Amount, CreationDate = x.CreationDate, Currency = x.Currency.ToString(), ExpenseType = x.ExpenseType.ToString(), ExpenseID = x.ExpenseID, FilePath = x.FilePath },
				where: x => x.AppUser.CompanyID.Equals(companyID) && x.ApprovalStatus == Project.Models.Enums.ApprovalStatus.Pending,
				orderBy: x => x.OrderByDescending(x => x.CreationDate),
				include: x => x.Include(x => x.AppUser)
				);

			return expenses;
        }

        public async Task<int> UpdateExpenseAsync(UpdateExpenseDTO expense, int expenseID)
		{
			var expenseToUpdate = await _expenseRepository.FindAsync(expenseID);
			_mapper.Map(expense, expenseToUpdate);
			return await _expenseRepository.UpdateAsync(expenseToUpdate);
		}
	}
}
