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
        private string[] mesesNumeros = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

        public GraficoView()
        {
            Build();
        }

        //EVENTO QUE MUESTRA LOS VALORES DE LA VENTANA GRAFICOS EN EL AÑO ACTUAL CUANDO ESTA SE ABRE
        private void GraficoView_Load(object sender, EventArgs e)
        {

            ValoresGraficoMinutoDistancia(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoActividadesDateTimePicker.Value));
            ValoresGraficoPesoCircunferencia(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoMedidasDateTimePicker.Value));
            ValoresGraficoPesoAnual(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoPesoDateTimePicker.Value));
        }

        //EVENTO QUE MODIFICA LOS VALORES DEL GRAFICO MINUTOS-DISTANCIA EN FUNCION DE LA FECHA SELECCIONADA
        private void anhoActividadesDateTimePicker_ValueChanged(Object sender, EventArgs e)
        {
            this.MinutoDistanciaChart.Invalidate();
            ValoresGraficoMinutoDistancia(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoActividadesDateTimePicker.Value));
            this.MinutoDistanciaChart.Update();
            this.MinutoDistanciaChart.Refresh();
        }

        //ESTABLECE LOS VALORES A MOSTRAR EN EL GRAFICO MINUTOS-DISTANCIA
        private void ValoresGraficoMinutoDistancia(Dictionary<DiaEntrenamiento, Medida> diarioPorAño)
        {
            Dictionary<DiaEntrenamiento, Medida> diario = diarioPorAño;
            List<int> minutosValores = new List<int>();
            List<double> distanciaValores = new List<double>();
            List<Core.Actividad> actividades = new List<Core.Actividad>();

            for (int i = 0; i < mesesNumeros.Length; i++)
            {
                actividades = ActividadesMes(diario, mesesNumeros[i]);
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

        //DEVUELVE LAS DISTANCIAS DEL MES EN ACTIVIDADES
        private double DistanciaMes(List<Core.Actividad> actividades)
        {
            double distancia = 0;

            foreach (var actividad in actividades)
            {
                distancia += actividad.Distancia;
            }
            return distancia;
        }

        //EVENTO QUE MODIFICA LOS VALORES DEL GRAFICO PESO-CIRCUNFERENCIA ABDOMINAL EN FUNCION DE LA FECHA SELECCIONADA
        private void AnhoMedidasDateTimePicker_ValueChanged(Object sender, EventArgs e)
        {
            this.PesoCircunferenciaAbdominalChart.Invalidate();
            ValoresGraficoPesoCircunferencia(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoMedidasDateTimePicker.Value));
            this.PesoCircunferenciaAbdominalChart.Update();
            this.PesoCircunferenciaAbdominalChart.Refresh();
        }

        //ESTABLECE LOS VALORES A MOSTRAR EN EL GRAFICO PESO-CIRCUNFERENCIA ABDOMINAL
        private void ValoresGraficoPesoCircunferencia(Dictionary<DiaEntrenamiento, Medida> diarioPorAño)
        {
            Dictionary<DiaEntrenamiento, Medida> diario = diarioPorAño;
            List<double> pesoValores = new List<double>();
            List<double> circunferenciaValores = new List<double>();
            List<Core.Medida> medidas = new List<Core.Medida>();

            for (int i = 0; i < mesesNumeros.Length; i++)
            {
                medidas = MedidasMes(diario, mesesNumeros[i]);
                pesoValores.Add(PesoMes(medidas));
                circunferenciaValores.Add(CircunferenciaMes(medidas));
            }

            this.PesoCircunferenciaAbdominalChart.Values3 = pesoValores.ToArray();

            this.PesoCircunferenciaAbdominalChart.Values4 = circunferenciaValores.ToArray();

            this.PesoCircunferenciaAbdominalChart.Draw4();

        }

        //DEVUELVE LAS MEDIDAS DE UN MES
        private List<Core.Medida> MedidasMes(Dictionary<DiaEntrenamiento, Medida> diario, String mes)
        {
            List<Core.Medida> medidasMes = new List<Core.Medida>();
            foreach (var dia in diario)
            {
                if (Convert.ToInt32(dia.Key.Fecha.Date.ToString("M tt")) == Convert.ToInt32(mes))
                {
                    medidasMes.Add(dia.Value);
                }
            }
            return medidasMes;
        }

        //DEVUELVE EL PESO EN UN MES DE MEDIDAS
        private double PesoMes(List<Core.Medida> medidas)
        {
            double peso = 0;
            int numMedidas = 0;

            foreach (var medida in medidas)
            {
                if (medida != null)
                {
                    peso += medida.Peso;
                    numMedidas++;
                }
            }

            if (peso > 0)
            {
                peso = peso / numMedidas;
            }

            return peso;
        }

        //DEVUELVE LA CIRCUNFERENCIA ABDOMINAL EN UN MES DE MEDIDAS
        private double CircunferenciaMes(List<Core.Medida> medidas)
        {
            double circunferencia = 0;
            int numMedidas = 0;

            foreach (var medida in medidas)
            {
                if (medida != null)
                {
                    circunferencia += medida.CircunferenciaAbdominal;
                    numMedidas++;
                }
            }

            if (circunferencia > 0)
            {
                circunferencia = circunferencia / numMedidas;
            }

            int convertCircunferencia = Convert.ToInt32(circunferencia);

            return convertCircunferencia;
        }

        //EVENTO QUE MODIFICA LOS VALORES DEL GRAFICO PESO ANUAL EN FUNCION DE LA FECHA SELECCIONADA
        private void AnualPesoDateTimePicker_ValueChanged(Object sender, EventArgs e)
        {
            this.PesoChart.Invalidate();
            this.AnualDataGridView.Rows.Clear();

            ValoresGraficoPesoAnual(Program.diarioEntrenamiento.ObtenerDiaEntrenamientoDesdeAnho(this.AnhoPesoDateTimePicker.Value.Date));

            this.PesoChart.Update();
            this.PesoChart.Refresh();
            this.AnualDataGridView.Update();
            this.AnualDataGridView.Refresh();

        }

        //ESTABLECE LOS VALORES A MOSTRAR EN EL GRAFICO PESO ANUAL
        private void ValoresGraficoPesoAnual(Dictionary<DiaEntrenamiento, Medida> diario)
        {
            List<double> pesos = new List<double>();
            Dictionary<DateTime, double> mesesGuardados = new Dictionary<DateTime, double>();
            List<Core.Medida> medidas = new List<Medida>();
            for (int i = 0; i < mesesNumeros.Length; i++)
            {
                medidas = MedidasMes(diario, mesesNumeros[i]);
                pesos.Add(PesoValores(medidas));
            }
            this.PesoChart.Values3 = pesos.ToArray();
            this.PesoChart.Draw2();
            this.TablaAnualDataGridView_Load(pesos);

        }

        //DEVUELVE LA MEDIA DEL PESO EN UN MES DE MEDIDAS
        private double PesoValores(List<Core.Medida> medidas)
        {
            double peso = 0;
            bool comprobacion = false;
            int numMedidas = 0;

            foreach (var medida in medidas)
            {
                if (medida != null)
                {
                    comprobacion = true;
                    peso += medida.Peso;
                    numMedidas++;
                }
            }
            if (comprobacion)
            {
                peso = peso / numMedidas;
            }
            else
            {
                peso = 0;
            }

            return peso;
        }

        //ESTABLECE LOS VALORES EN LA TABLA DE PESOS ANUALES
        public void TablaAnualDataGridView_Load(List<double> pesos)
        {
            if (pesos.Count != 0)
            {
                for (int i = 0; i < mesesNumeros.Count(); i++)
                {
                    String[] valores = new string[] { mesesLetras[i], pesos[i].ToString() + " Kg"};
                    AnualDataGridView.Rows.Add(valores);
                }
            }
        }
    }
}
