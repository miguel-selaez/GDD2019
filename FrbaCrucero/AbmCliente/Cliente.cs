using FrbaCrucero.Model;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCliente
{    
    public partial class Cliente : Form
    {
        private Model.Session _session;
        private Model.Cliente _editObject;

        public Cliente(Session session)
        {
            this._session = session;
            InitializeComponent();
        }

        private void InitValues()
        {
            dtFechaNacimiento.Value = Tools.GetDate();
            dtFechaNacimiento.MaxDate = Tools.GetDate().AddYears(18);
        }

        private void BindCliente()
        {
            txtNombre.Text = _editObject.Nombre;
            txtApellido.Text = _editObject.Apellido;         
            txtNroDocumento.Text = _editObject.NumeroDocumento.ToString();
            txtMail.Text = _editObject.Mail;
            txtTelefono.Text = _editObject.Telefono.ToString();            
            dtFechaNacimiento.Value = _editObject.FechaNacimiento ?? Tools.GetDate();                                                           
            lbInconsistente.Text = _editObject.Inconsistente ? "Cliente Inconsistente" : "";         
        }

        private string ValidarFormatos()
        {
            string result = "";
            if (!Regex.IsMatch(txtNombre.Text, @"\w+"))
                result = "Nombre";
            else if (!Regex.IsMatch(txtApellido.Text, @"\w+"))
                result = "Apellido";
            else if (!Regex.IsMatch(txtNroDocumento.Text, @"\d+"))
                result = "DNI";
            else if (!Regex.IsMatch(txtTelefono.Text, @"\d+"))
                result = "Teléfono";
            else if (!Regex.IsMatch(txtCalle.Text, @"^([a-zA-Z0-9_\-\.\s]+)"))
                result = "Dirección";
            else if(!ValidarFormatoEmail(txtMail.Text))
                result = "Mail";

            return result;

        }

        private bool ValidarFormatoEmail(string input)
        {
            return Regex.IsMatch(input, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string formato = ValidarFormatos();
            if (!formato.Equals(""))
            {
                MessageBox.Show(formato + " incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
            else
            {
                try
                {
                    bool esInsert = true;

                    if (_editObject == null || _editObject.Id == 0)
                    {
                        _editObject = new Model.Cliente(
                            txtNombre.Text,
                            txtApellido.Text,
                            Decimal.Parse(txtNroDocumento.Text),
                            txtCalle.Text,
                            Int32.Parse(txtTelefono.Text),
                            txtMail.Text,
                            dtFechaNacimiento.Value);
                    }
                    else
                    {
                        esInsert = false;
                        _editObject.Inconsistente = true;
                        _editObject.Nombre = txtNombre.Text;
                        _editObject.Apellido = txtApellido.Text;
                        _editObject.Mail = txtMail.Text;
                        _editObject.Telefono = Int32.Parse(txtTelefono.Text);
                        //_editObject.TipoDocumento = (Model.TipoDocumento)cbTipoDocumento.SelectedValue;
                        _editObject.NumeroDocumento = decimal.Parse(txtNroDocumento.Text);
                        _editObject.FechaNacimiento = dtFechaNacimiento.Value;
                        _editObject.Direccion = txtCalle.Text;
                    }
                   _editObject.Id = DAO.DAOFactory.ClienteDAO.CreateOrUpdate(_editObject, esInsert);

                    MessageBox.Show("Se ha " + (esInsert ? "ingresado" : "actualizado") + " correctamente al cliente", "", MessageBoxButtons.OK);
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
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
          if(!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
          {
                MessageBox.Show("Sólo se admiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
          }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Sólo se admiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Sólo se admiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Sólo se admiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !(char.IsLetterOrDigit(e.KeyChar))
                && (e.KeyChar != (char)Keys.Back)
                && !(char.IsWhiteSpace(e.KeyChar))
                && !(CaracterGenericoMethods.EsCaracterGenerico(e.KeyChar))
               )
            {
                MessageBox.Show("Sólo se admiten caracteres alfanuméricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public enum CaracterGenerico
    {
        DOT = 46,
        AACUTE_H = 181,
        AACUTE_L = 160,
        EACUTE_H = 144,
        EACUTE_L = 130,
        IACUTE_H = 214,
        IACUTE_L = 161,
        OACUTE_H = 224,
        OACUTE_L = 162,
        UACUTE_H = 233,
        UACUTE_L = 163,
        ENIE_H = 165,
        ENIE_L = 164
    }

    public static class CaracterGenericoMethods
    {
        public static bool EsCaracterGenerico(char e)
        {
            if
            (
                e.Equals((char)CaracterGenerico.DOT)
                || e.Equals((char)CaracterGenerico.AACUTE_H)
                || e.Equals((char)CaracterGenerico.AACUTE_H)
                || e.Equals((char)CaracterGenerico.AACUTE_L)
                || e.Equals((char)CaracterGenerico.EACUTE_H)
                || e.Equals((char)CaracterGenerico.EACUTE_L)
                || e.Equals((char)CaracterGenerico.IACUTE_H)
                || e.Equals((char)CaracterGenerico.IACUTE_L)
                || e.Equals((char)CaracterGenerico.OACUTE_H)
                || e.Equals((char)CaracterGenerico.OACUTE_L)
                || e.Equals((char)CaracterGenerico.UACUTE_H)
                || e.Equals((char)CaracterGenerico.UACUTE_L)
                || e.Equals((char)CaracterGenerico.ENIE_H)
                || e.Equals((char)CaracterGenerico.ENIE_L)
            )
            {
                return true;
            }
            else
                return false;
        }
    }
}
