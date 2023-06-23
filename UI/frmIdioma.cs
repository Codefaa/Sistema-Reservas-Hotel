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
using Abstraccion;
using BE;
using BLL;

namespace UI
{
    public partial class frmIdioma : Form, IObservador
    {
        public frmIdioma()
        {
            InitializeComponent();

            BLLunIdioma = new BLLIdioma();
        }

        BLLIdioma BLLunIdioma;
        Sesion sesion = Sesion.Instance;

        void CargarComboIdioma()
        {
            comboIdiomas.DataSource = null;
            comboIdiomas.DataSource = BLLunIdioma.LeerIdiomas();

            comboIdiomas.DisplayMember = "Nombre";
            comboIdiomas.ValueMember = "Id";
            comboIdiomas.Refresh();
        }
        private void frmIdioma_Load(object sender, EventArgs e)
        {
            CargarComboIdioma();

            sesion.RegistrarObservador(this);
            sesion.ActualizarObservadores(Sesion.Idioma);
        }
        private void btnCambiar_Click(object sender, EventArgs e)
        {
            Sesion.Idioma = (BEIdioma)comboIdiomas.SelectedItem;

            Sesion.Idioma = BLLunIdioma.GenerarDiccionarios(Sesion.Idioma);

            if(Sesion.Idioma != null)
            {
                BLLBitacora BLLunaBitacora = new BLLBitacora();
                Sesion sesion = Sesion.Instance;
                IUser user = sesion.DevolverUsuario();

                BLLunaBitacora.insertBitacora(user.Usuario, "Idioma", "Cambiar idioma");

                sesion.ActualizarObservadores(Sesion.Idioma);

                comboIdiomas.Text = Sesion.Idioma.Nombre;
            }
            else
            {
                MessageBox.Show("ERROR - Falta completar las 53 traducciones de las palabras");
            }
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
    }
}