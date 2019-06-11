using System.Data;

namespace FrbaCrucero.Model
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Marca(DataRow row)
        {
            Id = row.GetValue<int>("m_id");
            Descripcion = row.GetValue<string>("m_descripcion");
        }

        public Marca(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
