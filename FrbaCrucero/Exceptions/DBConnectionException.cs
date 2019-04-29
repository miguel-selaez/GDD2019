using System;

namespace FrbaCrucero.Exceptions
{
    public class DBConnectionException : Exception
    {
        public DBConnectionException(string message) :
            
            base( "Error de Base Datos: " + message )
        { }

    }
}