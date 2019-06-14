using FrbaCrucero.Model;
using System.Collections.Generic;
using System.Data;

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

        public List<Cabina> GetCabinasDisponiblesByViaje(int viajeId, int cruceroId)
        {
            var list = new List<Cabina>();

            var query = ArmarSentenciaSP("P_Obtener_Cabinas_Disponibles_x_Viaje", new[] { GetParam(viajeId), GetParam(cruceroId) });
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

        internal void SaveCabina(Cabina cabina, int cruceroId)
        {
            var query = ArmarSentenciaSP("P_Guardar_Cabina", new[] { 
                GetParam(cabina.Id), 
                GetParam(cabina.Numero),
                GetParam(cabina.Piso),
                GetParam(cabina.Baja),
                GetParam(cruceroId),
                GetParam(cabina.Tipo.Id)
            });
            Connection.ExecuteNoQuery(query);
        }

        public List<TipoCabina> GetTiposCabina()
        {
            var list = new List<TipoCabina>();

            var query = ArmarSentenciaSP("P_Obtener_Tipos_Cabina", null);
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new TipoCabina(row));
                }
            }
            return list;
        }
    }
}
