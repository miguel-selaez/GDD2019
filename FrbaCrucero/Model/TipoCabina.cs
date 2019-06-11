using System.Data;

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
