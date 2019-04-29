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
    public partial class CompraReserva : Form
    {
        private Model.Session session;

        public CompraReserva()
        {
            InitializeComponent();
        }

        public CompraReserva(Model.Session session)
        {
            // TODO: Complete member initialization
            this.session = session;
        }
    }
}
