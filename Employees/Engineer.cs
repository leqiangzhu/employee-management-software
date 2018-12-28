using System;
using System.Collections.Generic;

namespace Employees
{
    // Engineers have degrees
    public enum DegreeName { BS, MS, PhD }

    [System.Serializable]
    public class Engineer : Employee
    {
        #region Data members
        public DegreeName HighestDegree { get; set; } = DegreeName.BS;
        static protected string prop1Name = "Highest Degree:";
        static protected object prop1DefaultValue = new List<string>() { "BS", "MS", "PhD" };
 
        #endregion

        #region Constructors 
        // Static constructor for Add Employee spare props
        public Engineer() { }

		public Engineer(string firstName, string lastName, DateTime age, float currPay, string ssn, 
                        DegreeName degree)
          : base(firstName, lastName, age, currPay, ssn)
        {
            // This property is defined by the Engineer class.
            HighestDegree = degree;
		}
        #endregion

        #region Class methods
        public override void DisplayStats()
		{
			base.DisplayStats();
			Console.WriteLine("Highest Degree: {0}", HighestDegree);
        }

        // Details spare prop
        public override void SpareDetailProp1(ref string propName, ref string propValue)
        {
            propName  = prop1Name;
            propValue = HighestDegree.ToString();
        }

        // Add Employee spare props
        public new static string SpareAddProp1Name() { return prop1Name; }
        public new static object SpareAddProp1DefaultValue() { return prop1DefaultValue; }

        public new static object SpareAddProp1Convert(object obj) { return (DegreeName)obj; }
        public new static string SpareAddProp1Valid(object obj) { return String.Empty; }
        #endregion
    }
}
