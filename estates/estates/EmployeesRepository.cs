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
    public class EmployeesRepository:IComparer<Employee>,IRepository
    {
        string _name;
        List<Employee> _employelist;

        public string Name { get => _name; set => _name = value; }
        public List<Employee> Employelist { get => _employelist; set => _employelist = value; }
        /// <summary>
        /// Default constructor, inicializes Eployelist
        /// </summary>
        public EmployeesRepository()
        {
            Employelist = new List<Employee>();
        }
        /// <summary>
        /// Parametric contructor, creates repository with given name and refers to default contructor.
        /// </summary>
        /// <param name="n"></param>
        public EmployeesRepository(string n):this()
        {
            Name = n;
        }
        /// <summary>
        /// Adds employee to EmployeesRepository(list).
        /// </summary>
        /// <param name="e">Employee</param>
        public void AddEmployee(Employee e)
        {
            Employelist.Add(e);
        }
        /// <summary>
        /// Removes employee from EmployeesRepository(list) if the list contains this employee, otherwise throws exception
        /// </summary>
        /// <param name="e">Employee</param>
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
        /// <summary>
        /// Sorts employees by surnames and names.
        /// </summary>
        public void EmploySort()
        {
            Employelist.Sort();
        }
        /// <summary>
        /// Compares Employees surnames, when they are equal compares their names.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Employee x, Employee y)
        {
            if (x.Surname == y.Surname)
                return x.Name.CompareTo(y.Name);
            else
                return x.Surname.CompareTo(y.Surname);
        }
        /// <summary>
        /// Finds employee by given name.
        /// </summary>
        /// <param name="name">Employees'name</param>
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
        /// <summary>
        /// Finds employee by string (important for Gui)
        /// </summary>
        /// <param name="text">string from to string</param>
        /// <returns></returns>
        public Employee FindEmployeebyToString(string text)
        {
            foreach(var emp in Employelist)
            {
                if(emp.ToString()==text)
                {
                    return emp;
                }
            }
            Employee emp1=new Employee();
            return emp1;
        }
        /// <summary>
        /// Finds employee by given number
        /// </summary>
        /// <param name="number">Employees'number</param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        public void SaveToXML()
        {
            var xs = new XmlSerializer(typeof(EmployeesRepository));
            var fs = new FileStream("../../../employees.xml", FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public static EmployeesRepository ReadXML()
        {
            EmployeesRepository emp_rep;
            var xs = new XmlSerializer(typeof(EmployeesRepository));
            var fs = new FileStream("../../../employees.xml", FileMode.Open);
            emp_rep = (EmployeesRepository)xs.Deserialize(fs);
            fs.Close();
            return emp_rep;
        }




    }
}
