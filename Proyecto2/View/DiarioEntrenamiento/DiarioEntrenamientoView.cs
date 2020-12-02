using System.Drawing;
using System.Windows.Forms;

namespace Proyecto2.View.DiarioEntrenamiento
{
    public partial class DiarioEntrenamientoView: Form
    {
        public MenuStrip MenuPrincipal { get; set; }
        public ToolStripMenuItem MenuOpciones { get; set; }
        public ToolStripMenuItem MenuAnhadirActividad { get; set; }
        public ToolStripMenuItem MenuAnhadirCircuito { get; set; }
        public ToolStripMenuItem MenuAnhadirMedida { get; set; }
        public ToolStripMenuItem MenuGraficos { get; set; }

        public Panel PanelPanel { get; set; }
        public Label LibreLabel { get; set; }
        public Label OcupadoLabel { get; set; }
        public Label TituloActividadLabel { get; set; }
        public Label TituloCircuitoLabel { get; set; }
        public Label TituloMedidaLabel { get; set; }
        public Button EliminarActividadButton { get; set; }
        public Button EliminarCircuitoButton { get; set; }
        public Button EliminarMedidaButton { get; set; }
        public MonthCalendar CalendarioMonthCalendar { get; set; }
        public DataGridView TablaActividadDataGridView { get; set; }
        public DataGridView TablaCircuitoDataGridView { get; set; }
        public DataGridView TablaMedidaDataGridView { get; set; }

        private MenuStrip CreateMenu()
        {
             MenuPrincipal = new MenuStrip();

             MenuOpciones = new ToolStripMenuItem();
             MenuAnhadirActividad = new ToolStripMenuItem();
             MenuAnhadirCircuito = new ToolStripMenuItem();
             MenuAnhadirMedida = new ToolStripMenuItem();
             MenuGraficos = new ToolStripMenuItem();

            //
            //Menu principal
            //
            this.MenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpciones});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "menuStrip1";
            this.MenuPrincipal.Size = new System.Drawing.Size(1202, 28);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "menuStrip1";


