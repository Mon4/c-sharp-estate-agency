using System;

namespace estates
{
    public abstract class Owner :IComparable<Owner>
    {
        string _adress; //street and home number
        string _zipCode;
        string _city;
        string _phoneNumber;
        int _estatesNumber;

        protected Owner(string adress, string zipCode, string city, string phoneNumber, int estatesNumber)
        {
            _adress = adress;
            _zipCode = zipCode;
            _city = city;
            _phoneNumber = phoneNumber;
            _estatesNumber = estatesNumber;
        }

        public string Adress { get => _adress; set => _adress = value; }
        public string ZipCode { get => _zipCode; set => _zipCode = value; }
        public string City { get => _city; set => _city = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public int EstatesNumber { get => _estatesNumber; set => _estatesNumber = value; }
        public override string ToString()
        {
            return $"Adress: {Adress} {City} {ZipCode}, [phone numer: {PhoneNumber}, estates: {EstatesNumber}]";
        }
        public int CompareTo(Owner other)
        {
            return this._estatesNumber.CompareTo(other.EstatesNumber);
        }
    }

    

    

}
