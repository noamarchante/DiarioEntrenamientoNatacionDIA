using Proyecto2.Core;
using Proyecto2.View.Actividad;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Proyecto2.View.DiarioEntrenamiento
{
    public partial class DiarioEntrenamientoView: Form
    {
        public DiarioEntrenamientoView()
        {
            this.Build();
        }

        //MENU AÑADIR ACTIVIDAD MUESTRA FORMULARIO
        private void MenuAnhidirActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ActividadView(this).Show();
        }

        public void ActividadView_Load()
        {
            List<string[]> actividades = Program.diarioEntrenamiento.ObtenerAtributosActividad();
            if (actividades.Count != 0)
            {
                for (int i = 0; i < actividades.Count; i++)
                {
                    this.TablaActividadDataGridView.Rows.Add(actividades[i]);
                }
            }

            /* foreach (var actividad in ActividadView.actividades)
        {
            this.calMonthCalendar.AddBoldedDate(actividad.Fecha);

        }
        this.calMonthCalendar.UpdateBoldedDates();*/
        }

        //BOTON ELIMINAR DE LA TABLA ACTIVIDAD ELIMINAR ACTIVIDAD DE DIA ENTRENAMIENTO EN DIARIO ENTRENAMIENTO
        private void TablaActividadDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0)
            {
                var comprobacionId = senderGrid.Rows[e.RowIndex].Cells[5].Value;
                if (comprobacionId != null)
                {
                    int id = Convert.ToInt32(comprobacionId.ToString());
                    DateTime fecha = DateTime.Parse(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString());
                    KeyValuePair<DiaEntrenamiento, Medida> diaEntrenamiento = Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeFecha(fecha);
                    Program.diarioEntrenamiento.EliminarDia(diaEntrenamiento.Key);
                    diaEntrenamiento.Key.EliminarActividad(id);
                    Program.diarioEntrenamiento.AñadirDiaYMedida(diaEntrenamiento.Key, diaEntrenamiento.Value);
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                }
            }
            Console.WriteLine(Program.diarioEntrenamiento.DiarioEntrenamientos.Count);
        }

        //FECHA SELECCIONADA EN CALENDARIO MUESTRA ACTIVIDADES MEDIDAS Y CIRCUITOS ASOCIADOS
        private void CalendarioMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = this.CalendarioMonthCalendar.SelectionStart;
            List<string[]> atributosActividad = Program.diarioEntrenamiento.ObtenerAtributosActividad(fechaSeleccionada.Date);
            this.TablaActividadDataGridView.Rows.Clear();
            if (atributosActividad.Count != 0)
            {
                foreach (var actividad in atributosActividad)
                {
                    this.TablaActividadDataGridView.Rows.Add(actividad);
                }
            }
            this.TablaActividadDataGridView.Update();
            this.TablaActividadDataGridView.Refresh();
        }
    }
}
