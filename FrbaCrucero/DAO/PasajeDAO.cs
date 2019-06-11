using FrbaCrucero.Model;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class PasajeDAO : BaseDAO<Pasaje>
    {
        public PasajeDAO(DBConnection con) : base(con) { }

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
