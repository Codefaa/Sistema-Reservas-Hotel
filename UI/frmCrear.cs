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

namespace UI
{
    public partial class frmCrear : Form
    {
        public frmCrear()
        {
            InitializeComponent();

            BEunLogin = new BELogin();
        }
        BELogin BEunLogin;
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
