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
    /// Interaction logic for AddFlatWindow.xaml
    /// </summary>
    public partial class AddFlatWindow : Window
    {
        Flat flat;
        OwnersRepository owners = OwnersRepository.ReadXML();
        public AddFlatWindow()
        {
            InitializeComponent();
        }

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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(Adress.Text!="")
            {
                int working = 1;
                
                flat.Adress = Adress.Text;
                flat.ZipCode = ZipCode.Text;
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
                }
                flat.Balcony = (bool)Balcony.IsChecked;
                flat.Furniture = (bool)Furniture.IsChecked;
                flat.Description = Description.Text;
                flat.Building_development = BuildingDevelopment.Text;
                flat.Owner = (Owner)OwnerBox.SelectedItem;
                if(working==1)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
