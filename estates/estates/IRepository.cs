using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    interface IRepository
    {
        void SaveToXML();
        string ToString();
    }
}
