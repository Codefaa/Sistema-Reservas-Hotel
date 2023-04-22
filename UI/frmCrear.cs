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
                BLLUser BLLunUser = new BLLUser();
                IUser user = new BEUser()
                {
                    Usuario = txtUsuario.Text,
                    Contraseña = txtContraseña.Text,
                    DNI = Convert.ToInt32(txtDNI.Text),
                    Email = txtEmail.Text,
                };

                BLLunUser.Create(user);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
