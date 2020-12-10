using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Core
{
    public class Medidas
    {
        private double peso { get; set; }
        private int circunferencia { get; set; }

        private String notas { get; set; }

        public Medidas(double peso, int circunferencia, String notas)
        {
            this.peso = peso;
            this.circunferencia = circunferencia;
            this.notas = notas;

        }


        public override String ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.peso).Append(this.circunferencia).Append(this.notas);

            return str.ToString();


        }

    }
}