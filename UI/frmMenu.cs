using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Abstraccion;
using Servicios;
using BE;
using BLL;

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
            Sesion.Instance.Logout();
            Application.Restart();
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
            frmUsuarios_roles frm = new frmUsuarios_roles();
            frm.MdiParent = this;
            frm.Show();
        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIdioma frm = new frmIdioma();
            frm.MdiParent = this;
            frm.Show();
        }


        #region Idioma

        Sesion sesion = Sesion.Instance;
        private void frmMenu_Load(object sender, EventArgs e)
        {
            BLLUser bllU = new BLLUser();
            if (bllU.validarDigito()) {
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
            item.Text = idiomaObservado.BuscarTraduccion(item.Tag.ToString());

            foreach (ToolStripDropDownItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem)
                {
                    ActualizarItem((ToolStripMenuItem)subItem, idiomaObservado);
                }
            }
        }
        #endregion
    }
}