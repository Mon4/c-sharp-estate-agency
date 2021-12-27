namespace estates
{
    public abstract class Estate
    {
        int _id;
        string _adress;
        string _zip_code;
        string _city;
        decimal _price;
        decimal _area; //pol. powierzchnia
        bool _furniture;
        bool _balcony;
        int _rooms_numer;
        string _description;
        int _bedrooms;
        Owner _owner;

        protected Estate(int id, string adress, string zip_code, string city, decimal price, decimal area,
            bool furniture, bool balcony, int rooms_numer, string description, int bedrooms, Owner owner)
        {
            _id = id;
            _adress = adress;
            _zip_code = zip_code;
            _city = city;
            _price = price;
            _area = area;
            _furniture = furniture;
            _balcony = balcony;
            _rooms_numer = rooms_numer;
            _description = description;
            _bedrooms = bedrooms;
            _owner = owner;
        }

        public int Id { get => _id; set => _id = value; }
        public string Adress { get => _adress; set => _adress = value; }
        public string Zip_code { get => _zip_code; set => _zip_code = value; }
        public string City { get => _city; set => _city = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal Area { get => _area; set => _area = value; }
        public bool Furniture { get => _furniture; set => _furniture = value; }
        public bool Balcony { get => _balcony; set => _balcony = value; }
        public int Rooms_numer { get => _rooms_numer; set => _rooms_numer = value; }
        public string Description { get => _description; set => _description = value; }
        public int Bedrooms { get => _bedrooms; set => _bedrooms = value; }
        public Owner Owner { get => _owner; set => _owner = value; }
    }

    class Flat : Estate
    {
        string _building_development; //pol. zabudowa
        int _level;

        public Flat(int id, string adress, string zip_code, string city, decimal price,
            decimal area, bool furniture, bool balcony, int rooms_number, string description,
            int bedrooms, Owner owner, string building_development, int level) : base(id, adress, zip_code, city, price, area,
                furniture, balcony, rooms_number, description, bedrooms, owner)
        {
            _building_development = building_development;
            _level = level;
        }
    }
    class House : Estate
    {
        int _levels;
        bool _garden;
        decimal _garden_area;

        public House(int id, string adress, string zip_code, string city, decimal price,
            decimal area, bool furniture, bool balcony, int rooms_number, string description,
            int bedrooms, Owner owner, int levels, bool garden, decimal garden_area) : base(id, adress, zip_code, city, price, area,
                furniture, balcony, rooms_number, description, bedrooms, owner)
        {
            _levels = levels;
            _garden = garden;
            _garden_area = garden_area;
        }
    }

}
