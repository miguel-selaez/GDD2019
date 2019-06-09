using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAO
{
    public class CruceroDAO : BaseDAO<Crucero>
    {
        public CruceroDAO(DBConnection con) : base(con) { }

        public Crucero GetCrucero(int cruceroId)
        {
            var query = ArmarSentenciaSP("P_Obtener_Crucero", new[] { GetParam(cruceroId) });
            var result = Connection.ExecuteQuery(query);
            return new Crucero(result.Rows[0]);
        }

        public Marca GetMarca(int marcaId)
        {
            var query = ArmarSentenciaSP("P_Obtener_Marca", new[] { GetParam(marcaId) });
            var result = Connection.ExecuteQuery(query);
            return new Marca(result.Rows[0]);
        }

        public List<Crucero> GetCruceros(string codigo, int marcaId, string modelo, string estado)
        {
            var list = new List<Crucero>();

            var query = ArmarSentenciaSP("P_Obtener_Cruceros", new[] { GetParam(codigo), GetParam(marcaId), GetParam(modelo), GetParam(estado)});
            var result = Connection.ExecuteMultipleResult(query);

            if (result.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in result.Tables[0].Rows)
                {
                    list.Add(new Crucero(row));
                }
            }
            return list;
        }

        public List<Crucero> GetCrucerosDisponibles(DateTime fechaSalida, DateTime fechaLlegada)
        {
            var list = new List<Crucero>();

            var query = ArmarSentenciaSP("P_Obtener_Cruceros_Disponibles", new[] { GetParam(fechaSalida), GetParam(fechaLlegada) });
            var result = Connection.ExecuteMultipleResult(query);

            if (result.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in result.Tables[0].Rows)
                {
                    list.Add(new Crucero(row));
                }
            }
            return list;
        }

        public List<Marca> GetMarcas()
        {
            var list = new List<Marca>();

            var query = ArmarSentenciaSP("P_Obtener_Marcas", null);
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Marca(row));
                }
            }
            return list;
        }
    }
}
