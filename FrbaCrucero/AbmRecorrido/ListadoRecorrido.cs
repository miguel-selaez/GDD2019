using FrbaCrucero.DAO;
using FrbaCrucero.Model;
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
    public partial class ListadoRecorrido : Form
    {
        private Session _session;
        private List<Model.Recorrido> _results;

        public ListadoRecorrido()
        {
            InitializeComponent();
        }

        public ListadoRecorrido(Model.Session session)
        {
            InitializeComponent();
            _session = session;
            InitValues();
        }

        private void InitValues()
        {
            cbVigencia.SelectedIndex = 0;
        }

        public List<Model.Recorrido> GetResults()
        {
            return DAOFactory.RecorridoDAO.GetRecorridos(txtCodigo.Text, cbVigencia.SelectedItem.ToString());
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dgRecorridos.Rows.Clear();
            _results = GetResults();

            foreach (Model.Recorrido recorrido in _results)
            {
                var index = dgRecorridos.Rows.Add();
                dgRecorridos.Rows[index].Cells["Codigo"].Value = recorrido.Codigo;
                dgRecorridos.Rows[index].Cells["Vigente"].Value = recorrido.Baja ? "No" : "Si";
                dgRecorridos.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }
        }

        private void dgRecorrido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRol = _results.ElementAt(e.RowIndex);
            var nuevo = new Recorrido(_session, selectedRol, this);
            nuevo.Show();
        }

    }
}
