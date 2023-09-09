using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmRecepcion : Form
    {
        public frmRecepcion()
        {
            InitializeComponent();

            bllHabitacion = new BLLHabitacion();
            reserva = new BEReserva();
        }

        BLLHabitacion bllHabitacion;
        public static BEReserva reserva;

        void MostrarGrilla()
        {
            grillaHabitaciones.DataSource = null;
            grillaHabitaciones.DataSource = bllHabitacion.LeerHabitaciones();
        }
        enum ePiso
        {
            Todos,
            Primero,
            Segundo,
            Tercero,
            Cuarto,
            Quinto
        }

        private void frmRecepcion_Load(object sender, EventArgs e)
        {
            MostrarGrilla();
            comboPiso.DataSource = Enum.GetValues(typeof(ePiso));
        }

        private void grillaHabitaciones_DoubleClick(object sender, EventArgs e)
        {
            if (reserva.unaHabitacion.Estado == "Disponible")
            {
                frmReserva abrir = new frmReserva();
                abrir.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Esta habitacion no esta disponible por: " + reserva.unCliente.Nombre);
            }
        }

        private void grillaHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BLLReserva bllReserva = new BLLReserva();
            reserva.unaHabitacion = (BEHabitacion)grillaHabitaciones.CurrentRow.DataBoundItem;

            BEReserva reservaNueva = bllReserva.BuscarReserva(reserva.unaHabitacion);
            if(reservaNueva != null)
            {
                reserva = reservaNueva;
            }
        }

        private void comboPiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pisoHabitacion = comboPiso.Text;

            if(pisoHabitacion == "Todos")
            {
                MostrarGrilla();
            }
            else
            {
                grillaHabitaciones.DataSource = bllHabitacion.BuscarHabitacion(pisoHabitacion); 
            }
        }
    }
}