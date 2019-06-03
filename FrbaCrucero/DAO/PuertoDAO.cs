using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Rol> GetPuertos(string descripcion, string vigencia)
        {
            //var list = new List<Rol>();

            //var query = ArmarSentenciaSP("P_Obtener_Roles", new[] { GetParam(descripcion), GetParamVigencia(vigencia) });
            //var result = Connection.ExecuteQuery(query);

            //if (result.Rows.Count > 0)
            //{
            //    foreach (DataRow row in result.Rows)
            //    {
            //        list.Add(new Rol(row));
            //    }
            //}
            //return list;
            return null;
        }

    }
}
