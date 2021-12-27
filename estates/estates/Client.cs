using System;

namespace estates
{
    class Client
    {
        string _name;
        string _surname;
        string _phone_number;
        DateTime _date_of_birth;

        public Client(string name, string surname, string phone_number, string date)
        {
            _name = name;
            _surname = surname;
            _phone_number = phone_number;
            DateTime.TryParseExact(date, new[]{"dd/MM/yyyy", "dd.mm.yyyy"}, null, System.Globalization.DateTimeStyles.None, out DateTime _date_of_birth);
        }
    }
}
