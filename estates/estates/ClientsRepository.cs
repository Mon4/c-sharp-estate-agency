using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class ClientsRepository
    {
        string _name;
        List<Client> _clientList;

        public ClientsRepository()
        {
            _clientList = new List<Client>();
        }
        public ClientsRepository(string n):this()
        {
            _name = n;
        }
        public void AddClient(Client c)
        {
            _clientList.Add(c);
        }
        public void RemoveClient(Client c)
        {
            if (_clientList.Contains(c))
            {
                _clientList.Remove(c);
            }
            else
            {
                throw new NoItemFoundException();
            }
        }

        public void FindClient(string surname)
        {
            foreach(Client c in _clientList)
            {
                if(c.Surname==surname)
                {
                    Console.WriteLine(c);
                }
            }
        }

        public void SortClients()
        {
            _clientList.Sort();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + _name);
            foreach (Client c in _clientList)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }


    }
}
