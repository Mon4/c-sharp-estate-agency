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
    public class ClientsRepository
    {
        string _name;
        List<Client> _clientList;

        public string Name { get => _name; set => _name = value; }
        public List<Client> ClientList { get => _clientList; set => _clientList = value; }

        public ClientsRepository()
        {
            ClientList = new List<Client>();
        }
        public ClientsRepository(string n):this()
        {
            Name = n;
        }
        public void AddClient(Client c)
        {
            ClientList.Add(c);
        }
        public void RemoveClient(Client c)
        {
            try
            {
                if (ClientList.Contains(c))
                {
                    ClientList.Remove(c);
                }
                else
                {
                    throw new NoItemFoundException("Client not found");
                }
            }
            catch(NoItemFoundException nife)
            {
                Console.WriteLine(nife.Message);
            }
        }

        public void FindClient(string surname)
        {
            foreach(Client c in ClientList)
            {
                if(c.Surname==surname)
                {
                    Console.WriteLine(c);
                }
            }
        }

        public void SortClients()
        {
            ClientList.Sort();
        }
        public Client FindClientbyToString(string text)
        {
            foreach (var emp in ClientList)
            {
                if (emp.ToString() == text)
                {
                    return emp;
                }
            }
            Client emp1 = new Client();
            return emp1;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + Name);
            foreach (Client c in ClientList)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }
        public void SaveToXML()
        {
            var xs = new XmlSerializer(typeof(ClientsRepository));
            var fs = new FileStream("../../../clients.xml", FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public static ClientsRepository ReadXML()
        {
            ClientsRepository client_rep;
            var xs = new XmlSerializer(typeof(ClientsRepository));
            var fs = new FileStream("../../../clients.xml", FileMode.Open);
            client_rep = (ClientsRepository)xs.Deserialize(fs);
            fs.Close();
            return client_rep;
        }

    }
}
