﻿
namespace UI
{
    partial class frmIdioma
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
            this.btnCambiar = new System.Windows.Forms.Button();
            this.comboIdiomas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCambiar);
            this.groupBox1.Controls.Add(this.comboIdiomas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "Seleccionaridioma";
            this.groupBox1.Text = "Seleccionar idioma";
            // 
            // btnCambiar
            // 
            this.btnCambiar.Location = new System.Drawing.Point(218, 74);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(104, 23);
            this.btnCambiar.TabIndex = 2;
            this.btnCambiar.Tag = "Cambiar";
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // comboIdiomas
            // 
            this.comboIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIdiomas.FormattingEnabled = true;
            this.comboIdiomas.Location = new System.Drawing.Point(123, 28);
            this.comboIdiomas.Name = "comboIdiomas";
            this.comboIdiomas.Size = new System.Drawing.Size(199, 21);
            this.comboIdiomas.TabIndex = 1;
            this.comboIdiomas.Tag = "comboIdiomas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Idiomas";
            this.label1.Text = "Idiomas";
            // 
            // frmIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 151);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmIdioma";
            this.Text = "frmIdioma";
            this.Load += new System.EventHandler(this.frmIdioma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.ComboBox comboIdiomas;
        private System.Windows.Forms.Label label1;
    }
}