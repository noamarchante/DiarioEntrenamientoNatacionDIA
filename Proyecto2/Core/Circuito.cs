using System.Text;

namespace Proyecto2.Core
{
    
    public class Circuito
    {
        public double Distancia { get; set; }
        public string Lugar { get; set; }
        public string Notas { get; set; }
        public string Url { get; set; }

        public Circuito(double distancia, string lugar, string notas, string url)
        {
            this.Distancia = distancia;
            this.Lugar = lugar;
            this.Notas = notas;
            this.Url = url;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine( Distancia + "km");
            str.AppendLine(Lugar);
            str.AppendLine(Notas);
            str.AppendLine(Url);
            return str.ToString();
        }
    }
}