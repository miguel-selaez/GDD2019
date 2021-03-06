﻿using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class MedioPagoDAO : BaseDAO<MedioPago>
    {
        public MedioPagoDAO(DBConnection con) : base(con) { }

        public int CreateOrUpdate(MedioPago medioPago)
        {
            var query = ArmarSentenciaSP("P_Guardar_Medio_Pago", new[] { GetParam(medioPago.Id), GetParam(medioPago.Descripcion) });
            return Int32.Parse(Connection.ExecuteSingleResult(query));
        } 

        public MedioPago GetMedioPago(decimal id)
        {
            var query = ArmarSentenciaSP("P_Obtener_Medio_Pago", new[] { GetParam(id) });
            var result = Connection.ExecuteQuery(query);
            return new MedioPago(result.Rows[0]);
        }

        public List<MedioPago> GetMediosPago()
        {
            var query = ArmarSentenciaSP("P_Obtener_Medio_Pago", new[] { GetParam(0) });
            var result = Connection.ExecuteQuery(query);
            var list = new List<MedioPago>();

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new MedioPago(row));
                }
            }
            return list;           
        }
    }
}
