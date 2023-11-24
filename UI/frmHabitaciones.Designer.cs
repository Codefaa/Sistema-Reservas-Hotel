
namespace UI
{
    partial class frmHabitaciones
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
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.grillaHabitaciones = new System.Windows.Forms.DataGridView();
            this.btnCrear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaja);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.grillaHabitaciones);
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 436);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "ListaDeHabitaciones";
            this.groupBox1.Text = "Lista de Habitaciones";
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(593, 408);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 7;
            this.btnBaja.Tag = "btnBaja";
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.Control;
            this.btnModificar.Location = new System.Drawing.Point(681, 408);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Tag = "btnModificar";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // grillaHabitaciones
            // 
            this.grillaHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaHabitaciones.Location = new System.Drawing.Point(19, 59);
            this.grillaHabitaciones.Name = "grillaHabitaciones";
            this.grillaHabitaciones.ReadOnly = true;
            this.grillaHabitaciones.Size = new System.Drawing.Size(737, 343);
            this.grillaHabitaciones.TabIndex = 1;
            this.grillaHabitaciones.Tag = "grillaHabitaciones";
            this.grillaHabitaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaHabitaciones_CellContentClick);
            this.grillaHabitaciones.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaHabitaciones_CellEndEdit);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(19, 30);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Tag = "btnCrearNuevo";
            this.btnCrear.Text = "Crear Nuevo";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // frmHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHabitaciones";
            this.Text = "frmHabitaciones";
            this.Load += new System.EventHandler(this.frmHabitaciones_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaHabitaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grillaHabitaciones;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificar;
    }
}