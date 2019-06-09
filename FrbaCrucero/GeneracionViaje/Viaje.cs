using FrbaCrucero.Exceptions;
using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrbaCrucero.GeneracionViaje
{
    public partial class Viaje : Form
    {
        private Session _session;
        private Model.Viaje _editObject;
        private ListadoViajes _listado;

        public Viaje(Session session)
        {
            InitializeComponent();
            _session = session;
            InitValues();
        }

        public Viaje(Session session, Model.Viaje editViaje, ListadoViajes listado)
        {
            InitializeComponent();
            _session = session;
            _editObject = editViaje;
            _listado = listado;
            InitValues();
        }

        private void InitValues()
        {
            var recorridos = DAO.DAOFactory.RecorridoDAO.GetRecorridos(null, null);
            BindCbRecorridos(recorridos);
            
            if(_editObject != null)
            {
                cbRecorridos.SelectedItem = cbRecorridos.FindStringExact(_editObject.Recorrido.Codigo);
            }
        }

        private void BindCbRecorridos(List<Recorrido> recorridos)
        {
            cbRecorridos.DataSource = null;
            cbRecorridos.DataSource = recorridos;
            cbRecorridos.DisplayMember = "Codigo";
            cbRecorridos.SelectedIndex = 0;
        }

        private void BindCbCruceros(List<Crucero> cruceros)
        {
            cbCruceros.DataSource = null;
            cbCruceros.DataSource = cruceros;
            cbCruceros.DisplayMember = "Codigo";
            cbCruceros.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateFormDates();
                ValidateForm();
                if (_editObject == null)
                {
                    _editObject = new Model.Viaje(cbCruceros.SelectedItem as Crucero, cbRecorridos.SelectedItem as Recorrido, dtpFechaSalida.Value, dtpFechaLlegada.Value, dtpFechaLlegadaEstimada.Value);
                }
                else
                {
                    _editObject.Crucero = cbCruceros.SelectedItem as Crucero;
                    _editObject.Recorrido = cbRecorridos.SelectedItem as Recorrido;
                    _editObject.FechaLlegada = dtpFechaLlegada.Value;
                    _editObject.FechaSalida = dtpFechaSalida.Value;
                    _editObject.FechaLlegadaEstimada = dtpFechaLlegadaEstimada.Value;
                }
                DAO.DAOFactory.ViajeDAO.CreateOrUpdate(_editObject);

                CerrarAbm();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error de Validación";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private void ValidateForm()
        {
            if (cbCruceros.SelectedItem == null)
            {
                throw new ValidateException("Debe seleccionar un crucero.");
            }
            if(cbRecorridos.SelectedItem == null)
            {
                throw new ValidateException("Debe seleccionar un recorrido");
            }
        }

        private void ValidateFormDates()
        {
            if (dtpFechaSalida.Value > dtpFechaLlegada.Value)
            {
                throw new ValidateException("La fecha de salida no puede ser mayor a la fecha de llegada.");
            }
            if (dtpFechaSalida.Value > dtpFechaLlegadaEstimada.Value)
            {
                throw new ValidateException("La fecha de salida no puede ser mayor a la fecha de llegada estimada.");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CerrarAbm();
        }

        private void CerrarAbm()
        {
            if (_listado != null)
                _listado.UpdateViajes();
            Close();
        }

        private void BtnBuscarCruceros_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateFormDates();
                var cruceros = DAO.DAOFactory.CruceroDAO.GetCrucerosDisponibles(dtpFechaSalida.Value, dtpFechaLlegada.Value);
                if (cruceros.Count == 0)
                {
                    throw new ValidateException("No hay cruceros disponibles para la fecha seleccionada");
                }
                BindCbCruceros(cruceros);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error de Validación";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }
    }
}
