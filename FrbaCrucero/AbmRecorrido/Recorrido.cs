using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class Recorrido : Form
    {
        private Model.Session session;

        public Recorrido()
        {
            InitializeComponent();
        }

        public Recorrido(Model.Session session)
        {
            // TODO: Complete member initialization
            this.session = session;
        }
    }
}
