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
    public class EstatesRepository
    {

        string _name;
        List<Estate> _estateList;

        public string Name { get => _name; set => _name = value; }
        public List<Estate> EstateList { get => _estateList; set => _estateList = value; }

        public EstatesRepository()
        {
            EstateList = new List<Estate>();
        }
        public EstatesRepository(string n):this()
        {
            Name = n;
        }
        public void AddEstate(Estate e)
        {
            EstateList.Add(e);
            e.Owner.EstatesNumber += 1;
        }
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
        public void SellEstate(Estate est, Employee emp)
        {
            int numberOfEstates = EstateList.Count;
            decimal bonus = est.Price*(decimal)0.01;
            RemoveEstate(est);
            if(EstateList.Count<numberOfEstates)
            {
                emp.Sale_bonus += bonus;
                emp.Sold_estates += 1;
            }
            else
            {
                return;
            }
        }
        public void SortEstate()
        {
            EstateList.Sort();
        }

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
        public void SaveToXML(string path)
        {
            var xs = new XmlSerializer(typeof(EstatesRepository));                      
            var fs = new FileStream(path, FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public static EstatesRepository ReadXML(string path)
        {
            EstatesRepository estate_rep;
            var xs = new XmlSerializer(typeof(EstatesRepository));
            var fs = new FileStream(path, FileMode.Open);
            estate_rep = (EstatesRepository)xs.Deserialize(fs);
            fs.Close();
            return estate_rep;
        }
    }
}
