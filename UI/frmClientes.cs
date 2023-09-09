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
    public partial class frmClientes : Form
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

        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            MostrarGrilla();
        }

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
                bllCliente.BajaCliente(cliente);

                MostrarGrilla();
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
            }
            else
            {
                grillaClientes.ReadOnly = false;
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
            string nombreCliente = txtNombre.Text;

            grillaClientes.DataSource = bllCliente.BuscarCliente(nombreCliente);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarGrilla();
        }
    }
}
