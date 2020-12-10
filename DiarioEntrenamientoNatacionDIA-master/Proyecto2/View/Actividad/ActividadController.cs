using Proyecto2.Core;
using Proyecto2.View.DiarioEntrenamiento;
using System;
using System.Windows.Forms;

namespace Proyecto2.View.Actividad
{
    public partial class  
        ActividadView : Form
    {
        public DiaEntrenamiento diaEntrenamiento;
        public DiarioEntrenamientoView diarioEntrenamiento;

        public ActividadView(DiarioEntrenamientoView diarioEntrenamiento)
        {
            Build();
            diaEntrenamiento = new DiaEntrenamiento();
            this.diarioEntrenamiento = diarioEntrenamiento;
        }

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

        //EL BOTON INSERTAR INSERTA UNA ACTIVIDAD
        private void InsertarActividadButton_Click(object sender, EventArgs e)
        {          
            /* if (CircuitoView.circuitos.Count == 0)
             {
                 this.insertarActividadButton.Enabled = false;
             }
             else
             {*/
            Tiempo tiempo = new Tiempo((int)this.MinutosNumericUpDown.Value, (int)this.SegundosNumericUpDown.Value);
            diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
            if (Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(diaEntrenamiento.Fecha).Key == null)
            {
                diaEntrenamiento.AñadirActividad(new Core.Actividad(diaEntrenamiento.actividades.Count,tiempo, (Double)this.DistanciaNumericUpDown.Value, /*CircuitoView.circuitos[this.circuitoComboBox.SelectedIndex]*/new Core.Circuito((double)3,"","",""), this.NotaTextBox.Text));
                diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
                Program.diarioEntrenamiento.AñadirDiaEntrenamiento(diaEntrenamiento);
            }
            else
            {
                var diaEntrenamientoSeleccionado = Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(this.diaEntrenamiento.Fecha);
                Program.diarioEntrenamiento.EliminarDia(diaEntrenamientoSeleccionado.Key);
                this.diaEntrenamiento = diaEntrenamientoSeleccionado.Key;
                this.diaEntrenamiento.AñadirActividad(new Core.Actividad(this.diaEntrenamiento.actividades.Count, tiempo, (Double)this.DistanciaNumericUpDown.Value, /*CircuitoView.circuitos[this.circuitoComboBox.SelectedIndex]*/new Core.Circuito((double)3, "", "", ""), this.NotaTextBox.Text));
                this.diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
                if(diaEntrenamientoSeleccionado.Value != null)
                {
                    Program.diarioEntrenamiento.AñadirDiaYMedida(this.diaEntrenamiento, diaEntrenamientoSeleccionado.Value);
                }
                else
                {
                    Program.diarioEntrenamiento.AñadirDiaEntrenamiento(this.diaEntrenamiento);
                }
            }
            this.diarioEntrenamiento.TablaActividadDataGridView.Rows.Clear();
            this.diarioEntrenamiento.ActividadView_Load();
            this.diarioEntrenamiento.TablaActividadDataGridView.Update();
            this.diarioEntrenamiento.TablaActividadDataGridView.Refresh();
            this.Close();
            //}
        }

        //EL BOTON VOLVER CIERRA LA VENTANA DEL FORMULARIO
        private void VolverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
