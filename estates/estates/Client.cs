using System;

namespace estates
{
    class Client
    {
        string name;
        string surname;
        string phone_number;
        DateTime date_of_birth;

        public Client(string name, string surname, string phone_number, string date)
        {
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
            DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date_of_birth);
        }
    }
}
