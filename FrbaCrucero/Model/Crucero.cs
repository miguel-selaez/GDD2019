using FrbaCrucero.DAO;
using System;
using System.Collections.Generic;
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
        public DateTime? FechaBaja { get; set; }
        public bool Baja { get; set; }

        public string Estado { get; set; }

        private List<Cabina> _cabinas;
        public List<Cabina> Cabinas
        {
            get { return _cabinas ?? (_cabinas = DAOFactory.CabinaDAO.GetCabinasByCrucero(Id)); }
            set { _cabinas = value; }
        }

        public Crucero(DataRow row)
        {
            Id = row.GetValue<int>("cr_id");
            Codigo = row.GetValue<string>("cr_codigo");
            Modelo = row.GetValue<string>("cr_modelo");
            Marca = DAO.DAOFactory.CruceroDAO.GetMarca(row.GetValue<int>("cr_id_marca"));
            FechaAlta = row.GetDate("cr_fecha_alta");
            FechaBaja = row.GetDate("cr_fecha_baja");
            Baja = row.GetValue<bool>("cr_baja");
            Estado = row.GetValue<string>("cr_estado");
        }

        public Crucero(string codigo, string modelo, Model.Marca marca, bool baja, List<Cabina> cabinas)
        {
            Codigo = codigo;
            Modelo = modelo;
            Marca = marca;
            FechaAlta = Tools.GetDate();
            Baja = baja;
            Cabinas = cabinas;
        }
    }

    public static class CruceroEstados
    {
        public static string Vigente = "Vigente";
        public static string NoVigente = "No Vigente";
        public static string FueraServicio = "Fuera de Servicio";
    }
}
