using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    /// <summary>
    /// Exception thrown when there is no item found in list ( we use it when we want to remove
    /// someone or something from list in repositories)
    /// </summary>
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
