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
    /// Interaction logic for ButtonsAddEstatePage.xaml
    /// </summary>
    public partial class ButtonsAddEstatePage : Page
    {
        public ButtonsAddEstatePage()
        {
            InitializeComponent();
        }

        private void AddFlatBtn_Click(object sender, RoutedEventArgs e)
        {
            AddFlatWindow flatWindow = new AddFlatWindow();
            flatWindow.Show();
        }

        private void AddHouseBtn_Click(object sender, RoutedEventArgs e)
        {
            AddHouseWindow  houseWindow = new AddHouseWindow();
            houseWindow.Show();
        }
    }
}