            //
            // menu opciones
            //
            this.MenuOpciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAnhadirActividad,
            this.MenuAnhadirCircuito,
            this.MenuAnhadirMedida,
            this.MenuGraficos});
            this.MenuOpciones.Name = "opcionesToolStripMenuItem";
            this.MenuOpciones.Size = new System.Drawing.Size(85, 24);
            this.MenuOpciones.Text = "Opciones";

            // 
            // añadirActividadToolStripMenuItem
            // 
            this.MenuAnhadirActividad.Name = "añadirActividadToolStripMenuItem";
            this.MenuAnhadirActividad.Size = new System.Drawing.Size(224, 26);
            this.MenuAnhadirActividad.Text = "AñadirActividad";
            this.MenuAnhadirActividad.Click += new System.EventHandler(this.MenuAnhidirActividadToolStripMenuItem_Click);

            // 
            // añadirCircuitoToolStripMenuItem
            // 
            this.MenuAnhadirCircuito.Name = "añadirCircuitoToolStripMenuItem";
            this.MenuAnhadirCircuito.Size = new System.Drawing.Size(224, 26);
            this.MenuAnhadirCircuito.Text = "AñadirCircuito";
            // 
            // añadirMedidaToolStripMenuItem
            // 
            this.MenuAnhadirMedida.Name = "añadirMedidaToolStripMenuItem";
            this.MenuAnhadirMedida.Size = new System.Drawing.Size(224, 26);
            this.MenuAnhadirMedida.Text = "AñadirMedida";
            // 
            // graficosToolStripMenuItem
            // 
            this.MenuGraficos.Name = "graficosToolStripMenuItem";
            this.MenuGraficos.Size = new System.Drawing.Size(224, 26);
            this.MenuGraficos.Text = "Graficos";

            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            return MenuPrincipal;
        }

        private Panel BuildCalendario()
        {
            var resultado = new Panel { Dock = DockStyle.Left };
            //resultado.Location = new System.Drawing.Point(0, 0);
            resultado.Name = "calendario";
            resultado.Size = new System.Drawing.Size(400, 719);
            resultado.TabIndex = 0;
            

            this.CalendarioMonthCalendar = new MonthCalendar();
            this.OcupadoLabel = new Label();
            this.LibreLabel = new Label();

            // calMonthCalendar
            // 
            this.CalendarioMonthCalendar.Location = new System.Drawing.Point(18, 33);
            this.CalendarioMonthCalendar.Dock = DockStyle.Top;
            this.CalendarioMonthCalendar.Name = "calendarioMonthCalendar";
            this.CalendarioMonthCalendar.ShowToday = false;
            this.CalendarioMonthCalendar.TabIndex = 0;

            // 
            // ocupadoLabel
            // 
            this.OcupadoLabel.AutoSize = true;
            this.OcupadoLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OcupadoLabel.Dock = DockStyle.Top;
            this.OcupadoLabel.Name = "ocupadoLabel";
            this.OcupadoLabel.Size = new System.Drawing.Size(154, 24);
            this.OcupadoLabel.TabIndex = 1;
            this.OcupadoLabel.Text = "Día con actividad";
            // 
            // libreLabel
            // 
            this.LibreLabel.AutoSize = true;
            this.LibreLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LibreLabel.Dock = DockStyle.Top;
            this.LibreLabel.Name = "libreLabel";
            this.LibreLabel.Size = new System.Drawing.Size(80, 24);
            this.LibreLabel.TabIndex = 2;
            this.LibreLabel.Text = "Día libre";

            resultado.Controls.Add(LibreLabel);
            resultado.Controls.Add(OcupadoLabel);
            resultado.Controls.Add(CalendarioMonthCalendar);

            return resultado;
        }
        private Panel BuildTituloActividad()
        {
            var resultado = new Panel { Dock = DockStyle.Top };
            //resultado.Location = new System.Drawing.Point(0, 0);
            resultado.Name = "tituloActividad";
            resultado.Size = new System.Drawing.Size(982, 40);
            resultado.TabIndex = 0;

            this.TituloActividadLabel = new Label();
            //
            //TituloActividadLabel
            //
            this.TituloActividadLabel.AutoSize = true;
            this.TituloActividadLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloActividadLabel.Dock = DockStyle.Top;
            this.TituloActividadLabel.Name = "tituloActividadLabel";
            this.TituloActividadLabel.Size = new System.Drawing.Size(154, 24);
            this.TituloActividadLabel.TabIndex = 1;
            this.TituloActividadLabel.Text = "ACTIVIDADES";

            resultado.Controls.Add(TituloActividadLabel);

            return resultado;

        }

        private FlowLayoutPanel BuildTablaActividad()
        {
            var resultado = new FlowLayoutPanel { Dock = DockStyle.Top };
            //resultado.Location = new System.Drawing.Point(220, 0);
            resultado.Name = "panelTablaActividades";
            resultado.Size = new System.Drawing.Size(1200, 205);
            resultado.TabIndex = 1;

            
            this.TablaActividadDataGridView = new DataGridView();

           

            //
            // TablaActividadDataGridView
            //
            this.TablaActividadDataGridView.ColumnCount = 6;
            TablaActividadDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            TablaActividadDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TablaActividadDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(TablaActividadDataGridView.Font, FontStyle.Bold);
            TablaActividadDataGridView.Name = "tablaActividadDataGridView";
            TablaActividadDataGridView.Dock = DockStyle.Top;
            TablaActividadDataGridView.Size = new Size(1050, 200);
            TablaActividadDataGridView.MaximumSize = TablaActividadDataGridView.Size;
            TablaActividadDataGridView.MinimumSize = TablaActividadDataGridView.Size;
            TablaActividadDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            TablaActividadDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            TablaActividadDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            TablaActividadDataGridView.GridColor = Color.Black;
            TablaActividadDataGridView.RowHeadersVisible = true;
            TablaActividadDataGridView.Columns[0].Name = "Distancia";
            TablaActividadDataGridView.Columns[1].Name = "Tiempo";
            TablaActividadDataGridView.Columns[2].Name = "Notas";
            TablaActividadDataGridView.Columns[3].Name = "Fecha";
            TablaActividadDataGridView.Columns[4].Name = "Circuito";
            TablaActividadDataGridView.Columns[5].Name = "Eliminar";
            //TablaActividadDataGridView.Columns[4].DefaultCellStyle.Font = new Font(TablaActividadDataGridView.DefaultCellStyle.Font, FontStyle.Italic);
            TablaActividadDataGridView.SelectionMode =DataGridViewSelectionMode.FullRowSelect;
            TablaActividadDataGridView.MultiSelect = false;

            
            resultado.Controls.Add(TablaActividadDataGridView);

            return resultado;
        }

        private Panel BuildTituloCircuito()
        {
            var resultado = new Panel { Dock = DockStyle.Top };
            //resultado.Location = new System.Drawing.Point(0, 0);
            resultado.Name = "tituloCircuito";
            resultado.Size = new System.Drawing.Size(982, 40);
            resultado.TabIndex = 0;

            this.TituloCircuitoLabel = new Label();
            //
            //TituloActividadLabel
            //
            this.TituloCircuitoLabel.AutoSize = true;
            this.TituloCircuitoLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloCircuitoLabel.Dock = DockStyle.Top;
            this.TituloCircuitoLabel.Name = "tituloCircuitoLabel";
            this.TituloCircuitoLabel.Size = new System.Drawing.Size(154, 24);
            this.TituloCircuitoLabel.TabIndex = 1;
            this.TituloCircuitoLabel.Text = "CIRCUITOS";

            resultado.Controls.Add(TituloCircuitoLabel);

            return resultado;

        }

        private FlowLayoutPanel BuildTablaCircuito()
        {
            var resultado = new FlowLayoutPanel { Dock = DockStyle.Top };
            //resultado.Location = new System.Drawing.Point(220, 0);
            resultado.Name = "panelTablaCircuito";
            resultado.Size = new System.Drawing.Size(1200, 205);
            resultado.TabIndex = 1;

            this.TablaCircuitoDataGridView = new DataGridView();

            this.TablaCircuitoDataGridView.ColumnCount = 5;
            TablaCircuitoDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            TablaCircuitoDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TablaCircuitoDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(TablaActividadDataGridView.Font, FontStyle.Bold);
            TablaCircuitoDataGridView.Name = "tablaActividadDataGridView";
            TablaCircuitoDataGridView.Dock = DockStyle.Left;
            TablaCircuitoDataGridView.Size = new Size(700, 200);
            TablaCircuitoDataGridView.MaximumSize = TablaActividadDataGridView.Size;
            TablaCircuitoDataGridView.MinimumSize = TablaActividadDataGridView.Size;
            TablaCircuitoDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            TablaCircuitoDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            TablaCircuitoDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            TablaCircuitoDataGridView.GridColor = Color.Black;
            TablaCircuitoDataGridView.RowHeadersVisible = true;
            TablaCircuitoDataGridView.Columns[0].Name = "Lugar";
            TablaCircuitoDataGridView.Columns[1].Name = "Distancia";
            TablaCircuitoDataGridView.Columns[2].Name = "Notas";
            TablaCircuitoDataGridView.Columns[3].Name = "Url";
            TablaCircuitoDataGridView.Columns[4].Name = "Eliminar";
            //TablaCircuitoDataGridView.Columns[4].DefaultCellStyle.Font = new Font(TablaActividadDataGridView.DefaultCellStyle.Font, FontStyle.Italic);
            TablaCircuitoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TablaCircuitoDataGridView.MultiSelect = false;

            resultado.Controls.Add(TablaCircuitoDataGridView);

            return resultado;
        }

        private Panel BuildTituloMedida()
        {
            var resultado = new Panel { Dock = DockStyle.Top };
            //resultado.Location = new System.Drawing.Point(0, 0);
            resultado.Name = "tituloMedida";
            resultado.Size = new System.Drawing.Size(1200, 40);
            resultado.TabIndex = 0;

            this.TituloMedidaLabel = new Label();
            //
            //TituloActividadLabel
            //
            this.TituloMedidaLabel.AutoSize = true;
            this.TituloMedidaLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloMedidaLabel.Dock = DockStyle.Top;
            this.TituloMedidaLabel.Name = "tituloMedidaLabel";
            this.TituloMedidaLabel.Size = new System.Drawing.Size(154, 24);
            this.TituloMedidaLabel.TabIndex = 1;
            this.TituloMedidaLabel.Text = "MEDIDAS";

            resultado.Controls.Add(TituloMedidaLabel);

            return resultado;

        }

        private FlowLayoutPanel BuildTablaMedida()
        {
            var resultado = new FlowLayoutPanel { Dock = DockStyle.Top };
            //resultado.Location = new System.Drawing.Point(220, 0);
            resultado.Name = "panelTablaActividades";
            resultado.Size = new System.Drawing.Size(1200, 230);
            resultado.TabIndex = 1;

            this.TablaMedidaDataGridView = new DataGridView();

            this.TablaMedidaDataGridView.ColumnCount = 5;
            TablaMedidaDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            TablaMedidaDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TablaMedidaDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(TablaActividadDataGridView.Font, FontStyle.Bold);
            TablaMedidaDataGridView.Name = "tablaActividadDataGridView";
            TablaMedidaDataGridView.Dock = DockStyle.Left;
            TablaMedidaDataGridView.Size = new Size(900, 200);
            TablaMedidaDataGridView.MaximumSize = TablaActividadDataGridView.Size;
            TablaMedidaDataGridView.MinimumSize = TablaActividadDataGridView.Size;
            TablaMedidaDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            TablaMedidaDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            TablaMedidaDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            TablaMedidaDataGridView.GridColor = Color.Black;
            TablaMedidaDataGridView.RowHeadersVisible = true;
            TablaMedidaDataGridView.ReadOnly = true;
            TablaMedidaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TablaMedidaDataGridView.Columns[0].Name = "Peso";
            TablaMedidaDataGridView.Columns[1].Name = "Circunferencia abdominal";
            TablaMedidaDataGridView.Columns[2].Name = "Notas";
            TablaMedidaDataGridView.Columns[3].Name = "Fecha";
            TablaMedidaDataGridView.Columns[4].Name = "Eliminar";

            //TablaMedidaDataGridView.Columns[4].DefaultCellStyle.Font = new Font(TablaActividadDataGridView.DefaultCellStyle.Font, FontStyle.Italic);
            TablaMedidaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TablaMedidaDataGridView.MultiSelect = false;

            resultado.Controls.Add(TablaMedidaDataGridView);

            return resultado;
        }

        private Panel BuildVacioColumna()
        {
            var resultado = new Panel { Dock = DockStyle.Left};
            //resultado.Location = new System.Drawing.Point(0, 0);
            resultado.Name = "vacioColumna";
            resultado.Size = new System.Drawing.Size(20, 719);
            resultado.TabIndex = 0;

            return resultado;
        }

            private FlowLayoutPanel BuildVacioFila()
        {

            var resultado = new FlowLayoutPanel { Dock = DockStyle.Top };
            //resultado.Location = new System.Drawing.Point(220, 0);
            resultado.Name = "vacioFila";
            resultado.Size = new System.Drawing.Size(1202, 5);
            resultado.TabIndex = 1;
            return resultado;
        }

        private void Build()
        {
            SuspendLayout();

            PanelPanel = new Panel { Dock = DockStyle.Fill };

            PanelPanel.SuspendLayout();

            Controls.Add(PanelPanel);

            var tituloActividad = BuildTituloActividad();
            var tablaActividad = BuildTablaActividad();
            var calendario = BuildCalendario();
            var tituloCircuito = BuildTituloCircuito();
            var tablaCircuito = BuildTablaCircuito();
            var tituloMedida = BuildTituloMedida();
            var tablaMedida = BuildTablaMedida();
            var menu = CreateMenu();
            PanelPanel.Controls.Add(BuildVacioFila());
            PanelPanel.Controls.Add(tablaMedida);
            PanelPanel.Controls.Add(tituloMedida);
            PanelPanel.Controls.Add(BuildVacioFila());
            PanelPanel.Controls.Add(tablaCircuito);
            PanelPanel.Controls.Add(tituloCircuito);
            PanelPanel.Controls.Add(BuildVacioFila());
            PanelPanel.Controls.Add(tablaActividad);
            PanelPanel.Controls.Add(tituloActividad);
            PanelPanel.Controls.Add(calendario);
            PanelPanel.Controls.Add(BuildVacioColumna());
            PanelPanel.Controls.Add(menu);
            PanelPanel.ResumeLayout(true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F,20F);
            this.MaximumSize = new Size(1800, 1080);
            this.MinimumSize = MaximumSize;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Load += new System.EventHandler(this.ActividadView_Load);
            //this.ClientSize = new System.Drawing.Size(1202, 1000);
            this.ResumeLayout(false);
            Text = "DIARIO DE ENTRENAMIENTO";
            BackColor = Color.White;
            ResumeLayout(false);
        }
    }
}
