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
using estates;

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
            Company c = new Company();
            OwnersRepository ownersRep2 = new OwnersRepository();
            AddCompanyWindow comWindow = new AddCompanyWindow(c);
            bool? result = comWindow.ShowDialog();
            if (result == true)
            {
                ownersRep2 = OwnersRepository.ReadXML();
                ownersRep2.AddOwner(c);
                ownersRep2.SaveToXML();
            }
        }

        private void AddPrivateOwnerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPrivateOwnerWindow privateOwner = new AddPrivateOwnerWindow();
            privateOwner.Show();
        }
    }
}
