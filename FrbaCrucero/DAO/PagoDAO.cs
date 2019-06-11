using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class PagoDAO : BaseDAO<Pago>
    {
        public PagoDAO(DBConnection con) : base(con) { }

        public int CreateOrUpdate(Pago pago)
        {
            var query = ArmarSentenciaSP("P_Guardar_Pago", new[] { GetParam(pago.Id), GetParam(pago.CantidadCuotas), GetParam(pago.FechaCompra), GetParam(pago.Total), GetParam(pago.Cliente.Id), GetParam(pago.MedioPago.Id) });
            return Int32.Parse(Connection.ExecuteSingleResult(query));
        } 

        public Pago GetPago(decimal id)
        {
            var query = ArmarSentenciaSP("P_Obtener_Pago", new[] { GetParam(id) });
            var result = Connection.ExecuteQuery(query);
            return new Pago(result.Rows[0]);
        }

    }
}
