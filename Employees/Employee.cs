using System;
using System.Collections.Generic;

namespace Employees
{
    abstract public partial class Employee
    {
        #region Nested benefit packages
        [System.Serializable]
        public class BenefitPackage
        {
            // Assume we have other members that represent
            // dental/health benefits, and so on.
            public virtual double ComputePayDeduction() { return 125.0; }
            public override string ToString() { return "Standard"; }
        }

        // Other benefit packages derive from BenefitPackage directly
        // and provide definitions for ComputePayDeduction and ToString
        [System.Serializable]
        sealed public class GoldBenefitPackage : BenefitPackage
        {
            public override double ComputePayDeduction() { return 150.0; }
            public override string ToString() { return "Gold"; }
        }

        [System.Serializable]
        sealed public class PlatinumBenefitPackage : BenefitPackage
        {
            public override double ComputePayDeduction() { return 250.0; }
            public override string ToString() { return "Platinum"; }
        }

        // Contain a BenefitPackage object.
        protected BenefitPackage empBenefits = new BenefitPackage();

        // Expose certain benefit behaviors of object.
        public double GetBenefitCost()
        { return empBenefits.ComputePayDeduction(); }

        // Expose object through a read-only property.
        public BenefitPackage Benefits
        {
            get { return empBenefits; }
        }
        public string PrintBenefits
        {
            get { return string.Format("{0}(${1}/month)", empBenefits, GetBenefitCost()); }
        }
        public string PrintPay
        {
            get { return string.Format("${0}", currPay.ToString("###,###.00")); }
        }
        #endregion

        #region Class methods
        public virtual void GiveBonus(float amount)
        {
            currPay += amount;
        }

        // Move GivePromotion as virtual method on Employee
        public virtual void GivePromotion()
        {
            // Bump benefit package from Standard to Gold, Gold to Platinum
            if (empBenefits.GetType() == typeof(BenefitPackage))
                empBenefits = new GoldBenefitPackage();
            else if (empBenefits is GoldBenefitPackage)
                empBenefits = new PlatinumBenefitPackage();
        }

        // Console display
        public virtual void DisplayStats()
        {
            // Console code
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Id: {0}", Id);
            Console.WriteLine("Role: {0}", Role);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("DOB: {0}", DateOfBirth);
            Console.WriteLine("Pay: {0:C}", Pay);
            Console.WriteLine("SSN: {0}", SocialSecurityNumber);
            Console.WriteLine("Benefits: {0}", Benefits);
        }

        // Details spare props
        public virtual void SpareDetailProp1(ref string propName, ref string propValue) { }
        public virtual void SpareDetailProp2(ref string propName, ref string propValue) { }

        // Add Employee spare props
        public static string SpareAddProp1Name() { return null; }
        public static object SpareAddProp1DefaultValue() { return null; }

        public static string SpareAddProp2Name() { return null; }
        public static object SpareAddProp2DefaultValue() { return null; }

        public static object SpareAddProp1Convert(object obj) { return null; }
        public static object SpareAddProp2Convert(object obj) { return null; }

        // Return error message if there is error on else return empty or null string
        public static string SpareAddProp1Valid(object obj) { return String.Empty; }
        public static string SpareAddProp2Valid(object obj) { return String.Empty; }
        #endregion

        #region Employee sort oders
        // Sort employees by name.
        private class NameComparer : IComparer<Employee>
		{
            // Compare the name of each object.
            int IComparer<Employee>.Compare(Employee e1, Employee e2)
            {
				if (e1 != null && e2 != null)
					return String.Compare(e1.Name, e2.Name);
				else throw new ArgumentException("Parameter is not an Employee!");
			}
		}

		// Sort by age
		private class AgeComparer : IComparer<Employee>
		{
			// Compare the Age of each object.
			int IComparer<Employee>.Compare(Employee e1, Employee e2)
			{
				if (e1 != null && e2 != null)
					return e1.Age.CompareTo(e2.Age);
				else throw new ArgumentException("Parameter is not an Employee!");
			}
		}
		
        // Sort By pay
		private class PayComparer : IComparer<Employee>
		{
			// Compare the Pay of each object.
			int IComparer<Employee>.Compare(Employee e1, Employee e2)
			{
				if (e1 != null && e2 != null)
					return e1.Pay.CompareTo(e2.Pay);
				else
					throw new ArgumentException("Parameter is not an Employee!");
			}
		}

		// Static, read-only properties to return Employee Name, Age, or Pay comparers
		public static IComparer<Employee> SortByName { get; } = new NameComparer();
		public static IComparer<Employee> SortByAge { get; } = new AgeComparer();
		public static IComparer<Employee> SortByPay { get; } = new PayComparer();
		#endregion
	}
}