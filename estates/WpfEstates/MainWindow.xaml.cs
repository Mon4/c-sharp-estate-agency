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
    /// Main window of the program
    /// </summary>

    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent(); 
            Main.Content = new StartingPage();
            
        }
        /// <summary>
        /// Directs user to Estates Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EstatesBtn_Click(object sender, RoutedEventArgs e)
        {
            Globalls.currentPage = "Estates";
            Main.Content = new EstatesPage();
        }
        /// <summary>
        /// Directs user to Employees Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            Globalls.currentPage = "Employees";
            Main.Content = new EmployeesPage();
        }
        /// <summary>
        /// Directs user to Clients Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            Globalls.currentPage = "Clients";
            Main.Content = new ClientsPage();
        }
        /// <summary>
        /// Directs user to Owners Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OwnersBtn_Click(object sender, RoutedEventArgs e)
        {
            Globalls.currentPage = "Owners";
            Main.Content = new OwnersPage();
        }
        /// <summary>
        /// Directs user to Meetings Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MeetingsBtn_Click(object sender, RoutedEventArgs e)
        {
            Globalls.currentPage = "Meetings";
            Main.Content = new MeetingsPage();
        }
        /// <summary>
        /// Quits program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
