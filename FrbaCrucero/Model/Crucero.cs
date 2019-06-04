using System;
using System.Data;

namespace FrbaCrucero.Model
{
    public class Crucero
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Baja { get; set; }
        public DateTime? FechaFueraServicio { get; set; }
        public DateTime? FechaReinicioServicio { get; set; }
        public DateTime? FechaBajaDefinitica { get; set; }

        public Crucero(DataRow row)
        {
            Id = row.GetValue<int>("cr_id");
            Codigo = row.GetValue<string>("cr_codigo");
            Modelo = row.GetValue<string>("cr_modelo");
            Marca = row.GetValue<string>("cr_fabricante");
            FechaAlta = row.GetValue<DateTime>("cr_fecha_alta");
            Baja = row.GetValue<bool>("cr_baja");
            FechaFueraServicio = row.GetValue<DateTime>("cr_fecha_fuera_servicio");
            FechaReinicioServicio = row.GetValue<DateTime>("cr_fecha_reinicio_servicio");
            FechaBajaDefinitica = row.GetValue<DateTime>("cr_fecha_baja_definitiva");
        }
    }
}
