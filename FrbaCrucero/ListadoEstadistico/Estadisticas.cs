using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class Estadisticas : Form
    {
        private Session _session;
        private List<Model.Estadistica> _resultsRecorridosPasajes;
        private List<Model.Estadistica> _resultsRecorridosCabinas;
        private List<Model.Estadistica> _resultsCrucerosFueraServicio;

        public Estadisticas()
        {
            InitializeComponent();
        }

        public Estadisticas(Model.Session session)
        {
            InitializeComponent();
            _session = session;
            _session = session;
            InitValues();
        }
        private void InitValues()
        {
            List<Semestre> semestres = new List<Semestre>();
            semestres.Add(new Semestre("01/2015", new DateTime(2015, 01, 01, 0, 0, 0), new DateTime(2015, 06, 30, 23, 59, 59)));
            semestres.Add(new Semestre("02/2015", new DateTime(2015, 07, 01, 0, 0, 0), new DateTime(2015, 12, 31, 23, 59, 59)));
            semestres.Add(new Semestre("01/2016", new DateTime(2016, 01, 01, 0, 0, 0), new DateTime(2016, 06, 30, 23, 59, 59)));
            semestres.Add(new Semestre("02/2016", new DateTime(2016, 07, 01, 0, 0, 0), new DateTime(2016, 12, 31, 23, 59, 59)));
            semestres.Add(new Semestre("01/2017", new DateTime(2017, 01, 01, 0, 0, 0), new DateTime(2017, 06, 30, 23, 59, 59)));
            semestres.Add(new Semestre("02/2017", new DateTime(2017, 07, 01, 0, 0, 0), new DateTime(2017, 12, 31, 23, 59, 59)));
            semestres.Add(new Semestre("01/2018", new DateTime(2018, 01, 01, 0, 0, 0), new DateTime(2018, 06, 30, 23, 59, 59)));
            semestres.Add(new Semestre("02/2018", new DateTime(2018, 07, 01, 0, 0, 0), new DateTime(2018, 12, 31, 23, 59, 59)));
            semestres.Add(new Semestre("01/2019", new DateTime(2019, 01, 01, 0, 0, 0), new DateTime(2019, 06, 30, 23, 59, 59)));
            semestres.Add(new Semestre("02/2019", new DateTime(2019, 07, 01, 0, 0, 0), new DateTime(2019, 12, 31, 23, 59, 59)));
            semestres.Add(new Semestre("01/2020", new DateTime(2020, 01, 01, 0, 0, 0), new DateTime(2020, 06, 30, 23, 59, 59)));
            semestres.Add(new Semestre("02/2020", new DateTime(2020, 07, 01, 0, 0, 0), new DateTime(2020, 12, 31, 23, 59, 59)));
            BindCbSemestres(semestres);
        }

        public void BindCbSemestres(List<Semestre> semestres)
        {
            cbSemestres.DataSource = null;
            cbSemestres.DataSource = semestres;
            cbSemestres.DisplayMember = "Descripcion";
            cbSemestres.SelectedIndex = 0;
        }

        private void BtnBuscar_Click(object sender, System.EventArgs e)
        {
            dgRecorridosPasajes.Rows.Clear();
            dgRecorridosCabinas.Rows.Clear();
            dgCrucerosFueraServicio.Rows.Clear();
            DateTime fechaDesde = (cbSemestres.SelectedItem as Semestre).FechaDesde;
            DateTime fechaHasta = (cbSemestres.SelectedItem as Semestre).FechaHasta;
            _resultsRecorridosPasajes = DAO.DAOFactory.EstadisticaDAO.GetTopRecorridosPasajesComprados(fechaDesde, fechaHasta);
            if (_resultsRecorridosPasajes.Any())
            {
                foreach (Model.Estadistica estadistica in _resultsRecorridosPasajes)
                {
                    var index = dgRecorridosPasajes.Rows.Add();
                    dgRecorridosPasajes.Rows[index].Cells["rpvIdRecorrido"].Value = estadistica.IdRecorrido;
                    dgRecorridosPasajes.Rows[index].Cells["rpvCantidad"].Value = estadistica.Cantidad;
                }
            }

            _resultsRecorridosCabinas = DAO.DAOFactory.EstadisticaDAO.GetTopRecorridosCabinasLibres(fechaDesde, fechaHasta);
            if (_resultsRecorridosCabinas.Any())
            {
                foreach (Model.Estadistica estadistica in _resultsRecorridosCabinas)
                {
                    var index = dgRecorridosCabinas.Rows.Add();
                    dgRecorridosCabinas.Rows[index].Cells["rclIdRecorrido"].Value = estadistica.IdRecorrido;
                    dgRecorridosCabinas.Rows[index].Cells["rclIdViaje"].Value = estadistica.IdViaje;
                    dgRecorridosCabinas.Rows[index].Cells["rclCantidad"].Value = estadistica.Cantidad;
                }
            }

            _resultsCrucerosFueraServicio = DAO.DAOFactory.EstadisticaDAO.GetTopCrucerosFueraServicio(fechaDesde, fechaHasta);
            if (_resultsCrucerosFueraServicio.Any())
            {
                foreach (Model.Estadistica estadistica in _resultsCrucerosFueraServicio)
                {
                    var index = dgCrucerosFueraServicio.Rows.Add();
                    dgCrucerosFueraServicio.Rows[index].Cells["cfsIdCrucero"].Value = estadistica.IdCrucero;
                    dgCrucerosFueraServicio.Rows[index].Cells["cfsCantidad"].Value = estadistica.Cantidad;
                }
            }
            
        }
    }

    public partial class Semestre
    {
        public string Descripcion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public Semestre(string descripcion, DateTime fechaDesde, DateTime fechaHasta)
        {
            Descripcion = descripcion;
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
        }
    }
}
