using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class Recorrido : Form
    {
        private Model.Session _session;
        private Model.Recorrido _editObject;
        private ListadoRecorrido _listado;

        public Recorrido()
        {
            InitializeComponent();
        }

        public Recorrido(Model.Session session)
        {
            // TODO: Complete member initialization
            _session = session;
        }

        public Recorrido(Model.Session session, Model.Recorrido editRecorrido, ListadoRecorrido listado)
        {
            InitializeComponent();
            _session = session;
            _editObject = editRecorrido;
            _listado = listado;
            //InitValues();
            //BindRol();
        }
    }
}
