using System;
using System.Text;

namespace Proyecto2.Core
{
    public class Medida
    {
        private DateTime Fecha { get; }
        private double Peso { get; set; }
        private double CircunferenciaAbdominal { get; set; }
        private String Notas { get; set; }

        public Medida(double p, double cA, string n)
        {
            this.Fecha = DateTime.Now;
            this.Peso = p;
            this.CircunferenciaAbdominal = cA;
            this.Notas = n;
        }

        public Medida(DateTime f, double p, double cA, string n)
        {
            this.Fecha = f;
            this.Peso = p;
            this.CircunferenciaAbdominal = cA;
            this.Notas = n;
        }

        public override String ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.Fecha).Append(this.Peso).Append(this.CircunferenciaAbdominal).Append(this.Notas);

            return str.ToString();
        }
    }
}