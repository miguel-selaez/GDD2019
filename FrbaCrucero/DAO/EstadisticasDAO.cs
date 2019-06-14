using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class EstadisticaDAO : BaseDAO<Estadistica>
    {
        public EstadisticaDAO(DBConnection con) : base(con) { }

        public List<Estadistica> GetTopRecorridosPasajesComprados(DateTime fechaDesde, DateTime fechaHasta)
        {
            var list = new List<Estadistica>();

            var query = ArmarSentenciaSP("P_Top_Recorridos_Pasajes_Comprados", new[] { GetParam(fechaDesde), GetParam(fechaHasta) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Estadistica(row));
                }
            }
            return list;
        }

        public List<Estadistica> GetTopRecorridosCabinasLibres(DateTime fechaDesde, DateTime fechaHasta)
        {
            var list = new List<Estadistica>();

            var query = ArmarSentenciaSP("P_Top_Recorridos_Cabinas_Libres", new[] { GetParam(fechaDesde), GetParam(fechaHasta) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Estadistica(row));
                }
            }
            return list;
        }

        public List<Estadistica> GetTopCrucerosFueraServicio(DateTime fechaDesde, DateTime fechaHasta)
        {
            var list = new List<Estadistica>();

            var query = ArmarSentenciaSP("P_Top_Cruceros_Fuera_Servicio", new[] { GetParam(fechaDesde), GetParam(fechaHasta) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Estadistica(row));
                }
            }
            return list;
        }

    }
}
