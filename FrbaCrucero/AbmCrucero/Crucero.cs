using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class Crucero : Form
    {
        private Model.Session session;

        public Crucero()
        {
            InitializeComponent();
        }

        public Crucero(Model.Session session)
        {
            // TODO: Complete member initialization
            this.session = session;
        }
    }
}
