using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Employees
{
    public partial class CompAddEmployee : Page, INotifyPropertyChanged, IDataErrorInfo
    {
        #region Data members
        private EmployeeList empList;
        private CompHome compHome;
        private List<Type> empTypes = new List<Type>();
        public List<string> EmpTypeNames { get; } = new List<string>();

        // Employee name fields are validated in XAML
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Remainder of fields are validated with OnPropertyChanged event
        private DateTime _DOB = DateTime.Today.AddYears(-21);
        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; OnPropertyChanged("DOB"); }
        }

        private float _pay = 40000;
        public float Pay
        {
            get { return _pay; }
            set { _pay = value; OnPropertyChanged("Pay"); }
        }

        private string _SSN = "000-00-0000";
        public string SSN
        {
            get { return _SSN; }
            set { _SSN = value; OnPropertyChanged("SSN"); }
        }

        private string _spare1Value = "";
        public string Spare1Value
        {
            get { return _spare1Value; }
            set { _spare1Value = value; OnPropertyChanged("Spare1Value"); }
        }

        private string _spare2Value = "";
        public string Spare2Value
        {
            get { return _spare2Value; }
            set { _spare2Value = value; OnPropertyChanged("Spare2Value"); }
        }
        #endregion

        #region Data member validation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Error { get { return "Invalid Entry"; } }
        public string this[string columnName] { get { return Validate(columnName); } }

        private string _regex = @"^\d{3}-\d{2}-\d{4}$";
        private string Validate(string propertyName)
        {
            // Return error message if there is error on else return empty or null string
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "DOB": 
                    if (_DOB > DateTime.Now.AddYears(-21))
                        validationMessage = "Must be 21 or older";
                    else if (_DOB < DateTime.Now.AddYears(-65))
                        validationMessage = "Must be 65 or younger";
                    break;

                case "Pay": 
                    if (_pay < 20000 || _pay > 200000)
                        validationMessage = "Range is $20,000 - $200,000";
                    break;

                case "SSN": 
                    if (!Regex.IsMatch(_SSN, _regex))
                        validationMessage = "Enter ddd-dd-dddd";
                    break;

                case "Spare1Value":
                    validationMessage = IsValidSpareValue("SpareAddProp1", SpareProp1Name, 
                                                          SpareProp1Value, SpareProp1Combo);
                    break;

                case "Spare2Value":
                    validationMessage = IsValidSpareValue("SpareAddProp2", SpareProp2Name, 
                                                          SpareProp2Value, SpareProp2Combo);
                    break;   
            }

            return validationMessage;
        }
        #endregion

        #region Constructors
        public CompAddEmployee()
        {
            InitializeComponent();
            InitializeEmpTypes();
        }

        public CompAddEmployee(CompHome home, EmployeeList employees) :this()
        {
            empList = employees;
            compHome = home;
            DataContext = this;
            RoleComboBox.SelectedIndex = 0;
        }
        #endregion

        #region Class methods and event handlers
        // Get sorted list of non-abstract, Employee types
        // We want both the list of type objects as well as list of type names (no namespace)
        private void InitializeEmpTypes()
        {
            var empType = typeof(Employee);
            var assembly = empType.Assembly;

            foreach (Type t in assembly.GetTypes())
            {
                if (t.IsSubclassOf(empType) && !t.IsAbstract)
                {
                    empTypes.Add(t);
                    EmpTypeNames.Add(t.ToString().Substring(Employee.NamespaceLength));
                }
            }

            empTypes.Sort((x, y) => string.Compare(x.ToString(), y.ToString()));
            EmpTypeNames.Sort((s1, s2) => String.Compare(s1, s2));
        }

        private void Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayAllSpareProps();
        }

        // Display all spare properties
        private void DisplayAllSpareProps()
        {
            DisplaySpareProp("SpareAddProp1", SpareProp1Name, SpareProp1Value, SpareProp1Combo);
            DisplaySpareProp("SpareAddProp2", SpareProp2Name, SpareProp2Value, SpareProp2Combo);
        }

        // Display the passed property
        private void DisplaySpareProp(string propPrefix, Label nameLabel, TextBox valueTxt, ComboBox combo)
        {
            try
            {
                Type t = empTypes[RoleComboBox.SelectedIndex];
                MethodInfo mi = t.GetMethod(propPrefix + "Name", BindingFlags.Public | BindingFlags.Static);
                if (mi != null)
                {
                    object propName = mi.Invoke(null, null);
                    nameLabel.Content = propName;
                    nameLabel.Visibility = Visibility.Visible;

                    mi = t.GetMethod(propPrefix + "DefaultValue");
                    object propValue = mi.Invoke(null, null);
                    if (propValue is List<string>)
                    {
                        combo.ItemsSource = (List<String>)propValue;
                        combo.SelectedIndex = 0;
                        combo.Visibility = Visibility.Visible;
                        valueTxt.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        valueTxt.Text = propValue.ToString();
                        valueTxt.Visibility = Visibility.Visible;
                        combo.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    nameLabel.Visibility = Visibility.Hidden;
                    valueTxt.Visibility = Visibility.Hidden;
                    combo.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Enable/disable Save button if we have valid input
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName) &&
                !Validation.GetHasError(SSNTextBox) && !Validation.GetHasError(PayBox) && !Validation.GetHasError(DOBDateBox) &&
                !Validation.GetHasError(SpareProp1Value) && !Validation.GetHasError(SpareProp2Value);
        }

        // Return error message if there is error on else return empty or null string
        private string IsValidSpareValue(string propPrefix, Label nameLbl, TextBox valueTxt, ComboBox combo)
        {
            Type t = empTypes[RoleComboBox.SelectedIndex];

            // Check if spare is visible and not a enum (combo) value
            if (nameLbl.IsVisible && !combo.IsVisible)
            {
                try
                {
                    MethodInfo mi = t.GetMethod(propPrefix + "Valid", BindingFlags.Public | BindingFlags.Static);
                    if (mi != null)
                    {
                        return (string)mi.Invoke(null, new object[] { valueTxt.Text });
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            return String.Empty;
        }

        // Handle Save button click
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Type t = empTypes[RoleComboBox.SelectedIndex];
            ArrayList args = new ArrayList() { FirstName, LastName, DOB, Pay, SSN };

            if (SpareProp1Name.IsVisible) AddSpareProp(t, "SpareAddProp1", SpareProp1Value, SpareProp1Combo, args);
            if (SpareProp2Name.IsVisible) AddSpareProp(t, "SpareAddProp2", SpareProp2Value, SpareProp2Combo, args);

            object[] args1 = new object[args.Count];
            for (int i = 0; i < args.Count; i++) args1[i] = args[i];

            try
            {
                object obj = Activator.CreateInstance(t, args1);

                if (obj is Employee)
                {
                    Employee emp = (Employee)obj;
                    empList.Add(emp);
                }

                // Null out name fields and go back to home page
                FirstName = "";
                LastName = "";
                compHome.RefreshEmployeeList();
                this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddSpareProp(Type t, string propPrefix, TextBox valueTxt, ComboBox combo, ArrayList args)
        {
            object valueObj;

            if (combo.IsVisible)
                valueObj = combo.SelectedIndex;
            else valueObj = valueTxt.Text;

            try
            {
                MethodInfo mi = t.GetMethod(propPrefix + "Convert", BindingFlags.Public | BindingFlags.Static);
                if (mi != null)
                {
                    args.Add(mi.Invoke(null, new object[] { valueObj }));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion
    }
}
