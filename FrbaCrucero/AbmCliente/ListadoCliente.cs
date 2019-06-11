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

namespace FrbaCrucero.AbmCliente
{
    public partial class ListadoCliente : Form
    {
        private Model.Session _session;
        private List<Model.Cliente> _results;
        private int _paginaActual;

        public ListadoCliente(Session session)
        {
            InitializeComponent();
            _session = session;
            Limpiar();
        }

        public List<Model.Cliente> GetResults(int page, int offset)
        {
            var Dni = string.IsNullOrEmpty(txtDNI.Text) ? 0 : decimal.Parse(txtDNI.Text);
            return DAO.DAOFactory.ClienteDAO.GetClientes
                (
                    Dni, 
                    txtNombre.Text,
                    txtApellido.Text,
                    cbInconsistente.SelectedText.ToString(),
                    page,
                    offset
                );
        }

        public int GetCountResults()
        {
            var Dni = string.IsNullOrEmpty(txtDNI.Text) ? 0 : decimal.Parse(txtDNI.Text);
            return DAO.DAOFactory.ClienteDAO.GetClientesCount(Dni,
                    txtNombre.Text,
                    txtApellido.Text,
                    cbInconsistente.SelectedText.ToString());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var nuevo = new Cliente(_session);
            nuevo.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _paginaActual = 1;
                dgClientes.Rows.Clear();
                _results = GetResults(_paginaActual, Int32.Parse(cbTop.SelectedItem.ToString()));

                foreach (Model.Cliente cliente in _results)
                {
                    var index = dgClientes.Rows.Add();
                    dgClientes.Rows[index].Cells["Apellido"].Value = cliente.Apellido;
                    dgClientes.Rows[index].Cells["Nombre"].Value = cliente.Nombre;
                    dgClientes.Rows[index].Cells["Mail"].Value = cliente.Mail;
                    dgClientes.Rows[index].Cells["Nro_Documento"].Value = cliente.NumeroDocumento;
                    dgClientes.Rows[index].Cells["Inconsistente"].Value = cliente.Inconsistente ? "No" : "Si";
                    dgClientes.Rows[index].Cells["Editar"].Value = "Seleccionar";
                }

                btnAnterior.Visible = true;
                btnAnterior.Enabled = false;
                btnSiguiente.Visible = true;
                lblPagina.Visible = true;
                lblPagina.Text = _paginaActual + " de " + getTotalPages();

                if (_results.Count == 0) { MessageBox.Show("Sin resultados", "Búsqueda", MessageBoxButtons.OK); }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error de Validación";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                txtDNI.Clear();
                cbInconsistente.Text = "";
            }

        }

        public void Limpiar()
        {
            txtDNI.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            cbInconsistente.Text = string.Empty;
            btnAnterior.Visible = false;
            btnSiguiente.Visible = false;
            lblPagina.Visible = false;
            dgClientes.Rows.Clear();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int totalPages = getTotalPages();
            dgClientes.Rows.Clear();
            _paginaActual--;
            if (_paginaActual == 1)
            {
                btnAnterior.Enabled = false;
            }
            if (_paginaActual != totalPages)
            {
                btnSiguiente.Enabled = false;
            }
            _results = GetResults(_paginaActual, Int32.Parse(cbTop.SelectedItem.ToString()));

            foreach (Model.Cliente cliente in _results)
            {
                var index = dgClientes.Rows.Add();
                dgClientes.Rows[index].Cells["Apellido"].Value = cliente.Apellido;
                dgClientes.Rows[index].Cells["Nombre"].Value = cliente.Nombre;
                dgClientes.Rows[index].Cells["Mail"].Value = cliente.Mail;
                dgClientes.Rows[index].Cells["Nro_Documento"].Value = cliente.NumeroDocumento;
                dgClientes.Rows[index].Cells["Inconsistente"].Value = cliente.Inconsistente ? "No" : "Si";
                dgClientes.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }

            btnAnterior.Visible = true;
            btnSiguiente.Visible = true;
            lblPagina.Visible = true;
            lblPagina.Text = _paginaActual + " de " + totalPages;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int totalPages = getTotalPages();
            dgClientes.Rows.Clear();
            _paginaActual++;
            if (_paginaActual > 1)
            {
                btnAnterior.Enabled = true;
            }
            if (_paginaActual == totalPages)
            {
                btnSiguiente.Enabled = false;
            }
            _results = GetResults(_paginaActual, Int32.Parse(cbTop.SelectedItem.ToString()));

            foreach (Model.Cliente cliente in _results)
            {
                var index = dgClientes.Rows.Add();
                dgClientes.Rows[index].Cells["Apellido"].Value = cliente.Apellido;
                dgClientes.Rows[index].Cells["Nombre"].Value = cliente.Nombre;
                dgClientes.Rows[index].Cells["Mail"].Value = cliente.Mail;
                dgClientes.Rows[index].Cells["Nro_Documento"].Value = cliente.NumeroDocumento;
                dgClientes.Rows[index].Cells["Inconsistente"].Value = cliente.Inconsistente ? "No" : "Si";
                dgClientes.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }

            btnAnterior.Visible = true;
            btnSiguiente.Visible = true;
            lblPagina.Visible = true;
            lblPagina.Text = _paginaActual + " de " + totalPages;
        }

        private int getTotalPages()
        {
            int countResults = GetCountResults();
            return countResults / Int32.Parse(cbTop.SelectedItem.ToString()) + 1;
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedCliente = _results.ElementAt(e.RowIndex);
                var nuevo = new AbmCliente.Cliente(_session, selectedCliente, this);
                    nuevo.Show();                
            }
        }
    }
}
