using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class PrivateOwner : Owner
    {

        string _name;
        string _surname;

        public PrivateOwner(string adress, string zipCode, string city, string phoneNumber, int estatesNumber,
            string name, string surname) : base(adress, zipCode, city, phoneNumber, estatesNumber)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public override string ToString()
        {
            return $"{Name} {Surname}, " + base.ToString();
        }
    }
}
