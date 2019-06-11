using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class ReservaDAO : BaseDAO<Reserva>
    {
        public ReservaDAO(DBConnection con) : base(con) { }

        public int CreateOrUpdate(Reserva reserva)
        {
            var query = ArmarSentenciaSP("P_Guardar_Reserva", new[] { GetParam(reserva.Codigo), GetParam(reserva.Fecha), GetParam(reserva.Estado), GetParam(reserva.Cliente.Id) });
            return Int32.Parse(Connection.ExecuteSingleResult(query));
        } 

        public Reserva GetReserva(decimal codigo)
        {
            var query = ArmarSentenciaSP("P_Obtener_Reserva", new[] { GetParam(codigo) });
            var result = Connection.ExecuteQuery(query);
            return new Reserva(result.Rows[0]);
        }

    }
}
