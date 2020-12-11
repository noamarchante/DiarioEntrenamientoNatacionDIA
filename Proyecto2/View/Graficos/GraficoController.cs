using Proyecto2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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




   
     //DEVUELVE EL PRIMER PESO DE CADA MES
        private void AnualDateTimePicker_ValueChanged(Object sender, EventArgs e)
        {
            List<double> valores = PesoAnual(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnualDateTimePicker.Value.Date));
            this.GraficoPesoAnual.Invalidate();
            
            this.GraficoPesoAnual.Values3 = valores.ToArray();
            this.GraficoPesoAnual.Draw2();
            Console.WriteLine("fecha" + this.AnualDateTimePicker.Value);
            this.TablaAnual.Rows.Clear();
            this.TablaAnualView_Load(valores);
            this.GraficoPesoAnual.Update();
            this.GraficoPesoAnual.Refresh();
            
            this.TablaAnual.Update();
            this.TablaAnual.Refresh();

        }
        private List<double> PesoAnual(Dictionary<DiaEntrenamiento, Medida> diario)
        {
            List<double> peso= new List<double>();
            Dictionary<DateTime, double> mesesguardados = new Dictionary<DateTime,double>();
            List<Core.Medida>medidas= new List<Medida>();
            for (int i = 0; i < meses.Length; i++)
            {
                medidas = PesoMes(diario,meses[i]); 
                peso.Add(pesoValores(medidas));
            }    
            
            return peso;
        }
        
        private List<Core.Medida> PesoMes(Dictionary<DiaEntrenamiento, Medida> diario, String mes)
        {
            List<Core.Medida> medidasmes = new List<Core.Medida>();
            foreach (var dia in diario)
            {
                if (Convert.ToInt32(dia.Key.Fecha.Date.ToString("M tt")) == Convert.ToInt32(mes))
                {
                    medidasmes.Add(dia.Value);
                }
            }
            return medidasmes;
        }
        private double pesoValores(List<Core.Medida> medidas)
        {
            double peso = 0;
            bool comprobacion = false;

            foreach (var medida in medidas)
            {
                if (medida != null) { 
                comprobacion = true;
                peso += medida.Peso;
                }
            }
            if (comprobacion)
            {
                peso = peso / medidas.Count();
            }
            else
            {
                peso = 0;
            }

            return peso;
        }
        
        public void TablaAnualView_Load(List<double>valores)
        {
            //muestra todas las actividades en la tabla
            
            if (valores.Count != 0)
            {
                for (int i = 0; i < meses.Count(); i++)
                {
                    String[] insert = new string[]{mes[i],valores[i].ToString()};
                    TablaAnual.Rows.Add(insert);
                }
            }

        }




    }
}
