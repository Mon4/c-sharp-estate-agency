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

        public PrivateOwner(string adress, string zip_code, string city, string phone_number, int estates_number,
            string name, string surname) : base(adress, zip_code, city, phone_number, estates_number)
        {
            _name = name;
            _surname = surname;
        }

    }
}
