
namespace UI
{
    partial class frmCrearIdioma
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grillaIdiomas = new System.Windows.Forms.DataGridView();
            this.btnModificarIdioma = new System.Windows.Forms.Button();
            this.btnBajaIdioma = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtTraduccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPalabra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.grillaPalabras = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboIdiomas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grillaTraducciones = new System.Windows.Forms.DataGridView();
            this.lbPalabras = new System.Windows.Forms.Label();
            this.lbTraducciones = new System.Windows.Forms.Label();
            this.lbNumeroPalabras = new System.Windows.Forms.Label();
            this.lbNumeroTraducciones = new System.Windows.Forms.Label();
            this.lbPalabraTraducida = new System.Windows.Forms.Label();
            this.lbPalabraa = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaIdiomas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPalabras)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTraducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grillaIdiomas);
            this.groupBox1.Controls.Add(this.btnModificarIdioma);
            this.groupBox1.Controls.Add(this.btnBajaIdioma);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "groupCrearNuevoIdioma";
            this.groupBox1.Text = "Crear nuevo idioma";
            // 
            // grillaIdiomas
            // 
            this.grillaIdiomas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaIdiomas.Location = new System.Drawing.Point(25, 65);
            this.grillaIdiomas.Name = "grillaIdiomas";
            this.grillaIdiomas.ReadOnly = true;
            this.grillaIdiomas.Size = new System.Drawing.Size(254, 124);
            this.grillaIdiomas.TabIndex = 9;
            this.grillaIdiomas.Tag = "grillaIdiomas";
            this.grillaIdiomas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaIdiomas_CellContentClick);
            // 
            // btnModificarIdioma
            // 
            this.btnModificarIdioma.Location = new System.Drawing.Point(203, 195);
            this.btnModificarIdioma.Name = "btnModificarIdioma";
            this.btnModificarIdioma.Size = new System.Drawing.Size(75, 23);
            this.btnModificarIdioma.TabIndex = 8;
            this.btnModificarIdioma.Tag = "btnModificarIdioma";
            this.btnModificarIdioma.Text = "Modificar";
            this.btnModificarIdioma.UseVisualStyleBackColor = true;
            this.btnModificarIdioma.Click += new System.EventHandler(this.btnModificarIdioma_Click);
            // 
            // btnBajaIdioma
            // 
            this.btnBajaIdioma.Location = new System.Drawing.Point(113, 195);
            this.btnBajaIdioma.Name = "btnBajaIdioma";
            this.btnBajaIdioma.Size = new System.Drawing.Size(75, 23);
            this.btnBajaIdioma.TabIndex = 7;
            this.btnBajaIdioma.Tag = "btnBajaIdioma";
            this.btnBajaIdioma.Text = "Baja";
            this.btnBajaIdioma.UseVisualStyleBackColor = true;
            this.btnBajaIdioma.Click += new System.EventHandler(this.btnBajaIdioma_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(94, 34);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(185, 20);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.Tag = "txtNombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Tag = "lbNombre";
            this.label1.Text = "Nombre";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(24, 195);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 6;
            this.btnCrear.Tag = "btnCrearNuevoIdioma";
            this.btnCrear.Text = "Alta";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtTraduccion
            // 
            this.txtTraduccion.Location = new System.Drawing.Point(93, 133);
            this.txtTraduccion.Name = "txtTraduccion";
            this.txtTraduccion.Size = new System.Drawing.Size(185, 20);
            this.txtTraduccion.TabIndex = 9;
            this.txtTraduccion.Tag = "txtTraduccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Tag = "lbTraduccion";
            this.label3.Text = "Traduccion";
            // 
            // txtPalabra
            // 
            this.txtPalabra.Enabled = false;
            this.txtPalabra.Location = new System.Drawing.Point(93, 86);
            this.txtPalabra.Name = "txtPalabra";
            this.txtPalabra.Size = new System.Drawing.Size(185, 20);
            this.txtPalabra.TabIndex = 7;
            this.txtPalabra.Tag = "txtPalabra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Tag = "lbPalabra";
            this.label2.Text = "Palabra";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(203, 176);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Tag = "btnModificar";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(24, 176);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 2;
            this.btnAlta.Tag = "btnAlta";
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(113, 176);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 3;
            this.btnBaja.Tag = "btnBorrar";
            this.btnBaja.Text = "Borrar";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // grillaPalabras
            // 
            this.grillaPalabras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaPalabras.Location = new System.Drawing.Point(330, 47);
            this.grillaPalabras.Name = "grillaPalabras";
            this.grillaPalabras.ReadOnly = true;
            this.grillaPalabras.Size = new System.Drawing.Size(300, 407);
            this.grillaPalabras.TabIndex = 7;
            this.grillaPalabras.Tag = "grillaPalabras";
            this.grillaPalabras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaPalabras_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboIdiomas);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPalabra);
            this.groupBox2.Controls.Add(this.txtTraduccion);
            this.groupBox2.Controls.Add(this.btnAlta);
            this.groupBox2.Controls.Add(this.btnBaja);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnModificar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 211);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "groupIdiomaDesarrollar";
            this.groupBox2.Text = "Idioma a desarrollar";
            // 
            // comboIdiomas
            // 
            this.comboIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIdiomas.FormattingEnabled = true;
            this.comboIdiomas.Location = new System.Drawing.Point(93, 39);
            this.comboIdiomas.Name = "comboIdiomas";
            this.comboIdiomas.Size = new System.Drawing.Size(185, 21);
            this.comboIdiomas.TabIndex = 10;
            this.comboIdiomas.Tag = "comboIdioma";
            this.comboIdiomas.SelectedIndexChanged += new System.EventHandler(this.comboIdiomas_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Tag = "lbIdioma";
            this.label4.Text = "Idioma";
            // 
            // grillaTraducciones
            // 
            this.grillaTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTraducciones.Location = new System.Drawing.Point(656, 47);
            this.grillaTraducciones.Name = "grillaTraducciones";
            this.grillaTraducciones.ReadOnly = true;
            this.grillaTraducciones.Size = new System.Drawing.Size(228, 386);
            this.grillaTraducciones.TabIndex = 11;
            this.grillaTraducciones.Tag = "grillaPalabras";
            this.grillaTraducciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaTraducciones_CellContentClick);
            // 
            // lbPalabras
            // 
            this.lbPalabras.AutoSize = true;
            this.lbPalabras.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPalabras.Location = new System.Drawing.Point(379, 13);
            this.lbPalabras.Name = "lbPalabras";
            this.lbPalabras.Size = new System.Drawing.Size(156, 18);
            this.lbPalabras.TabIndex = 12;
            this.lbPalabras.Tag = "lbTodaslaspalabras";
            this.lbPalabras.Text = "Todas las palabras:";
            // 
            // lbTraducciones
            // 
            this.lbTraducciones.AutoSize = true;
            this.lbTraducciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTraducciones.Location = new System.Drawing.Point(664, 13);
            this.lbTraducciones.Name = "lbTraducciones";
            this.lbTraducciones.Size = new System.Drawing.Size(189, 18);
            this.lbTraducciones.TabIndex = 13;
            this.lbTraducciones.Tag = "lbTodasLasTraducciones";
            this.lbTraducciones.Text = "Todas las traducciones:";
            // 
            // lbNumeroPalabras
            // 
            this.lbNumeroPalabras.AutoSize = true;
            this.lbNumeroPalabras.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumeroPalabras.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbNumeroPalabras.Location = new System.Drawing.Point(543, 13);
            this.lbNumeroPalabras.Name = "lbNumeroPalabras";
            this.lbNumeroPalabras.Size = new System.Drawing.Size(0, 18);
            this.lbNumeroPalabras.TabIndex = 14;
            this.lbNumeroPalabras.Tag = "lbNumeroPalabras";
            // 
            // lbNumeroTraducciones
            // 
            this.lbNumeroTraducciones.AutoSize = true;
            this.lbNumeroTraducciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumeroTraducciones.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbNumeroTraducciones.Location = new System.Drawing.Point(859, 13);
            this.lbNumeroTraducciones.Name = "lbNumeroTraducciones";
            this.lbNumeroTraducciones.Size = new System.Drawing.Size(0, 18);
            this.lbNumeroTraducciones.TabIndex = 15;
            this.lbNumeroTraducciones.Tag = "lbNumeroTraducciones";
            // 
            // lbPalabraTraducida
            // 
            this.lbPalabraTraducida.AutoSize = true;
            this.lbPalabraTraducida.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPalabraTraducida.Location = new System.Drawing.Point(664, 436);
            this.lbPalabraTraducida.Name = "lbPalabraTraducida";
            this.lbPalabraTraducida.Size = new System.Drawing.Size(55, 18);
            this.lbPalabraTraducida.TabIndex = 16;
            this.lbPalabraTraducida.Tag = "lbPalabraTraducida";
            this.lbPalabraTraducida.Text = "Texto:";
            // 
            // lbPalabraa
            // 
            this.lbPalabraa.AutoSize = true;
            this.lbPalabraa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPalabraa.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbPalabraa.Location = new System.Drawing.Point(738, 436);
            this.lbPalabraa.Name = "lbPalabraa";
            this.lbPalabraa.Size = new System.Drawing.Size(0, 18);
            this.lbPalabraa.TabIndex = 17;
            this.lbPalabraa.Tag = "lbPalabraa";
            // 
            // frmCrearIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 469);
            this.Controls.Add(this.lbPalabraa);
            this.Controls.Add(this.lbPalabraTraducida);
            this.Controls.Add(this.lbNumeroTraducciones);
            this.Controls.Add(this.lbNumeroPalabras);
            this.Controls.Add(this.lbTraducciones);
            this.Controls.Add(this.lbPalabras);
            this.Controls.Add(this.grillaTraducciones);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grillaPalabras);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCrearIdioma";
            this.Text = "frmCrearIdioma";
            this.Load += new System.EventHandler(this.frmCrearIdioma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaIdiomas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPalabras)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTraducciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.DataGridView grillaPalabras;
        private System.Windows.Forms.TextBox txtPalabra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTraduccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboIdiomas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grillaTraducciones;
        private System.Windows.Forms.Label lbPalabras;
        private System.Windows.Forms.Label lbTraducciones;
        private System.Windows.Forms.Label lbNumeroPalabras;
        private System.Windows.Forms.Label lbNumeroTraducciones;
        private System.Windows.Forms.Label lbPalabraTraducida;
        private System.Windows.Forms.Label lbPalabraa;
        private System.Windows.Forms.DataGridView grillaIdiomas;
        private System.Windows.Forms.Button btnModificarIdioma;
        private System.Windows.Forms.Button btnBajaIdioma;
    }
}