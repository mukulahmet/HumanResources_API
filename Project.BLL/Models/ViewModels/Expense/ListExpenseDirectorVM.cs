using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.ViewModels.Expense
{
    public class ListExpenseDirectorVM
    {
        public int ExpenseID { get; set; }
        public string ExpenseType { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string? FilePath { get; set; }

        public string FirstName { get; set; }
        public string SecondFirstName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }

        public DateTime? CreationDate { get; set; } //aynı zamanda talep tarihi 
    }
}
