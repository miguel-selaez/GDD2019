using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAO
{
    public static class DAOFactory
    {
        private static DBConnection _connection = new DBConnection("Hotel");

        private static FuncionDAO _funcionDao;
        private static RolDAO _rolDao;
        private static UsuarioDAO _usuarioDao;
        private static ClienteDAO _clienteDao;

        public static FuncionDAO FuncionDAO { get { return _funcionDao ?? (_funcionDao = new FuncionDAO(_connection)); } }

        public static RolDAO RolDAO { get { return _rolDao ?? (_rolDao = new RolDAO(_connection)); } }

        public static UsuarioDAO UsuarioDAO { get { return _usuarioDao ?? (_usuarioDao = new UsuarioDAO(_connection)); } }

        public static ClienteDAO ClienteDAO { get { return _clienteDao ?? (_clienteDao = new ClienteDAO(_connection)); } }

    }
}
