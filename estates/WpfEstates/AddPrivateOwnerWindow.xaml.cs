using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            int working = 1;
            priv.Adress = Adress.Text;
            priv.City = City.Text;
            priv.Name = Name.Text;
            priv.Surname = Surname.Text;
            try
            {
                var r = new Regex(@"^\d{2}-\d{3}$");
                var r2 = new Regex(@"^\d{9}$");
                var r3 = new Regex(@"^\d{3}-\d{3}-\d{3}$");
                if (!r.IsMatch(ZipCode.Text) | (!r2.IsMatch(PhoneNumber.Text) & !r.IsMatch(PhoneNumber.Text)))
                {
                    throw new WrongFormatInTextBoxException("Wrong zip code/phone number format!");
                }
                else
                {
                    priv.ZipCode = ZipCode.Text;
                    priv.PhoneNumber = PhoneNumber.Text;
                }
            }
            catch (WrongFormatInTextBoxException wfit)
            {
                ExceptionLabelPO.Content = wfit.Message;
                working = 0;
            }
            if (Adress.Text=="" | ZipCode.Text=="" | City.Text=="" | PhoneNumber.Text=="" | Name.Text=="" |
                Surname.Text=="")
            {
                working = 0;
                ExceptionLabelPO.Content = "Some fields are empty!";
            }
            if(working==1)
            {
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
