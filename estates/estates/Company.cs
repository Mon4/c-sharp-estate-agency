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
        /// <summary>
        /// Default constructor
        /// </summary>
        public Company() { }
        /// <summary>
        /// Parametric constructor, creates a company with given information and refers to base class(Owner)
        /// </summary>
        /// <param name="adress">Company's adress</param>
        /// <param name="zipCode">Company's zipcode</param>
        /// <param name="city">City where it is registered</param>
        /// <param name="phoneNumber">Company's phone number</param>
        /// <param name="nip">Company's nip</param>
        /// <param name="companyName">Company's name</param>
        public Company(string adress, string zipCode, string city, string phoneNumber,
            string nip, string companyName) : base(adress, zipCode, city, phoneNumber)
        {
            NIP = nip;
            CompanyName = companyName;
        }
        /// <summary>
        /// Checks if the Nip code is valid - contains 10 numbers in format 3-3-2-2,if its not then throws exception.
        /// </summary>
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
        /// <summary>
        /// Return informations about company in text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{CompanyName} ({NIP}), " + base.ToString();
        }
    }
}
