using System;

namespace FrbaCrucero.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message) :      
            base( message )
        { }
    }
}
