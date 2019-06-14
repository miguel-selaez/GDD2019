using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool Inconsistente { get; set; }
           
        public Cliente(DataRow Row)
        {
            Id = Row.GetValue<int>("c_id");
            Nombre = Row.GetValue<string>("c_nombre");
            Apellido = Row.GetValue<string>("c_apellido");
            NumeroDocumento = Row.GetValue<decimal>("c_dni");
            Direccion = Row.GetValue<string>("c_direccion");
            Telefono = Row.GetValue<int>("c_telefono");
            Mail = Row.GetValue<string>("c_mail");
            FechaNacimiento = Row.GetDate("c_fecha_nacimiento");                                               
            Inconsistente = Row.GetValue<bool>("c_inconsistente");
        }

        public Cliente(string _nombre, string _apellido, decimal _numeroDocumento, string _direccion, int _telefono, string _mail, DateTime? _fechaNacimiento)
        {
            this.Id = 0;
            this.Nombre = _nombre;
            this.Apellido = _apellido;
            this.NumeroDocumento = _numeroDocumento;
            this.Direccion = _direccion;
            this.Telefono = _telefono;
            this.Mail = _mail;
            this.FechaNacimiento = _fechaNacimiento;
            this.Inconsistente = false;
        }


    }
}
