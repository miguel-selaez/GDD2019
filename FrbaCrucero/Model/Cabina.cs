using FrbaCrucero.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Model
{
    public class Cabina
    {
        public int Id { get; set; }
        public decimal Numero { get; set; }
        public decimal Piso { get; set; }
        public bool Baja { get; set; }
        public TipoCabina Tipo { get; set; }

        public Cabina(DataRow row)
        {
            Id = row.GetValue<int>("ca_id");
            Numero = row.GetValue<decimal>("ca_numero");
            Piso = row.GetValue<decimal>("ca_piso");
            Baja = row.GetValue<bool>("ca_baja");
            Tipo = DAO.DAOFactory.CabinaDAO.GetTipoCabina(row.GetValue<int>("ca_id_tipo_cabina"));
        }

        public Cabina(int id, decimal numero, decimal piso, bool baja, TipoCabina tipo)
        {
            Id = id;
            Numero = numero;
            Piso = piso;
            Baja = baja;
            Tipo = tipo;
        }
    }
}
