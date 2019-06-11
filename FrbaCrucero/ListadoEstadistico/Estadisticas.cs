using System.Windows.Forms;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class Estadisticas : Form
    {
        private Model.Session session;

        public Estadisticas()
        {
            InitializeComponent();
        }

        public Estadisticas(Model.Session session)
        {
            // TODO: Complete member initialization
            this.session = session;
        }
    }
}
