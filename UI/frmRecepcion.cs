using BE;
using BLL;
using System;
using System.Windows.Forms;

using Abstraccion;
using Servicios;

namespace UI
{
    public partial class frmRecepcion : Form, IObservador
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

        #region Idioma

        Sesion sesion = Sesion.Instance;
        private void frmRecepcion_Load(object sender, EventArgs e)
        {
            MostrarGrilla();
            comboPiso.DataSource = Enum.GetValues(typeof(ePiso));

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

        private void grillaHabitaciones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // BLLReserva bllReserva = new BLLReserva();
                // reserva.unaHabitacion = (BEHabitacion)grillaHabitaciones.CurrentRow.DataBoundItem;

                if(reserva.unaHabitacion != null)
                {
                    if (reserva.unaHabitacion.Estado == "Disponible")
                    {
                        frmReserva abrir = new frmReserva();
                        abrir.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Esta habitacion esta ocupada por: " + reserva.unCliente.Nombre);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una habitacion");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grillaHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BLLReserva bllReserva = new BLLReserva();
                reserva.unaHabitacion = (BEHabitacion)grillaHabitaciones.CurrentRow.DataBoundItem;

                BEReserva reservaNueva = bllReserva.BuscarReserva(reserva.unaHabitacion);
                if (reservaNueva != null)
                {
                    reserva = reservaNueva;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboPiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string pisoHabitacion = comboPiso.Text;

                if (pisoHabitacion == "Todos")
                {
                    MostrarGrilla();
                }
                else
                {
                    grillaHabitaciones.DataSource = bllHabitacion.BuscarHabitacion(pisoHabitacion);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}