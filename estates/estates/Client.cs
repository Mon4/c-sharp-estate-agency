using System;

namespace estates
{
    class Client:IComparable
    {
        string _name;
        string _surname;
        string _phoneNumber;
        DateTime _dateOfBirth;

        public Client(string name, string surname, string phoneNumber, string date)
        {
            _name = name;
            _surname = surname;
            _phoneNumber = phoneNumber;
            DateTime.TryParseExact(date, new[]{"dd/MM/yyyy", "dd.mm.yyyy"}, null, System.Globalization.DateTimeStyles.None, out DateTime _dateOfBirth);
        }

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public override string ToString()
        {
            return $"{Name} {Surname} (phone number: {PhoneNumber}, date of birth: {DateOfBirth})";
        }
        public int CompareTo(object obj)
        {
            Client pom = (Client)obj;
            if (this.Surname == pom.Surname)
            {
                return this.Name.CompareTo(pom.Name);
            }
            else
                return this.Surname.CompareTo(pom.Surname);
        }
    }
}
