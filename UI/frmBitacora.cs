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
using Servicios;

namespace UI
{
    public partial class frmBitacora : Form, IObservador
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string categoria = comboCategorias.Text;
            DateTime desde = dateTimePicker1.Value;
            DateTime hasta = dateTimePicker2.Value;

            grillaBitacora.DataSource = null;
            grillaBitacora.DataSource = _BLLBitacora.Buscar(categoria,desde,hasta);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }


        #region Idioma

        Sesion sesion = Sesion.Instance;
        private void frmBitacora_Load(object sender, EventArgs e)
        {
            comboCategorias.DataSource = Enum.GetValues(typeof(TipoCategorias));
            CargarGrilla();

            sesion.RegistrarObservador(this);
            sesion.ActualizarObservadores(Sesion.Idioma);
        }

        public void Actualizar(IIdioma idiomaObservado)
        {
            foreach (Control item in this.Controls)
            {
                item.Text = idiomaObservado.BuscarTraduccion(item.Tag.ToString());

                if (groupBox1.Controls.Count > 0)
                {
                    foreach (Control item2 in groupBox1.Controls)
                    {
                        item2.Text = idiomaObservado.BuscarTraduccion(item2.Tag.ToString());
                    }
                }
            }
        }
        #endregion
    }
}
