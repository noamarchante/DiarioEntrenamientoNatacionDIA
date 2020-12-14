using Proyecto2.Core;
using Proyecto2.View.Actividad;
using Proyecto2.View.Circuito;
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

        //EVENTO QUE CARGA LAS TABLAS AL INICIAR LA VENTANA
        private void DiarioEntrenamientoView_Load(object sender, EventArgs e)
        {
            this.TablaActividadDataGridView.Rows.Clear();
            ActividadView_Load();
            this.TablaActividadDataGridView.Update();
            this.TablaActividadDataGridView.Refresh();

            this.TablaMedidasDataGridView.Rows.Clear();
            MedidaView_Load();
            this.TablaMedidasDataGridView.Update();
            this.TablaMedidasDataGridView.Refresh();

            this.TablaCircuitoDataGridView.Rows.Clear();
            CircuitoView_Load();
            this.TablaCircuitoDataGridView.Update();
            this.TablaCircuitoDataGridView.Refresh();

        }

        //EVENTO QUE MUESTRA EL FORMULARIO DE ACTIVIDAD SI EXISTEN CIRCUITOS, AL PULSAR EL BOTON ACTIVIDAD DEL MENU
        private void MenuAnhadirActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.diarioEntrenamiento.Circuitos.Count == 0)
            {
                Help.ShowPopup(this.PanelPanel, "Para añadir una actividad debe haber, por lo menos, un circuito", new Point(this.PanelPanel.Left+200, this.PanelPanel.Top+200));
            }
            else
            {
                new ActividadView(this).Show();
            }
        }

        //EVENTO QUE MUESTRA LA VENTANA DE GRAFICOS AL PULSAR EL BOTON GRAFICOS DEL MENU
        private void MenuGraficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GraficoView().Show();
        }

        //EVENTO QUE MUESTRA EL FORMULARIO DE CIRCUITOS AL PULSAR EL BOTON CIRCUITO DEL MENU
        private void MenuAnhadirCircuitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CircuitoView(this).Show();
        }

        //EVENTO QUE MUESTRA EL FORMULARIO DE MEDIDAS AL PULSAR EL BOTON MEDIDAS DEL MENU
        private void MenuAnhadirMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MedidaView(this).Show();
        }

        //CARGA LAS ACTIVIDADES EN LA TABLA DE ACTIVIDADES Y PONE A NEGRITA LAS FECHAS DEL CALENDARIO CON ACTIVIDADES
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
            negritaCalendario();
        }

        //CARGA LAS MEDIDAS EN LA TABLA MEDIDAS Y PONE A NEGRITA LAS FECHAS DEL CALENDARIO CON MEDIDAS
        public void MedidaView_Load()
        {
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

        //CARGA LOS CIRCUITOS EN LA TABLA CIRCUITOS
        public void CircuitoView_Load()
        {
            List<string[]> circuitos = Program.diarioEntrenamiento.ObtenerAtributosCircuito();
            if (circuitos.Count != 0)
            {
                for (int i = 0; i < circuitos.Count; i++)
                {
                    this.TablaCircuitoDataGridView.Rows.Add(circuitos[i]);
                }
            }
        }

        //PONE A NEGRITA LAS FECHAS DEL CALENDARIO QUE ESTAN GUARDADAS EN EL DIARIO DE ENTRENAMIENTO
        private void negritaCalendario()
        {
            //marca en negrita los dias con diaEntrenamiento
            foreach (var diario in Program.diarioEntrenamiento.DiarioEntrenamientos.Keys)
            {
                this.CalendarioMonthCalendar.AddBoldedDate(diario.Fecha.Date);

            }
            this.CalendarioMonthCalendar.UpdateBoldedDates();
        }

        //EVENTO QUE MUESTRA TODOS LOS DATOS DE LAS TABLAS AL PULSAR EL BOTON X (SE OCULTA UNA VEZ PULSADO)
        private void MostrarTodoButton_Click(object sender, EventArgs e)
        {
            this.TablaActividadDataGridView.Rows.Clear();
            ActividadView_Load();
            this.TablaActividadDataGridView.Update();
            this.TablaActividadDataGridView.Refresh();

            this.TablaMedidasDataGridView.Rows.Clear();
            MedidaView_Load();
            this.TablaMedidasDataGridView.Update();
            this.TablaMedidasDataGridView.Refresh();

            this.TablaCircuitoDataGridView.Rows.Clear();
            CircuitoView_Load();
            this.TablaCircuitoDataGridView.Update();
            this.TablaCircuitoDataGridView.Refresh();

            this.MostrarTodoButton.Enabled = false;
            this.MostrarTodoButton.Visible = false;
        }

        //EVENTO QUE ELIMINA FILAS DE LA TABLA ACTIVIDAD AL PULSAR EL BOTON PAPELERA DE LA ULTIMA COLUMNA DE CADA FILA
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

        //ELIMINA LA NEGRITA DE LAS FECHAS DEL CALENDARIO QUE YA NO ESTAN EN EL DIARIO DE ENTRENAMIENTO
        private void borrarNegrita(DateTime fecha)
        {
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

        //EVENTO QUE ELIMINA FILAS DE LA TABLA MEDIDAS AL PULSAR EL BOTON PAPELERA DE LA ULTIMA COLUMNA DE CADA FILA
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

        //EVENTO QUE ELIMINA FILAS DE LA TABLA CIRCUITO AL PULSAR EL BOTON PAPELERA DE LA ULTIMA COLUMNA DE CADA FILA SI EL CIRCUITO NO ESTA ASOCIADO CON NINGUNA ACTIVIDAD
        private void TablaCircuitoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0)
            {
                var comprobacionId = senderGrid.Rows[e.RowIndex].Cells[4].Value;
                if (comprobacionId != null)
                {
                    int id = Convert.ToInt32(comprobacionId.ToString());
                    bool comprobacionCircuito = false;
                    foreach (var dia in Program.diarioEntrenamiento.DiarioEntrenamientos.Keys)
                    {
                        foreach (var actividad in dia.actividades)
                        {
                            if (actividad.Circuito.Id == id)
                            {
                                comprobacionCircuito = true;
                            }
                        }
                    }
                    if (comprobacionCircuito)
                    {
                        Help.ShowPopup(this.PanelPanel, "Este circuito no se puede eliminar, está asociado a alguna actividad", new Point(this.PanelPanel.Right, this.PanelPanel.Bottom-100));
                        }
                        else{
                        Core.Circuito circuitoSeleccionado = null;
                        foreach (var circuito in Program.diarioEntrenamiento.Circuitos)
                        {
                            if (circuito.Id.Equals(id))
                            {
                                circuitoSeleccionado = circuito;
                            }
                        }
                        Program.diarioEntrenamiento.Circuitos.Remove(circuitoSeleccionado);
                        senderGrid.Rows.RemoveAt(e.RowIndex);

                    }
                }
            }
        }

        //EVENTO QUE FILTRA LAS TABLAS SEGUN LOS ELEMENTOS DEL DIARIO DE ENTRENAMIENTOS EXISTENTES EN EL DIA SELECCIONADO
        private void CalendarioMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = this.CalendarioMonthCalendar.SelectionStart;
            List<string[]> atributosActividad = Program.diarioEntrenamiento.ObtenerAtributosActividad(fechaSeleccionada);
            string[] atributosMedida = Program.diarioEntrenamiento.ObtenerAtributosMedida(fechaSeleccionada);
            this.TablaActividadDataGridView.Rows.Clear();
            this.TablaMedidasDataGridView.Rows.Clear();
            this.TablaCircuitoDataGridView.Rows.Clear();
            if (atributosActividad.Count != 0)
            {
                foreach (var actividad in atributosActividad)
                {
                    this.TablaActividadDataGridView.Rows.Add(actividad);
                }

                var dia = Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeFecha(fechaSeleccionada);
                List<Core.Circuito> circuitosDia = new List<Core.Circuito>();
                foreach (var actividad in dia.Key.actividades)
                {
                    circuitosDia.Add(actividad.Circuito);
                }
                List<string[]> atributosCircuito = Program.diarioEntrenamiento.ObtenerAtributosCircuito(circuitosDia);
                if (atributosCircuito.Count != 0)
                {
                    foreach (var circuito in atributosCircuito)
                    {
                        this.TablaCircuitoDataGridView.Rows.Add(circuito);

                    }
                }
              
            }
            if (atributosMedida != null)
            {
                this.TablaMedidasDataGridView.Rows.Add(atributosMedida);
              
            }
            this.MostrarTodoButton.Enabled = true;
            this.MostrarTodoButton.Visible = true;
            this.TablaActividadDataGridView.Update();
            this.TablaActividadDataGridView.Refresh();
            this.TablaCircuitoDataGridView.Update();
            this.TablaCircuitoDataGridView.Refresh();
            this.TablaMedidasDataGridView.Update();
            this.TablaMedidasDataGridView.Refresh();
        }

        //EVENTO QUE CARGA LA IMAGEN PAPELERA EN LA ULTIMA COLUMNA DE CADA FILA DE LAS TABLAS
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
