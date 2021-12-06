using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    enum Kind_of_meeting { watching, selling}
    public abstract class Owner
    {
        string adress; //street and home number
        string zip_code;
        string city;
        string phone_number;
        string estates_number;

        protected Owner(string adress, string zip_code, string city, string phone_number, string estates_number)
        {
            this.adress = adress;
            this.zip_code = zip_code;
            this.city = city;
            this.phone_number = phone_number;
            this.estates_number = estates_number;
        }
    }

    class Client
    {
        string name;
        string surname;
        string phone_number;
        DateTime date_of_birth;

        public Client(string name, string surname, string phone_number, string data)
        {
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
            DateTime.TryParseExact(data, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date_of_birth);
        }
    }

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

    public abstract class Estate
    {
        int id;
        string adress;
        string zip_code;
        string city;
        decimal price;
        decimal area; //pol. powierzchnia
        bool furniture;
        bool balcony;
        int rooms_numer;
        string description;
        int bedrooms;
        Owner owner;

        protected Estate(int id, string adress, string zip_code, string city, decimal price, decimal area, 
            bool furniture, bool balcony, int rooms_numer, string description, int bedrooms, Owner owner)
        {
            this.id = id;
            this.adress = adress;
            this.zip_code = zip_code;
            this.city = city;
            this.price = price;
            this.area = area;
            this.furniture = furniture;
            this.balcony = balcony;
            this.rooms_numer = rooms_numer;
            this.description = description;
            this.bedrooms = bedrooms;
            this.owner = owner;
        }

        public int Id { get => id; set => id = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Zip_code { get => zip_code; set => zip_code = value; }
        public string City { get => city; set => city = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal Area { get => area; set => area = value; }
        public bool Furniture { get => furniture; set => furniture = value; }
        public bool Balcony { get => balcony; set => balcony = value; }
        public int Rooms_numer { get => rooms_numer; set => rooms_numer = value; }
        public string Description { get => description; set => description = value; }
        public int Bedrooms { get => bedrooms; set => bedrooms = value; }
        public Owner Owner { get => owner; set => owner = value; }
    }

    class House:Estate
    {
        int levels;
        bool garden;
        decimal garden_area;

        public House(int id, string adress, string zip_code, string city, decimal price, 
            decimal area, bool furniture, bool balcony, int rooms_number, string description,
            int bedrooms, Owner owner, int levels, bool garden, decimal garden_area):base(id, adress, zip_code, city, price, area,
                furniture, balcony, rooms_number, description, bedrooms, owner)
        {
            this.levels = levels;
            this.garden = garden;
            this.garden_area = garden_area;
        }
    }

    class Flat : Estate
    {
        string building_development; //pol. zabudowa
        int level;

        public Flat(int id, string adress, string zip_code, string city, decimal price,
            decimal area, bool furniture, bool balcony, int rooms_number, string description,
            int bedrooms, Owner owner, string building_development, int level):base(id, adress, zip_code, city, price, area,
                furniture, balcony, rooms_number, description, bedrooms, owner)
        {
            this.building_development = building_development;
            this.level = level;
        }
    }

    class Meeting
    {
        Client client;
        Employee employee;
        Estate estate;
        DateTime date;
        Kind_of_meeting kind;

        public Meeting(Client client, Employee employee, Estate estate, string date1, Kind_of_meeting kind)
        {
            this.client = client;
            this.employee = employee;
            this.estate = estate;
            DateTime.TryParseExact(date1, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date);
            this.kind = kind;
        }
    }

    class PrivateOwner:Owner
    {
        string name;
        string surname;

        public PrivateOwner(string adress, string zip_code, string city, string phone_number, string estates_number, 
            string name, string surname):base(adress, zip_code, city, phone_number, estates_number)
        {
            this.name = name;
            this.surname = surname;
        }
    }

    class Company:Owner
    {
        string NIP;
        string company_name;

        public Company(string adress, string zip_code, string city, string phone_number, string estates_number,
            string nip, string company_name): base(adress, zip_code, city, phone_number, estates_number)
        {
            NIP = nip;
            this.company_name = company_name;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            

        }
    }
}
