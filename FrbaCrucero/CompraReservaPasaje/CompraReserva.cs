using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class CompraReserva : Form
    {
        private Model.Session session;

        public CompraReserva()
        {
            InitializeComponent();
        }

        public CompraReserva(Model.Session session)
        {
            // TODO: Complete member initialization
            this.session = session;
        }
    }
}
