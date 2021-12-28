using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class House:Estate
    {
        int _levels;
        bool _garden;
        decimal _gardenArea;


        public House(int id, string adress, string zipCode, string city, decimal price,
            decimal area, bool furniture, bool balcony, int roomsNumber, string description,
            int bedrooms, Owner owner, int levels, bool garden, decimal gardenArea) : base(id, adress, zipCode, city, price, area,
                furniture, balcony, roomsNumber, description, bedrooms, owner)
        {
            _levels = levels;
            _garden = garden;
            _gardenArea = gardenArea;
           
        }
    }
}
