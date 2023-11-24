﻿
namespace UI
{
    partial class frmReservasLista
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.grillaReservas = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateFechaSalida);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnBaja);
            this.groupBox1.Controls.Add(this.grillaReservas);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(761, 414);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "ListaReservas";
            this.groupBox1.Text = "Lista Reservas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Tag = "lbFechaLimite";
            this.label1.Text = "Fecha Limite:";
            // 
            // dateFechaSalida
            // 
            this.dateFechaSalida.Location = new System.Drawing.Point(109, 28);
            this.dateFechaSalida.Margin = new System.Windows.Forms.Padding(2);
            this.dateFechaSalida.Name = "dateFechaSalida";
            this.dateFechaSalida.Size = new System.Drawing.Size(192, 20);
            this.dateFechaSalida.TabIndex = 5;
            this.dateFechaSalida.Tag = "dateFechaSalida";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(605, 388);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(62, 21);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Tag = "btnAgregar";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(322, 27);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(69, 21);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Tag = "btnModificar";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(685, 388);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(62, 21);
            this.btnBaja.TabIndex = 2;
            this.btnBaja.Tag = "btnBaja";
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // grillaReservas
            // 
            this.grillaReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaReservas.Location = new System.Drawing.Point(14, 58);
            this.grillaReservas.Margin = new System.Windows.Forms.Padding(2);
            this.grillaReservas.Name = "grillaReservas";
            this.grillaReservas.ReadOnly = true;
            this.grillaReservas.RowHeadersWidth = 51;
            this.grillaReservas.RowTemplate.Height = 24;
            this.grillaReservas.Size = new System.Drawing.Size(733, 323);
            this.grillaReservas.TabIndex = 1;
            this.grillaReservas.Tag = "grillaReservas";
            this.grillaReservas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaReservas_CellContentClick);
            // 
            // frmReservasLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 433);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmReservasLista";
            this.Text = "frmReservasLista";
            this.Load += new System.EventHandler(this.frmReservasLista_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaReservas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grillaReservas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFechaSalida;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBaja;
    }
}