using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        Employee emp;
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        public AddEmployeeWindow(Employee e):this()
        {
            emp = e;
            Name.Text = emp.Name;
            Surname.Text = emp.Name;
            PhoneNumber.Text = emp.PhoneNumber1;
            Salary.Text = emp.Salary.ToString();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(Name.Text!="")
            {
                int working = 1;
                emp.Name = Name.Text;
                emp.Surname = Surname.Text;
                emp.PhoneNumber1 = PhoneNumber.Text;
                try
                {
                    emp.Salary = decimal.Parse(Salary.Text, CultureInfo.InvariantCulture);
                }
                catch(System.FormatException)
                {
                    emp.Salary = 0;
                    working = 0;
                }
                emp.Sale_bonus = 0;
                emp.Sold_estates = 0;
                if (working==1)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
