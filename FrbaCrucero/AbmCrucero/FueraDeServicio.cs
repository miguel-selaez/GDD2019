using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class FueraDeServicio : Form
    {
        public FueraDeServicio()
        {
            InitializeComponent();
            dtIncioFueraServicio.Value = Tools.GetDate();
        }
    }
}
