﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto2.View.Graficos
{
    public partial class GraficoView: Form
    {
        private string[] mes = { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        public Panel PadrePanel { get; set; }
        public Panel InferiorPanel { get; set; }
        public Panel DerechaInferiorPanel { get; set; }
        public Panel IzquierdaInferiorPanel { get; set; }
        public Panel SuperiorPanel { get; set; }
        public Panel IzquierdaSuperiorPanel { get; set; }
        public Panel DerechaSuperiorPanel { get; set; }
        public DateTimePicker AnhoActividadesDateTimePicker { get; set; }
        public Chart MinutoDistanciaChart { get; set; }

        //PANEL CON GRÁFICO MINUTOS-DISTANCIA MENSUAL EN ACTIVIDADES
        private Panel IzquierdaSuperiorBuild()
        {
            this.IzquierdaSuperiorPanel = new Panel();
            this.MinutoDistanciaChart = new Chart(300, 200);
            this.AnhoActividadesDateTimePicker = new DateTimePicker();

            // 
            // IzquierdaArriba
            // 
            this.IzquierdaSuperiorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IzquierdaSuperiorPanel.Location = new System.Drawing.Point(0, 0);
            this.IzquierdaSuperiorPanel.BackColor = Color.White;
            this.IzquierdaSuperiorPanel.Name = "IzquierdaArriba";
            this.IzquierdaSuperiorPanel.Size = new System.Drawing.Size(573, 370);
            this.IzquierdaSuperiorPanel.TabIndex = 1;


            //
            // minutoDistanciaChart
            //
            this.MinutoDistanciaChart.Dock = DockStyle.Bottom;
            this.MinutoDistanciaChart.BackColor = Color.White;
            this.MinutoDistanciaChart.LegendY = "Minutos";
            this.MinutoDistanciaChart.LegendY2 = "Distancia";
            this.MinutoDistanciaChart.LegendX = "Mes";
      
            // 
            // fechaDateTimePicker
            // 
            this.AnhoActividadesDateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.AnhoActividadesDateTimePicker.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnhoActividadesDateTimePicker.Dock = DockStyle.Left;
            this.AnhoActividadesDateTimePicker.Name = "fechaDateTimePicker";
            this.AnhoActividadesDateTimePicker.Size = new System.Drawing.Size(150, 20);
            this.AnhoActividadesDateTimePicker.Value = DateTime.Now;
            this.AnhoActividadesDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.AnhoActividadesDateTimePicker.CustomFormat = "yyyy";
            this.AnhoActividadesDateTimePicker.TabIndex = 14;
            this.AnhoActividadesDateTimePicker.ValueChanged += new System.EventHandler(this.anhoActividadesDateTimePicker_ValueChanged);

            this.IzquierdaSuperiorPanel.Controls.Add(MinutoDistanciaChart);
            this.IzquierdaSuperiorPanel.Controls.Add(AnhoActividadesDateTimePicker);
            
            return IzquierdaSuperiorPanel;
        }

        //PANEL CON GRÁFICO PESO-CIRCUNFERENCIA ABDOMINAL MENSAUL EN MEDIDAS 
        private Panel DerechaSuperiorBuild()
        {
            this.DerechaSuperiorPanel = new Panel();

            // 
            // DerechoArriba
            // 
            this.DerechaSuperiorPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.DerechaSuperiorPanel.Location = new System.Drawing.Point(573, 0);
            this.DerechaSuperiorPanel.Name = "DerechoArriba";
            this.DerechaSuperiorPanel.Size = new System.Drawing.Size(633, 370);
            this.DerechaSuperiorPanel.TabIndex = 0;
            this.DerechaSuperiorPanel.BackColor = Color.White;

            return DerechaSuperiorPanel;
        }

        //CONSTRUYE LOS DOS PANELES SUPERIORES
        private Panel SuperiorBuild()
        {
            this.SuperiorPanel = new Panel();

            this.SuperiorPanel.SuspendLayout();

            // 
            // superior
            // 

            this.SuperiorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SuperiorPanel.Location = new System.Drawing.Point(0, 0);
            this.SuperiorPanel.Name = "superior";
            this.SuperiorPanel.Size = new System.Drawing.Size(1206, 370);
            this.SuperiorPanel.TabIndex = 0;

            var izquierdaSuperior = IzquierdaSuperiorBuild();
            var derechaSuperior = DerechaSuperiorBuild();

            this.SuperiorPanel.Controls.Add(izquierdaSuperior);
            this.SuperiorPanel.Controls.Add(derechaSuperior);

            this.SuperiorPanel.ResumeLayout(false);

            return SuperiorPanel;
        }

        //PANEL GRÁFICO PESO ANUAL 
        private Panel IzquierdaInferiorBuild()
        {
            this.IzquierdaInferiorPanel = new Panel();

            // 
            // IzquierdaAbajo
            // 
            this.IzquierdaInferiorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.IzquierdaInferiorPanel.Location = new System.Drawing.Point(0, 0);
            this.IzquierdaInferiorPanel.Name = "IzquierdaAbajo";
            this.IzquierdaInferiorPanel.Size = new System.Drawing.Size(573, 375);
            this.IzquierdaInferiorPanel.TabIndex = 0;
            this.IzquierdaInferiorPanel.BackColor = Color.White;
            return IzquierdaInferiorPanel;

        }

        //PANEL TABLA CON PESOS ANUALES
        private Panel DerechaInferiorBuild()
        {
            this.DerechaInferiorPanel = new Panel();
            
            // 
            // AbajoDerecha
            // 
            this.DerechaInferiorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DerechaInferiorPanel.Location = new System.Drawing.Point(573, 0);
            this.DerechaInferiorPanel.Name = "AbajoDerecha";
            this.DerechaInferiorPanel.Size = new System.Drawing.Size(633, 375);
            this.DerechaInferiorPanel.TabIndex = 1;
            this.DerechaInferiorPanel.BackColor = Color.White;

            return DerechaInferiorPanel;

        }

        //CONSTRUYE LOS PANELES INFERIORES
        private Panel InferiorBuild()
        {
            this.InferiorPanel = new Panel();
       
            this.InferiorPanel.SuspendLayout();
   
            // 
            // inferior
            // 
            this.InferiorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InferiorPanel.Location = new System.Drawing.Point(0, 370);
            this.InferiorPanel.Name = "inferior";
            this.InferiorPanel.Size = new System.Drawing.Size(1206, 375);
            this.InferiorPanel.TabIndex = 1;

            var izquierdaInferior = IzquierdaInferiorBuild();
            var derechaInferior = DerechaInferiorBuild();

            this.InferiorPanel.Controls.Add(derechaInferior);
            this.InferiorPanel.Controls.Add(izquierdaInferior);
  
            this.InferiorPanel.ResumeLayout(false);
            return InferiorPanel;
        }

        //CONSTRUYE LA VENTANA
        private void Build()
        {
            this.PadrePanel = new Panel();
            
            PadrePanel.SuspendLayout();
            this.SuspendLayout();
            this.Controls.Add(this.PadrePanel);

            // 
            // padre
            // 
            this.PadrePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PadrePanel.Location = new System.Drawing.Point(0, 0);
            this.PadrePanel.Name = "padre";
            this.PadrePanel.Size = new System.Drawing.Size(1206, 745);
            this.PadrePanel.TabIndex = 0;

            var superior = SuperiorBuild();
            var inferior = InferiorBuild();

            this.PadrePanel.Controls.Add(inferior);
            this.PadrePanel.Controls.Add(superior);

            PadrePanel.ResumeLayout(true);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 745);
            this.Name = "Graficos";
            this.Text = "Graficos";
            this.ResumeLayout(false);


        }

    }
}
