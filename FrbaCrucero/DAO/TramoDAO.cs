using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAO
{
    public class TramoDAO : BaseDAO<Funcion>
    {
        public TramoDAO(DBConnection con) : base(con) { }

        public List<Tramo> GetTramosByRecorrido(int recorridoId)
        {
            var list = new List<Tramo>();

            var query = ArmarSentenciaSP("P_Obtener_Tramos_x_Recorrido", new[] { GetParam(recorridoId) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Tramo(row));
                }
            }
            return list;
        }

        public List<Tramo> GetTramos()
        {
            var list = new List<Tramo>();

            var query = ArmarSentenciaSP("P_Obtener_Tramos", new string[0]);
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Tramo(row));
                }
            }
            return list;
        }

        public void SaveTramoxRecorrido(Tramo tramo, int recorridoId, int orden)
        {
            var query = ArmarSentenciaSP("P_Guardar_Tramo_x_Recorrido", new[] { GetParam(tramo.Id), GetParam(recorridoId), GetParam(orden) });
            Connection.ExecuteNoQuery(query);
        }
    }
}
