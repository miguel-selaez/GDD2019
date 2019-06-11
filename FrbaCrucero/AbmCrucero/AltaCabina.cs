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
        private AltaCrucero altaCrucero;

        public AltaCabina()
        {
            InitializeComponent();
        }

        public AltaCabina(Session session, Cabina selectedCabina, AltaCrucero altaCrucero)
        {
            InitializeComponent();
            _session = session;
            this._cabina = selectedCabina;
            this.altaCrucero = altaCrucero;

            //var tipos = DAO.DAOFactory.CabinaDAO.GetTiposCabina();
            //BindCbTipos();
            BindCabina();
        }

        private void BindCabina()
        {
            txtNumero.Text = _cabina.Numero.ToString();
            txtPiso.Text = _cabina.Piso.ToString();
            cbTipos.SelectedIndex = IndexOfBindCabina(_cabina.Tipo.Id);
        }

        private void BindCbTipos(List<Marca> tipos)
        {
            cbTipos.DataSource = null;
            cbTipos.DataSource = tipos;
            cbTipos.DisplayMember = "Descripcion";
            cbTipos.SelectedIndex = 0;
        }

        private int IndexOfBindCabina(int id)
        {
            var list = (List<Model.Cabina>)cbTipos.DataSource;
            return list.FindIndex(t => t.Id == id);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
