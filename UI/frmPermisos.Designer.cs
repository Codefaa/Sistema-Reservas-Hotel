
namespace UI
{
    partial class frmPermisos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupPatentes = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardarPatente = new System.Windows.Forms.Button();
            this.cmdAgregarPatente = new System.Windows.Forms.Button();
            this.cboPatentes = new System.Windows.Forms.ComboBox();
            this.txtNombrePatente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPermisos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupConfigurarFamilias = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdGuardarFamilia = new System.Windows.Forms.Button();
            this.treeConfigurarFamilia = new System.Windows.Forms.TreeView();
            this.groupFamilias = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            this.cmdAgregarFamilia = new System.Windows.Forms.Button();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFamilias = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupPatentes.SuspendLayout();
            this.groupConfigurarFamilias.SuspendLayout();
            this.groupFamilias.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPatentes
            // 
            this.groupPatentes.Controls.Add(this.label6);
            this.groupPatentes.Controls.Add(this.btnGuardarPatente);
            this.groupPatentes.Controls.Add(this.cmdAgregarPatente);
            this.groupPatentes.Controls.Add(this.cboPatentes);
            this.groupPatentes.Controls.Add(this.txtNombrePatente);
            this.groupPatentes.Controls.Add(this.label1);
            this.groupPatentes.Controls.Add(this.cboPermisos);
            this.groupPatentes.Controls.Add(this.label3);
            this.groupPatentes.Controls.Add(this.label2);
            this.groupPatentes.Location = new System.Drawing.Point(11, 11);
            this.groupPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.groupPatentes.Name = "groupPatentes";
            this.groupPatentes.Padding = new System.Windows.Forms.Padding(2);
            this.groupPatentes.Size = new System.Drawing.Size(258, 280);
            this.groupPatentes.TabIndex = 7;
            this.groupPatentes.TabStop = false;
            this.groupPatentes.Tag = "GroupPatentes";
            this.groupPatentes.Text = "Patentes";
            this.groupPatentes.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 12;
            this.label6.Tag = "lbCrearnuevapatente";
            this.label6.Text = "Crear nueva patente";
            // 
            // btnGuardarPatente
            // 
            this.btnGuardarPatente.Location = new System.Drawing.Point(19, 254);
            this.btnGuardarPatente.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarPatente.Name = "btnGuardarPatente";
            this.btnGuardarPatente.Size = new System.Drawing.Size(56, 23);
            this.btnGuardarPatente.TabIndex = 4;
            this.btnGuardarPatente.Tag = "Guardar";
            this.btnGuardarPatente.Text = "Guardar";
            this.btnGuardarPatente.UseVisualStyleBackColor = true;
            this.btnGuardarPatente.Click += new System.EventHandler(this.btnGuardarPatente_Click);
            // 
            // cmdAgregarPatente
            // 
            this.cmdAgregarPatente.Location = new System.Drawing.Point(19, 64);
            this.cmdAgregarPatente.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAgregarPatente.Name = "cmdAgregarPatente";
            this.cmdAgregarPatente.Size = new System.Drawing.Size(98, 23);
            this.cmdAgregarPatente.TabIndex = 11;
            this.cmdAgregarPatente.Tag = "Agregar";
            this.cmdAgregarPatente.Text = "Agregar ";
            this.cmdAgregarPatente.UseVisualStyleBackColor = true;
            this.cmdAgregarPatente.Click += new System.EventHandler(this.cmdAgregarPatente_Click);
            // 
            // cboPatentes
            // 
            this.cboPatentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatentes.FormattingEnabled = true;
            this.cboPatentes.Location = new System.Drawing.Point(19, 39);
            this.cboPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.cboPatentes.Name = "cboPatentes";
            this.cboPatentes.Size = new System.Drawing.Size(234, 21);
            this.cboPatentes.TabIndex = 10;
            this.cboPatentes.Tag = "comboPatentes";
            // 
            // txtNombrePatente
            // 
            this.txtNombrePatente.Location = new System.Drawing.Point(19, 230);
            this.txtNombrePatente.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombrePatente.Name = "txtNombrePatente";
            this.txtNombrePatente.Size = new System.Drawing.Size(174, 20);
            this.txtNombrePatente.TabIndex = 3;
            this.txtNombrePatente.Tag = "txtNombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 9;
            this.label1.Tag = "Todaslaspatentes";
            this.label1.Text = "Todas las patentes";
            // 
            // cboPermisos
            // 
            this.cboPermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPermisos.FormattingEnabled = true;
            this.cboPermisos.Location = new System.Drawing.Point(19, 182);
            this.cboPermisos.Margin = new System.Windows.Forms.Padding(2);
            this.cboPermisos.Name = "cboPermisos";
            this.cboPermisos.Size = new System.Drawing.Size(174, 21);
            this.cboPermisos.TabIndex = 1;
            this.cboPermisos.Tag = "comboPermisos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Tag = "NombrePatente";
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Tag = "Permiso";
            this.label2.Text = "Permiso";
            // 
            // groupConfigurarFamilias
            // 
            this.groupConfigurarFamilias.Controls.Add(this.button2);
            this.groupConfigurarFamilias.Controls.Add(this.cmdGuardarFamilia);
            this.groupConfigurarFamilias.Controls.Add(this.treeConfigurarFamilia);
            this.groupConfigurarFamilias.Location = new System.Drawing.Point(559, 11);
            this.groupConfigurarFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.groupConfigurarFamilias.Name = "groupConfigurarFamilias";
            this.groupConfigurarFamilias.Padding = new System.Windows.Forms.Padding(2);
            this.groupConfigurarFamilias.Size = new System.Drawing.Size(290, 280);
            this.groupConfigurarFamilias.TabIndex = 13;
            this.groupConfigurarFamilias.TabStop = false;
            this.groupConfigurarFamilias.Tag = "GroupConfigurarFamilia";
            this.groupConfigurarFamilias.Text = "Configurar familia";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(163, 250);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 2;
            this.button2.Tag = "btnSacarNodo";
            this.button2.Text = "Sacar nodo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdGuardarFamilia
            // 
            this.cmdGuardarFamilia.Location = new System.Drawing.Point(11, 250);
            this.cmdGuardarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.cmdGuardarFamilia.Name = "cmdGuardarFamilia";
            this.cmdGuardarFamilia.Size = new System.Drawing.Size(110, 23);
            this.cmdGuardarFamilia.TabIndex = 1;
            this.cmdGuardarFamilia.Tag = "btnGuardarFamilia";
            this.cmdGuardarFamilia.Text = "Guardar familia";
            this.cmdGuardarFamilia.UseVisualStyleBackColor = true;
            this.cmdGuardarFamilia.Click += new System.EventHandler(this.cmdGuardarFamilia_Click_1);
            // 
            // treeConfigurarFamilia
            // 
            this.treeConfigurarFamilia.Location = new System.Drawing.Point(11, 23);
            this.treeConfigurarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.treeConfigurarFamilia.Name = "treeConfigurarFamilia";
            this.treeConfigurarFamilia.Size = new System.Drawing.Size(262, 223);
            this.treeConfigurarFamilia.TabIndex = 0;
            this.treeConfigurarFamilia.Tag = "listFamilias";
            this.treeConfigurarFamilia.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeConfigurarFamilia_AfterSelect);
            // 
            // groupFamilias
            // 
            this.groupFamilias.Controls.Add(this.label7);
            this.groupFamilias.Controls.Add(this.button1);
            this.groupFamilias.Controls.Add(this.cmdSeleccionar);
            this.groupFamilias.Controls.Add(this.cmdAgregarFamilia);
            this.groupFamilias.Controls.Add(this.txtNombreFamilia);
            this.groupFamilias.Controls.Add(this.label5);
            this.groupFamilias.Controls.Add(this.cboFamilias);
            this.groupFamilias.Controls.Add(this.label4);
            this.groupFamilias.Location = new System.Drawing.Point(288, 11);
            this.groupFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.groupFamilias.Name = "groupFamilias";
            this.groupFamilias.Padding = new System.Windows.Forms.Padding(2);
            this.groupFamilias.Size = new System.Drawing.Size(258, 280);
            this.groupFamilias.TabIndex = 12;
            this.groupFamilias.TabStop = false;
            this.groupFamilias.Tag = "GroupFamilias";
            this.groupFamilias.Text = "Familias";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 13;
            this.label7.Tag = "lbCrearNuevaFamilia";
            this.label7.Text = "Crear nueva familia";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 207);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 4;
            this.button1.Tag = "btnGuardar";
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.Location = new System.Drawing.Point(14, 63);
            this.cmdSeleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(98, 23);
            this.cmdSeleccionar.TabIndex = 11;
            this.cmdSeleccionar.Tag = "btnConfigurar";
            this.cmdSeleccionar.Text = "Configurar";
            this.cmdSeleccionar.UseVisualStyleBackColor = true;
            this.cmdSeleccionar.Click += new System.EventHandler(this.cmdSeleccionar_Click);
            // 
            // cmdAgregarFamilia
            // 
            this.cmdAgregarFamilia.Location = new System.Drawing.Point(117, 63);
            this.cmdAgregarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAgregarFamilia.Name = "cmdAgregarFamilia";
            this.cmdAgregarFamilia.Size = new System.Drawing.Size(98, 23);
            this.cmdAgregarFamilia.TabIndex = 10;
            this.cmdAgregarFamilia.Tag = "btnAgregar";
            this.cmdAgregarFamilia.Text = "Agregar ";
            this.cmdAgregarFamilia.UseVisualStyleBackColor = true;
            this.cmdAgregarFamilia.Click += new System.EventHandler(this.cmdAgregarFamilia_Click);
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(16, 183);
            this.txtNombreFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(174, 20);
            this.txtNombreFamilia.TabIndex = 3;
            this.txtNombreFamilia.Tag = "txtNombreFamilia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 166);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Tag = "lbNombrefamilia";
            this.label5.Text = "Nombre";
            // 
            // cboFamilias
            // 
            this.cboFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilias.FormattingEnabled = true;
            this.cboFamilias.Location = new System.Drawing.Point(15, 39);
            this.cboFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.cboFamilias.Name = "cboFamilias";
            this.cboFamilias.Size = new System.Drawing.Size(234, 21);
            this.cboFamilias.TabIndex = 8;
            this.cboFamilias.Tag = "comboFamilias";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 7;
            this.label4.Tag = "lbTodaslasFamilias";
            this.label4.Text = "Todas las familias";
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 308);
            this.Controls.Add(this.groupConfigurarFamilias);
            this.Controls.Add(this.groupFamilias);
            this.Controls.Add(this.groupPatentes);
            this.Name = "frmPermisos";
            this.Text = "frmPermisos";
            this.Load += new System.EventHandler(this.frmPermisos_Load);
            this.groupPatentes.ResumeLayout(false);
            this.groupPatentes.PerformLayout();
            this.groupConfigurarFamilias.ResumeLayout(false);
            this.groupFamilias.ResumeLayout(false);
            this.groupFamilias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupPatentes;
        private System.Windows.Forms.Button btnGuardarPatente;
        private System.Windows.Forms.TextBox txtNombrePatente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPermisos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAgregarPatente;
        private System.Windows.Forms.ComboBox cboPatentes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupConfigurarFamilias;
        private System.Windows.Forms.Button cmdGuardarFamilia;
        private System.Windows.Forms.TreeView treeConfigurarFamilia;
        private System.Windows.Forms.GroupBox groupFamilias;
        private System.Windows.Forms.Button cmdSeleccionar;
        private System.Windows.Forms.Button cmdAgregarFamilia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFamilias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
    }
}