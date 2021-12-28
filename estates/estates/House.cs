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
