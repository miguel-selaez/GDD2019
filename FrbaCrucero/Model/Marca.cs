using FrbaCrucero.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
