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
using BE;
using BLL;
using Servicios;

namespace UI
{
    public partial class frmControlUser : Form, IObservador
    {

        public frmControlUser()
        {
            InitializeComponent();
        }
        BLLUser blluser = new BLLUser();
        BEUser beUser;

        private void RefreshCombo()
        {
            comboBox1.DataSource = blluser.getAllUsers();
        }
        private void RefreshGrid()
        {
            grillaControlUsuarios.DataSource = null;
            grillaControlUsuarios.DataSource = blluser.getLog(beUser);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != null && txtDni.Text != null)
            {
                beUser.Usuario = txtUsername.Text;
                beUser.DNI = Convert.ToInt32(txtDni.Text);
                blluser.Modificar(beUser);
                RefreshCombo();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            beUser =(BEUser) comboBox1.SelectedItem;
            txtUsername.Text = beUser.Usuario;
            txtDni.Text = beUser.DNI.ToString();
            RefreshGrid();

            txtEmail.Text = beUser.Email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BEUserLog log =(BEUserLog) grillaControlUsuarios.CurrentRow.DataBoundItem;
            blluser.RestaurarEstado(log);

            RefreshCombo();
        }


        #region Idioma

        Sesion sesion = Sesion.Instance;
        private void FrmControlUser_Load(object sender, EventArgs e)
        {
            sesion.RegistrarObservador(this);
            sesion.ActualizarObservadores(Sesion.Idioma);

            RefreshCombo();
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
