using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.GeneracionViaje
{
    public partial class Viaje : Form
    {
        private Session _session;
        private Model.Viaje _editObject;
        private ListadoViajes _listado;

        public Viaje(Session session)
        {
            InitializeComponent();
            _session = session;
            InitValues();
        }

        public Viaje(Session session, Model.Viaje editViaje, ListadoViajes listado)
        {
            InitializeComponent();
            _session = session;
            _editObject = editViaje;
            _listado = listado;
            InitValues();
            //BindViaje();
        }

        private void InitValues()
        {
            //var tramos = DAO.DAOFactory.TramoDAO.GetTramos();
            //tramos = tramos.Where(f => NoExisteEnEditObject(f)).ToList();
            //if (tramos.Any())
            //{
            //    BindCbTramos(tramos.Select(t => new TramoVO(t)).ToList());
            //}
        }
    }
}
