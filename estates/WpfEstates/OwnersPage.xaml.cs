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
                //Uncomment!!!!
                //OwnersLabel.Content = ownersRep.Name;
                //OwnersDataGrid.ItemsSource = new ObservableCollection<Owner>(ownersRep.OwnerList);
            }
        }
    }
}
