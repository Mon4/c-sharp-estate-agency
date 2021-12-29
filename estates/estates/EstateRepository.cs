using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class EstatesRepository
    {

        string _name;
        List<Estate> _estateList;

        public EstatesRepository()
        {
            _estateList = new List<Estate>();
        }
        public EstatesRepository(string n):this()
        {
            _name = n;
        }
        public void AddEstate(Estate e)
        {
            _estateList.Add(e);
            e.Owner.EstatesNumber += 1;
        }
        public void RemoveEstate(Estate e)
        {
            try
            {
                if (_estateList.Contains(e))
                {
                    _estateList.Remove(e);
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
            int numberOfEstates = _estateList.Count;
            decimal bonus = est.Price*(decimal)0.01;
            RemoveEstate(est);
            if(_estateList.Count<numberOfEstates)
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
            _estateList.Sort();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + _name);
            foreach (Estate e in _estateList)
            {
                sb.AppendLine(e.ToString());
            }
            return sb.ToString();
        }

    }
}
