using System;
using estates;
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
            Main.Content = new StartingPage();
            
        }
        private void EstatesBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EstatesPage();
            EditingButtons.Content = new ButtonsPage();
        }

        private void EployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EmployeesPage();
            EditingButtons.Content = new ButtonsPage();
        }
        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            Globalls.currentPage = "Clients";
            Main.Content = new ClientsPage();
            EditingButtons.Content = new ButtonsPage();
        }

        private void OwnersBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new OwnersPage();
            EditingButtons.Content = new ButtonsPage();
        }

        private void MeetingsBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MeetingsPage();
            EditingButtons.Content = new ButtonsPage();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
