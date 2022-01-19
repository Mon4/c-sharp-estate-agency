using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{/// <summary>
/// Employee working in estate agency, class contains information about his name, surname,
/// phone number and salary.
/// </summary>
    [Serializable]
    public class Employee
    {
        string _name;
        string _surname;
        string _phoneNumber;
        decimal _salary;

        /// <summary>
        /// Employee name property
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// Employee surname property
        /// </summary>
        public string Surname { get => _surname; set => _surname = value; }
        /// <summary>
        /// Employee phone number property
        /// </summary>
        public string PhoneNumber1 { get => _phoneNumber; set => _phoneNumber = value; }
        /// <summary>
        /// Employee salary property
        /// </summary>
        public decimal Salary { get => _salary; set => _salary = value; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Employee() { }
        /// <summary>
        /// Parametric constructor, creating new employee with given informations like name surname
        /// phone number and salary.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="salary"></param>
        public Employee(string name, string surname, string phoneNumber, decimal salary)
        {
            Name = name;
            Surname = surname;
            PhoneNumber1 = PhoneNumber(phoneNumber);
            Salary = salary;
        }
        /// <summary>
        /// method to change salary of an employee
        /// </summary>
        /// <param name="newSalary"></param>
        public void ChangeSalary(decimal newSalary)
        {
            _salary = newSalary;
        }
        /// <summary>
        /// method checking whether the employees phone number is valid, if now it throws exception.
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
        /// Returns informations about employee as text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _name + " " + _surname + " " + "(Phone number: "+_phoneNumber+")";
        }
    }

}
