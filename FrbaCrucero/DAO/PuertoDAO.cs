using FrbaCrucero.Model;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class PuertoDAO : BaseDAO<Rol>
    {
        public PuertoDAO(DBConnection con) : base(con) { }

        public Puerto GetPuerto(int puertoId)
        {
            var query = ArmarSentenciaSP("P_Obtener_Puerto", new[] { GetParam(puertoId) });
            var result = Connection.ExecuteQuery(query);
            return new Puerto(result.Rows[0]);
        }

        public List<Puerto> GetPuertos()
        {
            var list = new List<Puerto>();

            var query = ArmarSentenciaSP("P_Obtener_Puertos", null);
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Puerto(row));
                }
            }
            return list;
        }
    }
}
