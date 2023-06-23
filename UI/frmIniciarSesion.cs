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
            BLLUser bllU = new BLLUser();
            if (!bllU.validarDigito())
            {
                Hide();
                errorDigito frmError = new errorDigito();
                frmError.ShowDialog(this);


            }
            else { 
            InitializeComponent();
        }}

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
                frmCrear crear = new frmCrear();
                crear.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmIniciarSesion_Load(object sender, EventArgs e)
        {
            
        }
        }
}
