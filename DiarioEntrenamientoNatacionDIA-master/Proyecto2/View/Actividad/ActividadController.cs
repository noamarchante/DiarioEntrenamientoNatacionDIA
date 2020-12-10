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

        private void ActividadView_Load(object sender, EventArgs e)
        {
            if (Program.diarioEntrenamiento.circuitos.Count == 0)
            {
                this.CircuitoComboBox.Enabled = false;
            }
            else
            {
                foreach (var circuito in Program.diarioEntrenamiento.circuitos)
                {
                this.CircuitoComboBox.Items.Add(circuito.Lugar + " - " + circuito.Distancia + " m");
                    
                }
                this.CircuitoComboBox.SelectedIndex = 0;
                this.CircuitoComboBox.FormattingEnabled = false;
                this.FechaDateTimePicker.Value = DateTime.Today;
            }
        }

        //EL BOTON INSERTAR INSERTA UNA ACTIVIDAD
        private void InsertarActividadButton_Click(object sender, EventArgs e)
        {          
            if (Program.diarioEntrenamiento.circuitos.Count == 0)
             {
                 this.InsertarButton.Enabled = false;
             }
             else
             {
                Tiempo tiempo = new Tiempo((int)this.MinutosNumericUpDown.Value, (int)this.SegundosNumericUpDown.Value);
                diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
                if (Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(diaEntrenamiento.Fecha).Key == null)
                {
                    diaEntrenamiento.AñadirActividad(new Core.Actividad(diaEntrenamiento.actividades.Count,tiempo, (Double)this.DistanciaNumericUpDown.Value, Program.diarioEntrenamiento.circuitos[this.CircuitoComboBox.SelectedIndex], this.NotaTextBox.Text));
                    diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
                    Program.diarioEntrenamiento.AñadirDiaEntrenamiento(diaEntrenamiento);
                }
                else
                {
                    var diaEntrenamientoSeleccionado = Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(this.diaEntrenamiento.Fecha);
                    Program.diarioEntrenamiento.EliminarDia(diaEntrenamientoSeleccionado.Key);
                    this.diaEntrenamiento = diaEntrenamientoSeleccionado.Key;
                    this.diaEntrenamiento.AñadirActividad(new Core.Actividad(this.diaEntrenamiento.actividades.Count, tiempo, (Double)this.DistanciaNumericUpDown.Value, Program.diarioEntrenamiento.circuitos[this.CircuitoComboBox.SelectedIndex], this.NotaTextBox.Text));
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
             }
        }

        //EL BOTON VOLVER CIERRA LA VENTANA DEL FORMULARIO
        private void VolverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
