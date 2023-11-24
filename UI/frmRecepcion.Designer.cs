
namespace UI
{
    partial class frmRecepcion
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
            this.comboPiso = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grillaHabitaciones = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboPiso);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.grillaHabitaciones);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 406);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "groupRecepcion";
            // 
            // comboPiso
            // 
            this.comboPiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPiso.FormattingEnabled = true;
            this.comboPiso.Location = new System.Drawing.Point(151, 17);
            this.comboPiso.Name = "comboPiso";
            this.comboPiso.Size = new System.Drawing.Size(241, 21);
            this.comboPiso.TabIndex = 3;
            this.comboPiso.Tag = "comboPisos";
            this.comboPiso.SelectedIndexChanged += new System.EventHandler(this.comboPiso_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 2;
            this.label1.Tag = "SeleccionarElNivelPiso";
            this.label1.Text = "Seleccionar el Nivel/Piso";
            // 
            // grillaHabitaciones
            // 
            this.grillaHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaHabitaciones.Location = new System.Drawing.Point(22, 49);
            this.grillaHabitaciones.Name = "grillaHabitaciones";
            this.grillaHabitaciones.ReadOnly = true;
            this.grillaHabitaciones.Size = new System.Drawing.Size(730, 339);
            this.grillaHabitaciones.TabIndex = 1;
            this.grillaHabitaciones.Tag = "grillaHabitaciones";
            this.grillaHabitaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaHabitaciones_CellContentClick);
            this.grillaHabitaciones.DoubleClick += new System.EventHandler(this.grillaHabitaciones_DoubleClick);
            // 
            // frmRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRecepcion";
            this.Text = "Recepcion";
            this.Load += new System.EventHandler(this.frmRecepcion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaHabitaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboPiso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grillaHabitaciones;
    }
}