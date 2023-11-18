using BE;
using BLL;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UI
{
    public partial class frmHabitacion : Form
    {
        public frmHabitacion()
        {
            InitializeComponent();
        }

        enum eCategoria
        {
            Matrimonial,
            Individual,
            Doble
        }

        enum ePiso
        {
            Primero,
            Segundo,
            Tercero,
            Cuarto,
            Quinto
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Regex.IsMatch(txtPrecio.Text, "^([0-9]+$)") == true) //FALTA AGREGAR QUE VALIDE NUMEROS REALES
                {
                    if(Regex.IsMatch(numNumero.Value.ToString(), "^([0-9]+$)") == true)
                    {
                        BEHabitacion habitacion = new BEHabitacion();
                        habitacion.Numero = Convert.ToInt32(numNumero.Value);
                        habitacion.Precio = Convert.ToDecimal(txtPrecio.Text);  //ARREGLAR: ME REDONDE EL EL VALOR DECIMAL 
                        habitacion.Categoria = comboCategoria.SelectedItem.ToString();
                        habitacion.Piso = comboPiso.SelectedItem.ToString();

                        BLLHabitacion bllHabitacion = new BLLHabitacion();
                        bllHabitacion.AgregarHabitacion(habitacion);

                        MessageBox.Show("Habitacion Registrado con Exito!");
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un NUMERO valido");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un PRECIO valido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            frmHabitaciones abrir = new frmHabitaciones();
            abrir.Show();
            this.Close();
        }

        private void frmHabitacion_Load(object sender, EventArgs e)
        {
            comboCategoria.DataSource = Enum.GetValues(typeof(eCategoria));
            comboPiso.DataSource = Enum.GetValues(typeof(ePiso));
        }
    }
}
