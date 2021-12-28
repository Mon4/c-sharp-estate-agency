namespace estates
{
    public abstract class Owner
    {
        string _adress; //street and home number
        string _zipCode;
        string _city;
        string _phoneNumber;
        int _estatesNumber;

        protected Owner(string adress, string zip_code, string city, string phone_number, int estates_number)
        {
            _adress = adress;
            _zipCode = zip_code;
            _city = city;
            _phoneNumber = phone_number;
            _estatesNumber = estates_number;
        }
    }

    

    

}
