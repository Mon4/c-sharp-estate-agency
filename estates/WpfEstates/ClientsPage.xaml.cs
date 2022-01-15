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
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        ClientsRepository clientsRep;
        public ClientsPage()
        {
            clientsRep = ClientsRepository.ReadXML();
            InitializeComponent();
            if (clientsRep is object)
            {
                ClientsLabel.Content = clientsRep.Name;
                ClientsDataGrid.ItemsSource = new ObservableCollection<Client>(clientsRep.ClientList);
            }
        }

        private void EstatesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
