using FrbaCrucero.DAO;
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
    public partial class ListadoCrucero : Form
    {
        private List<Model.Crucero> _results;
        private Model.Session _session;

        public ListadoCrucero(Model.Session session)
        {
            InitializeComponent();
            _session = session;
            InitValues();
        }

        private void InitValues()
        {
            var marcas = new List<Model.Marca>();
            marcas.Add(new Model.Marca(0, "Todos"));
            marcas.AddRange(DAO.DAOFactory.CruceroDAO.GetMarcas());
            BindCbMarca(marcas);
            BindCbEstado();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgCruceros.Rows.Clear();
            _results = GetResults();

            foreach (Model.Crucero crucero in _results)
            {
                var index = dgCruceros.Rows.Add();
                dgCruceros.Rows[index].Cells["Codigo"].Value = crucero.Codigo;
                dgCruceros.Rows[index].Cells["Marca"].Value = crucero.Marca.Descripcion;
                dgCruceros.Rows[index].Cells["Modelo"].Value = crucero.Modelo;
                dgCruceros.Rows[index].Cells["Estado"].Value = crucero.Estado;
                dgCruceros.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtModelo.Text = "";
            cbMarca.SelectedIndex = 0;
            cbMarca.SelectedIndex = 0;
        }

        private void BindCbMarca(List<Model.Marca> marcas)
        {
            cbMarca.DataSource = null;
            cbMarca.DataSource = marcas;
            cbMarca.DisplayMember = "Descripcion";
            cbMarca.SelectedIndex = 0;
        }

        private void BindCbEstado()
        {
            cbEstado.DataSource = null;
            cbEstado.DataSource = GetEstadosCrucero();
            cbEstado.SelectedIndex = 0;
        }

        public List<Model.Crucero> GetResults()
        {
            return DAOFactory.CruceroDAO.GetCruceros(txtCodigo.Text, GetMarcaSeleccionada(), txtModelo.Text, cbEstado.SelectedItem.ToString());
        }

        private void dgCruceros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCrucero = _results.ElementAt(e.RowIndex);
            var nuevo = new AltaCrucero(_session, selectedCrucero, this);
            nuevo.Show();
        }

        private int GetMarcaSeleccionada() {
            try{
                var marca = (Model.Marca)cbMarca.SelectedItem;
                return marca.Id;
            }
            catch{
                return 0;
            }
        }

        private List<string> GetEstadosCrucero()
        {
            return new List<string> { 
                "Todos",
                Model.CruceroEstados.Vigente, 
                Model.CruceroEstados.NoVigente, 
                Model.CruceroEstados.FueraServicio 
            };
        }
        public void UpdateCruceros()
        {
            btnBuscar.PerformClick();
        }
    }
}
