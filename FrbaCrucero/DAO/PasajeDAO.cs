using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class PasajeDAO : BaseDAO<Pasaje>
    {
        public PasajeDAO(DBConnection con) : base(con) { }

        public int CreateOrUpdate(Pasaje pasaje)
        {
            var query = ArmarSentenciaSP("P_Guardar_Pasaje", new[] { GetParam(pasaje.Codigo), GetParam(pasaje.Precio), GetParam(pasaje.Viaje.Id), GetParam(pasaje.Cabina.Id), GetParam(pasaje.Reserva.Codigo), GetParam(pasaje.Cliente.Id), GetParam(pasaje.Pago.Id) });
            var pasajeId = Int32.Parse(Connection.ExecuteSingleResult(query));
            return pasajeId;
        }

        public List<Pasaje> GetPasajesByReservaCodigo(decimal codigo)
        {
            var list = new List<Pasaje>();

            var query = ArmarSentenciaSP("P_Obtener_Pasajes_x_Reserva", new[] { GetParam(codigo) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Pasaje(row));
                }
            }
            return list;
        }

        public List<Pasaje> GetPasajesByPagoId(int id)
        {
            var list = new List<Pasaje>();

            var query = ArmarSentenciaSP("P_Obtener_Pasajes_x_Pago", new[] { GetParam(id) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Pasaje(row));
                }
            }
            return list;
        }
    }
}
