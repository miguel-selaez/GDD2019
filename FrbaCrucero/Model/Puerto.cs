using FrbaCrucero.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
