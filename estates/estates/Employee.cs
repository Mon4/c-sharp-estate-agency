using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    [Serializable]
    public class Employee
    {
        string _name;
        string _surname;
        string _phoneNumber;
        decimal _salary;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string PhoneNumber1 { get => _phoneNumber; set => _phoneNumber = value; }
        public decimal Salary { get => _salary; set => _salary = value; }
        /// <summary>
        /// Default's constructor
        /// </summary>
        public Employee() { }
        /// <summary>
        /// Parametric constructor, creates employee with given information.
        /// </summary>
        /// <param name="name">Employee's name</param>
        /// <param name="surname">Employees' surname</param>
        /// <param name="phoneNumber">Employees' phone number</param>
        /// <param name="salary">Employees' salary</param>
        public Employee(string name, string surname, string phoneNumber, decimal salary)
        {
            Name = name;
            Surname = surname;
            PhoneNumber1 = PhoneNumber(phoneNumber);
            Salary = salary;

        }

       /// <summary>
       /// changes employees salary to new given salary
       /// </summary>
       /// <param name="newSalary"></param>
        public void ChangeSalary(decimal newSalary)
        {
            _salary = newSalary;
        }
        /// <summary>
        /// checks if the phone number is valid - 9 digits 3-3-3 format, if not then throws exception.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public string PhoneNumber(string phoneNumber)
        {
            var r = new Regex(@"^\d{9}$");
            var re = new Regex(@"^\d{3}-\d{3}-\d{3}$");
            try
            {
                if (r.IsMatch(phoneNumber) || re.IsMatch(phoneNumber))
                {
                    return _phoneNumber = phoneNumber;
                }
                else
                {
                    throw new System.Exception("Wrong phone number format!");
                }
            }
            catch(System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "unknown phone number";
            }
        }
        /// <summary>
        /// return informations about employees in text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _name + " " + _surname + " " + "(Phone number: "+_phoneNumber+")";
        }
    }

}
