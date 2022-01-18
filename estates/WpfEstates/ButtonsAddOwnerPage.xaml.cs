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
    /// Interaction logic for ButtonsAddOwnerPage.xaml
    /// </summary>
    public partial class ButtonsAddOwnerPage : Page
    {
        public ButtonsAddOwnerPage()
        {
            InitializeComponent();
        }

        private void AddCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCompanyWindow companyWindow = new AddCompanyWindow();
            companyWindow.Show();
        }

        private void AddPrivateOwnerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPrivateOwnerWindow privateOwner = new AddPrivateOwnerWindow();
            privateOwner.Show();
        }
    }
}
