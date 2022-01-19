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
        /// <summary>
        /// Default constructor, initializes ClientList
        /// </summary>
        public ClientsRepository()
        {
            ClientList = new List<Client>();
        }
        /// <summary>
        /// Creates ClientsRepository and gives its name
        /// </summary>
        /// <param name="n">given name</param>
        public ClientsRepository(string n):this()
        {
            Name = n;
        }
        /// <summary>
        /// Adds client to clientlist, invoked to default constructor
        /// </summary>
        /// <param name="c"></param>
        public void AddClient(Client c)
        {
            ClientList.Add(c);
        }
        /// <summary>
        /// Removes client from clientlist (if the list contains this client otherwise it throws exception)
        /// </summary>
        /// <param name="c"></param>
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
        /// <summary>
        /// Find Client with given surname
        /// </summary>
        /// <param name="surname"></param>
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
        /// <summary>
        /// sorts clients (Compares surnames and names)
        /// </summary>
        public void SortClients()
        {
            ClientList.Sort();
        }
        /// <summary>
        /// Finds client after string (import for GUI)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Return informations about ClientsRepository in text.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Saves repository to xml file
        /// </summary>
        public void SaveToXML()
        {
            var xs = new XmlSerializer(typeof(ClientsRepository));
            var fs = new FileStream("../../../clients.xml", FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        /// <summary>
        /// Reads xml file to repository.
        /// </summary>
        /// <returns></returns>
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
