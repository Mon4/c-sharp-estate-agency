namespace estates
{
    public abstract class Estate
    {
        int _id;
        string _adress;
        string _zipCode;
        string _city;
        decimal _price;
        decimal _area; //pol. powierzchnia
        bool _furniture;
        bool _balcony;
        int _roomsNumer;
        string _description;
        int _bedrooms;
        Owner _owner;

        protected Estate(int id, string adress, string zipCode, string city, decimal price, decimal area,
            bool furniture, bool balcony, int rooms_numer, string description, int bedrooms, Owner owner)
        {
            _id = id;
            _adress = adress;
            _zipCode = zipCode;
            _city = city;
            _price = price;
            _area = area;
            _furniture = furniture;
            _balcony = balcony;
            _roomsNumer = rooms_numer;
            _description = description;
            _bedrooms = bedrooms;
            _owner = owner;
        }

        public int Id { get => _id; set => _id = value; }
        public string Adress { get => _adress; set => _adress = value; }
        public string zipCode { get => _zipCode; set => _zipCode = value; }
        public string City { get => _city; set => _city = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal Area { get => _area; set => _area = value; }
        public bool Furniture { get => _furniture; set => _furniture = value; }
        public bool Balcony { get => _balcony; set => _balcony = value; }
        public int Rooms_numer { get => _roomsNumer; set => _roomsNumer = value; }
        public string Description { get => _description; set => _description = value; }
        public int Bedrooms { get => _bedrooms; set => _bedrooms = value; }
        public Owner Owner { get => _owner; set => _owner = value; }
    }

    


}
