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
    public partial class frmCrearIdioma : Form, IObservador
    {
        public frmCrearIdioma()
        {
            InitializeComponent();


            BEunaTraduccion = new BETraduccion();
            BEunaPalabra = new BEPalabra();

            BLLunIdioma = new BLLIdioma();
            BLLunaTraduccion = new BLLTraduccion();
            BLLunaPalabra = new BLLPalabra();
        }

        BEIdioma BEunIdioma;
        BETraduccion BEunaTraduccion;
        BEPalabra BEunaPalabra;

        BLLIdioma BLLunIdioma;
        BLLTraduccion BLLunaTraduccion;
        BLLPalabra BLLunaPalabra;

        void CargarTotalLabels()
        {
            List<BEPalabra> listPalabras = BLLunaPalabra.LeerPalabras();
            List<BETraduccion> listTraducciones = BLLunaTraduccion.LeerTraducciones(BEunaTraduccion);

            if(listPalabras != null)
            {
                lbNumeroPalabras.Text = listPalabras.Count.ToString();
            }
            else
            {
                lbNumeroPalabras.Text = "0";
            }
            if(listTraducciones != null)
            {
                lbNumeroTraducciones.Text = listTraducciones.Count.ToString();
            }
            else
            {
                lbNumeroTraducciones.Text = "0";
            }
        }
        void CargarGrillaPalabras()
        {
            grillaPalabras.DataSource = null;
            grillaPalabras.DataSource = BLLunaPalabra.LeerPalabras();

            int columnIndex = 1;
            int newWidth = 200;
            grillaPalabras.Columns[columnIndex].Width = newWidth;

        }
        void CargarGrillaTraducciones()
        {
            grillaTraducciones.DataSource = null;
            grillaTraducciones.DataSource = BLLunaTraduccion.LeerTraducciones(BEunaTraduccion);

            if(grillaTraducciones.Rows.Count > 0)
            {
                string columnName = "Palabra";
                string columnName2 = "Idioma";
                DataGridViewColumn columnToRemove = grillaTraducciones.Columns[columnName];
                grillaTraducciones.Columns.Remove(columnToRemove);
                DataGridViewColumn columnToRemove2 = grillaTraducciones.Columns[columnName2];
                grillaTraducciones.Columns.Remove(columnToRemove2);
                int columnIndex = 0; 
                int newWidth = 200; 
                grillaTraducciones.Columns[columnIndex].Width = newWidth;
            }
            else
            {
                grillaTraducciones.DataSource = null;
            }
        }
        void CargarGrillaIdiomas()
        {
            grillaIdiomas.DataSource = null;
            grillaIdiomas.DataSource = BLLunIdioma.LeerIdiomas();
        }
        void CargarComboIdiomas()
        {
            comboIdiomas.DataSource = null;
            comboIdiomas.DataSource = BLLunIdioma.LeerIdiomas();

            comboIdiomas.DisplayMember = "Nombre";
            comboIdiomas.ValueMember = "Id";
            comboIdiomas.Refresh();
        }
        private void comboIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BEunaTraduccion.Idioma = (BEIdioma)comboIdiomas.SelectedItem;

            if(BEunaTraduccion.Idioma != null)
            {
                CargarGrillaTraducciones();
                lbPalabraa.Text = string.Empty;
                CargarTotalLabels();
            }
        }
        private void grillaPalabras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BEunaPalabra = (BEPalabra)grillaPalabras.CurrentRow.DataBoundItem;

            txtPalabra.Text = BEunaPalabra.Texto;
        }
        private void grillaTraducciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BEunaTraduccion = (BETraduccion)grillaTraducciones.CurrentRow.DataBoundItem;

            txtTraduccion.Text = BEunaTraduccion.PalabraTraducida;
            lbPalabraa.Text = BEunaTraduccion.Palabra.Texto.ToString();
        }
        private void grillaIdiomas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BEunIdioma = (BEIdioma)grillaIdiomas.CurrentRow.DataBoundItem;

            txtNombre.Text = BEunIdioma.Nombre;
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                BEunaTraduccion.Palabra = BEunaPalabra;
                BEunaTraduccion.PalabraTraducida = txtTraduccion.Text;

                BLLunaTraduccion.AltaTraduccion(BEunaTraduccion);

                CargarGrillaTraducciones();
                CargarTotalLabels();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR - La traduccion de la palabra ya existe");
            }
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                BLLunaTraduccion.BorrarTraduccion(BEunaTraduccion);

                CargarGrillaTraducciones();
                CargarTotalLabels();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                BEunaTraduccion.PalabraTraducida = txtTraduccion.Text;

                BLLunaTraduccion.ModificarTraduccion(BEunaTraduccion);

                CargarGrillaTraducciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void InsertarBitacora(string categoria, string texto)
        {
            BLLBitacora BLLunaBitacora = new BLLBitacora();
            Sesion sesion = Sesion.Instance;
            IUser user = sesion.DevolverUsuario();
            BLLunaBitacora.insertBitacora(user.Usuario, categoria, texto);
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                BEunIdioma = new BEIdioma(txtNombre.Text);

                BLLunIdioma.AltaIdioma(BEunIdioma);

                CargarGrillaIdiomas();
                CargarComboIdiomas();

                #region Bitacora 
                InsertarBitacora("Idioma", "Crear Idioma");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnBajaIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                BEunaTraduccion.Idioma = (BEIdioma)grillaIdiomas.CurrentRow.DataBoundItem;
                List<BETraduccion> listTraducciones = BLLunaTraduccion.LeerTraducciones(BEunaTraduccion);
                if (listTraducciones == null)
                {
                    BLLunIdioma.BajaIdioma(BEunIdioma);

                    CargarGrillaIdiomas();
                    CargarComboIdiomas();

                    #region Bitacora 
                    InsertarBitacora("Idioma", "Borrar Idioma");
                    #endregion
                }
                else
                {
                    MessageBox.Show("No se puede borrar un idioma con traducciones ya echas");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                BEunIdioma.Nombre = txtNombre.Text; 

                BLLunIdioma.ModificarIdioma(BEunIdioma);

                CargarGrillaIdiomas();
                CargarComboIdiomas();

                #region Bitacora 
                InsertarBitacora("Idioma", "Modificar Idioma");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region Idioma

        Sesion sesion = Sesion.Instance;
        private void frmCrearIdioma_Load(object sender, EventArgs e)
        {
            CargarGrillaPalabras();
            CargarComboIdiomas();
            CargarGrillaIdiomas();

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
                if (groupBox2.Controls.Count > 0)
                {
                    foreach (Control item2 in groupBox2.Controls)
                    {
                        item2.Text = idiomaObservado.BuscarTraduccion(item2.Tag.ToString());
                    }
                }
            }
        }

        #endregion
    }
}