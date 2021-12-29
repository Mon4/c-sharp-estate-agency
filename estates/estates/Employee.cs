using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    public class Employee
    {
        string _name;
        string _surname;
        string _phoneNumber;
        decimal _salary;
        decimal _sale_bonus;
        int _sold_estates = 0;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string PhoneNumber1 { get => _phoneNumber; set => _phoneNumber = value; }
        public decimal Salary { get => _salary; set => _salary = value; }
        public decimal Sale_bonus { get => _sale_bonus; set => _sale_bonus = value; }
        public int Sold_estates { get => _sold_estates; set => _sold_estates = value; }

        public Employee(string name, string surname, string phoneNumber, decimal salary)
        {
            _name = name;
            _surname = surname;
            _phoneNumber = PhoneNumber(phoneNumber);
            _salary = salary;
            _sale_bonus = 0;
            _sold_estates = 0;
        }

        public void PaySaleBonus()
        {
            _sale_bonus = 0;
        }
        public void ChangeSalary(decimal newSalary)
        {
            _salary = newSalary;
        }
        public string PhoneNumber(string phoneNumber)
        {
            var r = new Regex(@"\d{9}");
            var re = new Regex(@"\d{3}\-\d{3}\-\d{3}");
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

        public override string ToString()
        {
            return _name + " " + _surname + " " + _phoneNumber;
        }
    }

}
