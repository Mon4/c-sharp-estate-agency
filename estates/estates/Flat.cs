using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace estates
{
    [Serializable]
    public class Flat : Estate
    {
        string _building_development; //pol. zabudowa
        int _level;
        public Flat()
        {

        }
        public Flat(int id, string adress, string zipCode, string city, decimal price,
            decimal area, bool furniture, bool balcony, int roomsNumber, string description,
            int bedrooms, Owner owner, string building_development, int level) : base(id, adress, zipCode, city, price, area,
                furniture, balcony, roomsNumber, description, bedrooms, owner)
        {
            Building_development = building_development;
            Level = level;
        }

        public string Building_development { get => _building_development; set => _building_development = value; }
        public int Level { get => _level; set => _level = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
