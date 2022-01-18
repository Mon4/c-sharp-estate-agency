using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEstates
{
    class WrongFormatInTextBoxException : Exception
    {
        public WrongFormatInTextBoxException() : base() { }
        public WrongFormatInTextBoxException(string msg) : base(msg) { }
    }
}
