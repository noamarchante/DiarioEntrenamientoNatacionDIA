using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto2.View.DiarioEntrenamiento
{
    public partial class DiarioEntrenamientoView : Form
    {
        public MenuStrip MenuPrincipalMenuStrip { get; set; }
        public ToolStripMenuItem MenuOpcionesToolStripMenuItem { get; set; }
        public ToolStripMenuItem MenuAnhadirActividadToolStripMenuItem { get; set; }
        public ToolStripMenuItem MenuAnhadirCircuitoToolStripMenuItem { get; set; }
        public ToolStripMenuItem MenuAnhadirMedidasToolStripMenuItem { get; set; }
        public ToolStripMenuItem MenuGraficosToolStripMenuItem { get; set; }
        public Panel PanelPanel { get; set; }
        public Label LibreLabel { get; set; }
        public Label OcupadoLabel { get; set; }
        public Label TituloActividadLabel { get; set; }
        public Label TituloCircuitoLabel { get; set; }
        public Label TituloMedidasLabel { get; set; }
        public Button EliminarActividadButton { get; set; }
        public Button EliminarCircuitoButton { get; set; }
        public Button EliminarMedidasButton { get; set; }
        public MonthCalendar CalendarioMonthCalendar { get; set; }
        public DataGridView TablaActividadDataGridView { get; set; }
        public DataGridView TablaCircuitoDataGridView { get; set; }
        public DataGridView TablaMedidasDataGridView { get; set; }
        public Button MostrarTodoButton { get; set; }

        //CONSTRUYE EL MENU SUPERIOR
        private MenuStrip BuildMenu()
        {
            MenuPrincipalMenuStrip = new MenuStrip();
            MenuOpcionesToolStripMenuItem = new ToolStripMenuItem();
            MenuAnhadirActividadToolStripMenuItem = new ToolStripMenuItem();
            MenuAnhadirCircuitoToolStripMenuItem = new ToolStripMenuItem();
            MenuAnhadirMedidasToolStripMenuItem = new ToolStripMenuItem();
            MenuGraficosToolStripMenuItem = new ToolStripMenuItem();

            //
            //Menu principal
            //
            this.MenuPrincipalMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPrincipalMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpcionesToolStripMenuItem, this.MenuGraficosToolStripMenuItem});
            this.MenuPrincipalMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipalMenuStrip.Name = "menuPrincipal";
            this.MenuPrincipalMenuStrip.Size = new System.Drawing.Size(1202, 28);
            this.MenuPrincipalMenuStrip.TabIndex = 0;
            this.MenuPrincipalMenuStrip.Text = "menuPrincipal";
            this.MenuPrincipalMenuStrip.BackColor = Color.GhostWhite;

            //
            // menu opciones
            //
            this.MenuOpcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAnhadirCircuitoToolStripMenuItem,
            this.MenuAnhadirActividadToolStripMenuItem,
            this.MenuAnhadirMedidasToolStripMenuItem});
            this.MenuOpcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.MenuOpcionesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.MenuOpcionesToolStripMenuItem.Text = "Formularios";
            //
            // menu gráficos
            //
            this.MenuGraficosToolStripMenuItem.Name = "graficosToolStripMenuItem";
            this.MenuGraficosToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.MenuGraficosToolStripMenuItem.Text = "Gráficos";
            this.MenuGraficosToolStripMenuItem.Click += new System.EventHandler(this.MenuGraficosToolStripMenuItem_Click);

            // 
            // añadirActividadToolStripMenuItem
            // 
            this.MenuAnhadirActividadToolStripMenuItem.Name = "añadirActividadToolStripMenuItem";
            this.MenuAnhadirActividadToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.MenuAnhadirActividadToolStripMenuItem.Text = "Añadir Actividad";
            this.MenuAnhadirActividadToolStripMenuItem.Click += new System.EventHandler(this.MenuAnhadirActividadToolStripMenuItem_Click);

            // 
            // añadirCircuitoToolStripMenuItem
            // 
            this.MenuAnhadirCircuitoToolStripMenuItem.Name = "añadirCircuitoToolStripMenuItem";
            this.MenuAnhadirCircuitoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.MenuAnhadirCircuitoToolStripMenuItem.Text = "Añadir Circuito";

            // 
            // añadirMedidasToolStripMenuItem
            // 
            this.MenuAnhadirMedidasToolStripMenuItem.Name = "añadirMedidasToolStripMenuItem";
            this.MenuAnhadirMedidasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.MenuAnhadirMedidasToolStripMenuItem.Text = "Añadir Medidas";
            this.MenuAnhadirMedidasToolStripMenuItem.Click += new System.EventHandler(this.MenuAnhadirMedidasToolStripMenuItem_Click);

            this.MenuPrincipalMenuStrip.ResumeLayout(false);
            this.MenuPrincipalMenuStrip.PerformLayout();

            return MenuPrincipalMenuStrip;
        }

        //CONSTRUYE EL CALENDARIO
        private Panel BuildCalendario()
        {
            var resultado = new Panel { Dock = DockStyle.Left };
            resultado.Name = "calendario";
            resultado.Size = new System.Drawing.Size(400, 719);
            resultado.TabIndex = 0;

            this.CalendarioMonthCalendar = new MonthCalendar();
            this.OcupadoLabel = new Label();
            this.LibreLabel = new Label();
            this.MostrarTodoButton = new Button();

            // calMonthCalendar
            // 
            this.CalendarioMonthCalendar.Location = new System.Drawing.Point(18, 33);
            this.CalendarioMonthCalendar.Dock = DockStyle.Top;
            this.CalendarioMonthCalendar.Name = "calendarioMonthCalendar";
            this.CalendarioMonthCalendar.ShowToday = false;
            this.CalendarioMonthCalendar.TabIndex = 0;
            this.CalendarioMonthCalendar.MaxSelectionCount = 1;
            this.CalendarioMonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.CalendarioMonthCalendar_DateChanged);

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

            // 
            // mostrarTodoButton
            // 
            this.MostrarTodoButton.BackColor = System.Drawing.Color.Transparent;
            this.MostrarTodoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MostrarTodoButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MostrarTodoButton.Dock = DockStyle.Top;
            this.MostrarTodoButton.Name = "MostrarTodoButton";
            this.MostrarTodoButton.AutoSize = false;
            this.MostrarTodoButton.MaximumSize = new Size(60, 50);
            this.MostrarTodoButton.FlatAppearance.BorderColor = Color.White;
            this.MostrarTodoButton.MinimumSize = this.MostrarTodoButton.MaximumSize;
            this.MostrarTodoButton.UseVisualStyleBackColor = false;
            //this.MostrarTodoButton.Text = "MOSTRAR TODO";
            this.MostrarTodoButton.Enabled = false;
            this.MostrarTodoButton.Visible = false;
            this.MostrarTodoButton.BackgroundImage = Image.FromFile(@"img\\cancelar.png");
            this.MostrarTodoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MostrarTodoButton.Click += new System.EventHandler(this.MostrarTodoButton_Click);

            resultado.Controls.Add(MostrarTodoButton);
            resultado.Controls.Add(BuildVacioFila());
            resultado.Controls.Add(BuildVacioFila());
            resultado.Controls.Add(BuildVacioFila());
            resultado.Controls.Add(LibreLabel);
            resultado.Controls.Add(OcupadoLabel);
            resultado.Controls.Add(CalendarioMonthCalendar);

            return resultado;
        }

        //CONSTRUYE EL TITULO DE LA TABLA ACTIVIDAD
        private Panel BuildTituloActividad()
        {
            var resultado = new Panel { Dock = DockStyle.Top };
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

        //CONSTRUYE TABLA ACTIVIDAD
        private FlowLayoutPanel BuildTablaActividad()
        {
            var resultado = new FlowLayoutPanel { Dock = DockStyle.Top };
            resultado.Name = "panelTablaActividades";
            resultado.Size = new System.Drawing.Size(1200, 205);
            resultado.TabIndex = 1;

            this.TablaActividadDataGridView = new DataGridView();

            //
            // TablaActividadDataGridView
            //
            this.TablaActividadDataGridView.ColumnCount = 6;
            TablaActividadDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            TablaActividadDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Transparent;
            TablaActividadDataGridView.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            TablaActividadDataGridView.BackgroundColor = Color.White;
            TablaActividadDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Transparent;
            TablaActividadDataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            TablaActividadDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TablaActividadDataGridView.Name = "tablaActividadDataGridView";
            TablaActividadDataGridView.Dock = DockStyle.Top;
            TablaActividadDataGridView.Size = new Size(1050, 200);
            TablaActividadDataGridView.MaximumSize = TablaActividadDataGridView.Size;
            TablaActividadDataGridView.MinimumSize = TablaActividadDataGridView.Size;
            TablaActividadDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            TablaActividadDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            TablaActividadDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            TablaActividadDataGridView.GridColor = Color.Black;
            TablaActividadDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.GhostWhite;
            TablaActividadDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            TablaActividadDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TablaActividadDataGridView.RowHeadersVisible = false;
            TablaActividadDataGridView.ReadOnly = true;
            TablaActividadDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TablaActividadDataGridView.AutoGenerateColumns = false;
            TablaActividadDataGridView.Columns[0].Name = "Distancia";
            TablaActividadDataGridView.Columns[1].Name = "Tiempo";
            TablaActividadDataGridView.Columns[2].Name = "Notas";
            TablaActividadDataGridView.Columns[3].Name = "Fecha";
            TablaActividadDataGridView.Columns[4].Name = "Circuito";
            TablaActividadDataGridView.Columns[5].Name = "indice";
            TablaActividadDataGridView.Columns[5].Visible = false;

            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "";
                //buttons.Text = "Eliminar";
                buttons.Name = "Eliminar";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Flat;
                buttons.CellTemplate.Style.BackColor = Color.Transparent;
                buttons.CellTemplate.Style.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                buttons.DisplayIndex = 6;
                buttons.CellTemplate.Style.SelectionBackColor = Color.Transparent;
            }
            TablaActividadDataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(this.DataGridView_CellPainting);
            TablaActividadDataGridView.Columns.Add(buttons);

            this.TablaActividadDataGridView.CellContentClick += new DataGridViewCellEventHandler(this.TablaActividadDataGridView_CellContentClick);
            TablaActividadDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TablaActividadDataGridView.MultiSelect = false;
            resultado.Controls.Add(TablaActividadDataGridView);

            return resultado;
        }

        //CONSTRUYE TITULO TABLA CIRCUITO
        private Panel BuildTituloCircuito()
        {
            var resultado = new Panel { Dock = DockStyle.Top };
            resultado.Name = "tituloCircuito";
            resultado.Size = new System.Drawing.Size(982, 40);
            resultado.TabIndex = 0;

            this.TituloCircuitoLabel = new Label();

            //
            //TituloCircuitoLabel
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

        //CONSTRUYE TABLA CIRCUITO
        private FlowLayoutPanel BuildTablaCircuito()
        {
            var resultado = new FlowLayoutPanel { Dock = DockStyle.Top };
            resultado.Name = "panelTablaCircuito";
            resultado.Size = new System.Drawing.Size(1200, 205);
            resultado.TabIndex = 1;

            this.TablaCircuitoDataGridView = new DataGridView();

            this.TablaCircuitoDataGridView.ColumnCount = 4;
            TablaCircuitoDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            TablaCircuitoDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TablaCircuitoDataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            TablaCircuitoDataGridView.BackgroundColor = Color.White;
            TablaCircuitoDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TablaCircuitoDataGridView.Name = "tablaActividadDataGridView";
            TablaCircuitoDataGridView.Dock = DockStyle.Left;
            TablaCircuitoDataGridView.Size = new Size(700, 200);
            TablaCircuitoDataGridView.MaximumSize = TablaActividadDataGridView.Size;
            TablaCircuitoDataGridView.MinimumSize = TablaActividadDataGridView.Size;
            TablaCircuitoDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            TablaCircuitoDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            TablaCircuitoDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            TablaCircuitoDataGridView.GridColor = Color.Black;
            TablaCircuitoDataGridView.RowHeadersVisible = false;
            TablaCircuitoDataGridView.ReadOnly = true;
            TablaCircuitoDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TablaCircuitoDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.GhostWhite;
            TablaCircuitoDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;

            TablaCircuitoDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            TablaCircuitoDataGridView.Columns[0].Name = "Lugar";
            TablaCircuitoDataGridView.Columns[1].Name = "Distancia";
            TablaCircuitoDataGridView.Columns[2].Name = "Notas";
            TablaCircuitoDataGridView.Columns[3].Name = "Url";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "";
                //buttons.Text = "Eliminar";
                buttons.Name = "Eliminar";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Flat;
                buttons.CellTemplate.Style.BackColor = Color.Transparent;
                buttons.CellTemplate.Style.SelectionBackColor = Color.Transparent;
                buttons.CellTemplate.Style.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                buttons.DisplayIndex = 4;
            }
            TablaCircuitoDataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(this.DataGridView_CellPainting);
            TablaCircuitoDataGridView.Columns.Add(buttons);
            TablaCircuitoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TablaCircuitoDataGridView.MultiSelect = false;

            resultado.Controls.Add(TablaCircuitoDataGridView);

            return resultado;
        }

        //CONSTRUYE TITULO TABLA MEDIDAS
        private Panel BuildTituloMedidas()
        {
            var resultado = new Panel { Dock = DockStyle.Top };
            resultado.Name = "tituloMedidas";
            resultado.Size = new System.Drawing.Size(1200, 40);
            resultado.TabIndex = 0;

            this.TituloMedidasLabel = new Label();

            //
            //TituloActividadLabel
            //
            this.TituloMedidasLabel.AutoSize = true;
            this.TituloMedidasLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloMedidasLabel.Dock = DockStyle.Top;
            this.TituloMedidasLabel.Name = "tituloMedidasLabel";
            this.TituloMedidasLabel.Size = new System.Drawing.Size(154, 24);
            this.TituloMedidasLabel.TabIndex = 1;
            this.TituloMedidasLabel.Text = "MEDIDAS";

            resultado.Controls.Add(TituloMedidasLabel);

            return resultado;
        }

        //CONSTRUYE TABLA MEDIDAS
        private FlowLayoutPanel BuildTablaMedidas()
        {
            var resultado = new FlowLayoutPanel { Dock = DockStyle.Top };
            resultado.Name = "panelTablaActividades";
            resultado.Size = new System.Drawing.Size(1200, 230);
            resultado.TabIndex = 1;

            this.TablaMedidasDataGridView = new DataGridView();

            this.TablaMedidasDataGridView.ColumnCount = 4;
            TablaMedidasDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            TablaMedidasDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TablaMedidasDataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            TablaMedidasDataGridView.BackgroundColor = Color.White;
            TablaMedidasDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TablaMedidasDataGridView.Name = "tablaActividadDataGridView";
            TablaMedidasDataGridView.Dock = DockStyle.Left;
            TablaMedidasDataGridView.Size = new Size(900, 200);
            TablaMedidasDataGridView.MaximumSize = TablaActividadDataGridView.Size;
            TablaMedidasDataGridView.MinimumSize = TablaActividadDataGridView.Size;
            TablaMedidasDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            TablaMedidasDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            TablaMedidasDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            TablaMedidasDataGridView.GridColor = Color.Black;
            TablaMedidasDataGridView.RowHeadersVisible = false;
            TablaMedidasDataGridView.ReadOnly = true;
            TablaMedidasDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TablaMedidasDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.GhostWhite;
            TablaMedidasDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;

            TablaMedidasDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            TablaMedidasDataGridView.Columns[0].Name = "Peso";
            TablaMedidasDataGridView.Columns[1].Name = "Circunferencia abdominal";
            TablaMedidasDataGridView.Columns[2].Name = "Notas";
            TablaMedidasDataGridView.Columns[3].Name = "Fecha";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "";
                //buttons.Text = "Eliminar";
                buttons.Name = "Eliminar";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Flat;
                buttons.CellTemplate.Style.BackColor = Color.Transparent;
                buttons.CellTemplate.Style.SelectionBackColor = Color.Transparent;
                buttons.CellTemplate.Style.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                buttons.DisplayIndex = 4;
            }
            TablaMedidasDataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(this.DataGridView_CellPainting);
            TablaMedidasDataGridView.Columns.Add(buttons);

            this.TablaMedidasDataGridView.CellContentClick += new DataGridViewCellEventHandler(this.TablaMedidaDataGridView_CellContentClick);
            TablaMedidasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TablaMedidasDataGridView.MultiSelect = false;

            resultado.Controls.Add(TablaMedidasDataGridView);

            return resultado;
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

        //CONSTRUYE VENTANA PRINCIPAL
        private void Build()
        {
            PanelPanel = new Panel { Dock = DockStyle.Fill };

            PanelPanel.SuspendLayout();

            Controls.Add(PanelPanel);

            var tituloActividad = BuildTituloActividad();
            var tablaActividad = BuildTablaActividad();
            var calendario = BuildCalendario();
            var tituloCircuito = BuildTituloCircuito();
            var tablaCircuito = BuildTablaCircuito();
            var tituloMedidas = BuildTituloMedidas();
            var tablaMedidas = BuildTablaMedidas();
            var menu = BuildMenu();


            PanelPanel.Controls.Add(BuildVacioFila());
            PanelPanel.Controls.Add(tablaMedidas);
            PanelPanel.Controls.Add(tituloMedidas);
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


            this.Icon = new Icon(@"img\\icono.ico");
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.MaximumSize = new Size(1800, 1080);
            this.MinimumSize = MaximumSize;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Text = "DIARIO DE ENTRENAMIENTO";
            BackColor = Color.White;
            ResumeLayout(false);
        }
    }
}
