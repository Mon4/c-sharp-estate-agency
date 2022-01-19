
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
    /// Interaction logic for Page1.xaml
    /// Page with information about Estates in datagrid.
    /// </summary>
    public partial class EstatesPage : Page
    {
        EstatesRepository estatesRep;
        OwnersRepository ownersRep;
        /// <summary>
        /// Reads xml file to ClientDataGrid.
        /// </summary>
        public EstatesPage()
        {
            estatesRep = EstatesRepository.ReadXML();
            InitializeComponent();
            if (estatesRep is object)
            {
                EstatesLabel.Content = estatesRep.Name;
                EstatesDataGrid.ItemsSource = new ObservableCollection<Estate>(estatesRep.EstateList);
            }
        }


        private void EstatesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// Deletes row of data from datagrid where selected estate is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            if (EstatesDataGrid.SelectedItem != null)
            {
                ownersRep = OwnersRepository.ReadXML();
                Estate es = (Estate)EstatesDataGrid.SelectedItem;
                ownersRep.FindOwnerbyNumber(es.Owner.PhoneNumber).EstatesNumber--;
                estatesRep.RemoveEstate(es);
                estatesRep.SaveToXML();
                ownersRep.SaveToXML();
                EstatesDataGrid.ItemsSource = new ObservableCollection<Estate>(estatesRep.EstateList);
            }
        }
        /// <summary>
        /// Adds flat to datagrid if result is true(if data is correct and user wants to save it).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Flat flat = new Flat();
            AddFlatWindow flatWindow = new AddFlatWindow(flat);
            bool? result = flatWindow.ShowDialog();
            ownersRep = OwnersRepository.ReadXML();
            if (result == true)
            {
                estatesRep.AddEstate(flat);
                EstatesDataGrid.ItemsSource = new ObservableCollection<Estate>(estatesRep.EstateList);
                ownersRep.FindOwnerbyNumber(flat.Owner.PhoneNumber).EstatesNumber = flat.Owner.EstatesNumber;
                estatesRep.SaveToXML();
                ownersRep.SaveToXML();
            }
        }
        /// <summary>
        /// Adds house to datagrid if result is true(if data is correct and user wants to save it).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            House house = new House();
            AddHouseWindow houseWindow = new AddHouseWindow(house);
            bool? result = houseWindow.ShowDialog();
            ownersRep = OwnersRepository.ReadXML();
            if (result == true)
            {
                estatesRep.AddEstate(house);
                EstatesDataGrid.ItemsSource = new ObservableCollection<Estate>(estatesRep.EstateList);
                ownersRep.FindOwnerbyNumber(house.Owner.PhoneNumber).EstatesNumber = house.Owner.EstatesNumber;
                estatesRep.SaveToXML();
                ownersRep.SaveToXML();
            }
        }
    }
}
