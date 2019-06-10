using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAO
{
    public class CabinaDAO : BaseDAO<Cabina>
    {
        public CabinaDAO(DBConnection con) : base(con) { }

        public List<Cabina> GetCabinasByCrucero(int cruceroId)
        {
            var list = new List<Cabina>();

            var query = ArmarSentenciaSP("P_Obtener_Cabinas_x_Crucero", new[] { GetParam(cruceroId) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Cabina(row));
                }
            }
            return list;
        }

        public TipoCabina GetTipoCabina(int tipoCabinaId)
        {
            var query = ArmarSentenciaSP("P_Obtener_Tipo_Cabina", new[] { GetParam(tipoCabinaId) });
            var result = Connection.ExecuteQuery(query);
            return new TipoCabina(result.Rows[0]);
        }
    }
}
