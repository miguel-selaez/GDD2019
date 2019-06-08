using System;
using System.Data;

namespace FrbaCrucero.Model
{
    public class Crucero
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public Marca Marca { get; set; }
        public DateTime? FechaAlta { get; set; }
        public bool Baja { get; set; }
        public DateTime? FechaFueraServicio { get; set; }
        public DateTime? FechaReinicioServicio { get; set; }
        public DateTime? FechaBajaDefinitiva { get; set; }

        public Crucero(DataRow row)
        {
            Id = row.GetValue<int>("cr_id");
            Codigo = row.GetValue<string>("cr_codigo");
            Modelo = row.GetValue<string>("cr_modelo");
            Marca = DAO.DAOFactory.CruceroDAO.GetMarca(row.GetValue<int>("cr_id_marca"));
            FechaAlta = row.GetDate("cr_fecha_alta");
            Baja = row.GetValue<bool>("cr_baja");
            FechaFueraServicio = row.GetDate("cr_fecha_fuera_servicio");
            FechaReinicioServicio = row.GetDate("cr_fecha_reinicio_servicio");
            FechaBajaDefinitiva = row.GetDate("cr_fecha_baja_definitiva");
        }
    }

    public static class CruceroEstados
    {
        public static string Vigente = "Vigente";
        public static string NoVigente = "No Vigente";
        public static string FueraServicio = "Fuera de Servicio";
    }
}
