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
        public DiarioEntrenamientoView diarioEntrenamientoView;

        public ActividadView(DiarioEntrenamientoView diarioEntrenamiento)
        {
            Build();
            diaEntrenamiento = new DiaEntrenamiento();
            this.diarioEntrenamientoView = diarioEntrenamiento;
        }

        //EVENTO QUE SE EJECUTA AL INICIAR LA VISTA CARGANDO LOS DATOS LOS DATOS BASE DEL FORMULARIO
        private void ActividadView_Load(object sender, EventArgs e)
        {
            if (Program.diarioEntrenamiento.Circuitos.Count == 0)
            {
                this.CircuitoComboBox.Enabled = false;
            }
            else
            {
                foreach (var circuito in Program.diarioEntrenamiento.Circuitos)
                {
                this.CircuitoComboBox.Items.Add(circuito.Lugar + " - " + circuito.Distancia + " Km");
                    
                }
                this.CircuitoComboBox.SelectedIndex = 0;
                this.CircuitoComboBox.FormattingEnabled = false;
                this.FechaDateTimePicker.Value = DateTime.Today;
            }
        }

        //EVENTO QUE INSERTA UNA ACTIVIDAD AL PULSAR EL BOTON INSERTAR
        private void InsertarActividadButton_Click(object sender, EventArgs e)
        {
            if (Program.diarioEntrenamiento.Circuitos.Count == 0)
            {
                this.InsertarButton.Enabled = false;
            }
            else
            {
                Tiempo tiempo = new Tiempo((int)this.MinutosNumericUpDown.Value, (int)this.SegundosNumericUpDown.Value);
                diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
                if (Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(diaEntrenamiento.Fecha).Key == null)
                {
                    diaEntrenamiento.AñadirActividad(new Core.Actividad(diaEntrenamiento.actividades.Count, tiempo, (Double)this.DistanciaNumericUpDown.Value, Program.diarioEntrenamiento.Circuitos[this.CircuitoComboBox.SelectedIndex], this.NotaTextBox.Text));
                    diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
                    Program.diarioEntrenamiento.AñadirDiaEntrenamiento(diaEntrenamiento);
                }
                else
                {
                    var diaEntrenamientoSeleccionado = Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(this.diaEntrenamiento.Fecha);
                    Program.diarioEntrenamiento.EliminarDia(diaEntrenamientoSeleccionado.Key);
                    this.diaEntrenamiento = diaEntrenamientoSeleccionado.Key;
                    this.diaEntrenamiento.AñadirActividad(new Core.Actividad(this.diaEntrenamiento.actividades.Count, tiempo, (Double)this.DistanciaNumericUpDown.Value, Program.diarioEntrenamiento.Circuitos[this.CircuitoComboBox.SelectedIndex], this.NotaTextBox.Text));
                    this.diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
                    if (diaEntrenamientoSeleccionado.Value != null)
                    {
                        Program.diarioEntrenamiento.AñadirDiaYMedida(this.diaEntrenamiento, diaEntrenamientoSeleccionado.Value);
                    }
                    else
                    {
                        Program.diarioEntrenamiento.AñadirDiaEntrenamiento(this.diaEntrenamiento);
                    }
                }
                this.diarioEntrenamientoView.TablaActividadDataGridView.Rows.Clear();
                this.diarioEntrenamientoView.ActividadView_Load();
                this.diarioEntrenamientoView.TablaActividadDataGridView.Update();
                this.diarioEntrenamientoView.TablaActividadDataGridView.Refresh();
                this.Close();
            }
        }

        //EVENTO QUE CIERRA LA VENTANA AL PULSAR EL BOTON VOLVER
        private void VolverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
