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

        //public List<Funcion> GetFuncionesByRol(int rolId)
        //{
        //    var list = new List<Funcion>();

        //    var query = ArmarSentenciaSP("P_Obtener_Funciones_x_Rol", new[] { GetParam(rolId) });
        //    var result = Connection.ExecuteQuery(query);

        //    if (result.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in result.Rows)
        //        {
        //            list.Add(new Funcion(row));
        //        }
        //    }
        //    return list;
        //}

        //public List<Funcion> GetFunciones()
        //{
        //    var list = new List<Funcion>();
        //    var baja = false;

        //    var query = ArmarSentenciaSP("P_Obtener_Funciones", new[] { GetParam(baja) });
        //    var result = Connection.ExecuteQuery(query);

        //    if (result.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in result.Rows)
        //        {
        //            list.Add(new Funcion(row));
        //        }
        //    }
        //    return list;
        //}

        //public void SaveFuncionxRol(Funcion funcion, int rolId)
        //{
        //    var query = ArmarSentenciaSP("P_Guardar_Funcion_x_Rol", new[] { GetParam(funcion.Id), GetParam(rolId) });
        //    Connection.ExecuteNoQuery(query);
        //}
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
    }
}
