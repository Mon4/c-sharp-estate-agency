using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class NoItemFoundException:Exception
    {
        public NoItemFoundException()
        {
            Console.WriteLine("The list doesnt contain the element you tried to delete");
        }
        public NoItemFoundException(string w)
        {
            Console.WriteLine(w);
        }


    }
}
