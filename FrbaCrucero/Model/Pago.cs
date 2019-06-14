using FrbaCrucero.DAO;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.Model
{
    public class Pago
    {
        public decimal Id { get; set; }
        public int CantidadCuotas { get; set; }
        public DateTime? FechaCompra { get; set; }
        public decimal Total { get; set; }
        public Cliente Cliente { get; set; }
        public MedioPago MedioPago { get; set; }

        private List<Pasaje> _pasajes;
        public List<Pasaje> Pasajes
        {
            get { return _pasajes ?? (_pasajes = DAOFactory.PasajeDAO.GetPasajesByReservaCodigo(Id)); }
            set { _pasajes = value; }
        }

        public Pago(DataRow row)
        {
            Id = row.GetValue<int>("p_id");
            CantidadCuotas = row.GetValue<int>("p_cant_cuotas");
            FechaCompra = row.GetDate("p_fecha_compra");
            Total = row.GetValue<decimal>("p_total");
            Cliente = DAOFactory.ClienteDAO.GetCliente(row.GetValue<int>("p_id_cliente"));
            MedioPago = DAOFactory.MedioPagoDAO.GetMedioPago(row.GetValue<int>("p_id_medio_pago"));
        }

        public Pago(int cantidadCuotas, DateTime fechaCompra, decimal total, Cliente cliente, MedioPago medioPago)
        {
            CantidadCuotas = cantidadCuotas;
            FechaCompra = fechaCompra;
            Total = total;
            Cliente = cliente;
            MedioPago = medioPago;
        }
    }
}
