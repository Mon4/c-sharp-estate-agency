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

        public Company(string adress, string zip_code, string city, string phone_number, int estates_number,
            string nip, string company_name) : base(adress, zip_code, city, phone_number, estates_number)
        {
            _NIP = nip;
            _companyName = company_name;
        }
    }
}
