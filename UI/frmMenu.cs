using Abstraccion;
using BLL;
using Servicios;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmMenu : Form, IObservador
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sesion.Instance.Logout();
            //Application.Restart();
        }
        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacora abrir = new frmBitacora();
            abrir.MdiParent = this;
            abrir.Show();
        }
        private void familiasYPatentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermisos frm = new frmPermisos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void asignarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuariosRoles frm = new frmUsuariosRoles();
            frm.MdiParent = this;
            frm.Show();
        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIdioma frm = new frmIdioma();
            frm.MdiParent = this;
            frm.Show();
        }
        private void crearIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrearIdioma frm = new frmCrearIdioma();
            frm.MdiParent = this;
            frm.Show();
        }

        private void controlDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmControlUser frm = new frmControlUser();
            frm.MdiParent = this;
            frm.Show();
        }


        #region Idioma

        Sesion sesion = Sesion.Instance;
        private void frmMenu_Load(object sender, EventArgs e)
        {
            BLLUser bllU = new BLLUser();
            if (bllU.validarDigito())
            {
                BLLIdioma BLLunIdioma = new BLLIdioma();
                Sesion.Idioma = BLLunIdioma.GenerarDiccionarios(Sesion.Idioma);
                sesion.RegistrarObservador(this);
                sesion.ActualizarObservadores(Sesion.Idioma);
            }
            else
            {

            }

        }
        public void Actualizar(IIdioma idiomaObservado)
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                ActualizarItem(item, idiomaObservado);
            }
        }

        public void ActualizarItem(ToolStripMenuItem item, IIdioma idiomaObservado)
        {
            if (item.Tag != null)
            {
                item.Text = idiomaObservado.BuscarTraduccion(item.Tag.ToString());
            }
            foreach (ToolStripDropDownItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem)
                {
                    ActualizarItem((ToolStripMenuItem)subItem, idiomaObservado);
                }
            }
        }

        #endregion

        private void recepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecepcion abrir = new frmRecepcion();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes abrir = new frmClientes();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHabitaciones abrir = new frmHabitaciones();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportes abrir = new frmReportes();
            abrir.MdiParent = this;
            abrir.Show();
        }
    }
}