using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.PagoReserva
{
    public partial class Pago : Form
    {
        private Model.Session session;

        public Pago()
        {
            InitializeComponent();
        }

        public Pago(Model.Session session)
        {
            // TODO: Complete member initialization
            this.session = session;
        }
    }
}
