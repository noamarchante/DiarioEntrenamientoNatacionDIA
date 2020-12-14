using Proyecto2.Core;
using Proyecto2.View.DiarioEntrenamiento;
using System;
using System.Windows.Forms;

namespace Proyecto2.View.Medidas
{
    public partial class MedidaView : Form
    {
        public DiaEntrenamiento diaEntrenamiento;
        public DiarioEntrenamientoView diarioEntrenamientoView;

        public MedidaView(DiarioEntrenamientoView diarioEntrenamiento)
        {
            Build();
            diaEntrenamiento = new DiaEntrenamiento();
            this.diarioEntrenamientoView = diarioEntrenamiento;
        }

        //EVENTO QUE INSERTA MEDIDA AL PULSAR EL BOTON INSERTAR
        private void InsertarMedidaButton_Click(object sender, EventArgs e)
        {
            diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
            var dia = Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(diaEntrenamiento.Fecha);
            if (dia.Key == null)
            {
                Program.diarioEntrenamiento.AñadirDiaYMedida(diaEntrenamiento,new Core.Medida((Double)this.PesoNumericUpDown.Value, (Double)this.CircunferenciaAbdominalNumericUpDown.Value, this.NotaTextBox.Text));

            }
            else
            {
                var diaEntrenamientoSeleccionado = Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(this.diaEntrenamiento.Fecha);
                Program.diarioEntrenamiento.EliminarDia(diaEntrenamientoSeleccionado.Key);
                this.diaEntrenamiento = diaEntrenamientoSeleccionado.Key;
                Program.diarioEntrenamiento.AñadirDiaYMedida(diaEntrenamiento, new Core.Medida((Double)this.PesoNumericUpDown.Value, (Double)this.CircunferenciaAbdominalNumericUpDown.Value, this.NotaTextBox.Text));
             
            }
            this.diarioEntrenamientoView.TablaMedidasDataGridView.Rows.Clear();
            this.diarioEntrenamientoView.MedidaView_Load();
            this.diarioEntrenamientoView.TablaMedidasDataGridView.Update();
            this.diarioEntrenamientoView.TablaMedidasDataGridView.Refresh();
            this.Close();

        }

        //EVENTO QUE CIERRA EL FORMULARIO AL PULSAR EL BOTON VOLVER
        private void VolverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
