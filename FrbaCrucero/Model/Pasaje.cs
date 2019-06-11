using FrbaCrucero.DAO;
using System;
using System.Data;

namespace FrbaCrucero.Model
{
    public class Pasaje
    {
        public decimal Codigo { get; set; }
        public decimal Precio { get; set; }
        public Viaje Viaje { get; set; }
        public Cabina Cabina { get; set; }
        public Reserva Reserva { get; set; }
        public Cliente Cliente { get; set; }
        public Pago Pago { get; set; }

        public Pasaje(DataRow row)
        {
            Codigo = row.GetValue<decimal>("pa_codigo");
            Precio = row.GetValue<decimal>("pa_precio");
            Viaje = DAOFactory.ViajeDAO.GetViaje(row.GetValue<int>("pa_id_viaje"));
            Reserva = DAOFactory.ReservaDAO.GetReserva(row.GetValue<decimal>("pa_id_reserva"));
            Cliente = DAOFactory.ClienteDAO.GetCliente(row.GetValue<int>("pa_id_cliente"));
            Pago = DAOFactory.PagoDAO.GetPago(row.GetValue<int>("pa_id_pago"));
        }

        public Pasaje(decimal precio, Viaje viaje, Reserva reserva, Cliente cliente, Pago pago)
        {
            Precio = precio;
            Viaje = viaje;
            Reserva = reserva;
            Cliente = cliente;
            Pago = pago;
        }
    }
}
