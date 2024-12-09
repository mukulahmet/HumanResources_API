using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Models.DTO_s.Expense;
using Project.BLL.Services.Abstracts;
using Project.Models.Concrete;

namespace Project.WebAPI2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpenseController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IExpenseService _expenseService;

		public ExpenseController(IMapper mapper, IExpenseService expenseService)
		{
			_mapper = mapper;
			_expenseService = expenseService;
		}

		[HttpPost("ExpenseEkle")]
		public async Task<IActionResult> AddExpense(AddExpenseDTO addExpenseDTO)
		{
			var expense = await _expenseService.AddNewExpenseAsync(addExpenseDTO);

			if (expense == null)
			{
				return BadRequest("olusum basarisiz.");
			}

			return Ok(expense);
		}

		[HttpPut("ExpenseGuncelle/{id}")]
		public async Task<IActionResult> UpdateExpense(UpdateExpenseDTO updateExpenseDTO, int id)
		{
			
			return Ok(await _expenseService.UpdateExpenseAsync(updateExpenseDTO,id));
		}

		[HttpDelete("ExpenseSil/{id}")]
		public async Task<IActionResult> DeleteExpense(int id)
		{
			var expense = await _expenseService.DeleteExpenseAsync(id);

			if (expense == false)
			{
				return BadRequest("silme basarisiz.");
			}

			return Ok(expense);
		}

		[HttpGet("ExpenseGetir/{id}")]
		public async Task<IActionResult> GetExpense(int id)
		{
			var expense = await _expenseService.FindExpenseAsync(id);

			if (expense == null)
			{
				return BadRequest("getirme basarisiz.");
			}

			return Ok(expense);
		}

		[HttpGet("ExpenseListele")]
		public async Task<IActionResult> GetExpenses()
		{
			var expenses = await _expenseService.GetAllExpensesAsync();

			return Ok(expenses);
		}

		[HttpGet("SirketeAitExpenseler/{companyID}")]
		public async Task<IActionResult> GetCompanyExpenses(int companyID)
		{
			return Ok(await _expenseService.GetCompanyExpensesAsync(companyID));
		}

        [HttpGet("ExpenseBul/{expenseID}")]
        public async Task<IActionResult> FindExpense(int expenseID)
        {
            var expense = await _expenseService.FindExpenseAsync(expenseID);

            if (expense == null)
            {
                return BadRequest("bulma basarisiz.");
            }

            return Ok(expense);
        }


    }
}
