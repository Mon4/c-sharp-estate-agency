namespace estates
{
    public abstract class Estate
    {
        int id;
        string adress;
        string zip_code;
        string city;
        decimal price;
        decimal area; //pol. powierzchnia
        bool furniture;
        bool balcony;
        int rooms_numer;
        string description;
        int bedrooms;
        Owner owner;

        protected Estate(int id, string adress, string zip_code, string city, decimal price, decimal area,
            bool furniture, bool balcony, int rooms_numer, string description, int bedrooms, Owner owner)
        {
            this.id = id;
            this.adress = adress;
            this.zip_code = zip_code;
            this.city = city;
            this.price = price;
            this.area = area;
            this.furniture = furniture;
            this.balcony = balcony;
            this.rooms_numer = rooms_numer;
            this.description = description;
            this.bedrooms = bedrooms;
            this.owner = owner;
        }

        public int Id { get => id; set => id = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Zip_code { get => zip_code; set => zip_code = value; }
        public string City { get => city; set => city = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal Area { get => area; set => area = value; }
        public bool Furniture { get => furniture; set => furniture = value; }
        public bool Balcony { get => balcony; set => balcony = value; }
        public int Rooms_numer { get => rooms_numer; set => rooms_numer = value; }
        public string Description { get => description; set => description = value; }
        public int Bedrooms { get => bedrooms; set => bedrooms = value; }
        public Owner Owner { get => owner; set => owner = value; }
    }

    class Flat : Estate
    {
        string building_development; //pol. zabudowa
        int level;

        public Flat(int id, string adress, string zip_code, string city, decimal price,
            decimal area, bool furniture, bool balcony, int rooms_number, string description,
            int bedrooms, Owner owner, string building_development, int level) : base(id, adress, zip_code, city, price, area,
                furniture, balcony, rooms_number, description, bedrooms, owner)
        {
            this.building_development = building_development;
            this.level = level;
        }
    }
    class House : Estate
    {
        int levels;
        bool garden;
        decimal garden_area;

        public House(int id, string adress, string zip_code, string city, decimal price,
            decimal area, bool furniture, bool balcony, int rooms_number, string description,
            int bedrooms, Owner owner, int levels, bool garden, decimal garden_area) : base(id, adress, zip_code, city, price, area,
                furniture, balcony, rooms_number, description, bedrooms, owner)
        {
            this.levels = levels;
            this.garden = garden;
            this.garden_area = garden_area;
        }
    }

}
