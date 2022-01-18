using System;
using System.Collections.Generic;
using System.Globalization;
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
        Client client;
        public AddClientWindow()
        {
            InitializeComponent();

        }

        public AddClientWindow(Client c):this()
        {
            client = c;
            Name.Text = client.Name;
            Surname.Text = client.Surname;
            PhoneNumber.Text = client.PhoneNumber;
            DateBirth.Text = $"{client.DateOfBirth:dd-MMM-yyyy}";
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" || Surname.Text != "" || PhoneNumber.Text != "" | DateBirth.Text!="")
            {
                int working = 1;
                try
                {
                    client.PhoneNumber = client.CheckPhoneNumber(PhoneNumber.Text);
                    if (client.PhoneNumber=="unknown phone number")
                    {
                        throw new WrongFormatInTextBoxException("Wrong phone number!");
                    }
                }
                catch(WrongFormatInTextBoxException wfit)
                {
                    working = 0;
                    ExceptionLabel.Content = wfit.Message;
                }
                client.PhoneNumber=client.CheckPhoneNumber(PhoneNumber.Text);
                client.Name = Name.Text;
                client.Surname = Surname.Text;
                try
                {
                    client.DateOfBirth = DateTime.Parse(DateBirth.Text);
                }
                catch(Exception)
                {
                    working = 0;
                    ExceptionLabel.Content = "Wrong date format!";
                }
                //DateTime.TryParseExact(DateBirth.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yyyy", "dd.MM.yyyy",
                //"dd-MMM-yy", "dd-MMM-yyyy","dd.MMM.yyyy" }, null, DateTimeStyles.None, out DateTime date);
                if (working == 1)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
        }
    }
}
