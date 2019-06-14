using System.Data;

namespace FrbaCrucero.Model
{
    public class Estadistica
    {
        public decimal IdRecorrido { get; set; }
        public int IdCrucero { get; set; }
        public int IdViaje { get; set; }
        public int Cantidad { get; set; }

        public Estadistica(DataRow row)
        {
            IdRecorrido = row.GetValue<decimal>("rc_id");
            IdViaje = row.GetValue<int>("v_id");
            IdCrucero = row.GetValue<int>("cr_id");
            Cantidad = row.GetValue<int>("cantidad");
        }
    }
}
