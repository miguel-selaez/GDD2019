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

        public AltaCrucero()
        {
            InitializeComponent();
        }

        public AltaCrucero(Model.Session session)
        {
            // TODO: Complete member initialization
            this._session = session;
        }

        public AltaCrucero(Model.Session _session, Model.Crucero selectedRol, ListadoCrucero listadoCrucero)
        {
            // TODO: Complete member initialization
            this._session = _session;
            this._selectedRol = selectedRol;
            this._listadoCrucero = listadoCrucero;
        }
    }
}
