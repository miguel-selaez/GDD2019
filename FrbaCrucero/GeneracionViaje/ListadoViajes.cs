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
        private int _paginaActual;
        private int _offset = 20;

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

        public List<Model.Viaje> GetResults(int page, int offset)
        {
            return DAOFactory.ViajeDAO.GetViajesPage(txtCodigoCrucero.Text, txtCodigoRecorrido.Text, page, offset);
        }

        public int GetCountResults()
        {
            return DAOFactory.ViajeDAO.GetViajesCount(txtCodigoCrucero.Text, txtCodigoRecorrido.Text);
        }

        public void Limpiar()
        {
            txtCodigoCrucero.Text = string.Empty;
            txtCodigoRecorrido.Text = string.Empty;
            btnAnterior.Visible = false;
            btnSiguiente.Visible = false;
            lblPagina.Visible = false;
            dgViajes.Rows.Clear();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _paginaActual = 1;
            dgViajes.Rows.Clear();
            _results = GetResults(_paginaActual, _offset);

            foreach (Model.Viaje viaje in _results)
            {
                var index = dgViajes.Rows.Add();
                dgViajes.Rows[index].Cells["CodigoCrucero"].Value = viaje.Crucero.Codigo;
                dgViajes.Rows[index].Cells["CodigoRecorrido"].Value = viaje.Recorrido.Codigo;
                dgViajes.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }

            btnAnterior.Visible = true;
            btnAnterior.Enabled = false;
            btnSiguiente.Visible = true;
            lblPagina.Visible = true;
            lblPagina.Text = _paginaActual + " de " + getTotalPages();
        }

        private void dgViaje_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedViaje = _results.ElementAt(e.RowIndex);
            var nuevo = new Viaje(_session, selectedViaje, this);
            nuevo.Show();
        }

        public void UpdateViajes()
        {
            btnBuscar.PerformClick();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            int totalPages = getTotalPages();
            dgViajes.Rows.Clear();
            _paginaActual++;
            if(_paginaActual > 1)
            {
                btnAnterior.Enabled = true;
            }
            if(_paginaActual == totalPages)
            {
                btnSiguiente.Enabled = false;
            }
            _results = GetResults(_paginaActual, _offset);

            foreach (Model.Viaje viaje in _results)
            {
                var index = dgViajes.Rows.Add();
                dgViajes.Rows[index].Cells["CodigoCrucero"].Value = viaje.Crucero.Codigo;
                dgViajes.Rows[index].Cells["CodigoRecorrido"].Value = viaje.Recorrido.Codigo;
                dgViajes.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }

            btnAnterior.Visible = true;
            btnSiguiente.Visible = true;
            lblPagina.Visible = true;
            lblPagina.Text = _paginaActual + " de " + totalPages;
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            int totalPages = getTotalPages();
            dgViajes.Rows.Clear();
            _paginaActual--;
            if (_paginaActual == 1)
            {
                btnAnterior.Enabled = false;
            }
            if (_paginaActual != totalPages)
            {
                btnSiguiente.Enabled = false;
            }
            _results = GetResults(_paginaActual, _offset);

            foreach (Model.Viaje viaje in _results)
            {
                var index = dgViajes.Rows.Add();
                dgViajes.Rows[index].Cells["CodigoCrucero"].Value = viaje.Crucero.Codigo;
                dgViajes.Rows[index].Cells["CodigoRecorrido"].Value = viaje.Recorrido.Codigo;
                dgViajes.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }

            btnAnterior.Visible = true;
            btnSiguiente.Visible = true;
            lblPagina.Visible = true;
            lblPagina.Text = _paginaActual + " de " + totalPages;
        }

        private int getTotalPages()
        {
            int countResults = GetCountResults();
            return countResults / _offset + 1;
        }
    }
}
