using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.DTO_s.Expense
{
	public class UpdateExpenseDTO
	{
		public decimal Amount { get; set; }
		public Currency Currency { get; set; }
		public ApprovalStatus ApprovalStatus { get; set; }
		public string? FilePath { get; set; }


	}
}
