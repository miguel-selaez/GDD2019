using FrbaCrucero.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Model
{
    public class Tramo
    {
        public int Id { get; set; }
        public Model.Puerto PuertoOrigen { get; set; }
        public Model.Puerto PuertoDestino { get; set; }
        public decimal Precio { get; set; }

        public Tramo(DataRow row)
        {
            Id = row.GetValue<int>("t_id");
            PuertoOrigen = DAOFactory.PuertoDAO.GetPuerto(row.GetValue<int>("t_id_origen"));
            PuertoDestino = DAOFactory.PuertoDAO.GetPuerto(row.GetValue<int>("t_id_destino"));
            Precio = row.GetValue<decimal>("t_precio");
        }

        public Tramo(Model.Puerto puertoOrigen, Model.Puerto puertoDestino, decimal precio)
        {
            PuertoOrigen = puertoOrigen;
            PuertoDestino = puertoDestino;
            Precio = precio;
        }
    }
}
