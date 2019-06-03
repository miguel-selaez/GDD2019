using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAO
{
    public class RecorridoDAO : BaseDAO<Rol>
    {
        public RecorridoDAO(DBConnection con) : base(con) { }

        public int CreateOrUpdate(Rol rol)
        {
            //var query = ArmarSentenciaSP("P_Guardar_Rol", new[] { GetParam(rol.Id), GetParam(rol.Descripcion), GetParam(rol.Baja) });
            //var rolId = Int32.Parse(Connection.ExecuteSingleResult(query));

            //foreach (var funcion in rol.Funciones)
            //{
            //    DAOFactory.FuncionDAO.SaveFuncionxRol(funcion, rolId);
            //}
            //return rolId;
            return 0;
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
