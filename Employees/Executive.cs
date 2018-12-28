using System;
using System.Collections.Generic;

namespace Employees
{
    // Executives have titles
    public enum ExecTitle { VP, CEO, CTO, CFO }

    [System.Serializable]
    public class Executive : Manager
    {
        #region Data members
        public ExecTitle Title { get; set; } = ExecTitle.VP;
        private static string prop2Name = "Title:";
        private static object prop2DefaultValue = new List<string>() { "VP", "CEO", "CTO", "CFO" };
    #endregion

        #region Constructors 
        // Executives start with Gold benefits and 10,000 stock options
        public Executive() : base()
        {
            empBenefits = new GoldBenefitPackage();
            StockOptions = 10000;
        }

		public Executive(string firstName, string lastName, DateTime age, float currPay, 
                         string ssn, int numbOfOpts = 10000, ExecTitle title = ExecTitle.VP)
          : base(firstName, lastName, age, currPay, ssn, numbOfOpts)
        {
			// Title defined by the Executive class.
			Title = title;
            empBenefits = new GoldBenefitPackage();
		}
        #endregion

        #region Class methods
        public override void DisplayStats()
		{
			base.DisplayStats();
			Console.WriteLine("Executive Title: {0}", Title);
		}

        // Change Role line to include title
        public override string Role { get { return base.Role + ", " + Title; } }

        // Executives get an extra 1000 bonus and 10,000 stock options on promotion
        public override void GivePromotion()
        {
            base.GivePromotion();
            GiveBonus(1000);
            StockOptions += 10000;
        }

		// Methods for adding reports
		public override void AddReport(Employee newReport)
        {
            // Check for proper report to Executive
            if (newReport is Manager || newReport is SalesPerson)
            {
                base.AddReport(newReport);
            }
            else
            {
                // Raise exception for report that is not a Manager or Salesperson
                Exception ex = new AddReportException("Executive report not a Manager or Salesperson");

                // Add Manager custom data dictionary
                ex.Data.Add("Manager", this.Name);

                // Add report that failed to be added, and throw exception
                ex.Data.Add("New Report", newReport.Name);
                throw ex;
            }            
        }

        // Add Employee spare props
        public new static string SpareAddProp1Name() { return Manager.SpareAddProp1Name(); }
        public new static object SpareAddProp1DefaultValue() { return Manager.SpareAddProp1DefaultValue(); }

        public new static string SpareAddProp2Name() { return prop2Name; }
        public new static object SpareAddProp2DefaultValue() { return prop2DefaultValue; }

        public new static object SpareAddProp1Convert(object obj) { return Manager.SpareAddProp1Convert(obj); }
        public new static string SpareAddProp1Valid(object obj) { return Manager.SpareAddProp1Valid(obj); }

        public new static object SpareAddProp2Convert(object obj) { return (ExecTitle)obj; }
        public new static string SpareAddProp2Valid(object obj) { return String.Empty; }

        #endregion
    }
}