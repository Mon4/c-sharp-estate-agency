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
    /// Interaction logic for AddFlatWindow.xaml
    /// Add Flat window opens window that enables user to add new flat to Estatelist 
    /// by writing data in blank windows. User can also save the changes or cancel it and quit.
    /// </summary>
    public partial class AddFlatWindow : Window
    {
        Flat flat;
        OwnersRepository owners = OwnersRepository.ReadXML();
        /// <summary>
        /// Default constructor.
        /// </summary>
        public AddFlatWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Parametric constructor, sets textboxes to default value.
        /// </summary>
        /// <param name="f"></param>

        public AddFlatWindow(Flat f):this()
        {
            flat = f;
            Adress.Text = flat.Adress;
            ZipCode.Text = flat.ZipCode;
            City.Text = flat.ZipCode;
            Price.Text = flat.Price.ToString();
            Area.Text = flat.Area.ToString();
            Furniture.IsChecked = flat.Furniture;
            Balcony.IsChecked = flat.Balcony;
            RoomsNumber.Text = flat.RoomsNumber.ToString();
            Description.Text = flat.Description;
            Bedrooms.Text = flat.Bedrooms.ToString();
            OwnerBox.ItemsSource = owners.OwnerList;
            BuildingDevelopment.Text = flat.Building_development;
            Level.Text = flat.Level.ToString();
        }
        /// <summary>
        /// Adds flat to estatelist, checks if the value is valid if not then throws exceptions,
        /// checks if zipcode is valid and trows exceptions otherwise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            {
                int working = 1;
                
                flat.Adress = Adress.Text;
                flat.City = City.Text;
                try
                {
                    flat.Price = Decimal.Parse(Price.Text);
                    flat.Area = Decimal.Parse(Area.Text);
                    flat.RoomsNumber = int.Parse(RoomsNumber.Text);
                    flat.Bedrooms = int.Parse(Bedrooms.Text);
                    flat.Level = int.Parse(Level.Text);
                }
                catch(System.FormatException)
                {
                    working = 0;
                    ExceptionLabelFlat.Content = "Wrong format!";

                }
                try
                {
                    var r = new Regex(@"^\d{2}-\d{3}$");
                    if (!r.IsMatch(ZipCode.Text))
                    {
                        throw new WrongFormatInTextBoxException("Wrong zip code format!");
                    }
                    else
                    {
                        flat.ZipCode = ZipCode.Text;
                    }
                }
                catch (WrongFormatInTextBoxException wfit)
                {
                    ExceptionLabelFlat.Content = wfit.Message;
                    working = 0;
                }
                flat.Balcony = (bool)Balcony.IsChecked;
                flat.Furniture = (bool)Furniture.IsChecked;
                flat.Description = Description.Text;
                flat.Building_development = BuildingDevelopment.Text;
                flat.Owner = (Owner)OwnerBox.SelectedItem;
                if (Adress.Text == "" | ZipCode.Text == "" | City.Text == "" | Area.Text == "" |
                Price.Text == "" | RoomsNumber.Text == "" | Bedrooms.Text == "" | Level.Text == "" |
                 OwnerBox.SelectedItem == null | Area.Text == "0" | Price.Text == "0")
                {
                    ExceptionLabelFlat.Content = "Some fields are ampty!";
                    working = 0;
                }
                if (working==1)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
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
    }
}
