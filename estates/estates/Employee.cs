﻿using System.Text.RegularExpressions;

namespace estates
{
    class Employee:RealEstateCompany
    {
        string _name;
        string _surname;
        string _phoneNumber;
        decimal _salary;
        decimal _sale_bonus;
        static decimal _amountForSale = 50;
        int _sold_estates = 0;

        public Employee(string name, string surname, string phone_number, decimal salary, int sold_estates)
        {
            _name = name;
            _surname = surname;
            _phoneNumber = PhoneNumber(phone_number);
            _salary = salary;
            _sale_bonus = SaleBonus(sold_estates, _amountForSale);
            _sold_estates = sold_estates;
            DodajPracownika(this);
            
        }

        public decimal SaleBonus(int sold_estates, decimal amount_for_sale)
        {
            return sold_estates * amount_for_sale;
        }

        public string PhoneNumber(string phone_number)
        {
            var r = new Regex(@"\d{9}");
            var re = new Regex(@"\d{3}\-\d{3}\-\d{3}");
            if (r.IsMatch(phone_number) || re.IsMatch(phone_number))
            {
                return _phoneNumber = phone_number;
            }
            else
            {
                throw new System.Exception();
            }
        }

        public override string ToString()
        {
            return _name + " " + _surname + " " + _phoneNumber;
        }
    }

}