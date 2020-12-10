using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto2.View.Actividad
{
    public partial class ActividadView:Form
    {
        public Panel PanelPanel { get; set; }
        public Button VolverButton { get; set; }
        public Button InsertarButton { get; set; }
        public DateTimePicker FechaDateTimePicker { get; set; }
        public Label FechaLabel { get; set; }
        public TextBox NotaTextBox { get; set; }
        public Label NotaLabel { get; set; }
        public ComboBox CircuitoComboBox { get; set; }
        public Label CircuitoLabel { get; set; }
        public NumericUpDown DistanciaNumericUpDown { get; set; }
        public Label DistanciaLabel { get; set; }
        public NumericUpDown SegundosNumericUpDown { get; set; }
        public Label SegundosLabel { get; set; }
        public NumericUpDown MinutosNumericUpDown { get; set; }
        public Label MinutosLabel { get; set; }
        public Label TiempoLabel { get; set; }

        //CONSTRUYE CAMPO MINUTOS
        private Panel BuildMinutos()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.TiempoLabel = new Label();
            this.MinutosLabel = new Label();
            this.MinutosNumericUpDown = new NumericUpDown();

            // 
            // minutosLabel
            // 
            this.MinutosLabel.AutoSize = true;
            this.MinutosLabel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinutosLabel.ForeColor = System.Drawing.Color.Black;
            this.MinutosLabel.Dock = DockStyle.Left;
            this.MinutosLabel.Name = "minutosLabel";
            this.MinutosLabel.Size = new System.Drawing.Size(97, 29);
            this.MinutosLabel.TabIndex = 1;
            this.MinutosLabel.Text = "Minutos";
            this.MinutosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // minutosNumericUpDown
            // 
            this.MinutosNumericUpDown.BackColor = System.Drawing.Color.White;
            this.MinutosNumericUpDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinutosNumericUpDown.ForeColor = System.Drawing.SystemColors.InfoText;
            this.MinutosNumericUpDown.Dock = DockStyle.Left;
            this.MinutosNumericUpDown.Name = "minutosNumericUpDown";
            this.MinutosNumericUpDown.Size = new System.Drawing.Size(74, 32);
            this.MinutosNumericUpDown.TabIndex = 0;
            this.MinutosNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            resultado.Controls.Add(MinutosNumericUpDown);
            resultado.Controls.Add(MinutosLabel);

            resultado.MaximumSize = new Size(int.MaxValue / 2, MinutosNumericUpDown.Height * 10);

            return resultado;
        }

        //CONSTRUYE CAMPO SEGUNDOS
        private Panel BuildSegundos()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.SegundosLabel = new Label();
            this.SegundosNumericUpDown = new NumericUpDown();
            
            // 
            // segundosLabel
            // 
            this.SegundosLabel.AutoSize = true;
            this.SegundosLabel.BackColor = System.Drawing.Color.Transparent;
            this.SegundosLabel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegundosLabel.ForeColor = System.Drawing.Color.Black;
            this.SegundosLabel.Dock = DockStyle.Left;
            this.SegundosLabel.Name = "segundosLabel";
            this.SegundosLabel.Size = new System.Drawing.Size(109, 29);
            this.SegundosLabel.TabIndex = 3;
            this.SegundosLabel.Text = "Segundos";
            this.SegundosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // segundosNumericUpDown
            // 
            this.SegundosNumericUpDown.BackColor = System.Drawing.Color.White;
            this.SegundosNumericUpDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegundosNumericUpDown.ForeColor = System.Drawing.SystemColors.InfoText;
            this.SegundosNumericUpDown.Dock = DockStyle.Left;
            this.SegundosNumericUpDown.Name = "minutosNumericUpDown";
            this.SegundosNumericUpDown.Size = new System.Drawing.Size(74, 32);
            this.SegundosNumericUpDown.TabIndex = 0;
            this.SegundosNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            resultado.Controls.Add(SegundosNumericUpDown);
            resultado.Controls.Add(SegundosLabel);

            resultado.MaximumSize = new Size(int.MaxValue / 2, SegundosNumericUpDown.Height);

            return resultado;
        }

        //CONSTRUYE CAMPO TIEMPO
        private Panel BuildTiempo()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            Panel minutos = BuildMinutos();
            Panel segundos = BuildSegundos();

            minutos.Dock = DockStyle.Left;
            segundos.Dock = DockStyle.Left;

            resultado.Controls.Add(segundos);
            resultado.Controls.Add(minutos);

            resultado.MaximumSize = new Size(int.MaxValue, segundos.Height);

            return resultado;
        }

        //CONSTRUYE CAMPO DISTANCIA
        private Panel BuildDistancia()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.DistanciaLabel = new Label();
            this.DistanciaNumericUpDown = new NumericUpDown();

            // 
            // distanciaLabel
            // 
            this.DistanciaLabel.AutoSize = true;
            this.DistanciaLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DistanciaLabel.ForeColor = System.Drawing.Color.Black;
            this.DistanciaLabel.Dock = DockStyle.Left;
            this.DistanciaLabel.Name = "distanciaLabel";
            this.DistanciaLabel.Size = new System.Drawing.Size(123, 35);
            this.DistanciaLabel.TabIndex = 21;
            this.DistanciaLabel.Text = "Distancia";
            
            // 
            // distanciaNumericUpDown
            // 
            this.DistanciaNumericUpDown.BackColor = System.Drawing.Color.White;
            this.DistanciaNumericUpDown.DecimalPlaces = 2;
            this.DistanciaNumericUpDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DistanciaNumericUpDown.ForeColor = System.Drawing.SystemColors.InfoText;
            this.DistanciaNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.DistanciaNumericUpDown.Dock = DockStyle.Left;
            this.DistanciaNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DistanciaNumericUpDown.Name = "distanciaNumericUpDown";
            this.DistanciaNumericUpDown.Size = new System.Drawing.Size(74, 32);
            this.DistanciaNumericUpDown.TabIndex = 22;
            this.DistanciaNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            resultado.Controls.Add(DistanciaNumericUpDown);
            resultado.Controls.Add(DistanciaLabel);

            resultado.MaximumSize = new Size(int.MaxValue, DistanciaNumericUpDown.Height);

            return resultado;
        }

        //CONSTRUYE CAMPO CIRCUITO
        private Panel BuildCircuito()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.CircuitoLabel = new Label();
            this.CircuitoComboBox = new ComboBox();

            // 
            // circuitoLabel
            // 
            this.CircuitoLabel.AutoSize = true;
            this.CircuitoLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircuitoLabel.ForeColor = System.Drawing.Color.Black;
            this.CircuitoLabel.Dock = DockStyle.Left;
            this.CircuitoLabel.Name = "circuitoLabel";
            this.CircuitoLabel.Size = new System.Drawing.Size(106, 35);
            this.CircuitoLabel.TabIndex = 9;
            this.CircuitoLabel.Text = "Circuito";
            
            // 
            // circuitoComboBox
            // 
            this.CircuitoComboBox.BackColor = System.Drawing.Color.White;
            this.CircuitoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CircuitoComboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircuitoComboBox.Dock = DockStyle.Left;
            this.CircuitoComboBox.Name = "circuitoComboBox";
            this.CircuitoComboBox.Size = new System.Drawing.Size(391, 32);
            this.CircuitoComboBox.TabIndex = 18;

            resultado.Controls.Add(CircuitoComboBox);
            resultado.Controls.Add(CircuitoLabel);

            resultado.MaximumSize = new Size(int.MaxValue, CircuitoComboBox.Height);

            return resultado;
        }

        //CONSTRUYE EL CAMPO NOTA
        private Panel BuildNota()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.NotaLabel = new Label();
            this.NotaTextBox = new TextBox();

            // 
            // notaLabel
            // 
            this.NotaLabel.AutoSize = true;
            this.NotaLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotaLabel.ForeColor = System.Drawing.Color.Black;
            this.NotaLabel.Dock = DockStyle.Left;
            this.NotaLabel.Name = "notaLabel";
            this.NotaLabel.Size = new System.Drawing.Size(72, 35);
            this.NotaLabel.TabIndex = 19;
            this.NotaLabel.Text = "Nota";
           
            // 
            // notaTextBox
            // 
            this.NotaTextBox.BackColor = System.Drawing.Color.White;
            this.NotaTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotaTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NotaTextBox.Dock = DockStyle.Left;
            this.NotaTextBox.Multiline = true;
            this.NotaTextBox.Name = "notaTextBox";
            this.NotaTextBox.Size = new System.Drawing.Size(391, 36);
            this.NotaTextBox.TabIndex = 12;

            resultado.Controls.Add(NotaTextBox);
            resultado.Controls.Add(NotaLabel);

            resultado.MaximumSize = new Size(int.MaxValue, NotaTextBox.Height);

            return resultado;
        }

        //CONSTRUYE EL CAMPO FECHA
        private Panel BuildFecha()
        {

            var resultado = new Panel { Dock = DockStyle.Top };

            this.FechaLabel = new Label();
            this.FechaDateTimePicker = new DateTimePicker();

            // 
            // fechaLabel
            // 
            this.FechaLabel.AutoSize = true;
            this.FechaLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaLabel.ForeColor = System.Drawing.Color.Black;
            this.FechaLabel.Dock = DockStyle.Left;
            this.FechaLabel.Name = "fechaLabel";
            this.FechaLabel.Size = new System.Drawing.Size(83, 35);
            this.FechaLabel.TabIndex = 15;
            this.FechaLabel.Text = "Fecha";
            
            // 
            // fechaDateTimePicker
            // 
            this.FechaDateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.FechaDateTimePicker.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDateTimePicker.Dock = DockStyle.Left;
            this.FechaDateTimePicker.Name = "fechaDateTimePicker";
            this.FechaDateTimePicker.Size = new System.Drawing.Size(391, 32);
            this.FechaDateTimePicker.Value = DateTime.Now;
            this.FechaDateTimePicker.TabIndex = 14;

            resultado.Controls.Add(FechaDateTimePicker);
            resultado.Controls.Add(FechaLabel);

            resultado.MaximumSize = new Size(int.MaxValue, FechaDateTimePicker.Height);

            return resultado;
        }

        //CONSTRUYE EL BOTON INSERTAR
        private Panel BuildInsertar()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.InsertarButton = new Button();

            // 
            // insertarActividadButton
            // 
            this.InsertarButton.BackColor = System.Drawing.Color.Transparent;
            this.InsertarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InsertarButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertarButton.Dock = DockStyle.Bottom;
            this.InsertarButton.BackgroundImage = Image.FromFile(@"img\\aceptar.png");
            this.InsertarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InsertarButton.FlatAppearance.BorderColor = Color.White;
            this.InsertarButton.Name = "insertarActividadButton";
            this.InsertarButton.AutoSize = false;
            this.InsertarButton.MaximumSize = new Size(60, 50);
            this.InsertarButton.MinimumSize = this.InsertarButton.MaximumSize;
            this.InsertarButton.UseVisualStyleBackColor = false;
            //this.InsertarButton.Text = "INSERTAR";
            this.InsertarButton.Click += new System.EventHandler(this.InsertarActividadButton_Click);
            resultado.Controls.Add(InsertarButton);

            resultado.MaximumSize = new Size(int.MaxValue / 2, InsertarButton.Height);

            return resultado;
        }

        //CONSTRUYE EL BOTON VOLVER
        private Panel BuildVolver()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.VolverButton = new Button();

            // 
            // volverButton
            // 
            this.VolverButton.BackColor = System.Drawing.Color.Transparent;
            this.VolverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VolverButton.Dock = DockStyle.Bottom;
            this.VolverButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolverButton.Name = "volverButton";
            this.VolverButton.BackgroundImage = Image.FromFile(@"img\\volver.png");
            this.VolverButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VolverButton.AutoSize = false;
            this.VolverButton.MaximumSize = new Size(60, 50);
            this.VolverButton.FlatAppearance.BorderColor = Color.White;
            this.VolverButton.MinimumSize = this.VolverButton.MaximumSize;
            this.VolverButton.UseVisualStyleBackColor = false;
            //this.VolverButton.Text = "VOLVER";
            this.VolverButton.Click += new System.EventHandler(this.VolverButton_Click);

            resultado.Controls.Add(VolverButton);

            resultado.MaximumSize = new Size(int.MaxValue / 2, VolverButton.Height);

            return resultado;
        }

        //CONSTRUYE LOS BOTONES
        private Panel BuildBotones()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            Panel insertar = BuildInsertar();
            Panel volver = BuildVolver();

            insertar.Dock = DockStyle.Right;
            volver.Dock = DockStyle.Right;

            
            resultado.Controls.Add(volver);
            resultado.Controls.Add(insertar);

            resultado.MaximumSize = new Size(int.MaxValue, volver.Height);

            return resultado;
        }

        //CONSTRUYE CAMPO VACIO
        private Panel BuildVacio()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            resultado.MaximumSize = new Size(int.MaxValue,25);

            return resultado;
        }

        //CONSTRUYE LA VENTANA DEL FORMULARIO
        public void Build()
        {

            PanelPanel = new TableLayoutPanel { Dock = DockStyle.Fill };

            var tiempo = BuildTiempo();
            var distancia = BuildDistancia();
            var circuito = BuildCircuito();
            var nota = BuildNota();
            var fecha = BuildFecha();
            var botones = BuildBotones();

            PanelPanel.SuspendLayout();

            Controls.Add(PanelPanel);

            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(tiempo);
            PanelPanel.Controls.Add(BuildVacio()); 
            PanelPanel.Controls.Add(distancia);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(circuito);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(nota);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(fecha);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(botones);

            PanelPanel.ResumeLayout(true);

            Text = "ACTIVIDAD";
            this.Icon = new Icon(@"img\\icono.ico");
            this.Load += new System.EventHandler(this.ActividadView_Load);
            BackColor = Color.White;
            Size = new Size(500, (tiempo.Height + distancia.Height + circuito.Height + nota.Height + fecha.Height + botones.Height) * 2 + 40);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }
    }
}
