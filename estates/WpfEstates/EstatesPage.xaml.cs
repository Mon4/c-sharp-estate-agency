
using estates;
using System;
using System.Collections.Generic;
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
        EstatesRepository estate_rep;
        public EstatesPage()
        {
            estate_rep = EstatesRepository.ReadXML();
            InitializeComponent();
            if (estate_rep is object)
            {
                EstatesLabel.Content = estate_rep.Name;
                EstatesDataGrid.ItemsSource = estate_rep.EstateList;
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
