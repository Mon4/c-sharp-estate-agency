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
            _name = name;
            _surname = surname;
        }

    }
}
