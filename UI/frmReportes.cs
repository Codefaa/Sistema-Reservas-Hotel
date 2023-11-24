﻿using System;
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
using Abstraccion;
using Servicios;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;


namespace UI
{
    public partial class frmReportes : Form, IObservador
    {
        public frmReportes()
        {
            InitializeComponent();

            reserva = new BEReserva();
        }

        BEReserva reserva;

        void MostrarCombo()
        {
            BLLReserva bllReserva = new BLLReserva();
            comboHabitaciones.DataSource = null;
            comboHabitaciones.DataSource = bllReserva.LeerReservas();
        }



        #region Idioma

        Sesion sesion = Sesion.Instance;
        private void frmReportes_Load(object sender, EventArgs e)
        {
            MostrarCombo();

            sesion.RegistrarObservador(this);
            sesion.ActualizarObservadores(Sesion.Idioma);
        }
        public void Actualizar(IIdioma idiomaObservado)
        {
            foreach (Control item in this.Controls)
            {
                item.Text = idiomaObservado.BuscarTraduccion(item.Tag.ToString());

                if (groupBox1.Controls.Count > 0)
                {
                    foreach (Control item2 in groupBox1.Controls)
                    {
                        item2.Text = idiomaObservado.BuscarTraduccion(item2.Tag.ToString());
                    }
                }
            }
        }

        #endregion

        private void comboHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                reserva = (BEReserva)comboHabitaciones.SelectedItem;

                dateInicio.Value = reserva.FechaEntrada;
                dateFin.Value = reserva.FechaSalida;
                txtCliente.Text = reserva.unCliente.Nombre;
                txtPrecioEstadia.Text = reserva.PrecioFinal.ToString();
                txtAdelanto.Text = reserva.Adelanto.ToString();
                txtTotalPagar.Text = reserva.Total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = "Reservas.pdf";

                string paginaHTML = Properties.Resources.index.ToString();
                //Datos del cliente
                paginaHTML = paginaHTML.Replace("@Nombre", reserva.unCliente.Nombre);
                paginaHTML = paginaHTML.Replace("@Apellido", reserva.unCliente.Apellido);
                paginaHTML = paginaHTML.Replace("@Correo", reserva.unCliente.Correo);
                paginaHTML = paginaHTML.Replace("@DNI", reserva.unCliente.DNI.ToString());

                //Datos de la habitacion
                paginaHTML = paginaHTML.Replace("@Numero", reserva.unaHabitacion.Numero.ToString());
                paginaHTML = paginaHTML.Replace("@Piso", reserva.unaHabitacion.Piso);
                paginaHTML = paginaHTML.Replace("@Categoria", reserva.unaHabitacion.Categoria);
                paginaHTML = paginaHTML.Replace("@Estado", reserva.unaHabitacion.Estado);
                paginaHTML = paginaHTML.Replace("@Precio", reserva.unaHabitacion.Precio.ToString());

                //Datos de la reserva
                paginaHTML = paginaHTML.Replace("@FechaEntrada", reserva.FechaEntrada.ToString("yyyy-MM-dd"));
                paginaHTML = paginaHTML.Replace("@FechaSalida", reserva.FechaSalida.ToString("yyyy-MM-dd"));
                paginaHTML = paginaHTML.Replace("@Observacion", reserva.Observacion.ToString());
                paginaHTML = paginaHTML.Replace("@Final", reserva.PrecioFinal.ToString());
                paginaHTML = paginaHTML.Replace("@Adelanto", reserva.Adelanto.ToString());
                paginaHTML = paginaHTML.Replace("@Total", reserva.Total.ToString());


                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase("")); //NOSE

                        //Insertar Imagen
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.uai, System.Drawing.Imaging.ImageFormat.Png);
                        img.ScaleToFit(180, 80);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;

                        img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 80);
                        pdfDoc.Add(img);


                        using (StringReader sr = new StringReader(paginaHTML))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
