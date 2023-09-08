using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmReserva : Form
    {
        public frmReserva()
        {
            InitializeComponent();
        }

        void DetallesHabitacion()
        {
            txtNumero.Text = frmRecepcion.reserva.unaHabitacion.Numero.ToString();
            txtCategoria.Text = frmRecepcion.reserva.unaHabitacion.Categoria;
            txtPrecio.Text = frmRecepcion.reserva.unaHabitacion.Precio.ToString();
            txtPiso.Text = frmRecepcion.reserva.unaHabitacion.Piso;
            txtPrecio2.Text = frmRecepcion.reserva.unaHabitacion.Precio.ToString();
        }

        void CargarComboClientes()
        {
            BLLCliente BLLCliente = new BLLCliente();

            comboClientes.DataSource = null;
            comboClientes.DataSource = BLLCliente.BuscarClienteSinReserva();

            comboClientes.DisplayMember = "Nombre";
            comboClientes.ValueMember = "ID";
            comboClientes.Refresh();
        }

        private void frmReserva_Load(object sender, EventArgs e)
        {
            DetallesHabitacion();
            CargarComboClientes();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmRecepcion abrir = new frmRecepcion();
            abrir.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLLReserva BLLReserva = new BLLReserva();
            BLLHabitacion BLLHabitacion = new BLLHabitacion();

            try
            {
                frmRecepcion.reserva.unCliente = (BECliente)comboClientes.SelectedItem;
                frmRecepcion.reserva.FechaEntrada = DateTime.Now;
                frmRecepcion.reserva.FechaSalida = dateSalida.Value;
                frmRecepcion.reserva.Adelanto = Convert.ToDecimal(txtAdelanto.Text);
                frmRecepcion.reserva.unaHabitacion.Estado = "Ocupada";

                BLLHabitacion.ModificarHabitacion(frmRecepcion.reserva.unaHabitacion);
                BLLReserva.AgregarReserva(frmRecepcion.reserva);

                MessageBox.Show("Reserva Registrada con Exito!");

                CargarComboClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            frmCliente abrir = new frmCliente();
            abrir.Show();
        }
    }
}
