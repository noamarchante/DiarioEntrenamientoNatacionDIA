using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WForms = System.Windows.Forms;
using Draw = System.Drawing;
using System.Collections.Generic;

namespace Proyecto2.View.Graficos
{
    public partial class GraficoView : Form
    {
        private List<string> mes = new List<string>() { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SET", "OCT", "NOV", "DIC" };
        public Panel PadrePanel { get; set; }
        public Panel InferiorPanel { get; set; }
        public Panel DerechaInferiorPanel { get; set; }
        public Panel IzquierdaInferiorPanel { get; set; }
        public Panel SuperiorPanel { get; set; }
        public Panel IzquierdaSuperiorPanel { get; set; }
        public Panel DerechaSuperiorPanel { get; set; }
        public DateTimePicker AnhoActividadesDateTimePicker { get; set; }
        public Chart MinutoDistanciaChart { get; set; }
        public Chart PesoCircunferenciaAbdominalChart { get; set; }
        public DateTimePicker AnhoMedidasDateTimePicker { get; set; }
        public DateTimePicker AnualDateTimePicker { get; set; }
        public Chart GraficoPesoAnual { get; set; }
        public DataGridView TablaAnual { get; set; }

        //PANEL CON GRÁFICO MINUTOS-DISTANCIA MENSUAL EN ACTIVIDADES
        private Panel IzquierdaSuperiorBuild()
        {
            this.IzquierdaSuperiorPanel = new Panel();
            this.MinutoDistanciaChart = new Chart(600, 340);
            this.AnhoActividadesDateTimePicker = new DateTimePicker();

            // 
            // IzquierdaArriba
            // 
            this.IzquierdaSuperiorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IzquierdaSuperiorPanel.Location = new System.Drawing.Point(0, 0);
            this.IzquierdaSuperiorPanel.BackColor = Color.White;
            this.IzquierdaSuperiorPanel.Name = "IzquierdaArriba";
            this.IzquierdaSuperiorPanel.Size = new System.Drawing.Size(633, 370);
            this.IzquierdaSuperiorPanel.TabIndex = 1;


            //
            // minutoDistanciaChart
            //
            this.MinutoDistanciaChart.Dock = DockStyle.Top;
            this.MinutoDistanciaChart.BackColor = Color.White;
            this.MinutoDistanciaChart.LegendY = "Minutos";
            this.MinutoDistanciaChart.LegendY2 = "Distancia";
            this.MinutoDistanciaChart.LegendX = mes;

            // 
            // fechaDateTimePicker
            // 
            this.AnhoActividadesDateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.AnhoActividadesDateTimePicker.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnhoActividadesDateTimePicker.Dock = DockStyle.Top;
            this.AnhoActividadesDateTimePicker.Name = "fechaDateTimePicker";
            this.AnhoActividadesDateTimePicker.Size = new System.Drawing.Size(80, 20);
            this.AnhoActividadesDateTimePicker.MaximumSize = new System.Drawing.Size(80, 20);
            this.AnhoActividadesDateTimePicker.MinimumSize = this.AnhoActividadesDateTimePicker.MaximumSize;
            this.AnhoActividadesDateTimePicker.Value = DateTime.Now;
            this.AnhoActividadesDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.AnhoActividadesDateTimePicker.CustomFormat = "yyyy";
            this.AnhoActividadesDateTimePicker.ShowUpDown = true;
            this.AnhoActividadesDateTimePicker.TabIndex = 14;
            this.AnhoActividadesDateTimePicker.MaxDate = DateTime.Now.AddYears(10);
            this.AnhoActividadesDateTimePicker.MinDate = DateTime.Now.AddYears(-DateTime.Now.Year + 2000);
            this.AnhoActividadesDateTimePicker.ValueChanged += new System.EventHandler(this.anhoActividadesDateTimePicker_ValueChanged);


            this.IzquierdaSuperiorPanel.Controls.Add(MinutoDistanciaChart);
            this.IzquierdaSuperiorPanel.Controls.Add(AnhoActividadesDateTimePicker);

            this.IzquierdaSuperiorPanel.Controls.Add(BuildVacioColumna());
            this.IzquierdaSuperiorPanel.Controls.Add(BuildVacioFila());


            return IzquierdaSuperiorPanel;
        }

        //PANEL CON GRÁFICO PESO-CIRCUNFERENCIA ABDOMINAL MENSAUL EN MEDIDAS 
        private Panel DerechaSuperiorBuild()
        {
            this.DerechaSuperiorPanel = new Panel();
            this.PesoCircunferenciaAbdominalChart = new Chart(600, 340);
            this.AnhoMedidasDateTimePicker = new DateTimePicker();
            // 
            // DerechoArriba
            // 
            this.DerechaSuperiorPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.DerechaSuperiorPanel.Location = new System.Drawing.Point(633, 0);
            this.DerechaSuperiorPanel.Name = "DerechoArriba";
            this.DerechaSuperiorPanel.Size = new System.Drawing.Size(633, 370);
            this.DerechaSuperiorPanel.TabIndex = 0;
            this.DerechaSuperiorPanel.BackColor = Color.White;

            //
            // pesoCircunferenciaAbdominalChart
            //
            this.PesoCircunferenciaAbdominalChart.Dock = DockStyle.Top;
            this.PesoCircunferenciaAbdominalChart.BackColor = Color.White;
            this.PesoCircunferenciaAbdominalChart.LegendY = "Peso (Kg)";
            this.PesoCircunferenciaAbdominalChart.LegendY2 = "CircunferenciaAbdominal (cms)";
            this.PesoCircunferenciaAbdominalChart.LegendX = mes;

            // 
            // fechaDateTimePicker
            // 
            this.AnhoMedidasDateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.AnhoMedidasDateTimePicker.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnhoMedidasDateTimePicker.Dock = DockStyle.Top;
            this.AnhoMedidasDateTimePicker.Name = "fechaDateTimePicker";
            this.AnhoMedidasDateTimePicker.Size = new System.Drawing.Size(80, 20);
            this.AnhoMedidasDateTimePicker.MaximumSize = new System.Drawing.Size(80, 20);
            this.AnhoMedidasDateTimePicker.MinimumSize = this.AnhoActividadesDateTimePicker.MaximumSize;
            this.AnhoMedidasDateTimePicker.Value = DateTime.Now;
            this.AnhoMedidasDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.AnhoMedidasDateTimePicker.CustomFormat = "yyyy";
            this.AnhoMedidasDateTimePicker.ShowUpDown = true;
            this.AnhoMedidasDateTimePicker.TabIndex = 15;
            this.AnhoMedidasDateTimePicker.MaxDate = DateTime.Now.AddYears(10);
            this.AnhoMedidasDateTimePicker.MinDate = DateTime.Now.AddYears(-DateTime.Now.Year + 2000);
          


            this.DerechaSuperiorPanel.Controls.Add(PesoCircunferenciaAbdominalChart);
            this.DerechaSuperiorPanel.Controls.Add(AnhoMedidasDateTimePicker);

            this.DerechaSuperiorPanel.Controls.Add(BuildVacioColumna());
            this.DerechaSuperiorPanel.Controls.Add(BuildVacioFila());

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
            this.SuperiorPanel.Size = new System.Drawing.Size(1266, 370);
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
            this.AnualDateTimePicker= new DateTimePicker();
            this.GraficoPesoAnual = new Chart(600,340);
            // 
            // IzquierdaAbajo
            // 
            this.IzquierdaInferiorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.IzquierdaInferiorPanel.Location = new System.Drawing.Point(0, 0);
            this.IzquierdaInferiorPanel.Name = "IzquierdaAbajo";
            this.IzquierdaInferiorPanel.Size = new System.Drawing.Size(633, 370);
            this.IzquierdaInferiorPanel.TabIndex = 0;
            this.IzquierdaInferiorPanel.BackColor = Color.White;
            
            //escoger año
            this.AnualDateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.AnualDateTimePicker.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnualDateTimePicker.Dock = DockStyle.Top;
            this.AnualDateTimePicker.Name = "fechaDateTimePicker";
            this.AnualDateTimePicker.Size = new System.Drawing.Size(80, 20);
            this.AnualDateTimePicker.MaximumSize = new System.Drawing.Size(80, 20);
            this.AnualDateTimePicker.MinimumSize = this.AnualDateTimePicker.MaximumSize;
            this.AnualDateTimePicker.Value = DateTime.Now;
            this.AnualDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.AnualDateTimePicker.CustomFormat = "yyyy";
            this.AnualDateTimePicker.ShowUpDown = true;
            this.AnualDateTimePicker.TabIndex = 14;
            this.AnualDateTimePicker.MaxDate = DateTime.Now.AddYears(10);
            this.AnualDateTimePicker.MinDate = DateTime.Now.AddYears(-DateTime.Now.Year + 2000);
            this.AnualDateTimePicker.ValueChanged += new System.EventHandler(this.AnualDateTimePicker_ValueChanged);
            
            //CONFIGURACION GRAFICO 
            this.GraficoPesoAnual.Dock = DockStyle.Top;
            this.GraficoPesoAnual.BackColor = Color.White;
            this.GraficoPesoAnual.LegendY = "PESO";
    
            this.GraficoPesoAnual.LegendX = mes;
            this.GraficoPesoAnual.LegendY2 = "";

            
            this.IzquierdaInferiorPanel.Controls.Add(GraficoPesoAnual);
            this.IzquierdaInferiorPanel.Controls.Add(AnualDateTimePicker);

            this.IzquierdaInferiorPanel.Controls.Add(BuildVacioColumna());
            this.IzquierdaInferiorPanel.Controls.Add(BuildVacioFila());


            
            return IzquierdaInferiorPanel;

        }

        //PANEL TABLA CON PESOS ANUALES
        private Panel DerechaInferiorBuild()
        {
            this.DerechaInferiorPanel = new Panel();
            this.TablaAnual=new DataGridView();

            // 
            // AbajoDerecha
            // 
            this.DerechaInferiorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DerechaInferiorPanel.Location = new System.Drawing.Point(633, 0);
            this.DerechaInferiorPanel.Name = "AbajoDerecha";
            this.DerechaInferiorPanel.Size = new System.Drawing.Size(633, 370);
            this.DerechaInferiorPanel.TabIndex = 1;
            this.DerechaInferiorPanel.BackColor = Color.White;
            
            //configuracion de la tabla 
            this.TablaAnual.ColumnCount = 2;
            TablaAnual.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            TablaAnual.ColumnHeadersDefaultCellStyle.ForeColor = Color.Transparent;
            TablaAnual.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            TablaAnual.BackgroundColor = Color.White;
            TablaAnual.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Transparent;
            TablaAnual.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            TablaAnual.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TablaAnual.Name = "tablaActividadDataGridView";
            TablaAnual.Dock = DockStyle.Top;
            TablaAnual.Size = new Size(600, 360);
            TablaAnual.MaximumSize = TablaAnual.Size;
            TablaAnual.MinimumSize = TablaAnual.Size;
            TablaAnual.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            TablaAnual.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            TablaAnual.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            TablaAnual.GridColor = Color.Black;
            TablaAnual.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.GhostWhite;
            TablaAnual.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            TablaAnual.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TablaAnual.RowHeadersVisible = false;
            TablaAnual.ReadOnly = true;
            TablaAnual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TablaAnual.AutoGenerateColumns = false;
            TablaAnual.Columns[0].Name = "Mes";
            TablaAnual.Columns[1].Name = "MediaPeso";
            
            
            DerechaInferiorPanel.Controls.Add(TablaAnual);

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
            this.InferiorPanel.Size = new System.Drawing.Size(1266, 370);
            this.InferiorPanel.TabIndex = 1;

            var izquierdaInferior = IzquierdaInferiorBuild();
            var derechaInferior = DerechaInferiorBuild();

            this.InferiorPanel.Controls.Add(derechaInferior);
            this.InferiorPanel.Controls.Add(izquierdaInferior);

            this.InferiorPanel.ResumeLayout(false);
            return InferiorPanel;
        }

        //CONSTRUYE COLUMNA VACIA
        private Panel BuildVacioColumna()
        {
            var resultado = new Panel { Dock = DockStyle.Left };
            resultado.Name = "vacioColumna";
            resultado.Size = new System.Drawing.Size(20, 719);
            resultado.TabIndex = 0;

            return resultado;
        }

        //CONSTRUYE FILA VACIA
        private FlowLayoutPanel BuildVacioFila()
        {
            var resultado = new FlowLayoutPanel { Dock = DockStyle.Top };
            resultado.Name = "vacioFila";
            resultado.Size = new System.Drawing.Size(1202, 5);
            resultado.TabIndex = 1;
            return resultado;
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
            this.PadrePanel.Size = new System.Drawing.Size(1266, 740);
            this.PadrePanel.TabIndex = 0;

            var superior = SuperiorBuild();
            var inferior = InferiorBuild();

            this.PadrePanel.Controls.Add(inferior);
            this.PadrePanel.Controls.Add(superior);

            PadrePanel.ResumeLayout(true);
            this.Icon = new Icon(@"img\\icono.ico");
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 740);
            this.Name = "Graficos";
            this.Text = "GRÁFICOS";
            this.ResumeLayout(false);


        }

    }
}