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
    /// Repository containing all owners, has its name and list of owners.
    /// </summary>
    [Serializable]
    public class OwnersRepository:IRepository
    {
        string _name;
        List<Owner> _ownerList;
        /// <summary>
        /// OwnersRepository's name property
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// OwnersRepository's ownerlist property
        /// </summary>
        public List<Owner> OwnerList { get => _ownerList; set => _ownerList = value; }
        /// <summary>
        /// Default constructor, inicializes OwnersList
        /// </summary>
        public OwnersRepository()
        {
            OwnerList = new List<Owner>();
        }
        /// <summary>
        /// Parametric constructor, creates new OwnersRepository with given name, refers to default constructor.
        /// </summary>
        /// <param name="n"></param>
        public OwnersRepository(string n):this()
        {
            Name = n;
        }
        /// <summary>
        /// Adds new owner to OwnersList.
        /// </summary>
        /// <param name="o">owner</param>
        public void AddOwner(Owner o)
        {
            OwnerList.Add(o);
        }
        /// <summary>
        /// Removes owner from OwnersList if the list contains this person, if not throws exception
        /// </summary>
        /// <param name="o">owner</param>
        public void RemoveOwner(Owner o)
        {
            try
            {
                if (OwnerList.Contains(o))
                {
                    OwnerList.Remove(o);
                }
                else
                {
                    throw new NoItemFoundException("Owner not found");
                }
            }
            catch(NoItemFoundException nife)
            {
                Console.WriteLine(nife.Message);
            }
        }
        /// <summary>
        /// Finds owner by its phone.
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public Owner FindOwnerbyNumber(string phone)
        {
            var pom = OwnerList.Find(x => x.PhoneNumber == phone);
            return pom;
        }
        /// <summary>
        /// Sorts owners.
        /// </summary>
        public void SortOwners()
        {
            OwnerList.Sort();
        }
        /// <summary>
        /// Returns informations about owners as text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + Name);
            foreach(Owner o in OwnerList)
            {
                sb.AppendLine(o.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Saves OwnersRepository to xml file.
        /// </summary>
        public void SaveToXML()
        {
            var xs = new XmlSerializer(typeof(OwnersRepository));
            var fs = new FileStream("../../../owners.xml", FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        /// <summary>
        /// Reads xml file to new OwnersRepository.
        /// </summary>
        /// <returns></returns>
        public static OwnersRepository ReadXML()
        {
            OwnersRepository owners_rep;
            var xs = new XmlSerializer(typeof(OwnersRepository));
            var fs = new FileStream("../../../owners.xml", FileMode.Open);
            owners_rep = (OwnersRepository)xs.Deserialize(fs);
            fs.Close();
            return owners_rep;
        }
    }
}
