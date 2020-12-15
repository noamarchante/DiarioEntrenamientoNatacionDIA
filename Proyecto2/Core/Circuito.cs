using System.Text;
using System.Xml.Linq;

namespace Proyecto2.Core
{
    
    public class Circuito
    {
        public int Id { get; set; }
        public double Distancia { get; set; }
        public string Lugar { get; set; }
        public string Notas { get; set; }
        public string Url { get; set; }

        public Circuito(int Id,double distancia, string lugar, string notas, string url)
        {
            this.Id = Id;
            this.Distancia = distancia;
            this.Lugar = lugar;
            this.Notas = notas;
            this.Url = url;
        }

        public Circuito()
        {
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
        
        //CONVIERTE LOS ATRIBUTOS Id, Distancia, Lugar, Url y Notas A ELEMENTOS XML 
        public XElement toXML()
        {
            XElement toRet = new XElement("Circuito",
                new XElement("Id",Id),
                new XElement("Distancia",Distancia),
                new XElement("Lugar",Lugar),
                new XElement("Url",Url),
                new XElement("Nota", Notas));

            return toRet;
        }
    }
}