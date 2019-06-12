using FrbaCrucero.Exceptions;
using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class AltaCrucero : Form
    {
        private Model.Session _session;
        private Model.Crucero _crucero;
        private ListadoCrucero _listadoCrucero;
        private List<Model.Cabina> _cabinas;
        
        public AltaCrucero(Model.Session session)
        {
            InitializeComponent();

            this._session = session;
        }

        public AltaCrucero(Model.Session session, Model.Crucero crucero, ListadoCrucero listadoCrucero)
        {
            InitializeComponent();

            _session = session;
            _crucero = crucero;
            _listadoCrucero = listadoCrucero;
            InitValues();
            BindCrucero();
        }

        private void InitValues()
        {
            var marcas = DAO.DAOFactory.CruceroDAO.GetMarcas();
            BindCbMarca(marcas);
        }

        private void BindCrucero()
        {
            txtCodigo.Text = _crucero.Codigo;
            txtModelo.Text = _crucero.Modelo;
            cbMarca.SelectedIndex = IndexOfBindMarca(_crucero.Marca.Id);

            dtAlta.Visible = _crucero.FechaAlta.HasValue;
            dtAlta.Value = _crucero.FechaAlta ?? Tools.GetDate();

            rdNo.Checked = _crucero.Baja;
            rdSi.Checked = !_crucero.Baja;

            _cabinas = _crucero.Cabinas;
            BindCabinas();
        }

        private void BindCabinas()
        {
            dgCabinas.Rows.Clear();

            foreach (Model.Cabina cabina in _cabinas)
            {
                var index = dgCabinas.Rows.Add();
                dgCabinas.Rows[index].Cells["Numero"].Value = cabina.Numero.ToString();
                dgCabinas.Rows[index].Cells["Piso"].Value = cabina.Piso.ToString();
                dgCabinas.Rows[index].Cells["Tipo"].Value = cabina.Tipo.Descripcion;
                dgCabinas.Rows[index].Cells["Eliminar"].Value = "X";
                dgCabinas.Rows[index].Visible = !cabina.Baja;
            }
        }

        private int IndexOfBindMarca(int id)
        {
            var list = (List<Model.Marca>)cbMarca.DataSource;
            return list.FindIndex(t => t.Id == id);
        }

        private void BindCbMarca(List<Marca> marcas)
        {
            cbMarca.DataSource = null;
            cbMarca.DataSource = marcas;
            cbMarca.DisplayMember = "Descripcion";
            cbMarca.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                var baja = rdNo.Checked;
                if (_crucero == null)
                {
                    _crucero = new Model.Crucero(txtCodigo.Text, txtModelo.Text, (Model.Marca)cbMarca.SelectedItem, baja, _cabinas);
                }
                else
                {
                    _crucero.Codigo = txtCodigo.Text;
                    _crucero.Modelo = txtModelo.Text;
                    _crucero.Marca = (Model.Marca)cbMarca.SelectedItem;
                    if (baja && !_crucero.FechaBaja.HasValue)
                        _crucero.FechaBaja = Tools.GetDate();
                    _crucero.Baja = baja;
                    _crucero.Cabinas = _cabinas;
                }
                DAO.DAOFactory.CruceroDAO.CreateOrUpdate(_crucero);

                CerrarAbm();
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
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                throw new ValidateException("El código no puede estar vacío.");
            }

            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                throw new ValidateException("El modelo no puede estar vacío.");
            }

            if (rdSi.Checked == false && rdNo.Checked == false)
            {
                throw new ValidateException("Debe seleccionar la vigencia del crucero");
            }

            if (!_cabinas.Any())
            {
                throw new ValidateException("El crucero debe tener alguna cabina");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CerrarAbm();
        }

        private void btnAgregarCabina_Click(object sender, EventArgs e)
        {
            var nuevo = new AltaCabina(_session, this);
            nuevo.Show();
        }

        public void AgregarCabina(Model.Cabina nuevaCabina)
        {
            _cabinas.Add(nuevaCabina);
            BindCabinas();
        }
        
        private void btnFueraServicio_Click(object sender, EventArgs e)
        {
            var fueraServicio = new FueraDeServicio();
            fueraServicio.Show();
        }

        private void dgCabinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _cabinas[e.RowIndex].Baja = true;
                BindCabinas();
            }
        }

        private void CerrarAbm()
        {
            if (_listadoCrucero != null)
                _listadoCrucero.UpdateCruceros();

            Close();
        }

    }
}
