using System;

namespace Employees
{
    [System.Serializable]
    sealed class PTSalesPerson : SalesPerson
    {
        #region Constructors
        public PTSalesPerson(string firstName, string lastName, DateTime age, float currPay, 
                             string ssn, int numbOfSales)
          : base(firstName, lastName, age, currPay, ssn, numbOfSales)
        {
        }
        #endregion

        #region Class methods
        // Add Employee spare props
        public new static string SpareAddProp1Name() { return SalesPerson.SpareAddProp1Name(); }
        public new static object SpareAddProp1DefaultValue() { return SalesPerson.SpareAddProp1DefaultValue(); }

        public new static object SpareAddProp1Convert(object obj) { return SalesPerson.SpareAddProp1Convert(obj); }
        public new static string SpareAddProp1Valid(object obj) { return SalesPerson.SpareAddProp1Valid(obj); }
        #endregion
    }
}
