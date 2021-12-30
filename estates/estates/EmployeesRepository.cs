using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace estates
{
    [Serializable]
    public class EmployeesRepository:IComparer<Employee>
    {
        string _name;
        List<Employee> _employelist;

        public string Name { get => _name; set => _name = value; }
        public List<Employee> Employelist { get => _employelist; set => _employelist = value; }

        public EmployeesRepository()
        {
            Employelist = new List<Employee>();
        }
        public EmployeesRepository(string n):this()
        {
            Name = n;
        }
        public void AddEmployee(Employee e)
        {
            Employelist.Add(e);
        }
        public void RemoveEmployee(Employee e)
        {
            try
            {
                if (Employelist.Contains(e))
                {
                    Employelist.Remove(e);
                }
                else
                {
                    throw new NoItemFoundException("Employee not found");
                }
            }
            catch(NoItemFoundException nife)
            {
                Console.WriteLine(nife.Message);
            }
        }

        public void EmploySort()
        {
            Employelist.Sort();
        }

        public int Compare(Employee x, Employee y)
        {
            if (x.Surname == y.Surname)
                return x.Name.CompareTo(y.Name);
            else
                return x.Surname.CompareTo(y.Surname);
        }

        public void FindEmployeebyName(string name)
        {
            foreach(Employee e in Employelist)
            {
                if(e.Name==name)
                {
                    Console.WriteLine(e);
                }    
            }
        }

        public void FindEmployeebyNumber(string number)
        {
            foreach (Employee e in Employelist)
            {
                if (e.PhoneNumber1 == number)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + Name);
            foreach (Employee e in Employelist)
            {
                sb.AppendLine(e.ToString());
            }
            return sb.ToString();
        }
        public void SaveToXML(string path)
        {
            var xs = new XmlSerializer(typeof(EmployeesRepository));
            var fs = new FileStream(path, FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public static EmployeesRepository ReadXML(string path)
        {
            EmployeesRepository emp_rep;
            var xs = new XmlSerializer(typeof(EmployeesRepository));
            var fs = new FileStream(path, FileMode.Open);
            emp_rep = (EmployeesRepository)xs.Deserialize(fs);
            fs.Close();
            return emp_rep;
        }




    }
}
