using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            comboPermisos.DataSource = null;
        }
        
        private void frmPermisos_Load(object sender, EventArgs e)
        {

        }
    }
}
