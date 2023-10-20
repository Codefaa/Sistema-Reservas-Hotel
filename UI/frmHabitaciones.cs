using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BE;
using BLL;

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
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!grillaHabitaciones.ReadOnly)
            {
                grillaHabitaciones.ReadOnly = true;
                btnModificar.BackColor = Color.White;
            }
            else
            {
                grillaHabitaciones.ReadOnly = false;
                btnModificar.BackColor = Color.Red;
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
