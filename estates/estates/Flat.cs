using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
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
}
