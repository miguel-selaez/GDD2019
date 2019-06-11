using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Reserva(Session session, List<Pasaje> pasajes)
        {
            InitializeComponent();
            _session = session;
            _pasajes = pasajes;
        }
    }
}
