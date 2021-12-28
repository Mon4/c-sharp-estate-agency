namespace estates
{
    public abstract class Owner
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
    }

    

    

}
