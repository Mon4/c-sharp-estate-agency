using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void InitalizeComponent()
        {
            throw new NotImplementedException();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void EstatesBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EstatePage();
        }

        private void EployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EmployeesPage();

        }
        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ClientsPage();

        }

        private void OwnersBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new OwnersPage();
        }

        private void MeetingsBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MeetingsPage();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
