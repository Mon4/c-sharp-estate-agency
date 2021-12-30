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
    public class OwnersRepository
    {
        string _name;
        List<Owner> _ownerList;

        public string Name { get => _name; set => _name = value; }
        public List<Owner> OwnerList { get => _ownerList; set => _ownerList = value; }

        public OwnersRepository()
        {
            OwnerList = new List<Owner>();
        }
        public OwnersRepository(string n):this()
        {
            Name = n;
        }
        public void AddOwner(Owner o)
        {
            OwnerList.Add(o);
        }
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
        public void FindOwnerbyNumber(string phone)
        {
            var pom = OwnerList.Find(x => x.PhoneNumber == phone);
            Console.WriteLine(pom);
        }
        public void SortOwners()
        {
            OwnerList.Sort();
        }

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
        public void SaveToXML(string path)
        {
            var xs = new XmlSerializer(typeof(OwnersRepository));
            var fs = new FileStream(path, FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public static OwnersRepository ReadXML(string path)
        {
            OwnersRepository owners_rep;
            var xs = new XmlSerializer(typeof(OwnersRepository));
            var fs = new FileStream(path, FileMode.Open);
            owners_rep = (OwnersRepository)xs.Deserialize(fs);
            fs.Close();
            return owners_rep;
        }
    }
}
