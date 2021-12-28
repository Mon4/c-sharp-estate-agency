using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    enum KindOfMeeting { watching, selling }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            PrivateOwner po1 = new PrivateOwner(adress: "Kraków", zipCode: "32-123", city: "Kraków", phoneNumber: "123456789", estatesNumber:1, name: "Mariusz", surname: "Grzyb");
         
            Client c1 = new Client(name: "Jan", surname: "Kowalski", phoneNumber: "512132546", date: "15.12.1980");
            
            Employee e1 = new Employee(name: "Janina", surname: "Nowak", phoneNumber: "801234123", salary: 2500, sold_estates:0);
            
            House h1 = new House(id:1, adress: "Kraków", zipCode: "31-642", city:"Kraków", price: 50000, area: 50, furniture: true, balcony: true, roomsNumber:4, 
                description:"nice house", bedrooms:2, owner: po1, levels:2, garden: true, gardenArea:20);
            
            Flat f1 = new Flat(id:2, adress: "Kraków", zipCode:"32-123", city:"Kraków", price: 400000, area:90, furniture:true, balcony:false, roomsNumber:5,
                description: "nice flat", bedrooms: 1, owner: po1, building_development: "kamienica", level:10);
            
            Meeting m1 = new Meeting(client: c1, employee: e1, estate: h1, date1: "12.12.2021", KindOfMeeting.selling);
            
            Company co1 = new Company(adress:"Kraków", zipCode:"23-534", city:"Kraków", phoneNumber:"123456789", estatesNumber:1, nip:"123", companyName:"BUDUJEMY_SE");


            System.Console.WriteLine(e1);
        }
    }
}
