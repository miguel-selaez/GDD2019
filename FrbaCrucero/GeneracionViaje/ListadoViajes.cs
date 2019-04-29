using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.GeneracionViaje
{
    public partial class ListadoViajes : Form
    {
        private Model.Session session;

        public ListadoViajes()
        {
            InitializeComponent();
        }

        public ListadoViajes(Model.Session session)
        {
            // TODO: Complete member initialization
            this.session = session;
        }
    }
}
