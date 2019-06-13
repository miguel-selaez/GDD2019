using System;
using System.Data;

namespace FrbaCrucero.Model
{
    public class FueraServicioCrucero
    {
        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Motivo { get; set; }
        public Model.Crucero Crucero { get; set; }

        public FueraServicioCrucero(Model.Crucero crucero, DateTime fechaInicio, DateTime fechaFin, string motivo)
        {
            Crucero = crucero;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Motivo = motivo;
        }
    }
}
