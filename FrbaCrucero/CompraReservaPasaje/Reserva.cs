using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class Reserva : Form
    {

        private Session _session;
        private List<Pasaje> _pasajes;

        public Reserva()
        {
            InitializeComponent();
        }

        public Reserva(Session session, List<Pasaje> pasajes, Cliente cliente)
        {
            InitializeComponent();
            _session = session;
            _pasajes = pasajes;
            Model.Reserva reserva = new Model.Reserva(0, new DateTime(), false, cliente);
            reserva.Codigo = DAO.DAOFactory.ReservaDAO.CreateOrUpdate(reserva);
            lbCodigo.Text = reserva.Codigo.ToString();
        }
    }
}
