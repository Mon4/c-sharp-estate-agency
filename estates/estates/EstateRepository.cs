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
        }
        public void RemoveEstate(Estate e)
        {
            if (_estateList.Contains(e))
            {
                _estateList.Remove(e);
            }
            else
            {
                throw new NoItemFoundException();
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
