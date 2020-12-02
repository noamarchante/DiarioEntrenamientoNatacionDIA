using Proyecto2.Core;
using Proyecto2.View.DiarioEntrenamiento;
using System;
using System.Windows.Forms;

namespace Proyecto2.View.Actividad
{
    public partial class ActividadView : Form
    {
        public DiaEntrenamiento dia;
        public DiarioEntrenamientoView diario;

        public ActividadView(DiarioEntrenamientoView diario)
        {
            Build();
            dia = new DiaEntrenamiento();
            this.diario = diario;
        }

        /*public ActividadView()
        {
            Build();
        }*/
        /*private void ActividadView_Load(object sender, EventArgs e)
        {
            if (CircuitoView.circuitos.Count == 0)
            {
                this.circuitoComboBox.Enabled = false;
            }
            else
            {
                int i = 0;
                foreach (var circuito in CircuitoView.circuitos)
                {
                    i++;
                    this.circuitoComboBox.Items.Add("Circuito " + i + "-" + circuito.Lugar);
                }
                this.circuitoComboBox.SelectedIndex = 0;
                this.circuitoComboBox.FormattingEnabled = false;
                this.fechaDateTimePicker.Value = DateTime.Today;
            }
        }*/

        private void insertarActividadButton_Click(object sender, EventArgs e)
        {          
            /* if (CircuitoView.circuitos.Count == 0)
             {
                 this.insertarActividadButton.Enabled = false;
             }
             else
             {*/
            Tiempo tiempo = new Tiempo((int)this.MinutosNumericUpDown.Value, (int)this.SegundosNumericUpDown.Value);
            dia.Dia = this.FechaDateTimePicker.Value;
            if (Program.actividades.getTuplaDesdeFecha(dia.Dia).Key == null)
            {
                dia.AñadirActividadesDia(new Core.Actividad(tiempo, (Double)this.DistanciaNumericUpDown.Value, /*CircuitoView.circuitos[this.circuitoComboBox.SelectedIndex]*/null, this.NotaTextBox.Text));
                dia.Dia = this.FechaDateTimePicker.Value;
                Program.actividades.AñadirDia(dia);
            }
            else
            {
                var diaSeleccionado = Program.actividades.getTuplaDesdeFecha(dia.Dia);
                Program.actividades.EliminarDia(diaSeleccionado.Key);
                this.dia = diaSeleccionado.Key;
                dia.AñadirActividadesDia(new Core.Actividad(tiempo, (Double)this.DistanciaNumericUpDown.Value, /*CircuitoView.circuitos[this.circuitoComboBox.SelectedIndex]*/null, this.NotaTextBox.Text));
                dia.Dia = this.FechaDateTimePicker.Value;
                if(diaSeleccionado.Value != null)
                {
                    Program.actividades.AñadirDiaMedidas(dia,diaSeleccionado.Value);
                }
                else
                {
                    Program.actividades.AñadirDia(dia);
                }
            }
            this.diario.Hide();
            this.diario.Show();
            this.Close();
            //}
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
