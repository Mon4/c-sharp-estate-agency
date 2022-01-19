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
    /// Logika interakcji dla klasy AddCompanyWindow.xaml
    /// Add Company window opens window that enables user to add new Company to estatelist 
    /// by writing data in blank windows. User can also save the changes or cancel it and quit.
    /// </summary>
    public partial class AddCompanyWindow : Window
    {
        Company company;
        /// <summary>
        /// Default constructor
        /// </summary>
        public AddCompanyWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Parametric constructor, sets textboxes to default value.
        /// </summary>
        /// <param name="c"></param>
        public AddCompanyWindow(Company c):this()
        {
            company = c;
            Adress.Text = company.Adress;
            ZipCode.Text = company.ZipCode;
            City.Text = company.City;
            PhoneNumber.Text = company.PhoneNumber;
            Nip.Text = company.NIP;
            CompanyName.Text = company.CompanyName;
        }
        /// <summary>
        ///  Quits the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Adds Company to Estatelist, checks if the value is valid if not then throws exceptions,
        /// checks if phone number zip and nip are valid and trows exceptions otherwise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            {
                int working = 1;
                company.Adress = Adress.Text;
                company.City = City.Text;
                company.CompanyName = CompanyName.Text;
                try
                {
                    var r = new Regex(@"^\d{2}-\d{3}$");
                    var r2 = new Regex(@"^\d{9}$");
                    var r3 = new Regex(@"^\d{3}-\d{3}-\d{3}$");
                    var r4 = new Regex(@"^\d{3}-\d{3}-\d{2}-\d{2}$");
                    var r5 = new Regex(@"^\d{10}$");
                    if (!r.IsMatch(ZipCode.Text) | (!r2.IsMatch(PhoneNumber.Text) & !r.IsMatch(PhoneNumber.Text))|
                        (!r4.IsMatch(Nip.Text) & !r5.IsMatch(Nip.Text)))
                    {
                        throw new WrongFormatInTextBoxException("Wrong zip code/phone number/NIP format!");
                    }
                    else
                    {
                        company.ZipCode = ZipCode.Text;
                        company.PhoneNumber = PhoneNumber.Text;
                        company.NIP = Nip.Text;
                    }
                }
                catch (WrongFormatInTextBoxException wfit)
                {
                    ExceptionLabelCompany.Content = wfit.Message;
                    working = 0;
                }
                if (Adress.Text == "" | ZipCode.Text == "" | City.Text == "" | PhoneNumber.Text == "" | CompanyName.Text == "" |
                Nip.Text == "")
                {
                    working = 0;
                    ExceptionLabelCompany.Content = "Some fields are empty!";
                }
                if (working == 1)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
        }
    }
}
