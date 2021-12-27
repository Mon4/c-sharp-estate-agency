namespace estates
{
    class Employee
    {
        string name;
        string surname;
        string phone_number;
        decimal salary;
        decimal sale_bonus;

        public Employee(string name, string surname, string phone_number, decimal salary, decimal sale_bonus)
        {
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
            this.salary = salary;
            this.sale_bonus = sale_bonus;
        }
    }
}
