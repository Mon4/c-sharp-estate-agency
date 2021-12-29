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
            NIP = nip;
            CompanyName = companyName;
        }

        public string NIP { get => _NIP; set => _NIP = value; }
        public string CompanyName { get => _companyName; set => _companyName = value; }

        public override string ToString()
        {
            return $"{CompanyName} ({NIP}), " + base.ToString();
        }
    }
}
