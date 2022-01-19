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
    /// AddPrivateowner window opens window that enables user to add new Private owner to estatelist 
    /// by writing data in blank windows. User can also save the changes or cancel it and quit.
    /// </summary>
    public partial class AddPrivateOwnerWindow : Window
    {
        PrivateOwner priv;
        /// <summary>
        /// Default constructor.
        /// </summary>
        public AddPrivateOwnerWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Parametric constructor, sets textboxes to default value.
        /// </summary>
        /// <param name="c"></param>
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
        /// <summary>
        /// Adds Private owner to Estatelist, checks if the value is valid if not then throws exceptions,
        /// checks if phone number and zip are valid and trows exceptions otherwise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Quits the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
