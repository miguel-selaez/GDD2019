﻿using FrbaCrucero.DAO;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.Model
{
    public class Recorrido
    {
        public decimal Id { get; set; }
        public string Codigo { get; set; }
        public bool Baja { get; set; }

        private List<Tramo> _tramos;
        public List<Tramo> Tramos
        {
            get { return _tramos ?? (_tramos = DAOFactory.TramoDAO.GetTramosByRecorrido(Id)); }
            set { _tramos = value; }
        }

        public Recorrido(DataRow row)
        {
            Id = row.GetValue<decimal>("rc_id");
            Codigo = row.GetValue<string>("rc_codigo");
            Baja = row.GetValue<bool>("rc_baja");
        }

        public Recorrido(string codigo, bool baja, List<Tramo> tramos)
        {
            Codigo = codigo;
            Baja = baja;
            Tramos = tramos;
        }
    }
}
