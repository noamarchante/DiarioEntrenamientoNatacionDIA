using System;
using System.Text;
using System.Xml.Linq;

namespace Proyecto2.Core
{
    public class Actividad
    {
        public int Id { get; set; }
        public Tiempo Tiempo { get; set; }
        public double Distancia { get; set; }
        public Circuito Circuito { get; set; }
        public String Notas { get; set; }

        public Actividad(int id,Tiempo tiempo, double distancia, Circuito circuito, string notas)
        {
            this.Id = id;
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
            str.AppendLine(Circuito.Lugar);
            str.AppendLine(Notas);
            return str.ToString();
        }
        
        public XElement toXML()
        {
            XElement toRet = new XElement("Actividad");
            toRet.Add(new XElement("Id",Id));
            toRet.Add(Tiempo.toXML());
            toRet.Add(new XElement("Distancia", Distancia));
            toRet.Add(Circuito.toXML());
            toRet.Add(new XElement("Nota", Notas));

            return toRet;
            
        }
    }
}