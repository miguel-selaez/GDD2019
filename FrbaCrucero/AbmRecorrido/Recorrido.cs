using FrbaCrucero.Exceptions;
using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class Recorrido : Form
    {
        private Session _session;
        private Model.Recorrido _editObject;
        private ListadoRecorrido _listado;

        public Recorrido(Session session)
        {
            InitializeComponent();
            _session = session;
            InitValues();
        }

        public Recorrido(Session session, Model.Recorrido editRecorrido, ListadoRecorrido listado)
        {
            InitializeComponent();
            _session = session;
            _editObject = editRecorrido;
            _listado = listado;
            InitValues();
            BindRecorrido();
        }

        private void InitValues()
        {
            var tramos = DAO.DAOFactory.TramoDAO.GetTramos();
            tramos = tramos.Where(f => NoExisteEnEditObject(f)).ToList();
            if (tramos.Any())
            {
                BindCbTramos(tramos.Select(t=>new TramoVO(t)).ToList());
            }
        }

        private void BindCbTramos(List<TramoVO> tramos)
        {
            cbTramos.DataSource = null;
            cbTramos.DataSource = tramos;
            cbTramos.DisplayMember = "Descripcion";
            cbTramos.SelectedIndex = 0;
        }

        private bool NoExisteEnEditObject(Tramo tramo)
        {
            return _editObject == null || !_editObject.Tramos.Exists(f => f.Id == tramo.Id);
        }


        private void BindRecorrido()
        {
            txtCodigo.Text = _editObject.Codigo;
            rdNo.Checked = _editObject.Baja;
            rdSi.Checked = !_editObject.Baja;

            BindLbTramos(_editObject.Tramos.Select(t => new TramoVO(t)).ToList());
        }

        private void BindLbTramos(List<TramoVO> tramos)
        {
            lbTramos.DataSource = null;
            lbTramos.DataSource = tramos;
            lbTramos.DisplayMember = "Descripcion";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                var baja = rdNo.Checked ? true : false;
                var tramos = lbTramos.Items.Cast<TramoVO>().ToList();
                if (_editObject == null)
                {
                    _editObject = new Model.Recorrido(txtCodigo.Text, baja, tramos.Select(tvo => tvo.Tramo).ToList());
                }
                else
                {
                    _editObject.Codigo = txtCodigo.Text;
                    _editObject.Baja = baja;
                    _editObject.Tramos = tramos.Select(tvo => tvo.Tramo).ToList();
                }
                DAO.DAOFactory.RecorridoDAO.CreateOrUpdate(_editObject);

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
                throw new ValidateException("El codigo no puede ser nulo.");
            }
            if (rdSi.Checked == false && rdNo.Checked == false)
            {
                throw new ValidateException("Debe seleccionar la vigencia del recorrido");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CerrarAbm();
        }

        private void CerrarAbm()
        {
            if (_listado != null)
                _listado.UpdateRecorridos();

            Close();
        }

        private void btnAddTramo_Click(object sender, EventArgs e)
        {
            var selected = (TramoVO)cbTramos.SelectedValue;

            var newLbList = (List<TramoVO>)lbTramos.DataSource ?? new List<TramoVO>();
            newLbList.Add(selected);

            BindLbTramos(newLbList);

            var newCbList = (List<TramoVO>)cbTramos.DataSource ?? new List<TramoVO>();
            newCbList.RemoveAt(cbTramos.SelectedIndex);

            BindCbTramos(newCbList);
        }

        private void btnDeleteTramo_Click(object sender, EventArgs e)
        {
            var deletedTramo = (TramoVO)lbTramos.SelectedValue;

            var newCbList = (List<TramoVO>)cbTramos.DataSource ?? new List<TramoVO>();
            newCbList.Add(deletedTramo);

            BindCbTramos(newCbList);

            var newLbList = (List<TramoVO>)lbTramos.DataSource ?? new List<TramoVO>();
            newLbList.RemoveAt(lbTramos.SelectedIndex);

            BindLbTramos(newLbList);
        }
    }

    public class TramoVO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Tramo Tramo { get; set; }

        public TramoVO(Tramo tramo)
        {
            Id = tramo.Id;
            Descripcion = tramo.PuertoOrigen.Descripcion + " - " + tramo.PuertoDestino.Descripcion + " - " + tramo.Precio;
            Tramo = tramo;
        }
    }
}