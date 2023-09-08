
namespace UI
{
    partial class frmReportes
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
            this.btnDescargar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.comboHabitaciones = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDescargar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateFin);
            this.groupBox1.Controls.Add(this.comboHabitaciones);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Alquiler";
            // 
            // btnDescargar
            // 
            this.btnDescargar.Location = new System.Drawing.Point(618, 48);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(151, 23);
            this.btnDescargar.TabIndex = 7;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero Habitacion:";
            // 
            // dateFin
            // 
            this.dateFin.Enabled = false;
            this.dateFin.Location = new System.Drawing.Point(410, 51);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(200, 20);
            this.dateFin.TabIndex = 5;
            // 
            // comboHabitaciones
            // 
            this.comboHabitaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHabitaciones.FormattingEnabled = true;
            this.comboHabitaciones.Location = new System.Drawing.Point(12, 50);
            this.comboHabitaciones.Name = "comboHabitaciones";
            this.comboHabitaciones.Size = new System.Drawing.Size(164, 21);
            this.comboHabitaciones.TabIndex = 6;
            this.comboHabitaciones.SelectedIndexChanged += new System.EventHandler(this.comboHabitaciones_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha FIn:";
            // 
            // dateInicio
            // 
            this.dateInicio.Enabled = false;
            this.dateInicio.Location = new System.Drawing.Point(190, 51);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(200, 20);
            this.dateInicio.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Inicio:";
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 120);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReportes";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFin;
        private System.Windows.Forms.ComboBox comboHabitaciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateInicio;
        private System.Windows.Forms.Label label2;
    }
}