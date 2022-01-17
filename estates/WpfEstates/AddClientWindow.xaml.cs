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
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        
        public AddClientWindow()
        {
            InitializeComponent();
        }
        /*public AddClientWindow(Client c):this()
        {
            cl = c;
            if (cl is Client osobaClient)
            {
                Name.Text = osobaClient.Name;
                Surname.Text = osobaClient.Surname;
                PhoneNumber.Text = osobaClient.PhoneNumber;
            }

        }*/
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            /*if (Name.Text != "" || Surname.Text != "" || PhoneNumber.Text != "")
            {
                cl.PhoneNumber = PhoneNumber.Text;
                cl.Name = Name.Text;
                cl.Surname = Surname.Text;
                
                DialogResult = true;
            }
            DialogResult = false;

            */
        }
    }
}
