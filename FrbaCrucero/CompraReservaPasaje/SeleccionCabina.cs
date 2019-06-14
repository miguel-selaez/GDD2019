﻿using FrbaCrucero.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class SeleccionCabina : Form
    {
        private Session _session;
        private List<Model.Cabina> _results;
        private Model.Viaje _viaje;
        private Model.Cliente _cliente;

        public SeleccionCabina()
        {
            InitializeComponent();
        }

        public SeleccionCabina(Model.Session session, Viaje viaje)
        {
            InitializeComponent();
            _session = session;
            _viaje = viaje;
            InitValues();
        }

        public void InitValues()
        {
            txtRecorrido.Text = _viaje.Recorrido.Codigo;
            txtViaje.Text = _viaje.Id.ToString();
            dtpFechaLlegadaEstimada.Value = _viaje.FechaLlegadaEstimada.Value;
            dtpFechaSalida.Value = _viaje.FechaSalida.Value;
            dgCabinas.Rows.Clear();
            _results = GetResults(_viaje);
            decimal precioRecorrido = GetPrecioRecorrido(_viaje.Recorrido);

            foreach (Model.Cabina cabina in _results)
            {
                var index = dgCabinas.Rows.Add();
                dgCabinas.Rows[index].Cells["Seleccionar"].Value = false;
                dgCabinas.Rows[index].Cells["Piso"].Value = cabina.Numero;
                dgCabinas.Rows[index].Cells["Numero"].Value = cabina.Piso;
                dgCabinas.Rows[index].Cells["TipoCabina"].Value = cabina.Tipo.Descripcion;
                dgCabinas.Rows[index].Cells["Precio"].Value = cabina.Tipo.PorcertajeRecargo * precioRecorrido;
            }
        }

        public decimal GetPrecioRecorrido(Recorrido recorrido)
        {
            return DAO.DAOFactory.RecorridoDAO.GetPrecioRecorrido(recorrido.Id);
        }

        public List<Model.Cabina> GetResults(Viaje viaje)
        {
            return DAO.DAOFactory.CabinaDAO.GetCabinasDisponiblesByViaje(viaje.Id, viaje.Crucero.Id);
        }

        public List<Pasaje> GetPasajesSeleccionados()
        {
            var pasajes = new List<Pasaje>();                            
            for(int i = 0; i < dgCabinas.Rows.Count; i++){
                if (dgCabinas.Rows[i].Cells["Seleccionar"].Value.Equals("true"))
                {
                    var cabina = _results.ElementAt(i);
                    var precio = System.Convert.ToDecimal(dgCabinas.Rows[i].Cells["Precio"].Value);
                    pasajes.Add(new Pasaje(precio, _viaje, cabina, _cliente));
                }
            }
            return pasajes;
        }

        private void BtnPagar_Click(object sender, System.EventArgs e)
        {
            List<Pasaje> pasajes = GetPasajesSeleccionados();
            //var nuevo = new PagoReserva.Pago(_session, selectedRecorrido, this);
            var nuevo = new PagoReserva.Pago(_session);
            nuevo.Show();
        }

        private void BtnBuscarCliente_Click(object sender, System.EventArgs e)
        {
            List<Cliente> clientes = DAO.DAOFactory.ClienteDAO.GetClientes(System.Convert.ToDecimal(txtDni.Text), "", "", "", 1, 1);
            if (clientes.Any())
            {
                _cliente = clientes[0];
                txtApellido.Text = _cliente.Apellido;
                txtNombre.Text = _cliente.Nombre;
            } else
            {
                var nuevo = new AbmCliente.Cliente(_session);
                nuevo.Show();
            }
        }

        private void BtnReservar_Click(object sender, System.EventArgs e)
        {
            List<Pasaje> pasajes = GetPasajesSeleccionados();
            var nuevo = new CompraReservaPasaje.Reserva(_session, pasajes, _cliente);
            nuevo.Show();
        }

    }
}
