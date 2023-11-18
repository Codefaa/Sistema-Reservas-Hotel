using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using BE;
using BLL;

namespace UI
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Regex.IsMatch(numDNI.Value.ToString(), "^([0-9]+$)") == true)
                {
                    if (Regex.IsMatch(txtCorreo.Text, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$") == true)
                    {
                        BECliente cliente = new BECliente();
                        cliente.Nombre = txtNombre.Text;
                        cliente.Apellido = txtApellido.Text;
                        cliente.DNI = Convert.ToInt32(numDNI.Value);
                        cliente.Correo = txtCorreo.Text;

                        BLLCliente bllCliente = new BLLCliente();
                        bllCliente.AgregarCliente(cliente);

                        MessageBox.Show("Cliente Registrado con Exito!");
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un EMAIL valido");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un DNI valido");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}