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
        private static CruceroDAO _cruceroDao;
        private static ViajeDAO _viajeDao;
        private static CabinaDAO _cabinaDao;
        private static PagoDAO _pagoDao;
        private static MedioPagoDAO _medioPagoDao;
        private static ReservaDAO _reservaDao;
        private static PasajeDAO _pasajeDao;
        private static EstadisticaDAO _estadisticaDao;

        public static FuncionDAO FuncionDAO { get { return _funcionDao ?? (_funcionDao = new FuncionDAO(_connection)); } }

        public static RolDAO RolDAO { get { return _rolDao ?? (_rolDao = new RolDAO(_connection)); } }

        public static UsuarioDAO UsuarioDAO { get { return _usuarioDao ?? (_usuarioDao = new UsuarioDAO(_connection)); } }

        public static ClienteDAO ClienteDAO { get { return _clienteDao ?? (_clienteDao = new ClienteDAO(_connection)); } }

        public static PuertoDAO PuertoDAO { get { return _puertoDao ?? (_puertoDao = new PuertoDAO(_connection)); } }

        public static TramoDAO TramoDAO { get { return _tramoDao ?? (_tramoDao = new TramoDAO(_connection)); } }

        public static RecorridoDAO RecorridoDAO { get { return _recorridoDao ?? (_recorridoDao = new RecorridoDAO(_connection)); } }

        public static CruceroDAO CruceroDAO { get { return _cruceroDao ?? (_cruceroDao = new CruceroDAO(_connection)); } }

        public static ViajeDAO ViajeDAO { get { return _viajeDao ?? (_viajeDao = new ViajeDAO(_connection)); } }

        public static CabinaDAO CabinaDAO { get { return _cabinaDao ?? (_cabinaDao = new CabinaDAO(_connection)); } }
        
        public static PagoDAO PagoDAO { get { return _pagoDao ?? (_pagoDao = new PagoDAO(_connection)); } }

        public static MedioPagoDAO MedioPagoDAO { get { return _medioPagoDao ?? (_medioPagoDao = new MedioPagoDAO(_connection)); } }
        
        public static ReservaDAO ReservaDAO { get { return _reservaDao ?? (_reservaDao = new ReservaDAO(_connection)); } }

        public static PasajeDAO PasajeDAO { get { return _pasajeDao ?? (_pasajeDao = new PasajeDAO(_connection)); } }

        public static EstadisticaDAO EstadisticaDAO { get { return _estadisticaDao ?? (_estadisticaDao = new EstadisticaDAO(_connection)); } }
    }
}
