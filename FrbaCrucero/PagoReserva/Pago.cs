using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCrucero.PagoReserva
{
    public partial class Pago : Form
    {
        private Session _session;
        private int[] cantCuotasCredito = { 1, 2, 3, 6, 9, 12 };
        private int[] cantCuotasEfeDb = { 1 };
        private List<Pasaje> pasajes;
        private Model.Pago _pago;
        private Model.Cliente _cliente;
        private decimal _totalPasajes;

        public Pago(Session session)
        {
            this._session = session;
            InitializeComponent();
            var mediosPago = DAO.DAOFactory.MedioPagoDAO.GetMediosPago();
            BindCbMedioPago(mediosPago);

            cbMedioPago.Enabled = false;
            cbCantCuotas.Enabled = false;
            button2.Enabled = false;
        }

        public Pago(Session session, List<Pasaje> pasajes, Cliente cliente)
        {
            this._session = session;
            InitializeComponent();
            var mediosPago = DAO.DAOFactory.MedioPagoDAO.GetMediosPago();

            this.pasajes = pasajes;

            BindCbMedioPago(mediosPago);

            BindDatosPasajes(this.pasajes);
            BindDatosViaje(this.pasajes);

            lbPrecioTotal.Text = _totalPasajes.ToString();
            txtNroReserva.Enabled = false;
            button1.Enabled = false;                       
            /*cbMedioPago.Enabled = false;
            cbCantCuotas.Enabled = false;
            button2.Enabled = false;*/
        }

        private void BindDatosPasajes(List<Pasaje> pasajes)
        {
            _totalPasajes = 0;
            foreach (Pasaje p in pasajes)
            {
                var index = dgPasajes.Rows.Add();
                dgPasajes.Rows[index].Cells["Tipo_cabina"].Value = p.Cabina.Tipo.Descripcion;
                dgPasajes.Rows[index].Cells["Nro_cabina"].Value = p.Cabina.Numero;
                dgPasajes.Rows[index].Cells["Piso"].Value = p.Cabina.Piso;
                dgPasajes.Rows[index].Cells["Precio"].Value = p.Precio;
                _totalPasajes += p.Precio;
            }            
        }

        private void BindDatosViaje(List<Pasaje> pasajes)
        {
            if (pasajes.Any())
            {
                Pasaje pa = pasajes[0];
                _cliente = pa.Cliente;
                lbCodRecorrido.Text = pa.Viaje.Recorrido.Codigo;
                lbCodCrucero.Text = pa.Viaje.Crucero.Codigo;
                lbFechaSalida.Text = pa.Viaje.FechaSalida.ToString();
                lbFechaLlegada.Text = pa.Viaje.FechaLlegadaEstimada.ToString();
            }
        }

        private void SumPrecioTotal(List<Pasaje> pasajes)
        {
            decimal total = 0;
            foreach(Pasaje p in pasajes)
            {
                total += p.Precio;
            }
            _pago.Total = total;
            lbPrecioTotal.Text = total.ToString();
        }

        private void BindCbMedioPago(List<MedioPago> mediosPago)
        {
            cbMedioPago.DataSource = null;
            cbMedioPago.DataSource = mediosPago;
            cbMedioPago.DisplayMember = "Descripcion";
            cbMedioPago.SelectedIndex = 0;
        }

        private void BindPrecioTotal(decimal total)
        {            
            lbPrecioTotal.Text = total.ToString();
        }

        private void BindDatosPasajes(DataTable dataTable)
        {            
            foreach(DataRow Row in dataTable.Rows){
                var index = dgPasajes.Rows.Add();
                dgPasajes.Rows[index].Cells["Tipo_cabina"].Value = Row.GetValue<string>("Tipo_de_cabina");
                dgPasajes.Rows[index].Cells["Nro_cabina"].Value = Row.GetValue<decimal>("Nro_Cabina");
                dgPasajes.Rows[index].Cells["Piso"].Value = Row.GetValue<decimal>("Piso_cabina");
                dgPasajes.Rows[index].Cells["Precio"].Value = Row.GetValue<decimal>("Precio");
            }
        }

        private bool BindDatosViaje(DataRow dataRow)
        {            
            if(dataRow.GetValue<string>("Cod. Recorrido").Trim().Equals("NO ROWS"))
            {
                MessageBox.Show("No existe una reserva activa registrada con el código ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                lbCodRecorrido.Text = dataRow.GetValue<string>("Cod. Recorrido");
                lbCodCrucero.Text = dataRow.GetValue<string>("Cod. Crucero");
                lbFechaSalida.Text = dataRow.GetDate("Fecha Salida").Value.ToString();
                lbFechaLlegada.Text = dataRow.GetDate("Fecha Llegada").Value.ToString();                
            }
            return true;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var datos_viaje = DAO.DAOFactory.PagoDAO.GetDatosViaje(decimal.Parse(txtNroReserva.Text.Equals("") ? "0" : txtNroReserva.Text));
            dgPasajes.Rows.Clear();
            if (BindDatosViaje(datos_viaje))
            {
                DataTable datos_pasajes = DAO.DAOFactory.PagoDAO.GetPasajes(decimal.Parse(txtNroReserva.Text.Equals("") ? "0" : txtNroReserva.Text));
                BindDatosPasajes(datos_pasajes);

                var total = DAO.DAOFactory.PagoDAO.GetPrecioTotalPasajes(decimal.Parse(txtNroReserva.Text.Equals("") ? "0" : txtNroReserva.Text));
                BindPrecioTotal(total);

                cbMedioPago.Enabled = true;
                cbCantCuotas.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal result;
            if (txtNroReserva.Enabled)
            {
                result = DAO.DAOFactory.PagoDAO.SetPagoAPasaje(
                                                    decimal.Parse(txtNroReserva.Text.Equals("") ? "0" : txtNroReserva.Text),
                                                    cbMedioPago.SelectedIndex + 1,
                                                    Int32.Parse(cbCantCuotas.Text),
                                                    decimal.Parse(lbPrecioTotal.Text)
                                                    );
            }
            else
            {
                _pago = new Model.Pago(Int32.Parse(cbCantCuotas.Text), Tools.GetDate(), _totalPasajes, _cliente, cbMedioPago.SelectedItem as Model.MedioPago);
                //result = DAO.DAOFactory.PagoDAO.GuardarPasajes(pasajes, _pago);
                result = DAO.DAOFactory.PagoDAO.CreateOrUpdate(_pago);
            }
            
            MessageBox.Show("Pago registrado. Código de Pago: " + result.ToString(),"", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMedioPago_ValueMemberChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Cambió");
        }

        private void cbMedioPago_TextChanged(object sender, EventArgs e)
        {            
            if(cbMedioPago.SelectedIndex == 1)
            {
                cbCantCuotas.DataSource = cantCuotasCredito;
            }
            else
            {
                cbCantCuotas.DataSource = cantCuotasEfeDb;
            }
        }
    }
}
