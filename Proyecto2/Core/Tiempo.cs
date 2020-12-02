using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Core
{
    public class Tiempo
    {
        public int Minutos { get; set; }
        public int Segundos { get; set; }


        public Tiempo(int minutos,int segundos)
        {
           if (segundos >59)
            {
                this.Minutos = minutos + segundos / 60;
                this.Segundos = segundos % 60;
            }
            else
            {
                this.Minutos = minutos;
                this.Segundos = segundos;
            }
        }


        public override String ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("00:").Append(this.Minutos).Append(":").Append(this.Segundos).Append("\n");


            return str.ToString();

        }
    }
}
