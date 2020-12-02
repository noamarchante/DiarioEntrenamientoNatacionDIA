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
        private void MenuAnhidirActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ActividadView(this).Show();
        }

        private void ActividadView_Load(object sender, EventArgs e)
        {
            List<string[]> actividades = Program.actividades.getInfoActividadArray();
            if (actividades.Count !=0)
            {
                for (int i = 0; i < actividades.Count; i++)
                {
                    this.TablaActividadDataGridView.Rows.Add(actividades[i]);
                }
            }
        }

        private void calendarioMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            int i = 0;

            DateTime actual = this.CalendarioMonthCalendar.SelectionStart;

           /* foreach (var actividad in Program.)
            {
                i++;

                if (actividad.Fecha.Date.Equals(actual.Date))
                {
                   // this.listaListBox.Items.Add("Actividad " + i + actividad.ToString());

                }
                else
                {
                    this.TablaActividadDataGridView.Rows.Clear();
                }
            }*/
        }

        private void CalendarioView_Load(object sender, EventArgs e)
        {
           /* foreach (var actividad in ActividadView.actividades)
            {
                this.calMonthCalendar.AddBoldedDate(actividad.Fecha);

            }
            this.calMonthCalendar.UpdateBoldedDates();*/
        }
    }
}
