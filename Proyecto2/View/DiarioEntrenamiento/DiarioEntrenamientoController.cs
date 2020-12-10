using Proyecto2.Core;
using Proyecto2.View.Actividad;
using Proyecto2.View.Graficos;
using Proyecto2.View.Medidas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace Proyecto2.View.DiarioEntrenamiento
{
    public partial class DiarioEntrenamientoView : Form
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

        //MENU AÑADIR MEDIDA MUESTRA FORMULARIO
        private void MenuAnhadirMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MedidaView(this).Show();
        }

        //CUANDO CARGA LA VENTANA MUESTRA LAS ACTIVIDADES LOS CIRCUITOS Y LAS MEDIDAS Y LAS FECHAS CON ACTIVIDADES O MEDIDAS EN NEGRITA 
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

            negritaCalendario();
        }

        public void MedidaView_Load()
        {
            //muestra todas las medidas en la tabla
            List<string[]> medida = Program.diarioEntrenamiento.ObtenerAtributosMedida();
            if (medida.Count != 0)
            {
                for (int i = 0; i < medida.Count; i++)
                {
                    this.TablaMedidasDataGridView.Rows.Add(medida[i]);
                }
            }

            negritaCalendario();

        }

        private void negritaCalendario()
        {
            //marca en negrita los dias con diaEntrenamiento
            foreach (var diario in Program.diarioEntrenamiento.DiarioEntrenamientos.Keys)
            {
                this.CalendarioMonthCalendar.AddBoldedDate(diario.Fecha.Date);

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

            this.TablaMedidasDataGridView.Rows.Clear();
            MedidaView_Load();
            this.MostrarTodoButton.Enabled = false;
            this.MostrarTodoButton.Visible = false;
            this.TablaMedidasDataGridView.Update();
            this.TablaMedidasDataGridView.Refresh();
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
                    borrarNegrita(fecha);
                }
            }
        }

        private void borrarNegrita(DateTime fecha)
        {
            //comprobacion si quedan actividades ese dia y sigue en negrita
            bool comprobacionMasActividadFecha = false;
            bool comprobacionMedidasFecha = false;
            foreach (var diario in Program.diarioEntrenamiento.DiarioEntrenamientos)
            {
                if (diario.Key.Fecha.Date.Equals(fecha.Date))
                {
                    comprobacionMasActividadFecha = true;
                }
                if (diario.Value != null)
                {
                    comprobacionMedidasFecha = true;
                }
            }
            if (!comprobacionMasActividadFecha && !comprobacionMedidasFecha)
            {
                this.CalendarioMonthCalendar.RemoveBoldedDate(fecha);
                this.CalendarioMonthCalendar.UpdateBoldedDates();
            }
        }

        //BOTON ELIMINAR DE LA TABLA MEDIDA 
        private void TablaMedidaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0)
            {
                var comprobacionFecha = senderGrid.Rows[e.RowIndex].Cells[3].Value;
                if (comprobacionFecha != null)
                {
                    DateTime fecha = DateTime.Parse(comprobacionFecha.ToString());

                    KeyValuePair<DiaEntrenamiento, Medida> diaEntrenamiento = Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeFecha(fecha);

                    Program.diarioEntrenamiento.EliminarDia(diaEntrenamiento.Key);
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                    if (diaEntrenamiento.Key.actividades.Count != 0)
                    {
                        Program.diarioEntrenamiento.AñadirDiaYMedida(diaEntrenamiento.Key, null);
                    }

                    borrarNegrita(fecha);
                }
            }
        }

        //FECHA SELECCIONADA EN CALENDARIO MUESTRA ACTIVIDADES MEDIDAS Y CIRCUITOS ASOCIADOS
        private void CalendarioMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = this.CalendarioMonthCalendar.SelectionStart;
            List<string[]> atributosActividad = Program.diarioEntrenamiento.ObtenerAtributosActividad(fechaSeleccionada);
            string[] atributosMedida = Program.diarioEntrenamiento.ObtenerAtributosMedida(fechaSeleccionada);
            this.TablaActividadDataGridView.Rows.Clear();
            this.TablaMedidasDataGridView.Rows.Clear();
            if (atributosActividad.Count != 0)
            {
                foreach (var actividad in atributosActividad)
                {
                    this.TablaActividadDataGridView.Rows.Add(actividad);
                }
                this.TablaActividadDataGridView.Update();
                this.TablaActividadDataGridView.Refresh();
            }
            if (atributosMedida.Length != 0)
            {
                this.TablaMedidasDataGridView.Rows.Add(atributosMedida);
                this.TablaMedidasDataGridView.Update();
                this.TablaMedidasDataGridView.Refresh();
            }
            this.MostrarTodoButton.Enabled = true;
            this.MostrarTodoButton.Visible = true;
        }

        //FOTO EN BOTONES ELIMINAR TABLA ACTIVIDAD
        private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.ContentBackground);
                senderGrid.CreateGraphics().DrawImage(Image.FromFile(@"img\\eliminar.png"), e.CellBounds);
                senderGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
        }
    }
}
