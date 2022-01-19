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
    /// Page with information about Clients in datagrid.
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsRepository clientsRep;
        /// <summary>
        /// Reads xml file to ClientDataGrid.
        /// </summary>
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
        /// <summary>
        /// Deletes row of data from datagrid where selected client is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem != null)
            {
                Client c = (Client)ClientsDataGrid.SelectedItem;
                clientsRep.RemoveClient(c);
                clientsRep.SaveToXML();
                ClientsDataGrid.ItemsSource = new ObservableCollection<Client>(clientsRep.ClientList);
            }
        }
        /// <summary>
        /// Adds client to datagrid if result is true(if data is correct and user wants to save it).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            AddClientWindow clientWindow = new AddClientWindow(client);
            bool? result = clientWindow.ShowDialog();
            if (result == true)
            {
                clientsRep.AddClient(client);
                ClientsDataGrid.ItemsSource = new ObservableCollection<Client>(clientsRep.ClientList);
                clientsRep.SaveToXML();
            }
        }
    }
}
