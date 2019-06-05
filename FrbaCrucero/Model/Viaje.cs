using FrbaCrucero.DAO;
using System;
using System.Data;

namespace FrbaCrucero.Model
{
    public class Viaje
    {
        public decimal Id { get; set; }
        public Crucero Crucero { get; set; }
        public Recorrido Recorrido { get; set; }
        public DateTime? FechaLlegada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaLlegadaEstimada { get; set; }

        public Viaje(DataRow row)
        {
            Id = row.GetValue<int>("v_id");
            Crucero = DAOFactory.CruceroDAO.GetCrucero(row.GetValue<int>("v_id_crucero"));
            Recorrido = DAOFactory.RecorridoDAO.GetRecorrido(row.GetValue<decimal>("v_id_recorrido"));
            FechaLlegada = row.GetDate("v_fecha_llegada");
            FechaSalida = row.GetDate("v_fecha_salida");
            FechaLlegadaEstimada = row.GetDate("v_fecha_llegada_estimada");
        }

        public Viaje(Crucero crucero, Recorrido recorrido, DateTime fechaLlegada, DateTime fechaSalida, DateTime fechaLlegadaEstimada)
        {
            Crucero = crucero;
            Recorrido = recorrido;
            FechaLlegada = fechaLlegada;
            FechaSalida = fechaSalida;
            FechaLlegadaEstimada = fechaLlegadaEstimada;
        }
    }
}
