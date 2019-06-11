using FrbaCrucero.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class FrbaCrucero : Form
    {
        public Session session;

        private MenuCreator _menuCreator;

        public FrbaCrucero()
        {
            InitializeComponent();
            _menuCreator = new MenuCreator(this);
            SetInitMenu();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenLogin();
        }

        public void OpenLogin()
        {
            Hide();
            var login = new Login.Login(this);
            login.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {

        }

        public void SetSession(Usuario user, Rol rol)
        {
            session = new Session()
            {
                User = user,
                Main = this,
                Rol = rol
            };
        }

        public void SetInitMenu()
        {
            var itemDefault = _menuCreator.GetItemMenu("INIT");
            mainMenu.MdiWindowListItem = itemDefault;
            mainMenu.Items.Add(itemDefault);

            mainMenu.Dock = DockStyle.Top;
            this.MainMenuStrip = mainMenu;

            var generico = DAO.DAOFactory.UsuarioDAO.Login("admin", "w23e");
            SetSession(generico, generico.Roles.First());
            SetUserFunctions();
        }

        public void SetMenuLogged()
        {
            this.MainMenuStrip.Items.Clear();
            var itemDefault = _menuCreator.GetItemMenu("LOGGED");
            mainMenu.MdiWindowListItem = itemDefault;
            mainMenu.Items.Add(itemDefault);

            SetUserFunctions();
        }

        private void SetUserFunctions()
        {
            foreach (var funcion in session.Rol.Funciones)
            {
                var itemFuncion = _menuCreator.GetItemMenu(funcion.Descripcion);
                mainMenu.MdiWindowListItem = itemFuncion;
                mainMenu.Items.Add(itemFuncion);
            }

            mainMenu.Dock = DockStyle.Top;
            this.MainMenuStrip = mainMenu;
        }
    }
}
