using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    /// <summary>
    /// Private owner of estate, inherits from Owner and has additional informations about
    /// name and surname of the owner.
    /// </summary>
    [Serializable]
    public class PrivateOwner : Owner
    {

        string _name;
        string _surname;
        /// <summary>
        /// Default contructor.
        /// </summary>
        public PrivateOwner() { }
        /// <summary>
        /// Parametric constructor, creates private owner with given informations.
        /// </summary>
        /// <param name="adress">Owner's adress</param>
        /// <param name="zipCode">Owner's zipcode</param>
        /// <param name="city">Owner's city</param>
        /// <param name="phoneNumber">Owner's phone number</param>
        /// <param name="name">Owner's name</param>
        /// <param name="surname">Owner's surname</param>
        public PrivateOwner(string adress, string zipCode, string city, string phoneNumber,
            string name, string surname) : base(adress, zipCode, city, phoneNumber)
        {
            Name = name;
            Surname = surname;
        }
        /// <summary>
        /// PrivateOwner's name property
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// PrivateOwner's surname property
        /// </summary>
        public string Surname { get => _surname; set => _surname = value; }
        /// <summary>
        /// Returns informations about Private Owner as text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} {Surname}, " + base.ToString();
        }
    }
}
