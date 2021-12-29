using System;
using System.Text.RegularExpressions;


namespace estates
{
    public abstract class Owner :IComparable<Owner>
    {
        string _adress; //street and home number
        string _zipCode;
        string _city;
        string _phoneNumber;
        int _estatesNumber;

        protected Owner(string adress, string zipCode, string city, string phoneNumber)
        {
            _adress = adress;
            ZipCode = zipCode;
            _city = city;
            _phoneNumber = CheckPhoneNumber(phoneNumber);
            _estatesNumber = 0;
        }

        public string Adress { get => _adress; set => _adress = value; }
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
        public string City { get => _city; set => _city = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public int EstatesNumber { get => _estatesNumber; set => _estatesNumber = value; }
        public override string ToString()
        {
            return $"Adress: {Adress} {ZipCode} {City}, [phone numer: {PhoneNumber}, estates: {EstatesNumber}]";
        }
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

        public int CompareTo(Owner other)
        {
            return this._estatesNumber.CompareTo(other.EstatesNumber);
        }
    }

    

    

}
