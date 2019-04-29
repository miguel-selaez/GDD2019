using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException(string message) :
            
            base( "Error: " + message )
        { }
    }
}
