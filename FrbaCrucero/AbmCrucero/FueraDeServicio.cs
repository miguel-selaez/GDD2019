using FrbaCrucero.Exceptions;
using FrbaCrucero.Model;
using System;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class FueraDeServicio : Form
    {
        private Model.Session _session;
        private AltaCrucero _altaCrucero;
        private Model.Crucero _crucero;

        public FueraDeServicio(Model.Session _session, AltaCrucero altaCrucero, Model.Crucero crucero)
        {
            InitializeComponent();
            this._session = _session;
            this._altaCrucero = altaCrucero;
            _crucero = crucero;

            dtIncioFueraServicio.Value = Tools.GetDate();
            dtFinFueraServicio.Value = Tools.GetDate();
        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidateForm();

                var fueraServicio = new FueraServicioCrucero(_crucero, dtIncioFueraServicio.Value, dtFinFueraServicio.Value, txtMotivo.Text);
                DAO.DAOFactory.CruceroDAO.SaveFueraServicio(fueraServicio);

                _altaCrucero.UpdateCrucero();
                Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error de Validación";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private void ValidateForm()
        {
            if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                throw new ValidateException("El motivo no puede estar vacío.");
            }

            if (dtFinFueraServicio.Value <= Tools.GetDate())
            {
                throw new ValidateException("La fecha fin no puede ser menor a la fecha actual.");
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
