using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FrbaCrucero.Model;

namespace FrbaCrucero.AbmCrucero
{
    public partial class AltaCabina : Form
    {
        private Session _session;
        private Cabina _cabina;
        private AltaCrucero _altaCrucero;

        public AltaCabina()
        {
            InitializeComponent();
        }

        public AltaCabina(Session session, AltaCrucero altaCrucero)
        {
            InitializeComponent();
            _session = session;
            this._altaCrucero = altaCrucero;

            var tipos = DAO.DAOFactory.CabinaDAO.GetTiposCabina();
            BindCbTipos(tipos);
        }
        
        private void BindCbTipos(List<Model.TipoCabina> tipos)
        {
            cbTipos.DataSource = null;
            cbTipos.DataSource = tipos;
            cbTipos.DisplayMember = "Descripcion";
            cbTipos.SelectedIndex = 0;
        }
        
        private void btnAgregarCabina_Click(object sender, EventArgs e)
        {
            var numero = Decimal.Parse(txtNumero.Text);
            var piso = decimal.Parse(txtPiso.Text);
            var nuevaCabina = new Cabina(numero, piso, false, (Model.TipoCabina)cbTipos.SelectedItem);
            _altaCrucero.AgregarCabina(nuevaCabina);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
