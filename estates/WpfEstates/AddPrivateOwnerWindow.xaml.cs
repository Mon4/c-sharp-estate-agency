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
using System.Windows.Shapes;
using estates;

namespace WpfEstates
{
    /// <summary>
    /// Interaction logic for AddOwnerWindow.xaml
    /// </summary>
    public partial class AddPrivateOwnerWindow : Window
    {
        PrivateOwner priv;
        public AddPrivateOwnerWindow()
        {
            InitializeComponent();
        }
        public AddPrivateOwnerWindow(PrivateOwner c):this()
        {
            priv = c;
            Adress.Text = priv.Adress;
            ZipCode.Text = priv.ZipCode;
            City.Text = priv.City;
            PhoneNumber.Text = priv.PhoneNumber;
            Name.Text = priv.Name;
            Surname.Text = priv.Surname;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                priv.Adress = Adress.Text;
                priv.ZipCode = ZipCode.Text;
                priv.City = City.Text;
                priv.PhoneNumber = PhoneNumber.Text;
                priv.Name = Name.Text;
                priv.Surname = Surname.Text;
                DialogResult = true;
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
