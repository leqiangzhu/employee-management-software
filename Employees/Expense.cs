using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public enum ExpenseCategory { Travel, Meals, Lodging, Conference, Misc }

    [Serializable]
    public class Expense
    {
        #region Data members / properties
        public DateTime Date { get; set; } = DateTime.Today;
        public ExpenseCategory Category { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        #endregion

        #region Constructors
        public Expense() { }

        public Expense(DateTime expDate, ExpenseCategory category, string description, double amount)
        {
            Date = expDate;
            Category = category;
            Description = description;
            Amount = amount;
        }
        #endregion
    }
}
