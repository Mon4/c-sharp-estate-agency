using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace estates
{
    [Serializable]
    [XmlInclude(typeof(Flat))]
    [XmlInclude(typeof(House))]
    public abstract class Estate :IComparable
    {
        int _id;
        static int id_now;
        string _adress;
        string _zipCode;
        string _city;
        decimal _price;
        decimal _area; //pol. powierzchnia
        bool _furniture;
        bool _balcony;
        int _roomsNumber;
        string _description;
        int _bedrooms;
        Owner _owner;

        static Estate()
        {
            id_now = 0;
        }
        public Estate()
        {
            Id = id_now + 1;
            id_now++;
        }
        protected Estate(string adress, string zipCode, string city, decimal price, decimal area,
            bool furniture, bool balcony, int roomsNumber, string description, int bedrooms, Owner owner):this()
        {
            Adress = adress;
            ZipCode = zipCode;
            City = city;
            Price = price;
            Area = area;
            Furniture = furniture;
            Balcony = balcony;
            RoomsNumber = roomsNumber;
            Description = description;
            Bedrooms = bedrooms;
            Owner = owner;
            //owner.EstatesNumber += 1;
        }

        public int Id { get => _id; set => _id = value; }
        public string Adress { get => _adress; set => _adress = value; }
        public string ZipCode
        {
            get => _zipCode; set
            {
                var r = new Regex(@"^\d{2}-\d{3}$");
                try
                {
                    if (r.IsMatch(value))
                    {
                        _zipCode = value;
                    }
                    else
                    {
                        throw new System.Exception("Wrong zip code format!");
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _zipCode = "unknown";
                }
            }
        }
        public string City { get => _city; set => _city = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal Area { get => _area; set => _area = value; }
        public bool Furniture { get => _furniture; set => _furniture = value; }
        public bool Balcony { get => _balcony; set => _balcony = value; }
        public int RoomsNumber { get => _roomsNumber; set => _roomsNumber = value; }
        public string Description { get => _description; set => _description = value; }
        public int Bedrooms { get => _bedrooms; set => _bedrooms = value; }
        public Owner Owner { get => _owner; set => _owner = value; }
        public override string ToString()
        {
            return $"ID: {Id:d5} Adress: {Adress} {ZipCode} {City} {Owner.EstatesNumber}";
        }
        public int CompareTo(object obj)
        {
            return _price.CompareTo(obj);
        }
    }

    


}
