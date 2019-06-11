using System;

namespace FrbaCrucero.Exceptions
{
    class ClienteException : Exception
    {
        public ClienteException(string message) :

        base("Error: " + message) { }
    }
}
