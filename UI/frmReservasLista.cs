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
    public partial class frmReservasLista : Form
    {
        public frmReservasLista()
        {
            InitializeComponent();

            reserva = new BEReserva();
            bllReservas = new BLLReserva();
        }

        BEReserva reserva;
        BLLReserva bllReservas;

        void MostrarGrillaReservas()
        {

            grillaReservas.DataSource = null;
            grillaReservas.DataSource = bllReservas.LeerReservas();
        }

        private void frmReservasLista_Load(object sender, EventArgs e)
        {
            MostrarGrillaReservas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            reserva.FechaSalida = dateFechaSalida.Value;

            bllReservas.ModificarReserva(reserva);

            MostrarGrillaReservas();
        }

        private void grillaReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            reserva = (BEReserva)grillaReservas.CurrentRow.DataBoundItem;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmRecepcion abrir = new frmRecepcion();
            abrir.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            BLLHabitacion bllHabitacion = new BLLHabitacion();
            bllHabitacion.CambiarEstado(reserva.unaHabitacion);

            bllReservas.BajaReserva(reserva);
            MostrarGrillaReservas();

            MessageBox.Show("Se dio de baja la reserva");
        }
    }
}
