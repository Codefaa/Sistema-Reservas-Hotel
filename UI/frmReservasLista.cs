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
            try
            {
                if(reserva.FechaEntrada < dateFechaSalida.Value)
                {
                    reserva.FechaSalida = dateFechaSalida.Value;
                    reserva.PrecioFinal = bllReservas.CalcularPrecioFinal(reserva);
                    reserva.Total = bllReservas.CalcularTotal(reserva);

                    bllReservas.ModificarReserva(reserva);  // Faltaria agregar un campo VUELTO por si la fecha de salida termina modificando el precio final a un precio menor al de adelanto.

                    MostrarGrillaReservas();

                    MessageBox.Show("Se modifico la fecha de salida de la reserva");
                }
                else
                {
                    MessageBox.Show("La fecha de salida no puede ser menor a la fecha de entrada");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grillaReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            reserva = (BEReserva)grillaReservas.CurrentRow.DataBoundItem;

            dateFechaSalida.Value = reserva.FechaSalida;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmRecepcion abrir = new frmRecepcion();
            abrir.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if(reserva != null)
                {
                    BLLHabitacion bllHabitacion = new BLLHabitacion();
                    bllHabitacion.CambiarEstado(reserva.unaHabitacion);

                    bllReservas.BajaReserva(reserva);
                    MostrarGrillaReservas();

                    MessageBox.Show("Se dio de baja la reserva");
                }
                else
                {
                    MessageBox.Show("Seleccione una reserva");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
