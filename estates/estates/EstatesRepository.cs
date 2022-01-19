using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace estates
{
    /// <summary>
    /// Repository containing all estates, has its name and list of estates
    /// </summary>
    [Serializable]
    public class EstatesRepository:IRepository
    {

        string _name;
        List<Estate> _estateList;
        /// <summary>
        /// EstateRepository's name property
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// EstateRepository's estatelist property
        /// </summary>
        public List<Estate> EstateList { get => _estateList; set => _estateList = value; }
        /// <summary>
        /// Creates default constructor, inicializes EstateList
        /// </summary>
        public EstatesRepository()
        {
            EstateList = new List<Estate>();
        }
        /// <summary>
        /// Parametric constructor, creates EstateRepository with given name, refers to default contructor.
        /// </summary>
        /// <param name="n">Estate's name</param>
        public EstatesRepository(string n):this()
        {
            Name = n;
        }
        /// <summary>
        /// Adds estate to EstateList.
        /// </summary>
        /// <param name="e"></param>
        public void AddEstate(Estate e)
        {
            EstateList.Add(e);
            e.Owner.EstatesNumber += 1;
        }
        /// <summary>
        /// Removes estate from EstateList if the list contains the element, if not then throws exception.
        /// </summary>
        /// <param name="e"></param>
        public void RemoveEstate(Estate e)
        {
            try
            {
                if (EstateList.Contains(e))
                {
                    EstateList.Remove(e);
                    e.Owner.EstatesNumber -= 1;
                }
                else
                {
                    throw new NoItemFoundException("Estate not found");
                }
            }
            catch(NoItemFoundException nife)
            {
                Console.WriteLine(nife.Message);
            }
        }
       /// <summary>
       /// Sorts Estate
       /// </summary>
        public void SortEstate()
        {
            EstateList.Sort();
        }
        /// <summary>
        /// Returns informations about EstateRepository in text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + Name);
            foreach (Estate e in EstateList)
            {
                sb.AppendLine(e.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Finds Estete by string (important for GUI)
        /// </summary>
        /// <param name="text">string in tostring</param>
        /// <returns></returns>
        public Estate FindEstatebyToString(string text)
        {
            foreach (var emp in EstateList)
            {
                if (emp.ToString() == text)
                {
                    return emp;
                }
            }
            Flat emp1 = new Flat();
            return emp1;
        }
        /// <summary>
        /// Saves EstateRepository to xml file.
        /// </summary>
        public void SaveToXML()
        {
            var xs = new XmlSerializer(typeof(EstatesRepository));                      
            var fs = new FileStream("../../../estates.xml", FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        /// <summary>
        /// Reads xml file to new EstateRepository
        /// </summary>
        /// <returns></returns>
        public static EstatesRepository ReadXML()
        {
            EstatesRepository estate_rep;
            var xs = new XmlSerializer(typeof(EstatesRepository));
            var fs = new FileStream("../../../estates.xml", FileMode.Open);
            estate_rep = (EstatesRepository)xs.Deserialize(fs);
            fs.Close();
            return estate_rep;
        }
    }
}
