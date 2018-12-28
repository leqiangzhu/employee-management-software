using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Employees
{
    public partial class CompDetails : Page
    {
        #region Constructors
        private Employee emp;
        private EmployeeList empList;

        public CompDetails()
        {
            InitializeComponent();
        }

        // Custom constructor to pass Employee object
        public CompDetails(object data, EmployeeList emps) : this()
        {
            // Bind context to Employee
            this.DataContext = data;
            empList = emps;

            if (data is Employee)
            {
                emp = (Employee)data;
                string name1 = "";
                string value1 = "";
                string name2 = "";
                string value2 = "";
                
                emp.SpareDetailProp1(ref name1, ref value1);
                emp.SpareDetailProp2(ref name2, ref value2);
                SpareProp1Name.Content = name1;
                SpareProp1Value.Content = value1;
                
                if (!(emp is Manager))
                {
                    SpareProp2Name.Content = name2;
                    SpareProp2Value.Content = value2;
                    SpareProp2Value.Visibility = Visibility.Visible;
                    SpareProp2List.Visibility = Visibility.Hidden;
                }
                else
                {
                    InitReportsListBox();
                }
                InitComboReport();
            }
        }
        private void InitReportsListBox()
        {
            string name = "";
            string value = "";
            emp.SpareDetailProp2(ref name, ref value);
            List<string> reports = new List<string>();
            if (value != "")
            {
                int pos = -1;
                int begin = 0;
                pos = value.IndexOf(",", begin);
                while (pos != -1 && pos < value.Length)
                {
                    reports.Add(value.Substring(begin, pos - begin).Trim());
                    begin = pos + 1;
                    pos = value.IndexOf(",", begin);
                }
                if (value.Substring(begin) != "")
                    reports.Add(value.Substring(begin).Trim());
            }

            if (reports.Count > 0)
            {
                SpareProp2Name.Content = name;
                SpareProp2List.ItemsSource = reports;
                SpareProp2Name.Visibility = Visibility.Visible;
                SpareProp2Value.Visibility = Visibility.Hidden;
                SpareProp2List.Visibility = Visibility.Visible;
            }
            else
            {
                SpareProp2Value.Visibility = Visibility.Hidden;
                SpareProp2Name.Visibility = Visibility.Hidden;
                SpareProp2List.Visibility = Visibility.Hidden;
                RmReport.IsEnabled = false;
            }

        }
        private void InitComboReport()
        {
            List<string> reports = new List<string>();
            if (emp is Executive)
            {
                foreach(Employee tmpEmp in empList)
                {
                    if (tmpEmp is Manager || tmpEmp is SalesPerson)
                        reports.Add(tmpEmp.Name);
                }
            }
            else if (emp is Manager)
            {
                foreach (Employee tmpEmp in empList)
                {
                    if (!(tmpEmp is Manager))
                        reports.Add(tmpEmp.Name);
                }
            }

            if (reports.Count > 0)
            {
                ComboReport.ItemsSource = reports;
                ComboReport.IsEnabled = true;
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (emp is Manager && SpareProp2List.SelectedIndex != -1)
            {
                RmReport.IsEnabled = true;
            }
        }
        private void ComboReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (emp is Manager && ComboReport.SelectedIndex != -1)
            {
                AddReport.IsEnabled = true;
            }
        }
        private void Promotion_Click(object sender, RoutedEventArgs e)
        {
            emp.GivePromotion();
            BenefitsLabel.Content = emp.PrintBenefits;
        }
        private void Bonus_Click(object sender, RoutedEventArgs e)
        {
            float f = 0;
            float.TryParse(BonusBox.Text, out f);
            if (f >= 500 && f <= 10000)
                emp.GiveBonus(f);
            else
            {
                BonusBox.Text = "500";
            }
            PayLabel.Content = emp.PrintPay;

        }

        private void AddReport_Click(object sender, RoutedEventArgs e)
        {
            if (emp is Manager && ComboReport.SelectedIndex != -1)
            {
                Manager mng = (Manager)emp;
                foreach (Employee emp in empList)
                {
                    if (emp.Name == (string)ComboReport.SelectedValue)
                    {
                        try
                        {
                            mng.AddReport(emp);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
                        break;
                    }
                }
            }
            InitReportsListBox();
        }

        private void RmReport_Click(object sender, RoutedEventArgs e)
        {
            if (emp is Manager && SpareProp2List.SelectedIndex != -1)
            {
                Manager mng = (Manager)emp;
                foreach (Employee emp in mng)
                {
                    if (emp.Name == (string)SpareProp2List.SelectedValue)
                    {
                        mng.RemoveReport(emp);
                        break;
                    }
                }
            }
            InitReportsListBox();
        }
        #endregion
    }
}
