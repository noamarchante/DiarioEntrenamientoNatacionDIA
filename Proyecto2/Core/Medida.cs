using System;
using System.Text;

namespace Proyecto2.Core
{
    public class Medida
    {
        public double Peso { get; set; }
        public double CircunferenciaAbdominal { get; set; }
        public String Notas { get; set; }

        public Medida(double peso, double circunferenciaAbdominal, string notas)
        {
            this.Peso = peso;
            this.CircunferenciaAbdominal = circunferenciaAbdominal;
            this.Notas = notas;
        }

        public override String ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.Peso).Append(this.CircunferenciaAbdominal).Append(this.Notas);

            return str.ToString();
        }
    }
}