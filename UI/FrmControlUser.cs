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
namespace UI
{
    public partial class FrmControlUser : Form
    {

        public FrmControlUser()
        {
            InitializeComponent();
        }
        BLLUser blluser = new BLLUser();
        BEUser beUser;
        private void FrmControlUser_Load(object sender, EventArgs e)
        {
            RefreshCombo();
        }
        private void RefreshCombo()
        {
            comboBox1.DataSource = blluser.getAllUsers();
        }
        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blluser.getLog(beUser);
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


        }

        private void button2_Click(object sender, EventArgs e)
        {
            BEUserLog log =(BEUserLog) dataGridView1.CurrentRow.DataBoundItem;
            blluser.RestaurarEstado(log);

            RefreshCombo();
        }
    }
}
