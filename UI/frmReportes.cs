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
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();

            reserva = new BEReserva();
        }

        BEReserva reserva;

        void MostrarCombo()
        {
            BLLReserva bllReserva = new BLLReserva();
            comboHabitaciones.DataSource = null;
            comboHabitaciones.DataSource = bllReserva.LeerReservas();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            MostrarCombo();
        }

        private void comboHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            reserva = (BEReserva)comboHabitaciones.SelectedItem;

            dateInicio.Value = reserva.FechaEntrada;
            dateFin.Value = reserva.FechaSalida;
        }
    }
}
