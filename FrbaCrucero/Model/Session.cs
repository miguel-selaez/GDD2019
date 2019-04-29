using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Model
{
    public class Session
    {
        public Usuario User { get; set; }
        public FrbaCrucero Main { get; set; }
        public Rol Rol { get; set; }
    }
}
