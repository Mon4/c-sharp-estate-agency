using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using estates;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ClientTest()
        {
            Client client1 = new Client("Adam", "Nowa", "900456100", "11.01.2000");
            ClientsRepository cr = new ClientsRepository("Repository of the clients");
            cr.AddClient(client1);
            Assert.AreEqual("Repository of the clients", cr.Name);
            Assert.AreEqual("Adam", client1.Name);
            DateTime dt = new DateTime(2000, 1, 11);
            Assert.AreEqual(dt, client1.DateOfBirth);
            Assert.AreEqual(1, cr.ClientList.Count);
        }
        [TestMethod]
        public void RepositoryTest()
        {
            Employee e1 = new Employee("Agata", "Kowalska", "100100100", 4000m);
            EmployeesRepository er = new EmployeesRepository("Repository");
            er.AddEmployee(e1);
            Assert.AreEqual(1, er.Employelist.Count);
            er.RemoveEmployee(e1);
            Assert.AreEqual(0, er.Employelist.Count);
        }
        [TestMethod]
        public void SortingTest()
        {
            PrivateOwner p1 = new PrivateOwner("Koszalinska 1", "34-100", "Wadowice", "900100700", "Marcin", "Nowak");
            PrivateOwner p2 = new PrivateOwner("Koszalinska 2", "45-100", "Kraków", "000111000", "Adam", "Druz");
            OwnersRepository ow = new OwnersRepository("Repository");
            ow.AddOwner(p1);
            ow.AddOwner(p2);
            Assert.AreEqual(p1, ow.OwnerList[0]);
            ow.SortOwners();
            Assert.AreEqual(p2, ow.OwnerList[0]);
        }
        [TestMethod]
        public void SaveTest()
        {
            Client c1 = new Client("Adam", "Nowak", "000111222", "11.12.1900");
            ClientsRepository cr = new ClientsRepository("Repository of the clients");
            cr.AddClient(c1);
            cr.SaveToXML();
            ClientsRepository cr2 = ClientsRepository.ReadXML();
            Assert.AreEqual(cr2.ClientList[0].Name, "Adam");
        }
        [TestMethod]
        public void PhoneNumberTest()
        {
            Client c = new Client("Adam", "Nowak", "blednyNumer", "12.03.1990");
            Assert.AreEqual("unknown phone number", c.PhoneNumber);
            c.PhoneNumber = "900100100";
            Assert.AreEqual("900100100", c.PhoneNumber);
        }
        [TestMethod]
        public void EstateCounterTest()
        {
            PrivateOwner p = new PrivateOwner("Koszalinska 1", "12-300", "Warszawa", "900100100", "Maria", "Nowak");
            Flat f = new Flat("Elblaska 1", "12-600", "Warszawa", 600000, 67.5m, true, false, 5, "nice house", 2, p, "blok", 1);
            EstatesRepository est1 = new EstatesRepository("Repository");
            est1.AddEstate(f);
            Assert.AreEqual(p.EstatesNumber, 1);
        }
    }
}
