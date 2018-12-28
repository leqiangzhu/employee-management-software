using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Employees
{
    public partial class CompExpenses : Page
    {
        #region Data members
        private bool isInsertMode = false;
        private bool isBeingEdited = false;
        private Employee emp;
        #endregion

        #region Constructors
        public CompExpenses()
        {
            InitializeComponent();
        }

        // Custom constructor to pass Employee object
        public CompExpenses(object data) : this()
        {
            // Bind context to Employee
            this.DataContext = data;

            if (data is Employee)
            {
                emp = (Employee)data;

                // Bind data grid to Employee expenses
                dgExpenses.ItemsSource = new ObservableCollection<Expense>(emp.Expenses);
            }
        }
        #endregion

        #region Event handlers
        private void DgExp_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            Expense exp = e.Row.DataContext as Expense;

            if (isInsertMode)
            {
                Expense expense = new Expense();

                expense.Date = exp.Date;
                expense.Category = exp.Category;
                expense.Description = exp.Description;
                expense.Amount = exp.Amount;
                emp.Expenses.Add(expense);
            }
        }

        private void DgExp_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && !isBeingEdited)
            {
                if (dgExpenses.SelectedItems.Count > 0)
                {
                    foreach (var row in dgExpenses.SelectedItems)
                    {
                        Expense expense = row as Expense;
                        emp.Expenses.Remove(expense);
                    }
                }
            }
        }

        private void DgExp_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            isInsertMode = true;
        }

        private void DgExp_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            isBeingEdited = true;
        }
        #endregion
    }
}
