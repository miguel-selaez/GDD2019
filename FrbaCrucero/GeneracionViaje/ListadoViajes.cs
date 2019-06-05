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

namespace FrbaCrucero.GeneracionViaje
{
    public partial class ListadoViajes : Form
    {
        private Session _session;
        private List<Model.Viaje> _results;

        public ListadoViajes()
        {
            InitializeComponent();
        }

        public ListadoViajes(Model.Session session)
        {
            InitializeComponent();
            _session = session;
            InitValues();
        }

        private void InitValues()
        {
            Limpiar();
        }

        public List<Model.Viaje> GetResults()
        {
            return DAOFactory.ViajeDAO.GetViajes(txtCodigoCrucero.Text, txtCodigoRecorrido.Text);
        }

        public void Limpiar()
        {
            txtCodigoCrucero.Text = string.Empty;
            txtCodigoRecorrido.Text = string.Empty;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dgViajes.Rows.Clear();
            _results = GetResults();

            foreach (Model.Viaje viaje in _results)
            {
                var index = dgViajes.Rows.Add();
                dgViajes.Rows[index].Cells["CodigoCrucero"].Value = viaje.Crucero.Codigo;
                dgViajes.Rows[index].Cells["CodigoRecorrido"].Value = viaje.Recorrido.Codigo;
                dgViajes.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }
        }

        private void dgRecorrido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRecorrido = _results.ElementAt(e.RowIndex);
            var nuevo = new Recorrido(_session, selectedRecorrido, this);
            nuevo.Show();
        }

        public void UpdateRecorridos()
        {
            btnBuscar.PerformClick();
        }
    }
}
