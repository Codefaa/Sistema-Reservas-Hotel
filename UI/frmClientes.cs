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
    public partial class frmClientes : Form, IObservador
    {
        public frmClientes()
        {
            InitializeComponent();

            cliente = new BECliente();
            bllCliente = new BLLCliente();
        }

        BECliente cliente;
        BLLCliente bllCliente;
        public void MostrarGrilla()
        {
            grillaClientes.DataSource = null;
            grillaClientes.DataSource = bllCliente.LeerClientes();
        }

        public void MostrarGrillaFormulario(List<BECliente> clientes)
        {
            grillaClientes.DataSource = null;
            grillaClientes.DataSource = clientes;
        }


        #region Idioma

        Sesion sesion = Sesion.Instance;
        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            MostrarGrilla();

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


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCliente abrir = new frmCliente();
            abrir.Show();
            this.Close();
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if(cliente != null)
                {
                    bllCliente.BajaCliente(cliente);

                    MostrarGrilla();
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR - El cliente tiene una RESERVA");
                MessageBox.Show(ex.Message);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!grillaClientes.ReadOnly)
            {
                grillaClientes.ReadOnly = true;
                btnModificar.BackColor = Color.White;
            }
            else
            {
                grillaClientes.ReadOnly = false;
                btnModificar.BackColor = Color.Red;
            }
        }

        private void grillaClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bllCliente.ModificarCliente(cliente);
        }

        private void grillaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cliente = (BECliente)grillaClientes.CurrentRow.DataBoundItem;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreCliente = txtNombre.Text;

                grillaClientes.DataSource = bllCliente.BuscarCliente(nombreCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarGrilla();
        }
    }
}
