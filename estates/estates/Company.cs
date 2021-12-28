using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class Company:Owner
    {
        string _NIP;
        string _companyName;

        public Company(string adress, string zipCode, string city, string phoneNumber, int estatesNumber,
            string nip, string companyName) : base(adress, zipCode, city, phoneNumber, estatesNumber)
        {
            _NIP = nip;
            _companyName = companyName;
        }
    }
}
