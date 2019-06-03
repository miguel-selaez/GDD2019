using FrbaCrucero.DAO;
using FrbaCrucero.Exceptions;
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

namespace FrbaCrucero.Login
{
    public partial class Login : Form
    {
        private FrbaCrucero _inicio;

        public Login(FrbaCrucero inicio)
        {
            InitializeComponent();
            _inicio = inicio;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            _inicio.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                var currentUser = AutenticateUser();
                if (currentUser != null)
                {
                    _inicio.SetSession(currentUser, currentUser.Roles.First());
                    _inicio.SetMenuLogged();
                    _inicio.Show();
                    Close();
                }
                else throw new LoginException("Usuario o Password incorrecto.");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void ValidateForm()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
                throw new ValidateException("El usuario es un campo requerido");
            if (string.IsNullOrEmpty(txtPassword.Text))
                throw new ValidateException("El password es un campo requerido");
        }

        private Usuario AutenticateUser()
        {
            return DAOFactory.UsuarioDAO.Login(txtUser.Text, txtPassword.Text);
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _inicio.Show();
            Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
