using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class Estadisticas : Form
    {
        private Model.Session session;

        public Estadisticas()
        {
            InitializeComponent();
        }

        public Estadisticas(Model.Session session)
        {
            // TODO: Complete member initialization
            this.session = session;
        }
    }
}
