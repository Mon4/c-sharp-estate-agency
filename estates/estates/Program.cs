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
    }

    class Client
    {
        string name;
        string surname;
        string phone_number;
        DateTime date_of_birth;
    }

    class Employee
    {
        string name;
        string surname;
        string phone_number;
        decimal salary;
        decimal sale_bonus;
    }

    public abstract class Estate
    {
        int id;
        string adress;
        string zip_code;
        string city;
        double price;
        decimal area; //pol. powierzchnia
        bool furniture;
        bool balcony;
        int rooms_numer;
        string description;
        int bedrooms;
        Owner owner;
    }

    class House:Estate
    {
        int levels;
        bool garden;
        decimal garden_area;
    }

    class Flat : Estate
    {
        string building_development; //pol. zabudowa
        int level;
    }

    class Meeting
    {
        Client client;
        Employee employee;
        Estate estate;
        DateTime date;
        Kind_of_meeting kind;
    }

    class PrivateOwner
    {
        string name;
        string surname;
    }

    class Company
    {
        string NIP;
        string company_name;
    }

    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
