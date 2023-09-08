using Abstraccion;
using BE;
using BLL;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
                if (Regex.IsMatch(txtDNI.Text, "^([0-9]+$)") == true)
                {
                    if (Regex.IsMatch(txtEmail.Text, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$") == true)
                    {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmIniciarSesion abrir = new frmIniciarSesion();
            abrir.Show();
            this.Hide();
        }
    }
}
