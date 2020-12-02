using System.Text;

namespace Proyecto2.Core
{
    
    public class Circuito
    {
        private double distancia;
        private string lugar;
        private string notas;
        private string url;

        public Circuito(double distancia, string lugar, string notas, string url)
        {
            this.distancia = distancia;
            this.lugar = lugar;
            this.notas = notas;
            this.url = url;
        }

        public double Distancia
        {
            get;
        }

        public string Lugar
        {
            get;
        }

        public string Notas
        {
            get;
        }

        public string Url
        {
            get;
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