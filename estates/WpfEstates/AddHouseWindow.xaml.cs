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
    /// Logika interakcji dla klasy AddHouseWindow.xaml
    /// Add House window opens window that enables user to add new flat to Estatelist 
    /// by writing data in blank windows. User can also save the changes or cancel it and quit.
    /// </summary>
    public partial class AddHouseWindow : Window
    {
        House house;
        OwnersRepository owners = OwnersRepository.ReadXML();
        /// <summary>
        /// Default constructor
        /// </summary>
        public AddHouseWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Parametric constructor, sets textboxes to default value.
        /// </summary>
        /// <param name="h"></param>
        public AddHouseWindow(House h):this()
        {
            GardenArea.IsEnabled = false;
            house = h;
            Adress.Text = house.Adress;
            ZipCode.Text = house.ZipCode;
            City.Text = house.ZipCode;
            Price.Text = house.Price.ToString();
            Area.Text = house.Area.ToString();
            Furniture.IsChecked = house.Furniture;
            Balcony.IsChecked = house.Balcony;
            RoomsNumber.Text = house.RoomsNumber.ToString();
            Description.Text = house.Description;
            Bedrooms.Text = house.Bedrooms.ToString();
            OwnerBox.ItemsSource = owners.OwnerList;
            Levels.Text = house.Levels.ToString();
            Garden.IsChecked = house.Garden;
            GardenArea.Text = house.GardenArea.ToString();
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
        /// Adds house to estatelist, checks if the value is valid if not then throws exceptions,
        /// checks if zipcode is valid and trows exceptions otherwise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Adress.Text != "" | ZipCode.Text != "" | City.Text != "" | Area.Text != "" |
                Price.Text != "" | RoomsNumber.Text != "" | Bedrooms.Text != "" | Levels.Text != "" |
                GardenArea.Text != "" | OwnerBox.SelectedItem == null)
            {
                int working = 1;
                house.Adress = Adress.Text;
                house.City = City.Text;
                try
                {
                    var r = new Regex(@"^\d{2}-\d{3}$");
                    if (!r.IsMatch(ZipCode.Text))
                    {
                        throw new WrongFormatInTextBoxException("Wrong zip code format!");
                    }
                    else
                    {
                        house.ZipCode = ZipCode.Text;
                    }
                }
                catch (WrongFormatInTextBoxException wfit)
                {
                    ExceptionLabelHouse.Content = wfit.Message;
                    working = 0;
                }
                try
                {
                    house.Price = Decimal.Parse(Price.Text);
                    house.Area = Decimal.Parse(Area.Text);
                    house.RoomsNumber = int.Parse(RoomsNumber.Text);
                    house.Bedrooms = int.Parse(Bedrooms.Text);
                    house.Levels = int.Parse(Levels.Text);
                    house.GardenArea = decimal.Parse(GardenArea.Text);
                }
                catch (System.FormatException)
                {
                    working = 0;
                    ExceptionLabelHouse.Content = "Wrong format!";
                }
                house.Balcony = (bool)Balcony.IsChecked;
                house.Furniture = (bool)Furniture.IsChecked;
                house.Description = Description.Text;
                house.Garden = (bool)Garden.IsChecked;
                house.Owner = (Owner)OwnerBox.SelectedItem;
                if (Adress.Text == "" | ZipCode.Text == "" | City.Text == "" | Area.Text == "" |
                Price.Text == "" | RoomsNumber.Text == "" | Bedrooms.Text == "" | Levels.Text == "" |
                 OwnerBox.SelectedItem == null | Area.Text == "0" | Price.Text == "0")
                {
                    ExceptionLabelHouse.Content = "Some fields are blank!";
                    working = 0;
                }
                if (working == 1)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// If house has garden it enables to write garden area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Garden_Checked(object sender, RoutedEventArgs e)
        {
            GardenArea.IsEnabled =  true;
        }
        /// <summary>
        /// If House doesnt have garden it disables to write garden area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Garden_Unchecked(object sender, RoutedEventArgs e)
        {
            GardenArea.IsEnabled = false;
        }
    }
}
