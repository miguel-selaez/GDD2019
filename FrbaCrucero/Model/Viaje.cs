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
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegadaEstimada { get; set; }

        public Viaje(DataRow row)
        {
            Id = row.GetValue<decimal>("v_id");
            Crucero = new Crucero(row);
            //Recorrido = DAOFactory.RecorridoDAO.GetRecorrido(row.GetValue<decimal>("v_id_recorrido"));
            FechaLlegada = row.GetValue<DateTime>("v_fecha_llegada");
            FechaSalida = row.GetValue<DateTime>("v_fecha_salida");
            FechaLlegadaEstimada = row.GetValue<DateTime>("v_fecha_llegada_estimada");

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
