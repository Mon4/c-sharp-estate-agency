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
    /// Logika interakcji dla klasy AddCompanyWindow.xaml
    /// </summary>
    public partial class AddCompanyWindow : Window
    {
        Company company;
        public AddCompanyWindow()
        {
            InitializeComponent();
        }
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(CompanyName.Text!="")
            {
                company.Adress = Adress.Text;
                company.ZipCode = ZipCode.Text;
                company.City = City.Text;
                company.PhoneNumber = PhoneNumber.Text;
                company.NIP = Nip.Text;
                company.CompanyName = CompanyName.Text;
                DialogResult = true;
                this.Close();
            }
        }
    }
}
