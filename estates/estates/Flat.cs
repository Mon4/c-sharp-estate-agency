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

        public Flat(int id, string adress, string zipCode, string city, decimal price,
            decimal area, bool furniture, bool balcony, int roomsNumber, string description,
            int bedrooms, Owner owner, string building_development, int level) : base(id, adress, zipCode, city, price, area,
                furniture, balcony, roomsNumber, description, bedrooms, owner)
        {
            _building_development = building_development;
            _level = level;
        }
    }
}
