using System;

namespace FrbaCrucero.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException(string message) :
            
            base( "Error: " + message )
        { }
    }
}
