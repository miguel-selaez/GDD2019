using System.Data;

namespace FrbaCrucero.Model
{
    public class Puerto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Puerto(DataRow row)
        {
            Id = row.GetValue<int>("pt_id");
            Descripcion = row.GetValue<string>("pt_descripcion");
        }

        public Puerto(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
