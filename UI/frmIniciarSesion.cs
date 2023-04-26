using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL;
using Abstraccion;
using BE;
namespace UI
{
    public partial class frmIniciarSesion : Form
    {
        public frmIniciarSesion()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BLLUser _BLLUser = new BLLUser();
                IUser user = _BLLUser.Login(txtEmail.Text, txtContraseña.Text);
                if(user != null)
                {
                    frmMenu menu = new frmMenu();
                    this.Hide();
                    menu.Show();

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
                this.Hide();

                frmCrear abrir = new frmCrear();
                abrir.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
