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
    /// Interaction logic for OwnersPage.xaml
    /// </summary>
    public partial class OwnersPage : Page
    {
        OwnersRepository ownersRep;
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
            //throw new NotImplementedException();
        }
        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void AddCompany_Click(object sender, RoutedEventArgs e)
        {
            Company c = new Company();
            AddCompanyWindow comWindow = new AddCompanyWindow(c);
            bool? result = comWindow.ShowDialog();
            if (result == true)
            {
                ownersRep.AddOwner(c);
                OwnersDataGrid.ItemsSource= new ObservableCollection<Owner>(ownersRep.OwnerList);
                ownersRep.SaveToXML();
            }
        }

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
