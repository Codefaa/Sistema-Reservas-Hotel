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
using Servicios;
using BLL;
using BE;
namespace UI
{
    public partial class frmUsuarios_roles : Form, IObservador
    {
        BLLPermisos bllPermisos;
        BLLUser bllUser;
        BEUser seleccion;
        BEUser tmp = new BEUser();

        public frmUsuarios_roles()
        {
            InitializeComponent();

            bllUser = new BLLUser();
            bllPermisos = new BLLPermisos();

            this.cboUsuarios.DataSource = bllUser.getAllUsers();
            this.cboFamilias.DataSource = bllPermisos.GetAllCompuestos();
            this.cboPatentes.DataSource = bllPermisos.GetAllPatentes();
        }

        void LlenarTreeView(TreeNode padre, BEComposite c)
        {
            TreeNode hijo = new TreeNode(c.Nombre);
            hijo.Tag = c;
            padre.Nodes.Add(hijo);

            foreach (var item in c.Hijos)
            {
                LlenarTreeView(hijo, item);
            }


        }
        void MostrarPermisos(BEUser u)
        {
            this.treeView1.Nodes.Clear();
            TreeNode root = new TreeNode(u.Usuario);

            foreach (var item in u.Permisos)
            {
                LlenarTreeView(root, item);
            }

            this.treeView1.Nodes.Add(root);
            this.treeView1.ExpandAll();
        }
        private void cmdConfigurar_Click(object sender, EventArgs e)
        {
            seleccion = (BEUser)this.cboUsuarios.SelectedItem;

            tmp = new BEUser();
            tmp.id = seleccion.id;
            tmp.Usuario= seleccion.Usuario;
            bllPermisos.FillUserComponents(tmp);

            MostrarPermisos(tmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tmp != null)
            {
                var patente = (BEComponenteSimple)cboPatentes.SelectedItem;
                if (patente != null)
                {
                    var esta = false;

                    foreach (var item in tmp.Permisos)
                    {
                        if (bllPermisos.Existe(item, patente.Id))
                        {
                            esta = true;
                            break;
                        }
                    }
                    if (esta)
                        MessageBox.Show("El usuario ya tiene la patente indicada");
                    else
                    {
                        {
                            tmp.Permisos.Add(patente);
                            MostrarPermisos(tmp);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tmp != null)
            {
                var flia = (BEComponente_compuesto)cboFamilias.SelectedItem;
                if (flia != null)
                {
                    var esta = false;
                    foreach (var item in tmp.Permisos)
                    {
                        if (bllPermisos.Existe(item, flia.Id))
                        {
                            esta = true;
                        }
                    }

                    if (esta)
                        MessageBox.Show("El usuario ya tiene la familia indicada");
                    else
                    {
                        {
                            bllPermisos.FillFamilyComponents(flia);

                            tmp.Permisos.Add(flia);
                            MostrarPermisos(tmp);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Seleccione un usuario");
        }

        private void cmdGuardarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                bllUser.GuardarPermisos(tmp);
                MessageBox.Show("Usuario guardado correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar el usuario");
            }
        }


        #region Idioma 
        Sesion sesion = Sesion.Instance;
        private void frmUsuarios_roles_Load(object sender, EventArgs e)
        {
            sesion.RegistrarObservador(this);
            sesion.ActualizarObservadores(Sesion.Idioma);
        }

        public void Actualizar(IIdioma idiomaObservado)
        {
            foreach (Control item in this.Controls)
            {
                item.Text = idiomaObservado.BuscarTraduccion(item.Tag.ToString());

                if (grpPatentes.Controls.Count > 0)
                {
                    foreach (Control item2 in grpPatentes.Controls)
                    {
                        item2.Text = idiomaObservado.BuscarTraduccion(item2.Tag.ToString());
                    }
                }
            }
        }
        #endregion
    }
}
