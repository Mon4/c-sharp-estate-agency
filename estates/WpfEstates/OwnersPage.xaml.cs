using estates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for OwnersPage.xaml
    /// Page with information about Owners in datagrid.
    /// </summary>
    public partial class OwnersPage : Page
    {
        OwnersRepository ownersRep;
        /// <summary>
        ///  Reads xml file to OwnersDataGrid.
        /// </summary>
        public OwnersPage()
        {
            ownersRep = OwnersRepository.ReadXML();
            InitializeComponent();
            if (ownersRep is object)
            {

                OwnersLabel.Content = ownersRep.Name;
                OwnersDataGrid.ItemsSource = new ObservableCollection<Owner>(ownersRep.OwnerList);
            }
        }

        private void OwnersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        /// <summary>
        /// Deletes row of data from datagrid where selected owner is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            if (OwnersDataGrid.SelectedItem != null)
            {
                Owner o = (Owner)OwnersDataGrid.SelectedItem;
                ownersRep.RemoveOwner(o);
                ownersRep.SaveToXML();
                OwnersDataGrid.ItemsSource = new ObservableCollection<Owner>(ownersRep.OwnerList);
            }
        }
        /// <summary>
        /// Adds company to datagrid if result is true(if data is correct and user wants to save it).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCompany_Click(object sender, RoutedEventArgs e)
        {
            Company c = new Company();
            AddCompanyWindow comWindow = new AddCompanyWindow(c);
            bool? result = comWindow.ShowDialog();
            if (result == true)
            {
                ownersRep.AddOwner(c);
                OwnersDataGrid.ItemsSource = new ObservableCollection<Owner>(ownersRep.OwnerList);
                ownersRep.SaveToXML();
            }
        }
        /// <summary>
        /// Adds Private owner to datagrid if result is true(if data is correct and user wants to save it).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPrivateOwner_Click(object sender, RoutedEventArgs e)
        {
            PrivateOwner c = new PrivateOwner();
            AddPrivateOwnerWindow comWindow = new AddPrivateOwnerWindow(c);
            bool? result = comWindow.ShowDialog();
            if (result == true)
            {
                ownersRep.AddOwner(c);
                OwnersDataGrid.ItemsSource = new ObservableCollection<Owner>(ownersRep.OwnerList);
                ownersRep.SaveToXML();
            }
        }
    }
}
