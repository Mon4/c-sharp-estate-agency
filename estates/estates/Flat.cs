using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace estates
{
    /// <summary>
    /// Flat - specific estate, inherits from estate and has additional informations 
    /// about building developments and level of the flat.
    /// </summary>
    [Serializable]
    public class Flat : Estate
    {
        string _building_development; //pol. zabudowa
        int _level;
        /// <summary>
        /// Default constructor
        /// </summary>
        public Flat()
        {

        }
        /// <summary>
        /// Parametric constructor, creating flat with given informations, refering to default constructor
        /// </summary>
        /// <param name="adress">Flat's adress</param>
        /// <param name="zipCode">Flat's ZipCode</param>
        /// <param name="city">Flat's city</param>
        /// <param name="price">Flat's price</param>
        /// <param name="area">Flat's area</param>
        /// <param name="furniture">does it have furniture or not (yes/no answers)</param>
        /// <param name="balcony">does it have balcony or not (yes/no answers)</param>
        /// <param name="roomsNumber">Number of rooms</param>
        /// <param name="description">Flat's description</param>
        /// <param name="bedrooms">Number of bedrooms</param>
        /// <param name="owner">Flat's owner</param>
        /// <param name="building_development">Building type of Flat</param>
        /// <param name="level">Flat levels</param>
        public Flat(string adress, string zipCode, string city, decimal price,
            decimal area, bool furniture, bool balcony, int roomsNumber, string description,
            int bedrooms, Owner owner, string building_development, int level) : base( adress, zipCode, city, price, area,
                furniture, balcony, roomsNumber, description, bedrooms, owner)
        {
            Building_development = building_development;
            Level = level;
        }

        public string Building_development { get => _building_development; set => _building_development = value; }
        public int Level { get => _level; set => _level = value; }
        /// <summary>
        /// Returns information about flat to text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
