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
    /// Logika interakcji dla klasy AddHouseWindow.xaml
    /// </summary>
    public partial class AddHouseWindow : Window
    {
        House house;
        OwnersRepository owners = OwnersRepository.ReadXML();

        public AddHouseWindow()
        {
            InitializeComponent();
        }
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
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Adress.Text != "")
            {
                int working = 1;
                house.Adress = Adress.Text;
                house.ZipCode = ZipCode.Text;
                house.City = City.Text;
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
                }
                house.Balcony = (bool)Balcony.IsChecked;
                house.Furniture = (bool)Furniture.IsChecked;
                house.Description = Description.Text;
                house.Garden = (bool)Garden.IsChecked;
                house.Owner = (Owner)OwnerBox.SelectedItem;
                if (working == 1)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
        }


        private void Garden_Checked(object sender, RoutedEventArgs e)
        {
            GardenArea.IsEnabled =  true;
        }
        private void Garden_Unchecked(object sender, RoutedEventArgs e)
        {
            GardenArea.IsEnabled = false;
        }
    }
}
