using System;
using System.Text;

namespace Proyecto2.Core
{
    public class Medida
    {
        private double Peso { get; set; }
        private int Circunferencia { get; set; }
        private String Notas { get; set;}

        public Medida(double peso, int circunferencia, String notas)
        {
            this.Peso = peso;
            this.Circunferencia = circunferencia;
            this.Notas = notas;
        }

        public override String ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.Peso).Append(this.Circunferencia).Append(this.Notas);
            return str.ToString();
        }

    }
}