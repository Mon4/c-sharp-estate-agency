using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class OwnersRepository
    {
        string _name;
        List<Owner> _ownerList;

        public OwnersRepository()
        {
            _ownerList = new List<Owner>();
        }
        public OwnersRepository(string n):this()
        {
            _name = n;
        }
        public void AddOwner(Owner o)
        {
            _ownerList.Add(o);
        }
        public void RemoveOwner(Owner o)
        {
            _ownerList.Remove(o);
        }
        public void FindOwnerbyNumber(string phone)
        {
            var pom = _ownerList.Find(x => x.PhoneNumber == phone);
            Console.WriteLine(pom);
        }
        public void SortOwners()
        {
            _ownerList.Sort();
        }
    }
}
