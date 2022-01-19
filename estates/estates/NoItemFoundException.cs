using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class NoItemFoundException:Exception
    {
        /// <summary>
        /// Default contructor
        /// </summary>
        public NoItemFoundException() : base() { }
        /// <summary>
        /// Parametric constructor
        /// </summary>
        /// <param name="msg"></param>
        public NoItemFoundException(string msg) : base(msg) { }
    }
}
