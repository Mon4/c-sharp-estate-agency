namespace estates
{
    public abstract class Owner
    {
        string adress; //street and home number
        string zip_code;
        string city;
        string phone_number;
        int estates_number;

        protected Owner(string adress, string zip_code, string city, string phone_number, int estates_number)
        {
            this.adress = adress;
            this.zip_code = zip_code;
            this.city = city;
            this.phone_number = phone_number;
            this.estates_number = estates_number;
        }
    }

    class PrivateOwner : Owner
    {
        string name;
        string surname;

        public PrivateOwner(string adress, string zip_code, string city, string phone_number, int estates_number,
            string name, string surname) : base(adress, zip_code, city, phone_number, estates_number)
        {
            this.name = name;
            this.surname = surname;
        }
    }

    class Company : Owner
    {
        string NIP;
        string company_name;

        public Company(string adress, string zip_code, string city, string phone_number, int estates_number,
            string nip, string company_name) : base(adress, zip_code, city, phone_number, estates_number)
        {
            NIP = nip;
            this.company_name = company_name;
        }
    }

}
