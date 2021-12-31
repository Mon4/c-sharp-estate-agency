using estates;
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
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        ClientsRepository estate_rep;
        public ClientsPage()
        {
            estate_rep = ClientsRepository.ReadXML();
            InitializeComponent();
            if (estate_rep is object)
            {
                ClientsLabel.Content = estate_rep.Name;
                ClientsDataGrid.ItemsSource = estate_rep.ClientList;
            }
        }

        private void EstatesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
