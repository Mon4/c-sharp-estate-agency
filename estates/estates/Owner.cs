namespace estates
{
    public abstract class Owner
    {
        string _adress; //street and home number
        string _zip_code;
        string _city;
        string _phone_number;
        int _estates_number;

        protected Owner(string adress, string zip_code, string city, string phone_number, int estates_number)
        {
            _adress = adress;
            _zip_code = zip_code;
            _city = city;
            _phone_number = phone_number;
            _estates_number = estates_number;
        }
    }

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

    class Company : Owner
    {
        string _NIP;
        string _company_name;

        public Company(string adress, string zip_code, string city, string phone_number, int estates_number,
            string nip, string company_name) : base(adress, zip_code, city, phone_number, estates_number)
        {
            _NIP = nip;
            _company_name = company_name;
        }
    }

}
