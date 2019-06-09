using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public class MenuCreator
    {
        private FrbaCrucero MainInit { get; set; }

        public MenuCreator(FrbaCrucero main)
        {
            MainInit = main;
        }

        public ToolStripMenuItem GetItemMenu(string funcion)
        {
            ToolStripMenuItem itemMenu = new ToolStripMenuItem();

            switch (funcion)
            {
                case "ABM ROL":
                    itemMenu.Text = "Rol";
                    ToolStripMenuItem listadoRol = new ToolStripMenuItem("Listado", null, new EventHandler(listadoRol_Click));
                    itemMenu.DropDownItems.Add(listadoRol);

                    ToolStripMenuItem nuevoRol = new ToolStripMenuItem("Nuevo", null, new EventHandler(nuevoRol_Click));
                    itemMenu.DropDownItems.Add(nuevoRol);
                    break;
                case "ABM USUARIO":
                    itemMenu.Text = "Usuario";
                    break;
                case "ABM PUERTO":
                    itemMenu.Text = "Puerto";
                    break;
                case "ABM RECORRIDO":
                    itemMenu.Text = "Recorrido";
                    ToolStripMenuItem listadoRecorrido = new ToolStripMenuItem("Listado", null, new EventHandler(listadoRecorrido_Click));
                    itemMenu.DropDownItems.Add(listadoRecorrido);

                    ToolStripMenuItem nuevoRecorrido = new ToolStripMenuItem("Nuevo", null, new EventHandler(nuevoRecorrido_Click));
                    itemMenu.DropDownItems.Add(nuevoRecorrido);
                    break;
                case "ABM CRUCERO":
                    itemMenu.Text = "Crucero";
                    ToolStripMenuItem listadoCrucero = new ToolStripMenuItem("Listado", null, new EventHandler(listadoCrucero_Click));
                    itemMenu.DropDownItems.Add(listadoCrucero);

                    ToolStripMenuItem nuevoCrucero = new ToolStripMenuItem("Nuevo", null, new EventHandler(nuevoCrucero_Click));
                    itemMenu.DropDownItems.Add(nuevoCrucero);
                    break;
                case "ABM VIAJE":
                    itemMenu.Text = "Viajes";
                    //ToolStripMenuItem listadoViaje = new ToolStripMenuItem("Listado", null, new EventHandler(listadoViaje_Click));
                    //itemMenu.DropDownItems.Add(listadoViaje);

                    ToolStripMenuItem generarViaje = new ToolStripMenuItem("Generar viaje", null, new EventHandler(generarViaje_Click));
                    itemMenu.DropDownItems.Add(generarViaje);
                    break;
                case "COMPRAS Y RESERVAS":
                    itemMenu.Text = "Compras y/o Reservas";
                    ToolStripMenuItem listadoCompraReserva = new ToolStripMenuItem("Buscar", null, new EventHandler(listadoCompraReserva_Click));
                    itemMenu.DropDownItems.Add(listadoCompraReserva);

                    ToolStripMenuItem listadoCliente = new ToolStripMenuItem("Listado de Clientes", null, new EventHandler(listadoCliente_Click));
                    itemMenu.DropDownItems.Add(listadoCliente);

                    ToolStripMenuItem nuevoCliente = new ToolStripMenuItem("Nuevo Cliente", null, new EventHandler(nuevoCliente_Click));
                    itemMenu.DropDownItems.Add(nuevoCliente);
                    break;                
                case "PAGOS":
                    itemMenu = new ToolStripMenuItem("Pagos", null, new EventHandler(pagos_Click));
                    break;
                case "LISTADO ESTADISTICO":
                    itemMenu = new ToolStripMenuItem("Estadísticas", null, new EventHandler(estadisticas_Click));
                    break;
                case "LOGGED":
                    itemMenu.Text = "Archivo";
                    ToolStripMenuItem cerrarSesion = new ToolStripMenuItem("Cerrar Sessión", null, new EventHandler(cerrarSesion_Click));
                    itemMenu.DropDownItems.Add(cerrarSesion);

                    ToolStripMenuItem cerrarL = new ToolStripMenuItem("Cerrar", null, new EventHandler(cerrar_Click));
                    itemMenu.DropDownItems.Add(cerrarL);
                    break;
                default:
                    itemMenu.Text = "Archivo";
                    ToolStripMenuItem iniciarSesion = new ToolStripMenuItem("Iniciar Sesión", null, new EventHandler(iniciarSesion_Click));
                    itemMenu.DropDownItems.Add(iniciarSesion);

                    ToolStripMenuItem cerrarD = new ToolStripMenuItem("Cerrar", null, new EventHandler(cerrar_Click));
                    itemMenu.DropDownItems.Add(cerrarD);
                    break;
            }

            ((ToolStripDropDownMenu)(itemMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(itemMenu.DropDown)).ShowCheckMargin = true;

            return itemMenu;
        }

        private void pagos_Click(object sender, EventArgs e)
        {
            var nuevo = new PagoReserva.Pago(MainInit.session);
            nuevo.Show();
        }
        
        private void listadoCompraReserva_Click(object sender, EventArgs e)
        {
            var listado = new CompraReservaPasaje.CompraReserva(MainInit.session);

            listado.Show();
        }

        private void generarViaje_Click(object sender, EventArgs e)
        {
            var nuevo = new GeneracionViaje.Viaje(MainInit.session);
            nuevo.Show();
        }

        private void listadoViaje_Click(object sender, EventArgs e)
        {
            var listado = new GeneracionViaje.ListadoViajes(MainInit.session);

            listado.Show();
        }

        private void nuevoCrucero_Click(object sender, EventArgs e)
        {
            var nuevoRol = new AbmCrucero.AltaCrucero(MainInit.session);
            nuevoRol.Show();
        }

        private void listadoCrucero_Click(object sender, EventArgs e)
        {
            var listado = new AbmCrucero.ListadoCrucero(MainInit.session);

            listado.Show();
        }

        private void nuevoRecorrido_Click(object sender, EventArgs e)
        {
            var nuevoRol = new AbmRecorrido.Recorrido(MainInit.session);
            nuevoRol.Show();
        }

        private void listadoRecorrido_Click(object sender, EventArgs e)
        {
            var listado = new AbmRecorrido.ListadoRecorrido(MainInit.session);

            listado.Show();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            MainInit.Close();
        }

        private void cerrarSesion_Click(object sender, EventArgs e)
        {
            MainInit.session = null;
            MainInit.MainMenuStrip.Items.Clear();

            MainInit.SetInitMenu();
        }

        private void iniciarSesion_Click(object sender, EventArgs e)
        {
            MainInit.OpenLogin();
        }

        private void estadisticas_Click(object sender, EventArgs e)
        {
            var estadisticas = new ListadoEstadistico.Estadisticas(MainInit.session);

            estadisticas.Show();
        }

        private void nuevoCliente_Click(object sender, EventArgs e)
        {
            var nuevo = new AbmCliente.Cliente(MainInit.session);

            nuevo.Show();
        }

        private void listadoCliente_Click(object sender, EventArgs e)
        {
            var listado = new AbmCliente.ListadoCliente(MainInit.session);

            listado.Show();
        }

        private void nuevoRol_Click(object sender, EventArgs e)
        {
            var nuevoRol = new AbmRol.Rol(MainInit.session);
            nuevoRol.Show();
        }

        private void listadoRol_Click(object sender, EventArgs e)
        {
            var listado = new AbmRol.ListadoRol(MainInit.session);
            listado.Show();
        }
    }
}
