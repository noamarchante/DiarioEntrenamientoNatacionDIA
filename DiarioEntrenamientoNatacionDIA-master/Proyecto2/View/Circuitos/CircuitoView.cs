using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto2.View.Circuito
{
    public partial class CircuitoView : Form
    {
        public Panel PanelPanel { get; set; }
        public Button VolverButton { get; set; }
        public Button InsertarButton { get; set; }
        public TextBox NotaTextBox { get; set; }
        public Label NotaLabel { get; set; }
        public TextBox LugarTextBox { get; set; }
        public Label LugarLabel { get; set; }
        public NumericUpDown DistanciaNumericUpDown { get; set; }
        public Label DistanciaLabel { get; set; }
        public TextBox UrlTextBox { get; set; }
        public Label UrlLabel { get; set; }


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

        //CONSTRUYE EL CAMPO LUGAR
        private Panel BuildLugar()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.LugarLabel = new Label();
            this.LugarTextBox = new TextBox();

            // 
            // lugarLabel
            // 
            this.LugarLabel.AutoSize = true;
            this.LugarLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LugarLabel.ForeColor = System.Drawing.Color.Black;
            this.LugarLabel.Dock = DockStyle.Left;
            this.LugarLabel.Name = "lugarLabel";
            this.LugarLabel.Size = new System.Drawing.Size(72, 35);
            this.LugarLabel.TabIndex = 19;
            this.LugarLabel.Text = "Lugar";

            // 
            // lugarTextBox
            // 
            this.LugarTextBox.BackColor = System.Drawing.Color.White;
            this.LugarTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LugarTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LugarTextBox.Dock = DockStyle.Left;
            this.LugarTextBox.Multiline = true;
            this.LugarTextBox.Name = "notaTextBox";
            this.LugarTextBox.Size = new System.Drawing.Size(391, 36);
            this.LugarTextBox.TabIndex = 12;

            resultado.Controls.Add(LugarTextBox);
            resultado.Controls.Add(LugarLabel);

            resultado.MaximumSize = new Size(int.MaxValue, LugarTextBox.Height);

            return resultado;
        }

        //CONSTRUYE EL CAMPO URL
        private Panel BuildUrl()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.UrlLabel = new Label();
            this.UrlTextBox = new TextBox();

            // 
            // lugarLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlLabel.ForeColor = System.Drawing.Color.Black;
            this.UrlLabel.Dock = DockStyle.Left;
            this.UrlLabel.Name = "lugarLabel";
            this.UrlLabel.Size = new System.Drawing.Size(72, 35);
            this.UrlLabel.TabIndex = 19;
            this.UrlLabel.Text = "Url";

            // 
            // UrlTextBox
            // 
            this.UrlTextBox.BackColor = System.Drawing.Color.White;
            this.UrlTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.UrlTextBox.Dock = DockStyle.Left;
            this.UrlTextBox.Multiline = true;
            this.UrlTextBox.Name = "notaTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(391, 36);
            this.UrlTextBox.TabIndex = 12;

            resultado.Controls.Add(UrlTextBox);
            resultado.Controls.Add(UrlLabel);

            resultado.MaximumSize = new Size(int.MaxValue, UrlTextBox.Height);

            return resultado;
        }

        //CONSTRUYE EL BOTON INSERTAR
        private Panel BuildInsertar()
        {
            var resultado = new Panel { Dock = DockStyle.Top };

            this.InsertarButton = new Button();

            // 
            // insertarCircuitoButton
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
            this.InsertarButton.Click += new System.EventHandler(this.InsertarCircuitoButton_Click);
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
            var distancia = BuildDistancia();
            var nota = BuildNota();
            var lugar = BuildLugar();
            var url = BuildUrl();
            var botones = BuildBotones();

            PanelPanel.SuspendLayout();

            Controls.Add(PanelPanel);

            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(distancia);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(nota);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(lugar);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(url);
            PanelPanel.Controls.Add(BuildVacio());
            PanelPanel.Controls.Add(botones);

            PanelPanel.ResumeLayout(true);

            Text = "CIRCUITO";
            this.Icon = new Icon(@"img\\icono.ico");
            BackColor = Color.White;
            Size = new Size(500, (distancia.Height + nota.Height + lugar.Height + url.Height + botones.Height) * 2 + 40);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }
    }
}
