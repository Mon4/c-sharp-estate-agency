namespace estates
{
    class Employee
    {
        string _name;
        string _surname;
        string _phone_number;
        decimal _salary;
        decimal _sale_bonus;

        public Employee(string name, string surname, string phone_number, decimal salary, decimal sale_bonus)
        {
            _name = name;
            _surname = surname;
            _phone_number = phone_number;
            _salary = salary;
            _sale_bonus = sale_bonus;
        }
    }
}
