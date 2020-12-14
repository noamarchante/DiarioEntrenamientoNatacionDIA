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

        private void GraficoView_Load(object sender, EventArgs e)
        {

            ValoresGraficoMinutoDistancia(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoActividadesDateTimePicker.Value));
            ValoresGraficoPesoCircunferencia(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoMedidasDateTimePicker.Value));
            PesoAnual(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoPesoDateTimePicker.Value));
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
        private void ValoresGraficoMinutoDistancia(Dictionary<DiaEntrenamiento, Medida> diarioPorAño)
        {
            Dictionary<DiaEntrenamiento, Medida> diario = diarioPorAño;
            List<int> minutosValores = new List<int>();
            List<double> distanciaValores = new List<double>();
            List<Core.Actividad> actividades = new List<Core.Actividad>();

            for (int i = 0; i < meses.Length; i++)
            {
                actividades = ActividadesMes(diario, meses[i]);
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
        private double DistanciaMes(List<Core.Actividad> actividades)
        {
            double distancia = 0;

            foreach (var actividad in actividades)
            {
                distancia += actividad.Distancia;
            }
            return distancia;
        }

        //CAMBIA LOS VALORES DEL GRAFICO DE MEDIDAS POR AÑO
        private void anhoMedidasDateTimePicker_ValueChanged(Object sender, EventArgs e)
        {

            this.PesoCircunferenciaAbdominalChart.Invalidate();
            ValoresGraficoPesoCircunferencia(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoMedidasDateTimePicker.Value));
            this.PesoCircunferenciaAbdominalChart.Update();
            this.PesoCircunferenciaAbdominalChart.Refresh();

        }

        //ESTABLECE LOS VALORES DEL GRAFICO PESO CIRCUNFERENCIA ABDOMINAL
        private void ValoresGraficoPesoCircunferencia(Dictionary<DiaEntrenamiento, Medida> diarioPorAño)
        {
            Dictionary<DiaEntrenamiento, Medida> diario = diarioPorAño;
            List<double> pesoValores = new List<double>();
            List<double> circunferenciaValores = new List<double>();
            List<Core.Medida> medidas = new List<Core.Medida>();

            for (int i = 0; i < meses.Length; i++)
            {
                medidas = MediasMes(diario, meses[i]);
                pesoValores.Add(PesoMes(medidas));
                circunferenciaValores.Add(CircunferenciaMes(medidas));
            }

            this.PesoCircunferenciaAbdominalChart.Values3 = pesoValores.ToArray();

            this.PesoCircunferenciaAbdominalChart.Values4 = circunferenciaValores.ToArray();

            this.PesoCircunferenciaAbdominalChart.Draw4();

        }

        //DEVUELVE LAS MEDIDAS DE UN MES
        private List<Core.Medida> MediasMes(Dictionary<DiaEntrenamiento, Medida> diario, String mes)
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

        //DEVUELVE EL PESO EN UN MES DE MEDIDAS
        private double PesoMes(List<Core.Medida> medidas)
        {
            double peso = 0;

            foreach (var medida in medidas)
            {
                if (medida != null)
                {
                    peso += medida.Peso;
                }
            }

            if (peso > 0)
            {
                peso = peso / medidas.Count();
            }

            return peso;
        }

        //DEVUELVE LA CIRCUNFERENCIA ABDOMINAL EN UN MES DE MEDIDAS
        private double CircunferenciaMes(List<Core.Medida> medidas)
        {
            double circunferencia = 0;

            foreach (var medida in medidas)
            {
                if (medida != null)
                {
                    circunferencia += medida.CircunferenciaAbdominal;
                }
            }

            if (circunferencia > 0)
            {
                circunferencia = circunferencia / medidas.Count();
            }

            int convertCircunferencia = Convert.ToInt32(circunferencia);

            return convertCircunferencia;
        }














        //DEVUELVE EL PRIMER PESO DE CADA MES
        private void AnualDateTimePicker_ValueChanged(Object sender, EventArgs e)
        {
            this.PesoChart.Invalidate();
            this.AnualDataGridView.Rows.Clear();

            PesoAnual(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoPesoDateTimePicker.Value.Date));

            this.PesoChart.Update();
            this.PesoChart.Refresh();
            this.AnualDataGridView.Update();
            this.AnualDataGridView.Refresh();

        }
        private void PesoAnual(Dictionary<DiaEntrenamiento, Medida> diario)
        {
            List<double> peso = new List<double>();
            Dictionary<DateTime, double> mesesguardados = new Dictionary<DateTime, double>();
            List<Core.Medida> medidas = new List<Medida>();
            for (int i = 0; i < meses.Length; i++)
            {
                medidas = PesoMes(diario, meses[i]);
                peso.Add(pesoValores(medidas));
            }
            this.PesoChart.Values3 = peso.ToArray();
            this.PesoChart.Draw2();
            this.TablaAnualView_Load(peso);

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
                if (medida != null)
                {
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

        public void TablaAnualView_Load(List<double> valores)
        {
            //muestra todas las actividades en la tabla

            if (valores.Count != 0)
            {
                for (int i = 0; i < meses.Count(); i++)
                {
                    String[] insert = new string[] { mesesLetras[i], valores[i].ToString() + " Kg" };
                    AnualDataGridView.Rows.Add(insert);
                }
            }
        }
    }
}
