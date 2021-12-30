using System;
using estates;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class EstatePage : Page
    {
        EstatesRepository estate_rep;
        public EstatePage()
        {
            estate_rep = EstatesRepository.ReadXML("estates.xml");
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
    }
}
