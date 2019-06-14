using FrbaCrucero.DAO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class CompraReserva : Form
    {
        private Model.Session session;
        private List<Model.Viaje> _results;
        private int _paginaActual;
        private int _offset = 10;

        public CompraReserva(Model.Session session)
        {
            InitializeComponent();
            this.session = session;
            InitValues();
        }

        private void InitValues()
        {
            Limpiar();
            dtInicio.Value = Tools.GetDate();

            var puertoOrigen = new List<Model.Puerto>();
            puertoOrigen.Add(new Model.Puerto(0, "Todos"));
            puertoOrigen.AddRange(DAO.DAOFactory.PuertoDAO.GetPuertos());
            BindCbPuertoOrigen(puertoOrigen);
            
            var puertoDestino = new List<Model.Puerto>();
            puertoDestino.Add(new Model.Puerto(0, "Todos"));
            puertoDestino.AddRange(DAO.DAOFactory.PuertoDAO.GetPuertos());
            BindCbPuertoLlegada(puertoDestino);
        }

        public void Limpiar()
        {
            btnAnterior.Visible = false;
            btnSiguiente.Visible = false;
            lblPagina.Visible = false;
            dgViajes.Rows.Clear();
        }

        private void BindCbPuertoOrigen(List<Model.Puerto> puertos)
        {
            cbPuertoOrigen.DataSource = null;
            cbPuertoOrigen.DataSource = puertos;
            cbPuertoOrigen.DisplayMember = "Descripcion";
            cbPuertoOrigen.SelectedIndex = 0;
        }

        private void BindCbPuertoLlegada(List<Model.Puerto> puertos)
        {
            cbPuertoLlegada.DataSource = null;
            cbPuertoLlegada.DataSource = puertos;
            cbPuertoLlegada.DisplayMember = "Descripcion";
            cbPuertoLlegada.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            _paginaActual = 1;
            dgViajes.Rows.Clear();
            _results = GetResults(_paginaActual, _offset);

            foreach (Model.Viaje viaje in _results)
            {
                var index = dgViajes.Rows.Add();
                dgViajes.Rows[index].Cells["Codigo"].Value = viaje.Id;
                dgViajes.Rows[index].Cells["Crucero"].Value = viaje.Crucero.Modelo;
                dgViajes.Rows[index].Cells["PuertoOrigen"].Value = viaje.PuertoOrigen;
                dgViajes.Rows[index].Cells["PuertoLlegada"].Value = viaje.PuertoDestino;
                dgViajes.Rows[index].Cells["FechaSalida"].Value = viaje.FechaSalida;
                dgViajes.Rows[index].Cells["FechaLlegada"].Value = viaje.FechaLlegadaEstimada;
                dgViajes.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }

            btnAnterior.Visible = true;
            btnAnterior.Enabled = false;
            btnSiguiente.Visible = true;
            lblPagina.Visible = true;
            lblPagina.Text = _paginaActual + " de " + getTotalPages();
        }

        public List<Model.Viaje> GetResults(int page, int offset)
        {
            return DAOFactory.ViajeDAO.GetViajes(dtInicio.Value, GetPuertoOrigenSeleccionado(), GetPuertoLlegadaSeleccionada(), page, offset);
        }

        public int GetCountResults()
        {
            return DAOFactory.ViajeDAO.GetViajesCount(dtInicio.Value, GetPuertoOrigenSeleccionado(), GetPuertoLlegadaSeleccionada());
        }

        private int GetPuertoOrigenSeleccionado()
        {
            try
            {
                var marca = (Model.Puerto)cbPuertoOrigen.SelectedItem;
                return marca.Id;
            }
            catch
            {
                return 0;
            }
        }

        private int GetPuertoLlegadaSeleccionada()
        {
            try
            {
                var marca = (Model.Puerto)cbPuertoLlegada.SelectedItem;
                return marca.Id;
            }
            catch
            {
                return 0;
            }
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            Limpiar();
        }

        private void btnSiguiente_Click(object sender, System.EventArgs e)
        {
            int totalPages = getTotalPages();
            dgViajes.Rows.Clear();
            _paginaActual++;
            if (_paginaActual > 1)
            {
                btnAnterior.Enabled = true;
            }
            if (_paginaActual == totalPages)
            {
                btnSiguiente.Enabled = false;
            }
            _results = GetResults(_paginaActual, _offset);

            foreach (Model.Viaje viaje in _results)
            {
                var index = dgViajes.Rows.Add();
                dgViajes.Rows[index].Cells["Codigo"].Value = viaje.Id;
                dgViajes.Rows[index].Cells["Crucero"].Value = viaje.Crucero.Modelo;
                dgViajes.Rows[index].Cells["PuertoOrigen"].Value = viaje.PuertoOrigen;
                dgViajes.Rows[index].Cells["PuertoLlegada"].Value = viaje.PuertoDestino;
                dgViajes.Rows[index].Cells["FechaSalida"].Value = viaje.FechaSalida;
                dgViajes.Rows[index].Cells["FechaLlegada"].Value = viaje.FechaLlegadaEstimada;
                dgViajes.Rows[index].Cells["Editar"].Value = "Seleccionar";
            }

            btnAnterior.Visible = true;
            btnSiguiente.Visible = true;
            lblPagina.Visible = true;
            lblPagina.Text = _paginaActual + " de " + totalPages;
        }
        
        private void btnAnterior_Click(object sender, System.EventArgs e)
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
                dgViajes.Rows[index].Cells["Codigo"].Value = viaje.Id;
                dgViajes.Rows[index].Cells["Crucero"].Value = viaje.Crucero.Modelo;
                dgViajes.Rows[index].Cells["PuertoOrigen"].Value = viaje.PuertoOrigen;
                dgViajes.Rows[index].Cells["PuertoLlegada"].Value = viaje.PuertoDestino;
                dgViajes.Rows[index].Cells["FechaSalida"].Value = viaje.FechaSalida;
                dgViajes.Rows[index].Cells["FechaLlegada"].Value = viaje.FechaLlegadaEstimada;
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
