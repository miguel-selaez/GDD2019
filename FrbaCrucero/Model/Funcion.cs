using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Model
{
    public class Funcion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Baja { get; set; }

        public Funcion(DataRow row)
        {
            Id = row.GetValue<int>("f_id");
            Descripcion = row.GetValue<string>("f_descripcion");
            Baja = row.GetValue<bool>("f_baja");
        }
    }
}
