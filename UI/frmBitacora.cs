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

namespace UI
{
    public partial class frmBitacora : Form
    {
        public frmBitacora()
        {
            InitializeComponent();

            _BLLBitacora = new BLLBitacora();
        }
        BLLBitacora _BLLBitacora;
        public void CargarGrilla()
        {
            grillaBitacora.DataSource = null;
            grillaBitacora.DataSource = _BLLBitacora.getAll();
        }
        private void grillaBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            

            comboCategorias.DataSource = Enum.GetValues(typeof(Categorias)); 
            CargarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string categoria = comboCategorias.Text;
            DateTime desde = dateTimePicker1.Value;
            DateTime hasta = dateTimePicker2.Value;


            grillaBitacora.DataSource = null;
            grillaBitacora.DataSource = _BLLBitacora.Buscar(categoria,desde,hasta);
        }
    }
}
