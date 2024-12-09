using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.DTO_s.Expense
{
	public class AddExpenseDTO
	{
		public ExpenseType ExpenseType { get; set; } = ExpenseType.TravelExpense;
		public decimal Amount { get; set; }
		public Currency Currency { get; set; } = Currency.TL;
		public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Pending;
		public string? FilePath { get; set; }

		public DateTime? CreationDate { get; set; } = DateTime.Now;
		public Status? Status { get; set; }= Project.Models.Enums.Status.Active;


		public int AppUserID { get; set; }
		
	}
}
