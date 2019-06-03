using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAO
{
    public static class DAOFactory
    {
        private static DBConnection _connection = new DBConnection("Crucero");

        private static FuncionDAO _funcionDao;
        private static RolDAO _rolDao;
        private static UsuarioDAO _usuarioDao;
        private static ClienteDAO _clienteDao;
        private static PuertoDAO _puertoDao;
        private static TramoDAO _tramoDao;
        private static RecorridoDAO _recorridoDao;

        public static FuncionDAO FuncionDAO { get { return _funcionDao ?? (_funcionDao = new FuncionDAO(_connection)); } }

        public static RolDAO RolDAO { get { return _rolDao ?? (_rolDao = new RolDAO(_connection)); } }

        public static UsuarioDAO UsuarioDAO { get { return _usuarioDao ?? (_usuarioDao = new UsuarioDAO(_connection)); } }

        public static ClienteDAO ClienteDAO { get { return _clienteDao ?? (_clienteDao = new ClienteDAO(_connection)); } }

        public static PuertoDAO PuertoDAO { get { return _puertoDao ?? (_puertoDao = new PuertoDAO(_connection)); } }

        public static TramoDAO TramoDAO { get { return _tramoDao ?? (_tramoDao = new TramoDAO(_connection)); } }

        public static RecorridoDAO RecorridoDAO { get { return _recorridoDao ?? (_recorridoDao = new RecorridoDAO(_connection)); } }

    }
}
