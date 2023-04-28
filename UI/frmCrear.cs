using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BE;
using BLL;
using Abstraccion;

namespace UI
{
    public partial class frmCrear : Form
    {
        public frmCrear()
        {
            InitializeComponent();

            BEunLogin = new BEUser();
        }
        BEUser BEunLogin;
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if(Regex.IsMatch(txtDNI.Text, "^([0-9]+$)") == true) {
                    if (Regex.IsMatch(txtEmail.Text, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$") == true) {
                        BLLUser BLLunUser = new BLLUser();
                        IUser user = new BEUser()
                        {
                            Usuario = txtUsuario.Text,
                            Contraseña = txtContraseña.Text,
                            DNI = Convert.ToInt32(txtDNI.Text),
                            Email = txtEmail.Text,
                        };

                        BLLunUser.Create(user);

                        frmIniciarSesion frm = new frmIniciarSesion();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("ingrese un email valido");
                    }
                }
                else
                {
                    MessageBox.Show("Error al iniciar sesion, ingrese dni valido");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmIniciarSesion frm = new frmIniciarSesion();
            frm.Show();
            this.Hide();
        }

    }
}
