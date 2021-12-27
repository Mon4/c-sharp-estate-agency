using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    enum Kind_of_meeting { watching, selling }

    internal class Program
    {
        static void Main(string[] args)
        {
            PrivateOwner po1 = new PrivateOwner(adress: "Kraków", zip_code: "32-123", city: "Kraków", phone_number: "123456789", estates_number:1, name: "Mariusz", surname: "Grzyb");
         
            Client c1 = new Client(name: "Jan", surname: "Kowalski", phone_number: "512132546", date: "15.12.1980");
            
            Employee e1 = new Employee(name: "Janina", surname: "Nowak", phone_number: "801234123", salary: 2500, sold_estates:0);
            
            House h1 = new House(id:1, adress: "Kraków", zip_code: "31-642", city:"Kraków", price: 50000, area: 50, furniture: true, balcony: true, rooms_number:4, 
                description:"nice house", bedrooms:2, owner: po1, levels:2, garden: true, garden_area:20);
            
            Flat f1 = new Flat(id:2, adress: "Kraków", zip_code:"32-123", city:"Kraków", price: 400000, area:90, furniture:true, balcony:false, rooms_number:5,
                description: "nice flat", bedrooms: 1, owner: po1, building_development: "kamienica", level:10);
            
            Meeting m1 = new Meeting(client: c1, employee: e1, estate: h1, date1: "12.12.2021", Kind_of_meeting.selling);
            
            Company co1 = new Company(adress:"Kraków", zip_code:"23-534", city:"Kraków", phone_number:"123456789", estates_number:1, nip:"123", company_name:"BUDUJEMY_SE");


            System.Console.WriteLine(e1);
        }
    }
}
