using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Exceptions
{
    class ClienteException : Exception
    {
        public ClienteException(string message) :

        base("Error: " + message) { }
    }
}
