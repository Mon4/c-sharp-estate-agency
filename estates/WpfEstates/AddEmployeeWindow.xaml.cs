using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using estates;

namespace WpfEstates
{
    /// <summary>
    /// Interaction logic for AddEmployeeWindow.xaml
    /// Add Employee window opens window that enables user to add new employee to employeelist 
    /// by writing data in blank windows. User can also save the changes or cancel it and quit.
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        Employee emp;
        /// <summary>
        /// Default contructor
        /// </summary>
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Parametric constructor, sets textboxes to default value.
        /// </summary>
        /// <param name="e"></param>
        public AddEmployeeWindow(Employee e):this()
        {
            emp = e;
            Name.Text = emp.Name;
            Surname.Text = emp.Name;
            PhoneNumber.Text = emp.PhoneNumber1;
            Salary.Text = emp.Salary.ToString();
        }
        /// <summary>
        /// Adds employee to employeeslist, checks if the value is valid if not then throws exceptions,
        /// checks if phone number is valid and trows exceptions otherwise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            {
                int working = 1;
                emp.Name = Name.Text;
                emp.Surname = Surname.Text;
                emp.PhoneNumber1 = PhoneNumber.Text;
                try
                {
                    var r1 = new Regex(@"^\d{9}$");
                    var r2 = new Regex(@"^\d{3}-\d{3}-\d{3}$");
                    if (!r1.IsMatch(PhoneNumber.Text) & !r2.IsMatch(PhoneNumber.Text))
                    {
                        throw new WrongFormatInTextBoxException("Wrong phone number format!");
                    }
                    else
                    {
                        emp.PhoneNumber1 = PhoneNumber.Text;
                    }
                }
                catch (WrongFormatInTextBoxException wfit)
                {
                    ExceptionLabelEmp.Content = wfit.Message;
                    working = 0;
                }
                try
                {
                    emp.Salary = decimal.Parse(Salary.Text);
                }
                catch (System.FormatException)
                {
                    ExceptionLabelEmp.Content = "Wrong format!";
                    emp.Salary = 0;
                    working = 0;

                }

                if(Name.Text=="" | Surname.Text=="" | Salary.Text=="" | PhoneNumber.Text=="")
                {
                    working = 0;
                    ExceptionLabelEmp.Content = "Some fields are empty!";
                }
                if (working==1)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
        }
        /// <summary>
        ///  Quits the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
