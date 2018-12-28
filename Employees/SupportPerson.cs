using System;
using System.Collections.Generic;

namespace Employees
{
	// SupportPerson works a shift
    public enum ShiftName { One, Two, Three }

    [System.Serializable]
    public class SupportPerson : Employee
    {
        #region Data members
        public ShiftName Shift { get; set; } = ShiftName.One;

        // Spare prop data
        private static string prop1Name = "Shift:";
        private static object prop1DefaultValue = new List<string>() { "One", "Two", "Three" };
    #endregion

    #region Constructors 
        public SupportPerson() { }

		public SupportPerson(string firstName, string lastName, DateTime age, float currPay, 
                             string ssn, ShiftName shift)
          : base(firstName, lastName, age, currPay, ssn)
        {
            // This property is defined by the SupportPerson class.
            Shift = shift;
		}
        #endregion

        #region Class methods
        public override void DisplayStats()
		{
			base.DisplayStats();
			Console.WriteLine("Shift: {0}", Shift);
		}

        // Details spare prop
        public override void SpareDetailProp1(ref string propName, ref string propValue)
        {
            propName  = "Shift:";
            propValue = Shift.ToString();
        }

        // Add Employee spare prop
        public new static string SpareAddProp1Name() { return prop1Name; }
        public new static object SpareAddProp1DefaultValue() { return prop1DefaultValue; }

        public new static object SpareAddProp1Convert(object obj) { return (ShiftName)obj; }
        public new static bool SpareAddProp1Valid(object obj) { return true; }
        #endregion
    }
}
