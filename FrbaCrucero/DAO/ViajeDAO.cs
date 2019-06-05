using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class ViajeDAO : BaseDAO<Viaje>
    {
        public ViajeDAO(DBConnection con) : base(con) { }

        public int CreateOrUpdate(Viaje viaje)
        {
            var query = ArmarSentenciaSP("P_Guardar_Viaje", new[] { GetParam(viaje.Id), GetParam(viaje.Crucero.Id), GetParam(viaje.Recorrido.Id), GetParam(viaje.FechaLlegada), GetParam(viaje.FechaSalida), GetParam(viaje.FechaLlegadaEstimada) });
            var viajeId = Int32.Parse(Connection.ExecuteSingleResult(query));
            return viajeId;
        } 

        public List<Viaje> GetViajes(string codigoCrucero, string codigoRecorrido)
        {
            var list = new List<Viaje>();

            var query = ArmarSentenciaSP("P_Obtener_Viajes", new[] { GetParam(codigoCrucero), GetParam(codigoRecorrido)});
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Viaje(row));
                }
            }
            return list;
        }

        public Viaje GetViaje(decimal id)
        {
            var query = ArmarSentenciaSP("P_Obtener_Viaje", new[] { GetParam(id) });
            var result = Connection.ExecuteQuery(query);
            return new Viaje(result.Rows[0]);
        }

    }
}
