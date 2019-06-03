using FrbaCrucero.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Model
{
    public class Rol
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Baja { get; set; }

        private List<Funcion> _funciones;
        public List<Funcion> Funciones
        {
            get { return _funciones ?? (_funciones = DAOFactory.FuncionDAO.GetFuncionesByRol(Id)); }
            set { _funciones = value; }
        }

        public Rol(DataRow row)
        {
            Id = row.GetValue<int>("r_id");
            Descripcion = row.GetValue<string>("r_descripcion");
            Baja = row.GetValue<bool>("r_baja");
        }

        public Rol(string descripcion, bool vigente, List<Funcion> funciones)
        {
            Descripcion = descripcion;
            Baja = !vigente;
            Funciones = funciones;
        }
    }
}
