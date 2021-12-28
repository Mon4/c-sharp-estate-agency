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
            _estateList.Remove(e);
        }
        public void SortEstate()
        {
            _estateList.Sort();
        }

    }
}
