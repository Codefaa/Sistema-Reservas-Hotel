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
        enum enumIdiomas
        {
            Español,
            Ingles
        }
        private void frmIdioma_Load(object sender, EventArgs e)
        {
            comboIdiomas.DataSource = Enum.GetValues(typeof(enumIdiomas));
            comboIdiomas.Text = Sesion.Idioma.Nombre;

            sesion.RegistrarObservador(this);
            sesion.ActualizarObservadores(Sesion.Idioma);
        }
        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if(comboIdiomas.Text == "Español")
            {
                Sesion.Idioma.Id = 1;
                Sesion.Idioma.Nombre = "Español";
            }
            if(comboIdiomas.Text == "Ingles")
            {
                Sesion.Idioma.Id = 2;
                Sesion.Idioma.Nombre = "Ingles";
            }

            Sesion.Idioma = BLLunIdioma.GenerarDiccionarios(Sesion.Idioma);
            sesion.ActualizarObservadores(Sesion.Idioma);

            comboIdiomas.Text = Sesion.Idioma.Nombre;
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