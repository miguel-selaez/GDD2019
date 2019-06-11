using System.Data;

namespace FrbaCrucero.Model
{
    public class MedioPago
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public MedioPago(DataRow row)
        {
            Id = row.GetValue<int>("mp_id");
            Descripcion = row.GetValue<string>("mp_descripcion");
        }

        public MedioPago(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
