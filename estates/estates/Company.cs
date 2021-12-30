using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace estates
{
    [Serializable]
    public class Company:Owner
    {
        string _NIP;
        string _companyName;

        public Company() { }
        public Company(string adress, string zipCode, string city, string phoneNumber,
            string nip, string companyName) : base(adress, zipCode, city, phoneNumber)
        {
            NIP = nip;
            CompanyName = companyName;
        }

        public string NIP { get => _NIP; set
            {
                var r = new Regex(@"^\d{3}-\d{3}-\d{2}-\d{2}$");
                var r2 = new Regex(@"^\d{10}$");
                try
                {
                    if (r.IsMatch(value) || r2.IsMatch(value))
                    {
                        _NIP = value;
                    }
                    else
                    {
                        throw new System.Exception("Wrong NIP format!");
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _NIP = "unknown";
                }
            }
        }
        public string CompanyName { get => _companyName; set => _companyName = value; }

        public override string ToString()
        {
            return $"{CompanyName} ({NIP}), " + base.ToString();
        }
    }
}
