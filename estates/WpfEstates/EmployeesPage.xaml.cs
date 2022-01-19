using estates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEstates
{
    /// <summary>
    /// Interaction logic for EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        EmployeesRepository employeesRep;
        public EmployeesPage()
        {
            employeesRep = EmployeesRepository.ReadXML();
            InitializeComponent();
            if (employeesRep is object)
            {
                
                EmployeesLabel.Content = employeesRep.Name;
                EmployeesDataGrid.ItemsSource = new ObservableCollection<Employee>(employeesRep.Employelist);
            }

        }
        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem != null)
            {
                Employee em = (Employee) EmployeesDataGrid.SelectedItem;
                employeesRep.RemoveEmployee(em);
                employeesRep.SaveToXML();
                EmployeesDataGrid.ItemsSource = new ObservableCollection<Employee>(employeesRep.Employelist);
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            AddEmployeeWindow employeeWindow = new AddEmployeeWindow(emp);
            bool? result = employeeWindow.ShowDialog();
            if (result == true)
            {
                employeesRep.AddEmployee(emp);
                EmployeesDataGrid.ItemsSource = new ObservableCollection<Employee>(employeesRep.Employelist);
                employeesRep.SaveToXML();
            }
        }
    }
}
