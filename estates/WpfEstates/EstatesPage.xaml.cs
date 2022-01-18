
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
    /// </summary>
    public partial class EstatesPage : Page
    {
        EstatesRepository estatesRep;
        OwnersRepository ownersRep;
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

        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            
        }

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
