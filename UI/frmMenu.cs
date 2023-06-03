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

        private void familiasYPatentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermisos frm = new frmPermisos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void asignarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios_roles frm = new frmUsuarios_roles();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
