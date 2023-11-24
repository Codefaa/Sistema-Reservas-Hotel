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
using Abstraccion;
using Servicios;

namespace UI
{
    public partial class frmHabitaciones : Form, IObservador
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



        #region Idioma

        Sesion sesion = Sesion.Instance;
        private void frmHabitaciones_Load(object sender, EventArgs e)
        {
            MostrarGrilla();

            sesion.RegistrarObservador(this);
            sesion.ActualizarObservadores(Sesion.Idioma);
        }

        public void Actualizar(IIdioma idiomaObservado)
        {
            foreach (Control item in this.Controls)
            {
                item.Text = idiomaObservado.BuscarTraduccion(item.Tag.ToString());

                if (groupBox1.Controls.Count > 0)
                {
                    foreach (Control item2 in groupBox1.Controls)
                    {
                        item2.Text = idiomaObservado.BuscarTraduccion(item2.Tag.ToString());
                    }
                }
            }
        }

        #endregion


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
                if (habitacion != null)
                {
                    bllHabitacion.BajaHabitacion(habitacion);
                    MostrarGrilla();
                }
                else
                {
                    MessageBox.Show("Seleccione una habitacion");
                }
                    
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
