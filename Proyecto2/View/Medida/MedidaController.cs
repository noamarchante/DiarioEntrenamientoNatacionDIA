using Proyecto2.Core;
using Proyecto2.View.DiarioEntrenamiento;
using System;
using System.Windows.Forms;

namespace Proyecto2.View.Medida
{
    public partial class MedidaView : Form
    {
        public DiaEntrenamiento diaEntrenamiento;
        public DiarioEntrenamientoView diarioEntrenamiento;

        public MedidaView(DiarioEntrenamientoView diarioEntrenamiento)
        {
            Build();
            diaEntrenamiento = new DiaEntrenamiento();
            this.diarioEntrenamiento = diarioEntrenamiento;
        }

        //EL BOTON INSERTAR, INSERTA UNA MEDIDA
        private void InsertarMedidaButton_Click(object sender, EventArgs e)
        {
            diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
            if (Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(diaEntrenamiento.Fecha).Key == null)
            {
                diarioEntrenamiento.AñadirMedida(new Core.Medida(diarioEntrenamiento.medida.Count, (Double)this.PesoNumericUpDown.Value, (Double)this.CircunferenciaAbdominalNumericUpDown.Value, this.NotaTextBox.Text));
                diaEntrenamiento.Fecha = this.FechaDateTimePicker.Value;
                Program.diarioEntrenamiento.AñadirDiaEntrenamiento(diaEntrenamiento);
            }
            else
            {
                var diaEntrenamientoSeleccionado = Program.diarioEntrenamiento.ObtenerDiaEntrenamientoPorFecha(this.diaEntrenamiento.Fecha);
                Program.diarioEntrenamiento.EliminarDia(diaEntrenamientoSeleccionado.Key);
                this.diaEntrenamiento = diaEntrenamientoSeleccionado.Key;
                this.diarioEntrenamiento.AñadirMedida(new Core.Medida(this.diarioEntrenamiento.medida.Count, (Double)this.PesoNumericUpDown.Value, (Double)this.CircunferenciaAbdominalNumericUpDown.Value, this.NotaTextBox.Text));
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
            this.diarioEntrenamiento.TablaMedidasDataGridView.Rows.Clear();
            this.diarioEntrenamiento.MedidaView_Load();
            this.diarioEntrenamiento.TablaMedidasDataGridView.Update();
            this.diarioEntrenamiento.TablaMedidasDataGridView.Refresh();
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
