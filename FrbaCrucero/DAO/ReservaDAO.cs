using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class ReservaDAO : BaseDAO<Reserva>
    {
        public ReservaDAO(DBConnection con) : base(con) { }

        public decimal CreateOrUpdate(Reserva reserva)
        {
            var query = ArmarSentenciaSP("P_Guardar_Reserva", new[] { GetParam(reserva.Codigo), GetParam(reserva.Fecha), GetParam(reserva.Estado), GetParam(reserva.Cliente.Id) });
            reserva.Codigo =  Int32.Parse(Connection.ExecuteSingleResult(query));
            foreach (Model.Pasaje pasaje in reserva.Pasajes)
            {
                pasaje.Reserva = reserva;
                pasaje.Cliente = reserva.Cliente;
                DAO.DAOFactory.PasajeDAO.CreateOrUpdate(pasaje);
            }
            return reserva.Codigo;
        } 

        public Reserva GetReserva(decimal codigo)
        {
            var query = ArmarSentenciaSP("P_Obtener_Reserva", new[] { GetParam(codigo) });
            var result = Connection.ExecuteQuery(query);
            return new Reserva(result.Rows[0]);
        }

    }
}
