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
    public partial class frmPermisos : Form
    {
        BLLPermisos BLLPermisos;
        BEComponente_compuesto seleccion;

        public frmPermisos()
        {
            InitializeComponent();
            BLLPermisos = new BLLPermisos();
            this.cboPermisos.DataSource = BLLPermisos.GetAllPermission();
        }
        void MostrarFamilia(bool init)
        {
            if (seleccion == null) return;


            IList<BEComposite> comp = null;
            if (init)
            {
                comp = BLLPermisos.GetAll("=" + seleccion.Id);


                foreach (var i in comp)
                    seleccion.AgregarHijo(i);
            }
            else
            {
                comp = seleccion.Hijos;
            }

            this.treeConfigurarFamilia.Nodes.Clear();

            TreeNode root = new TreeNode(seleccion.Nombre);
            root.Tag = seleccion;
            this.treeConfigurarFamilia.Nodes.Add(root);

            foreach (var item in comp)
            {
                MostrarEnTreeView(root, item);
            }

            treeConfigurarFamilia.ExpandAll();
        }
        private void cmdGuardarFamilia_Click(object sender, EventArgs e)
        {

        }
       
        
        private void frmPermisos_Load(object sender, EventArgs e)
        {
            LlenarPatentesFamilias();
        }
        private void LlenarPatentesFamilias()
        {

            this.cboPatentes.DataSource = BLLPermisos.GetAllPatentes();
            this.cboFamilias.DataSource = BLLPermisos.GetAllCompuestos();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarPatente_Click(object sender, EventArgs e)
        {
            BEComponenteSimple c = new BEComponenteSimple()
            {
                Nombre = this.txtNombrePatente.Text,
                Permiso = (TipoPermiso)this.cboPermisos.SelectedItem
            };
            BLLPermisos.GuardarComponente(c, false);
            LlenarPatentesFamilias();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmdAgregarPatente_Click(object sender, EventArgs e)
        {
            if (seleccion != null)
            {
                var patente = (BEComponenteSimple)cboPatentes.SelectedItem;
                if (patente != null)
                {
                    var esta = BLLPermisos.Existe(seleccion, patente.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la patente indicada");
                    else
                    {

                        {
                            seleccion.AgregarHijo(patente);
                            MostrarFamilia(false);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BEComponente_compuesto miComponente = new BEComponente_compuesto()
            {
                Nombre = this.txtNombreFamilia.Text
            };

            BLLPermisos.GuardarComponente(miComponente, true);
            LlenarPatentesFamilias();

        }
        void MostrarEnTreeView(TreeNode tn, BEComposite c)
        {
            TreeNode n = new TreeNode(c.Nombre);
            tn.Tag = c;
            tn.Nodes.Add(n);
            if (c.Hijos != null)
                foreach (var item in c.Hijos)
                {
                    MostrarEnTreeView(n, item);
                }

        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            var miComponente = (BEComponente_compuesto)this.cboFamilias.SelectedItem;
            seleccion = new BEComponente_compuesto();
            seleccion.Id = miComponente.Id;
            seleccion.Nombre = miComponente.Nombre;

            MostrarFamilia(true);
        }

        private void cmdAgregarFamilia_Click(object sender, EventArgs e)
        {
            if (seleccion != null)
            {
                var familia = (BEComponente_compuesto)cboFamilias.SelectedItem;
                if (familia != null)
                {

                    var esta = BLLPermisos.Existe(seleccion, familia.Id);
                    if (esta)
                        MessageBox.Show("ya exsite la familia indicada");
                    else
                    {

                        BLLPermisos.FillFamilyComponents(familia);
                        seleccion.AgregarHijo(familia);
                        MostrarFamilia(false);
                    }


                }
            }
        }

        private void cmdGuardarFamilia_Click_1(object sender, EventArgs e)
        {

            try
            {
                BLLPermisos.GuardarFamilia(seleccion);
                MessageBox.Show("Familia guardada correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar la familia");
            }
        }
    }
}
