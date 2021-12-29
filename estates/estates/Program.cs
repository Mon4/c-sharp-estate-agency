using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    enum KindOfMeeting { watching, selling }
    enum StatusOfMeeting { waiting, ended, endedWithSale}

    internal class Program
    {
        static void Main(string[] args)
        {
            PrivateOwner po1 = new PrivateOwner(adress: "ul. Kwiatowa 4", zipCode: "32-123", city: "Kraków", phoneNumber: "123456789", name: "Mariusz", surname: "Grzyb");
         
            Client c1 = new Client(name: "Jan", surname: "Kowalski", phoneNumber: "512132546", date: "15.12.1980");
            
            Employee e1 = new Employee(name: "Janina", surname: "Nowak", phoneNumber: "801234123", salary: 2500);
            
            House h1 = new House(id:1, adress: "ul. Niebieska 14", zipCode: "31-642", city:"Kraków", price: 50000, area: 50, furniture: true, balcony: true, roomsNumber:4, 
                description:"nice house", bedrooms:2, owner: po1, levels:2, garden: true, gardenArea:20);
            
            Flat f1 = new Flat(id:2, adress: "ul. Mickiewicza 1", zipCode:"32-123", city:"Kraków", price: 400000, area:90, furniture:true, balcony:false, roomsNumber:5,
                description: "nice flat", bedrooms: 1, owner: po1, building_development: "kamienica", level:10);
            
            Meeting m1 = new Meeting(client: c1, employee: e1, estate: h1, date1: "12.12.2021 16:00", KindOfMeeting.selling);
            
            Company co1 = new Company(adress:"ul. Zielona 12", zipCode:"23-534", city:"Kraków", phoneNumber:"123456789", nip:"123-123-12-12", companyName:"BUDUJEMY_SE");

            OwnersRepository or1 = new OwnersRepository("List of the owners");
            or1.AddOwner(co1);
            or1.RemoveOwner(po1);

            System.Console.WriteLine(e1);
            System.Console.WriteLine(m1);
            System.Console.WriteLine(co1);
            System.Console.WriteLine(f1);
            Console.ReadKey();
        }
    }
}
