using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace estates
{
    [Serializable]
    public class House:Estate
    {
        int _levels;
        bool _garden;
        decimal _gardenArea;

        public House() { }
        public House(int id, string adress, string zipCode, string city, decimal price,
            decimal area, bool furniture, bool balcony, int roomsNumber, string description,
            int bedrooms, Owner owner, int levels, bool garden, decimal gardenArea) : base(id, adress, zipCode, city, price, area,
                furniture, balcony, roomsNumber, description, bedrooms, owner)
        {
            Levels = levels;
            Garden = garden;
            GardenArea = gardenArea;
           
        }

        public int Levels { get => _levels; set => _levels = value; }
        public bool Garden { get => _garden; set => _garden = value; }
        public decimal GardenArea { get => _gardenArea; set => _gardenArea = value; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
