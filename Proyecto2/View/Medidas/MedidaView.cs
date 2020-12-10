using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto2.View.Medidas
{
    public partial class MedidaView : Form
    {
        public Panel PanelPanel { get; set; }
        public Button VolverButton { get; set; }
        public Button InsertarButton { get; set; }
        public DateTimePicker FechaDateTimePicker { get; set; }
        public Label FechaLabel { get; set; }
        public TextBox NotaTextBox { get; set; }
        public Label NotaLabel { get; set; }
        public NumericUpDown PesoNumericUpDown { get; set; }
        public Label PesoLabel { get; set; }
        public NumericUpDown CircunferenciaAbdominalNumericUpDown { get; set; }
        public Label CircunferenciaAbdominalLabel { get; set; }

        //CONSTRUYE CAMPO PESO
        private Panel BuildPeso()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.PesoLabel = new Label();
            this.PesoNumericUpDown = new NumericUpDown();

            // 
            // pesoLabel
            // 
            this.PesoLabel.AutoSize = true;
            this.PesoLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PesoLabel.ForeColor = System.Drawing.Color.Black;
            this.PesoLabel.Dock = DockStyle.Left;
            this.PesoLabel.Name = "pesoLabel";
            this.PesoLabel.Size = new System.Drawing.Size(123, 35);
            this.PesoLabel.TabIndex = 21;
            this.PesoLabel.Text = "Peso";

            // 
            // pesoNumericUpDown
            // 
            this.PesoNumericUpDown.BackColor = System.Drawing.Color.White;
            this.PesoNumericUpDown.DecimalPlaces = 2;
            this.PesoNumericUpDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PesoNumericUpDown.ForeColor = System.Drawing.SystemColors.InfoText;
            this.PesoNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.PesoNumericUpDown.Dock = DockStyle.Left;
            this.PesoNumericUpDown.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.PesoNumericUpDown.Name = "pesoNumericUpDown";
            this.PesoNumericUpDown.Size = new System.Drawing.Size(74, 32);
            this.PesoNumericUpDown.TabIndex = 22;
            this.PesoNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            resultado.Controls.Add(PesoNumericUpDown);
            resultado.Controls.Add(PesoLabel);

            resultado.MaximumSize = new Size(int.MaxValue, PesoNumericUpDown.Height);

            return resultado;
        }

        //CONSTRUYE CAMPO CIRCUNFERENCIA ABDOMINAL
        private Panel BuildCircunferenciaAbdominal()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.CircunferenciaAbdominalLabel = new Label();
            this.CircunferenciaAbdominalNumericUpDown = new NumericUpDown();

            // 
            // circunferenciaAbdominalLabel
            // 
            this.CircunferenciaAbdominalLabel.AutoSize = true;
            this.CircunferenciaAbdominalLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircunferenciaAbdominalLabel.ForeColor = System.Drawing.Color.Black;
            this.CircunferenciaAbdominalLabel.Dock = DockStyle.Left;
            this.CircunferenciaAbdominalLabel.Name = "circunferenciaAbdominalLabel";
            this.CircunferenciaAbdominalLabel.Size = new System.Drawing.Size(123, 35);
            this.CircunferenciaAbdominalLabel.TabIndex = 21;
            this.CircunferenciaAbdominalLabel.Text = "CircunferenciaAbdominal";

            // 
            // circunferenciaAbdominalNumericUpDown
            // 
            this.CircunferenciaAbdominalNumericUpDown.BackColor = System.Drawing.Color.White;
            this.CircunferenciaAbdominalNumericUpDown.DecimalPlaces = 2;
            this.CircunferenciaAbdominalNumericUpDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircunferenciaAbdominalNumericUpDown.ForeColor = System.Drawing.SystemColors.InfoText;
            this.CircunferenciaAbdominalNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.CircunferenciaAbdominalNumericUpDown.Dock = DockStyle.Left;
            this.CircunferenciaAbdominalNumericUpDown.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.CircunferenciaAbdominalNumericUpDown.Name = "circunferenciaAbdominalNumericUpDown";
            this.CircunferenciaAbdominalNumericUpDown.Size = new System.Drawing.Size(74, 32);
            this.CircunferenciaAbdominalNumericUpDown.TabIndex = 22;
            this.CircunferenciaAbdominalNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            resultado.Controls.Add(CircunferenciaAbdominalNumericUpDown);
            resultado.Controls.Add(CircunferenciaAbdominalLabel);

            resultado.MaximumSize = new Size(int.MaxValue, CircunferenciaAbdominalNumericUpDown.Height);

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
            // insertarMedidaButton
            // 
            this.InsertarButton.BackColor = System.Drawing.Color.Transparent;
            this.InsertarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InsertarButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertarButton.Dock = DockStyle.Bottom;
            this.InsertarButton.BackgroundImage = Image.FromFile(@"img\\aceptar.png");
            this.InsertarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InsertarButton.FlatAppearance.BorderColor = Color.White;
            this.InsertarButton.Name = "insertarMedidaButton";
            this.InsertarButton.AutoSize = false;
            this.InsertarButton.MaximumSize = new Size(60, 50);
            this.InsertarButton.MinimumSize = this.InsertarButton.MaximumSize;
            this.InsertarButton.UseVisualStyleBackColor = false;
            //this.InsertarButton.Text = "INSERTAR";
            this.InsertarButton.Click += new System.EventHandler(this.InsertarMedidaButton_Click);
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

            resultado.MaximumSize = new Size(int.MaxValue, 25);

            return resultado;
        }

        //CONSTRUYE LA VENTANA DEL FORMULARIO
        public void Build()
        {

            PanelPanel = new TableLayoutPanel { Dock = DockStyle.Fill };

            var peso = BuildPeso();
            var circunferenciaAbdominal = BuildCircunferenciaAbdominal();
            var nota = BuildNota();
            var fecha = BuildFecha();
            var botones = BuildBotones();

            PanelPanel.SuspendLayout();

            Controls.Add(PanelPanel);

            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(peso);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(circunferenciaAbdominal);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(nota);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(fecha);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(botones);

            PanelPanel.ResumeLayout(true);

            Text = "MEDIDA";
            this.Icon = new Icon(@"img\\icono.ico");
            BackColor = Color.White;
            Size = new Size(500, (peso.Height + circunferenciaAbdominal.Height + nota.Height + fecha.Height + botones.Height) * 2 + 40);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }
    }
}
