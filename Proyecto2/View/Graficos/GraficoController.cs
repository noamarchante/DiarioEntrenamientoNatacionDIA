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

            this.MinutoDistanciaChart.Invalidate();
            ValoresGraficoMinutoDistancia(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoActividadesDateTimePicker.Value));
            this.MinutoDistanciaChart.Update();
            this.MinutoDistanciaChart.Refresh();

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

            this.MinutoDistanciaChart.Draw();
           

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




        //CAMBIA LOS VALORES DEL GRAFICO DE MEDIDAS POR AÑO
        private void anhoMedidasDateTimePicker_ValueChanged(Object sender, EventArgs e)
        {

            //this.PesoCircunferenciaAbdominalChart.Invalidate();
            //ValoresGraficoPesoCircunferenciaAbdominal(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoMedidasDateTimePicker.Value));
            //this.PesoCircunferenciaAbdominalChart.Update();
            //this.PesoCircunferenciaAbdominalChart.Refresh();

        }

        //ESTABLECE LOS VALORES DEL GRAFICO PESO CIRCUNFERENCIA_ABDOMINAL
       /* private void ValoresGraficoPesoCircunferenciaAbdominal(Dictionary<DiaEntrenamiento, Medida> diarioPorAño)
        {
            Dictionary<DiaEntrenamiento, Medida> diario = diarioPorAño;
            List<int> pesoValores = new List<int>();
            List<int> circunferenciaAbdominalValores = new List<int>();
            List<Core.Medida> medidas = new List<Core.Medida>();

            for (int i = 0; i < meses.Length; i++)
            {
                medidas = MedidasMes(diario, meses[i]);
                pesoValores.Add(MinutosMes(medidas));
                circunferenciaAbdominalValores.Add(DistanciaMes(medidas));
            }

            this.PesoCircunferenciaAbdominalChart.Values = pesoValores.ToArray();

            this.PesoCircunferenciaAbdominalChart.Values2 = circunferenciaAbdominalValores.ToArray();

            this.PesoCircunferenciaAbdominalChart.Draw();


        }*/

        //DEVUELVE LAS MEDIDAS DE UN MES
       /* private List<Core.Medida> MedidasMes(Dictionary<DiaEntrenamiento, Medida> diario, String mes)
        {
            List<Core.Medida> medidas = new List<Core.Medida>();
            foreach (var dia in diario.Keys)
            {
                if (Convert.ToInt32(dia.Fecha.Date.ToString("M tt")) == Convert.ToInt32(mes))
                {
                    foreach (var medida in dia.medidas)
                    {
                        medidas.Add(medida);
                    }
                }
            }
            return medidas;
        }*/

        //DEVUELVE EL PESO EN UN MES DE MEDIDAS
      /*  private double PesoMes(List<Core.Medida> medidas)
        {
            double peso = 0.00;

            foreach (var medida in medidas)
            {
                peso += Convert.ToInt32(medida.Peso);
            }
            return peso;
        }*/

        //DEVUELVE LA CIRCUNFERENCIA_ABDOMINAL EN UN MES DE MEDIDAS
       /* private double CircunferenciaAbdominalMes(List<Core.Medida> medidas)
        {
            double circunferenciaAbdominal = 0.00;

            foreach (var medida in medidas)
            {
                circunferenciaAbdominal += Convert.ToInt32(medida.CircunferenciaAbdominal);
            }
            return circunferenciaAbdominal;
        }*/



    }
}
