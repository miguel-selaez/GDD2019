﻿using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class RecorridoDAO : BaseDAO<Recorrido>
    {
        public RecorridoDAO(DBConnection con) : base(con) { }

        public int CreateOrUpdate(Recorrido recorrido)
        {
            var query = ArmarSentenciaSP("P_Guardar_Recorrido", new[] { GetParam(recorrido.Id), GetParam(recorrido.Codigo), GetParam(recorrido.Baja) });
            var recorridoId = Int32.Parse(Connection.ExecuteSingleResult(query));

            int i = 1;
            foreach (var tramo in recorrido.Tramos)
            {
                DAOFactory.TramoDAO.SaveTramoxRecorrido(tramo, recorridoId, i);
                i++;
            }
            return recorridoId;
        } 

        public List<Recorrido> GetRecorridos(string codigo, string vigencia)
        {
            var list = new List<Recorrido>();

            var query = ArmarSentenciaSP("P_Obtener_Recorridos", new[] { GetParam(codigo), GetParamVigencia(vigencia) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Recorrido(row));
                }
            }
            return list;
        }

    }
}
