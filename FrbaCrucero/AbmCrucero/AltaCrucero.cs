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
    public partial class AltaCrucero : Form
    {
        private Model.Session _session;
        private Model.Crucero _selectedRol;
        private ListadoCrucero _listadoCrucero;
        
        public AltaCrucero(Model.Session session)
        {
            InitializeComponent();

            this._session = session;
        }

        public AltaCrucero(Model.Session _session, Model.Crucero selectedRol, ListadoCrucero listadoCrucero)
        {
            InitializeComponent();

            this._session = _session;
            this._selectedRol = selectedRol;
            this._listadoCrucero = listadoCrucero;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarCabina_Click(object sender, EventArgs e)
        {
            var nueva = new AltaCabina();
            nueva.Show();
        }

        private void btnEliminarCabina_Click(object sender, EventArgs e)
        {

        }

        private void btnFueraServicio_Click(object sender, EventArgs e)
        {
            var fueraServicio = new FueraDeServicio();
            fueraServicio.Show();
        }
    }
}
