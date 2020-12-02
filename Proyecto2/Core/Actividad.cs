using System;
using System.Text;

namespace Proyecto2.Core
{
    public class Actividad
    {

        public Tiempo Tiempo { get; set; }
        public double Distancia { get; set; }
        public Circuito Circuito { get; set; }
        public String Notas { get; set; }

        public Actividad(Tiempo tiempo, double distancia, Circuito circuito, string notas)
        {
            this.Tiempo = tiempo;
            this.Distancia = distancia;
            this.Circuito = circuito;
            this.Notas = notas;
        }

        

        public override string ToString()
        {
            StringBuilder str = new StringBuilder(); 
            str.AppendLine(Tiempo.ToString());
            str.AppendLine(Distancia + "Km");
           // str.AppendLine(Circuito.Lugar);
            str.AppendLine(Notas);
            return str.ToString();
        }
    }
}