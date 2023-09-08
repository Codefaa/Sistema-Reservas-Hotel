using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmHabitaciones : Form
    {
        public frmHabitaciones()
        {
            InitializeComponent();

            habitacion = new BEHabitacion();
            bllHabitacion = new BLLHabitacion();
        }

        BEHabitacion habitacion;
        BLLHabitacion bllHabitacion;
        void MostrarGrilla()
        {
            grillaHabitaciones.DataSource = null;
            grillaHabitaciones.DataSource = bllHabitacion.LeerHabitaciones();
        }

        private void frmHabitaciones_Load(object sender, EventArgs e)
        {
            MostrarGrilla();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmHabitacion abrir = new frmHabitacion();
            abrir.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!grillaHabitaciones.ReadOnly)
            {
                grillaHabitaciones.ReadOnly = true;
            }
            else
            {
                grillaHabitaciones.ReadOnly = false;
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                bllHabitacion.BajaHabitacion(habitacion);
                MostrarGrilla();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR - La habitacion ya tiene una RESERVA");
                MessageBox.Show(ex.Message);
            }
        }

        private void grillaHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            habitacion = (BEHabitacion)grillaHabitaciones.CurrentRow.DataBoundItem;
        }

        private void grillaHabitaciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bllHabitacion.ModificarHabitacion(habitacion);
        }
    }
}
