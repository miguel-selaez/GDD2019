using FrbaCrucero.DAO;
using System;
using System.Data;

namespace FrbaCrucero.Model
{
    public class Reserva
    {
        public decimal Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Estado { get; set; }
        public Cliente Cliente { get; set; }

        public Reserva(DataRow row)
        {
            Codigo = row.GetValue<decimal>("r_codigo");
            Fecha = row.GetDate("r_fecha");
            Estado = row.GetValue<bool>("r_estado");
            Cliente = DAOFactory.ClienteDAO.GetCliente(row.GetValue<int>("r_id_cliente"));
        }

        public Reserva(decimal codigo, DateTime fecha, bool estado, Cliente cliente)
        {
            Codigo = codigo;
            Fecha = fecha;
            Estado = estado;
            Cliente = cliente;
        }
    }
}
