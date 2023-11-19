using Abstraccion;
using BLL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmIniciarSesion : Form
    {
        public frmIniciarSesion()
        {
            //BLLUser bllU = new BLLUser();

            //if (!bllU.validarDigito())
            //{
            //    Hide();
            //    frmErrorDigito frmError = new frmErrorDigito();
            //    frmError.ShowDialog(this);
            //}
            //else 
            //{ 
            //    InitializeComponent();  // RECORDATORIO: Cuando salga devuelta el ErrorDigito, mover esta funcion dentro del If verdadero....
            //}

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BLLBitacora _BLLBitacora = new BLLBitacora();
                BLLUser _BLLUser = new BLLUser();

                IUser user = _BLLUser.Login(txtEmail.Text, txtContraseña.Text);


                if (user != null)
                {
                    _BLLBitacora.insertBitacora(user.Usuario, "Sesion", "Iniciar Sesion");

                    frmMenu menu = new frmMenu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                frmCrear abrir = new frmCrear();
                abrir.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
