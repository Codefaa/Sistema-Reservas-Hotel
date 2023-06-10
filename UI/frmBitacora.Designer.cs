
namespace UI
{
    partial class frmBitacora
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
            this.grillaBitacora = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboCategorias = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaBitacora
            // 
            this.grillaBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaBitacora.Location = new System.Drawing.Point(12, 143);
            this.grillaBitacora.Name = "grillaBitacora";
            this.grillaBitacora.Size = new System.Drawing.Size(402, 173);
            this.grillaBitacora.TabIndex = 0;
            this.grillaBitacora.Tag = "grillaBuscar";
            this.grillaBitacora.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaBitacora_CellContentClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(322, 96);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Tag = "btnBuscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Tag = "lbTexto";
            this.label1.Text = "Texto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboCategorias);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTexto);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "groupBitacora";
            this.groupBox1.Text = "BITACORA";
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(262, 58);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(135, 20);
            this.txtTexto.TabIndex = 3;
            this.txtTexto.Tag = "txtTexto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Tag = "lbDesde";
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Tag = "lbHasta";
            this.label3.Text = "Hasta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(135, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.Tag = "timeDesde";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(262, 18);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(135, 20);
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.Tag = "timeHasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Tag = "lbCategoria";
            this.label4.Text = "Categoria";
            // 
            // comboCategorias
            // 
            this.comboCategorias.FormattingEnabled = true;
            this.comboCategorias.Location = new System.Drawing.Point(72, 58);
            this.comboCategorias.Name = "comboCategorias";
            this.comboCategorias.Size = new System.Drawing.Size(135, 21);
            this.comboCategorias.TabIndex = 9;
            this.comboCategorias.Tag = "comboCategorias";
            // 
            // frmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 328);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grillaBitacora);
            this.Name = "frmBitacora";
            this.Text = "frmBitacora";
            this.Load += new System.EventHandler(this.frmBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaBitacora;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.ComboBox comboCategorias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}