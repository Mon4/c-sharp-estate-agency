using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
     class RealEstateCompany
    {
        List<Employee> employees;
        List<Meeting> meetings;

        public List<Employee> Employees { get => employees; set => employees = value; }
        public List<Meeting> Meetings { get => meetings; set => meetings = value; }

        public RealEstateCompany()
        {
            Employees = new List<Employee>();
            Meetings = new List<Meeting>();
        }

        public void DodajPracownika(Employee e)
        {
            Employees.Add(e);
        }
        public void UsunPracownika(Employee e)
        {
            Employees.Remove(e);
        }
        public void dodajSpotkanie(Meeting m)
        {
            Meetings.Add(m);
        }
        public void usunSpotkanie(Meeting m)
        {
            Meetings.Remove(m);
        }


    }
}
