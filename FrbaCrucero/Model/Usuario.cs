using FrbaCrucero.DAO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FrbaCrucero.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public bool Baja { get; set; }
        public int IntentosFallidos { get; set; }

        private List<Rol> _roles;

        public Usuario(DataRow row)
        {
            Id = row.GetValue<int>("u_id");
            NombreUsuario = row.GetValue<string>("u_nombre_usuario");
            Password = row.GetValue<string>("u_password");
            Baja = row.GetValue<bool>("u_baja");
            IntentosFallidos = row.GetValue<int>("u_intentos_fallidos");
        }

        public List<Rol> Roles
        {
            get { return _roles ?? (_roles = DAOFactory.RolDAO.GetRolesByUserId(Id)); }
            set { _roles = value; }
        }

        public List<Funcion> Funciones
        {
            get { return Roles.SelectMany(r => r.Funciones).ToList(); }
        }
    }
}
