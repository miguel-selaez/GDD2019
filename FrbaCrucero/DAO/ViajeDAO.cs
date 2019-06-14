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
            var query = ArmarSentenciaSP("P_Guardar_Viaje", new[] { GetParam(viaje.Id), GetParam(viaje.Crucero.Id), GetParam(viaje.Recorrido.Id), GetParam(viaje.FechaSalida), GetParam(viaje.FechaLlegada), GetParam(viaje.FechaLlegadaEstimada) });
            var viajeId = Int32.Parse(Connection.ExecuteSingleResult(query));
            return viajeId;
        } 

        public List<Viaje> GetViajesPage(string codigoCrucero, string codigoRecorrido, int page, int offset)
        {
            var list = new List<Viaje>();

            var query = ArmarSentenciaSP("P_Obtener_Viajes", new[] { GetParam(codigoCrucero), GetParam(codigoRecorrido), GetParam(page), GetParam(offset)});
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

        public int GetViajesCount(string codigoCrucero, string codigoRecorrido)
        {
            var query = ArmarSentenciaSP("P_Obtener_Cantidad_Viajes", new[] { GetParam(codigoCrucero), GetParam(codigoRecorrido) });
            var result = Connection.ExecuteQuery(query);
            return result.Rows[0].GetValue<int>("count");
        }

        public Viaje GetViaje(decimal id)
        {
            var query = ArmarSentenciaSP("P_Obtener_Viaje", new[] { GetParam(id) });
            var result = Connection.ExecuteQuery(query);
            return new Viaje(result.Rows[0]);
        }

        public List<Viaje> GetViajes(DateTime fecha, int puertoOrigen, int puertoLlegada, int page, int offset)
        {
            var list = new List<Viaje>();

            var query = ArmarSentenciaSP("P_Obtener_Viajes_Compra", new[] { GetParam(fecha), GetParam(puertoOrigen), GetParam(puertoLlegada), GetParam(page), GetParam(offset) });
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

        public int GetViajesCount(DateTime fecha, int puertoOrigen, int puertoLlegada)
        {
            var query = ArmarSentenciaSP("P_Obtener_Cantidad_Viajes_Compra", new[] { GetParam(fecha), GetParam(puertoOrigen), GetParam(puertoLlegada) });
            var result = Connection.ExecuteQuery(query);
            return result.Rows[0].GetValue<int>("count");
        }
    }
}
