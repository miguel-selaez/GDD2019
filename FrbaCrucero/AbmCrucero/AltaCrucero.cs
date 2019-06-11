using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class AltaCrucero : Form
    {
        private Model.Session _session;
        private Model.Crucero _crucero;
        private ListadoCrucero _listadoCrucero;
        
        public AltaCrucero(Model.Session session)
        {
            InitializeComponent();

            this._session = session;
        }

        public AltaCrucero(Model.Session session, Model.Crucero crucero, ListadoCrucero listadoCrucero)
        {
            InitializeComponent();

            _session = session;
            _crucero = crucero;
            _listadoCrucero = listadoCrucero;
            InitValues();
            BindCrucero();
        }

        private void InitValues()
        {
            var marcas = DAO.DAOFactory.CruceroDAO.GetMarcas();
            BindCbMarca(marcas);
        }

        private void BindCrucero()
        {
            txtCodigo.Text = _crucero.Codigo;
            txtModelo.Text = _crucero.Modelo;
            cbMarca.SelectedIndex = IndexOfBindMarca(_crucero.Marca.Id);

            dtAlta.Visible = _crucero.FechaAlta.HasValue;
            dtAlta.Value = _crucero.FechaAlta ?? Tools.GetDate();

            rdNo.Checked = _crucero.Baja;
            rdSi.Checked = !_crucero.Baja;

            BindCabinas();
        }

        private void BindCabinas()
        {
            dgCabinas.Rows.Clear();
            var results = _crucero.Cabinas;

            foreach (Model.Cabina cabina in results)
            {
                var index = dgCabinas.Rows.Add();
                dgCabinas.Rows[index].Cells["Numero"].Value = cabina.Numero.ToString();
                dgCabinas.Rows[index].Cells["Piso"].Value = cabina.Piso.ToString();
                dgCabinas.Rows[index].Cells["Tipo"].Value = cabina.Tipo.Descripcion;
                dgCabinas.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }
        }

        private int IndexOfBindMarca(int id)
        {
            var list = (List<Model.Marca>)cbMarca.DataSource;
            return list.FindIndex(t => t.Id == id);
        }

        private void BindCbMarca(List<Marca> marcas)
        {
            cbMarca.DataSource = null;
            cbMarca.DataSource = marcas;
            cbMarca.DisplayMember = "Descripcion";
            cbMarca.SelectedIndex = 0;
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

        private void dgCabinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCabina = _crucero.Cabinas.ElementAt(e.RowIndex);
            var nuevo = new AltaCabina(_session, selectedCabina, this);
            nuevo.Show();
        }

    }
}
