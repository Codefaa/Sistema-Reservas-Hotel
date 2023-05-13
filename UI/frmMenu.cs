using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;
namespace UI
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Sesion.Instance.Logout();
            Application.Restart();
        }


        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesion.Instance.Logout();
            Application.Restart();
        }
    }
}
