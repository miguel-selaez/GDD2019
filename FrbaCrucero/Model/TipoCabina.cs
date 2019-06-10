using FrbaCrucero.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Model
{
    public class TipoCabina
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal PorcertajeRecargo { get; set; }

        public TipoCabina(DataRow row)
        {
            Id = row.GetValue<int>("tc_id");
            Descripcion = row.GetValue<string>("tc_descripcion");
            PorcertajeRecargo = row.GetValue<decimal>("tc_porcentaje_recargo");
        }
    }
}
