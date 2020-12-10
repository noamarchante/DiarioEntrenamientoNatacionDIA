using Proyecto2.Core;
using Proyecto2.View.DiarioEntrenamiento;
using System;
using System.Windows.Forms;
using Proyecto2.View.Circuito;

namespace Proyecto2.View.Circuito
{
    public partial class
        CircuitoView : Form
    {
        public Core.Circuito circuito;
        public DiarioEntrenamientoView diarioEntrenamiento;
        public CircuitoView circuitoView;

        public CircuitoView(DiarioEntrenamientoView diarioEntrenamiento)
        {
            Build();
            circuito = new Core.Circuito();
            this.diarioEntrenamiento = diarioEntrenamiento;
        }

        //EL BOTON INSERTAR INSERTA UNA ACTIVIDAD
        private void InsertarCircuitoButton_Click(object sender, EventArgs e)
        {

            circuito = new Core.Circuito(Program.diarioEntrenamiento.circuitos.Count,(Double)this.DistanciaNumericUpDown.Value, this.LugarTextBox.Text, this.NotaTextBox.Text, this.UrlTextBox.Text);
            Program.diarioEntrenamiento.AñadirCircuito(circuito);
            this.diarioEntrenamiento.TablaCircuitoDataGridView.Rows.Clear();
            this.diarioEntrenamiento.CircuitoView_Load();
            this.diarioEntrenamiento.TablaCircuitoDataGridView.Update();
            this.diarioEntrenamiento.TablaCircuitoDataGridView.Refresh();
            this.Close();
            
        }

        //EL BOTON VOLVER CIERRA LA VENTANA DEL FORMULARIO
        private void VolverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
