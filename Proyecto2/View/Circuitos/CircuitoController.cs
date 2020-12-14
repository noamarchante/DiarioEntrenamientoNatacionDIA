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

        //EVENTO QUE INSERTA CIRCUITOS AL PULSAR EL BOTON INSERTAR
        private void InsertarCircuitoButton_Click(object sender, EventArgs e)
        {

            circuito = new Core.Circuito(Program.diarioEntrenamiento.Circuitos.Count,(Double)this.DistanciaNumericUpDown.Value, this.LugarTextBox.Text, this.NotaTextBox.Text, this.UrlTextBox.Text);
            Program.diarioEntrenamiento.AñadirCircuito(circuito);
            this.diarioEntrenamiento.TablaCircuitoDataGridView.Rows.Clear();
            this.diarioEntrenamiento.CircuitoView_Load();
            this.diarioEntrenamiento.TablaCircuitoDataGridView.Update();
            this.diarioEntrenamiento.TablaCircuitoDataGridView.Refresh();
            this.Close();
            
        }

        //EVENTO QUE CIERRA LA VENTANA AL PULSAR EL BOTON VOLVER
        private void VolverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
