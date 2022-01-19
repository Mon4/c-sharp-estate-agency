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
    /// Add client window opens window that enables user to add new client to Clientlist 
    /// by writing data in blank windows. User can also save the changes or cancel it and quit.
    /// </summary>
    /// 
    
    public partial class AddClientWindow : Window
    {
        Client client;
        /// <summary>
        /// Default contructor
        /// </summary>
        public AddClientWindow()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Parametric constructor, sets textboxes to default value.
        /// </summary>
        /// <param name="c">Client</param>

        public AddClientWindow(Client c):this()
        {
            client = c;
            Name.Text = client.Name;
            Surname.Text = client.Surname;
            PhoneNumber.Text = client.PhoneNumber;
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
        /// <summary>
        /// Adds client to clientslist, checks if the value is valid if not then throws exceptions,
        /// checks if phone number and date are valid and trows exceptions otherwise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
