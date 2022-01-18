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
using estates;

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
                Client client = new Client();
                ClientsRepository clientsRep2 = new ClientsRepository();
                AddClientWindow clientWindow = new AddClientWindow(client);
                bool? result = clientWindow.ShowDialog();
                if (result == true)
                {
                    clientsRep2 = ClientsRepository.ReadXML();
                    clientsRep2.AddClient(client);
                    clientsRep2.SaveToXML();
                }

            }
            else if(Globalls.currentPage=="Employees")
            {
                AddEmployeeWindow employeeWindow = new AddEmployeeWindow();
                employeeWindow.Show();
            }
            else if (Globalls.currentPage == "Meetings")
            {
                AddMeetingWindow meetingWindow = new AddMeetingWindow();
                meetingWindow.Show();
            }
        }
    }
}
