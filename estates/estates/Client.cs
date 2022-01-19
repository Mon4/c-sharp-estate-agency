using System;
using System.Text.RegularExpressions;


namespace estates
{
    [Serializable]
    public class Client:IComparable
    {
        string _name;
        string _surname;
        string _phoneNumber;
        DateTime _dateOfBirth;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Client() { }
        /// <summary>
        /// parametric constructor
        /// </summary>
        /// <param name="name">client's name</param>
        /// <param name="surname">client's surname</param>
        /// <param name="phoneNumber">client's phone number</param>
        /// <param name="date">date of birth</param>
        public Client(string name, string surname, string phoneNumber, string date)
        {
            _name = name;
            _surname = surname;
            _phoneNumber = CheckPhoneNumber(phoneNumber);
            DateTime.TryParseExact(date, new[]{"dd/MM/yyyy", "dd.mm.yyyy"}, null, System.Globalization.DateTimeStyles.None, out _dateOfBirth);
        }

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }

        /// <summary>
        /// Returns informations about clients in text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} {Surname} (phone number: {PhoneNumber}, date of birth: {DateOfBirth: dd.mm.yyyy})";
        }
        /// <summary>
        /// checks if phone numer has 9 digits in 3-3-3 format
        /// if its true its returns the number if its false it throws exception
        /// </summary>
        /// <param name="phoneNumber">client's phone number</param>
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
        /// Compares Client's Surnames, if they are the same, then it compares clients' Names
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
