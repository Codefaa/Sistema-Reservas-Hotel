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

namespace UI
{
    public partial class frmPermisos : Form
    {
        public frmPermisos()
        {
            InitializeComponent();
        }

        private void cmdGuardarFamilia_Click(object sender, EventArgs e)
        {

        }
        private void cargarCOmbosPermisos()
        {
            BLLComponentes BLLunComponente = new BLLComponentes();
            comboPermisos.DataSource = null;
            comboPermisos.DataSource = BLLunComponente.getRoles();

            comboPermisos.ValueMember = "Id";
            comboPermisos.DisplayMember = "Nombre";
            comboPermisos.Refresh();
        }
        
        private void frmPermisos_Load(object sender, EventArgs e)
        {
            cargarCOmbosPermisos();
        }
    }
}
