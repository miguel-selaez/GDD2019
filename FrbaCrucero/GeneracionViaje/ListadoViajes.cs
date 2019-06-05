using FrbaCrucero.DAO;
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
    public partial class ListadoViajes : Form
    {
        private Session _session;
        private List<Model.Viaje> _results;

        public ListadoViajes()
        {
            InitializeComponent();
        }

        public ListadoViajes(Model.Session session)
        {
            InitializeComponent();
            _session = session;
            InitValues();
        }

        private void InitValues()
        {
            cbVigencia.SelectedIndex = 0;
        }

        public List<Model.Viaje> GetResults()
        {
            return DAOFactory.ViajeDAO.GetViajes(txtCodigoCrucero.Text, txtCodigoRecorrido.Text, cbVigencia.SelectedItem.ToString());
        }

    }
}
