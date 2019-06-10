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

        public ListadoCliente(Session session)
        {
            InitializeComponent();
        }

        public List<Model.Cliente> GetResults()
        {
            var Dni = string.IsNullOrEmpty(txtDNI.Text) ? 0 : decimal.Parse(txtDNI.Text);
            return DAO.DAOFactory.ClienteDAO.GetClientes
                (
                    Dni, 
                    txtNombre.Text,
                    txtApellido.Text,
                    cbInconsistente.SelectedText.ToString()
                );
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDNI.Text = "";
            cbInconsistente.Text = "";
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
                dgClientes.Rows.Clear();
                _results = GetResults();

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
    }
}
