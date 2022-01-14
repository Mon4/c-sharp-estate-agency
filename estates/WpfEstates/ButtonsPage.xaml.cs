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
    /// Interaction logic for ButtonsPage.xaml
    /// </summary>
    public partial class ButtonsPage : Page
    {
        public ButtonsPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Globalls.currentPage=="Clients")
            {
                AddClientWindow clientWindow = new AddClientWindow();
                clientWindow.Show();
            }
            else if(Globalls.currentPage=="Employees")
            {
                AddEmployeeWindow employeeWindow = new AddEmployeeWindow();
                employeeWindow.Show();
            }
            else if (Globalls.currentPage == "Estates")
            {
                AddEstateWindow estateWindow = new AddEstateWindow();
                estateWindow.Show();
            }
            else if (Globalls.currentPage == "Meetings")
            {
                AddMeetingWindow meetingWindow = new AddMeetingWindow();
                meetingWindow.Show();
            }
            else if (Globalls.currentPage == "Owners")
            {
                AddOwnerWindow ownerWindow = new AddOwnerWindow();
                ownerWindow.Show();
            }
        }
    }
}
