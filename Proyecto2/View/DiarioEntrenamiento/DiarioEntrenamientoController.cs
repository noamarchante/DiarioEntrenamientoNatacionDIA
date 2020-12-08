using Proyecto2.Core;
using Proyecto2.View.Actividad;
using Proyecto2.View.Graficos;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private void MenuAnhadirActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ActividadView(this).Show();
        }

        private void MenuGraficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GraficoView().Show();
        }

        //CUANDO CARGA LA VENTANA MUESTRA LAS ACTIVIDADES LOS CIRCUITOS Y LAS MEDIDAS Y LAS FECHAS CON ACTIVIDADES O MEDIDAS EN EN NEGRITA 
        public void ActividadView_Load()
        {
            //muestra todas las actividades en la tabla
            List<string[]> actividades = Program.diarioEntrenamiento.ObtenerAtributosActividad();
            if (actividades.Count != 0)
            {
                for (int i = 0; i < actividades.Count; i++)
                {
                    this.TablaActividadDataGridView.Rows.Add(actividades[i]);
                }
            }

            //marca en negrita los dias con actividad
            foreach (var diario in Program.diarioEntrenamiento.DiarioEntrenamientos.Keys)
            {
                this.CalendarioMonthCalendar.AddBoldedDate(diario.Fecha);

            }
            this.CalendarioMonthCalendar.UpdateBoldedDates();
        }

        //BOTON MOSTRAR TODO QUITA LOS FILTROS A LA TABLA
        private void MostrarTodoButton_Click(object sender, EventArgs e)
        {
            this.TablaActividadDataGridView.Rows.Clear();
            ActividadView_Load();
            this.MostrarTodoButton.Enabled = false;
            this.MostrarTodoButton.Visible = false;
            this.TablaActividadDataGridView.Update();
            this.TablaActividadDataGridView.Refresh();
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
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                    if (diaEntrenamiento.Value != null || diaEntrenamiento.Key.actividades.Count != 0)
                    {
                        Program.diarioEntrenamiento.AñadirDiaYMedida(diaEntrenamiento.Key, diaEntrenamiento.Value);
                    }
                    
                    //comprobacion si quedan actividades ese dia y sigue en negrita
                    bool comprobacionMasActividadFecha = false;
                    foreach (var diario in Program.diarioEntrenamiento.DiarioEntrenamientos.Keys)
                    {
                        if (diario.Fecha.Equals(fecha))
                        {
                            comprobacionMasActividadFecha = true;
                        }
                    }
                        if (!comprobacionMasActividadFecha)
                        {
                            this.CalendarioMonthCalendar.RemoveBoldedDate(fecha);
                            this.CalendarioMonthCalendar.UpdateBoldedDates();
                        }
                }
            }
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
            this.MostrarTodoButton.Enabled = true;
            this.MostrarTodoButton.Visible = true;
            this.TablaActividadDataGridView.Update();
            this.TablaActividadDataGridView.Refresh();
        }

        //FOTO EN BOTONES ELIMINAR TABLA ACTIVIDAD
       private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
           
            if (e.ColumnIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.ContentBackground);
                senderGrid.CreateGraphics().DrawImage(Image.FromFile(@"img\\eliminar.png"),e.CellBounds);
                senderGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
        }
    }
}
