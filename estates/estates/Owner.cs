using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace estates
{
    /// <summary>
    /// Owners of the estate, contains informations about adress, zipcode, city, phonenumber and
    /// estetes number, Company and PrivateOwner inherits from this abstract class.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(PrivateOwner))]
    [XmlInclude(typeof(Company))]
    public abstract class Owner :IComparable<Owner>
    {
        string _adress; //street and home number
        string _zipCode;
        string _city;
        string _phoneNumber;
        int _estatesNumber;
        /// <summary>
        /// Default constructor
        /// </summary>
        public Owner() { }
        /// <summary>
        /// Parametric constructor, creates new owner with given informations, states _estates_number as 0.
        /// </summary>
        /// <param name="adress">Owner's adress</param>
        /// <param name="zipCode">Owner's Zipcode</param>
        /// <param name="city">Owner's city</param>
        /// <param name="phoneNumber">Owner's phone number</param>
        protected Owner(string adress, string zipCode, string city, string phoneNumber)
        {
            _adress = adress;
            ZipCode = zipCode;
            _city = city;
            _phoneNumber = CheckPhoneNumber(phoneNumber);
            _estatesNumber = 0;
        }
        /// <summary>
        /// Owner's adress property
        /// </summary>
        public string Adress { get => _adress; set => _adress = value; }
        /// <summary>
        /// Owner's zipcode property, checking whether zip code is valid 2digit-3digit format
        /// </summary>
        public string ZipCode { get => _zipCode; set
            {
                var r = new Regex(@"^\d{2}-\d{3}$");
                try
                {
                    if (r.IsMatch(value))
                    {
                        _zipCode = value;
                    }
                    else
                    {
                        throw new System.Exception("Wrong zip code format!");
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _zipCode = "unknown";
                }
            }
        }
        /// <summary>
        /// Owner's city property
        /// </summary>
        public string City { get => _city; set => _city = value; }
        /// <summary>
        /// Owner's phonenumber property
        /// </summary>
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        /// <summary>
        /// Owner's estatenumber property
        /// </summary>
        public int EstatesNumber { get => _estatesNumber; set => _estatesNumber = value; }
        /// <summary>
        /// Returns informations about owners in text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Adress: {Adress} {ZipCode} {City}, [phone numer: {PhoneNumber}]";
        }
        /// <summary>
        /// Checks if the phone number is valid - 9 digits, 3-3-3 format, if yes then returns number if not then throws exception.
        /// </summary>
        /// <param name="phoneNumber">Owner's phone number</param>
        /// <returns></returns>
        public string CheckPhoneNumber(string phoneNumber)
        {
            var r = new Regex(@"^\d{9}$");
            var re = new Regex(@"^\d{3}-\d{3}-\d{3}$");
            try
            {
                if (r.IsMatch(phoneNumber) || re.IsMatch(phoneNumber))
                {
                    return phoneNumber;
                }
                else
                {
                    throw new System.Exception("Wrong phone number format!");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "unknown phone number";
            }
        }
        /// <summary>
        /// Compares owners by their estates number
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>

        public int CompareTo(Owner other)
        {
            return this._estatesNumber.CompareTo(other.EstatesNumber);
        }
    }

    

    

}
