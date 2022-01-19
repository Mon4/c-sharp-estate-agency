using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace estates
{
    /// <summary>
    /// House specific estate, inherits from estate and has additional informations about 
    /// levels, garden and garden area.
    /// </summary>
    [Serializable]
    public class House:Estate
    {
        int _levels;
        bool _garden;
        decimal _gardenArea;

        /// <summary>
        /// Default constructor
        /// </summary>
        public House() { }
        /// <summary>
        /// Parametric constructor, creates House with given information, refers to default constructor
        /// </summary>
        /// <param name="adress">House adress</param>
        /// <param name="zipCode">House zipcode</param>
        /// <param name="city">House city</param>
        /// <param name="price">House price</param>
        /// <param name="area">House area</param>
        /// <param name="furniture">does it have furniture(yes/no)</param>
        /// <param name="balcony">does it have balcony(yes/no)</param>
        /// <param name="roomsNumber">Number of rooms</param>
        /// <param name="description">House description</param>
        /// <param name="bedrooms">Number of bedrooms</param>
        /// <param name="owner">House owner</param>
        /// <param name="levels">House levels</param>
        /// <param name="garden">Does it have garden(yes/no)</param>
        /// <param name="gardenArea">Garden Area</param>
        public House(string adress, string zipCode, string city, decimal price,
            decimal area, bool furniture, bool balcony, int roomsNumber, string description,
            int bedrooms, Owner owner, int levels, bool garden, decimal gardenArea) : base(adress, zipCode, city, price, area,
                furniture, balcony, roomsNumber, description, bedrooms, owner)
        {
            Levels = levels;
            Garden = garden;
            GardenArea = gardenArea;
           
        }
        /// <summary>
        /// House levels property
        /// </summary>
        public int Levels { get => _levels; set => _levels = value; }
        /// <summary>
        /// House Garden property
        /// </summary>
        public bool Garden { get => _garden; set => _garden = value; }
        /// <summary>
        /// House GardenArea property
        /// </summary>
        public decimal GardenArea { get => _gardenArea; set => _gardenArea = value; }
        /// <summary>
        /// Returns information about house to text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
