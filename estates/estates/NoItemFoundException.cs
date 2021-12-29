using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class NoItemFoundException:Exception
    {
        public NoItemFoundException() : base() { }
        public NoItemFoundException(string msg) : base(msg) { }
    }
}
