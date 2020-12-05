using Proyecto2.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proyecto2.View.Graficos
{
    public partial class GraficoView : Form
    {
        private string[] meses = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

        public GraficoView()
        {
            Build();
        }

        //CAMBIA LOS VALORES DEL GRAFICO DE ACTIVIDAD POR AÑO
        private void anhoActividadesDateTimePicker_ValueChanged(Object sender, EventArgs e)
        {
            ValoresGraficoMinutoDistancia(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoActividadesDateTimePicker.Value));
            
        }

        //ESTABLECE LOS VALORES DEL GRAFICO MINUTOS DISTANCIA
        private void ValoresGraficoMinutoDistancia(Dictionary<DiaEntrenamiento,Medida> diarioPorAño)
        {
            Dictionary<DiaEntrenamiento, Medida> diario = diarioPorAño;
            List<int> minutosValores = new List<int>();
            List<int> distanciaValores = new List<int>();
            List<Core.Actividad> actividades = new List<Core.Actividad>();

            for (int i = 0; i < meses.Length; i++)
            {
                actividades = ActividadesMes(diario,meses[i]);
                minutosValores.Add(MinutosMes(actividades));
                distanciaValores.Add(DistanciaMes(actividades));
            }            
   
            this.MinutoDistanciaChart.Values = minutosValores.ToArray();
      
            this.MinutoDistanciaChart.Values2 = distanciaValores.ToArray();

            this.MinutoDistanciaChart.Invalidate();
            this.MinutoDistanciaChart.Draw();
            this.MinutoDistanciaChart.Update();
            this.MinutoDistanciaChart.Refresh();

        }

        //DEVUELVE LAS ACTIVIDADES DE UN MES
        private List<Core.Actividad> ActividadesMes(Dictionary<DiaEntrenamiento, Medida> diario, String mes)
        {
            List<Core.Actividad> actividades = new List<Core.Actividad>();
            foreach (var dia in diario.Keys)
            {
                if (Convert.ToInt32(dia.Fecha.Date.ToString("M tt")) == Convert.ToInt32(mes))
                {
                    foreach (var actividad in dia.actividades)
                    {
                        actividades.Add(actividad);
                    }
                }
            }
            return actividades;
        }

        //DEVUELVE LOS MINUTOS DEL MES EN ACTIVIDADES
        private int MinutosMes(List<Core.Actividad> actividades)
        {
            int minutos = 0;
            int segundos = 0;

            foreach (var actividad in actividades)
            {
                segundos += actividad.Tiempo.Segundos;
                if (segundos > 59)
                {
                    minutos += 1;
                    segundos = 0;
                }
                minutos += actividad.Tiempo.Minutos;
            }
            return minutos;
        }

        //DEVUELVE LA DISTANCIA EN UN MES DE ACTIVIDADES
        private int DistanciaMes(List<Core.Actividad> actividades)
        {
            int distancia = 0;

            foreach (var actividad in actividades)
            {
                distancia += Convert.ToInt32(actividad.Distancia);
            }
            return distancia;
        }



    }
}
