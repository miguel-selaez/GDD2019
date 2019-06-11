using FrbaCrucero.Model;

namespace FrbaCrucero.DAO
{
    public class UsuarioDAO : BaseDAO<Usuario>
    {
        public UsuarioDAO(DBConnection con) : base(con) { }

        //public void CreateOrUpdate(Usuario user) {
        //    var personaQuery = DAOFactory.PersonaDAO.CreateOrUpdateScript(user.Persona);

        //    var query = personaQuery;
        //    query += "DECLARE @id_usuario int;";
        //    query += ArmarSentenciaSP("P_Guardar_Usuario", new[] { 
        //        GetParam(user.Id),
        //        GetParam(user.NombreUsuario),
        //        GetParam(user.Password),
        //        GetParam(user.Baja),
        //        "@id_persona",
        //        "@id_usuario output"
        //    });

        //    foreach (var rol in user.Roles)
        //    {
        //        query += ArmarSentenciaSP("P_Guardar_Rol_x_Usuario", new[] { "@id_usuario", GetParam(rol.Id) });
        //    }
        //    foreach (var hotel in user.HotelesAsignados)
        //    {
        //        query += ArmarSentenciaSP("P_Guardar_Usuario_x_Hotel", new[] { "@id_usuario", GetParam(hotel.Id) });
        //    }

        //    query = IncluirEnTransaccion(query);

        //    Connection.ExecuteQuery(query);
        //}

        public Usuario Login(string user, string password)
        {
            var query = ArmarSentenciaSP("P_LOGIN", new[] { 
                GetParam(user), 
                GetParam(password) 
            });
            var result = Connection.ExecuteQuery(query);
            return result.Rows.Count > 0 ? new Usuario(result.Rows[0]) : null;
        }

        //public List<Usuario> GetUsuarios(string usuario, string vigencia)
        //{
        //    var list = new List<Usuario>();

        //    var query = ArmarSentenciaSP("P_Obtener_Usuarios", new[] { GetParam(usuario), GetParamVigencia(vigencia) });
        //    var result = Connection.ExecuteQuery(query);

        //    if (result.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in result.Rows)
        //        {
        //            list.Add(new Usuario(row));
        //        }
        //    }
        //    return list;
        //}
    }
}
