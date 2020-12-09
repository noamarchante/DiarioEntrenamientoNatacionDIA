using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Core
{
    public class DiaEntrenamiento
    {
        internal IEnumerable<object> medidas;

        public List<Actividad> actividades{get; set;}
        public DateTime Fecha { get; set; }

        public DiaEntrenamiento()
        {
            this.actividades = new List<Actividad>();
        }
        public DiaEntrenamiento(int dia,int mes,int anho)
        { 
            this.actividades = new List<Actividad>();
            this.Fecha = new DateTime(anho, mes, dia);
        }
        public DiaEntrenamiento(DateTime fecha)
        {
            this.actividades = new List<Actividad>();
            this.Fecha = fecha;
        }

        //AÑADIR ACTIVIDAD AL DIA
        public void AñadirActividad(Actividad c)
        {
            this.actividades.Add(c);
        }

        //ELIMINAR ACTIVIDAD POR ACTIVIDAD
        public void EliminarActividad(Actividad c)
        {
            if (!this.actividades.Remove(c))
            {
                Console.WriteLine("La actividad no estaba añadida");
            }
        }

        //ELIMINAR ACTIVIDAD POR ID
        public void EliminarActividad(int id)
        {
            Actividad resultado = null;
           
            foreach (var actividad in actividades)
            {
                if(actividad.Id.Equals(id))
                {
                    resultado = actividad;
                }
            }
            this.EliminarActividad(resultado);
        }

        //COMPRUEBA SI HAY ACTIVIDADES EN EL DIA
        public bool HayActividadesDia()
        {
            return actividades.Count == 0;
        }


        public override String ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Fecha.Date);
            foreach(Actividad actividad in this.actividades)
            {
                str.AppendLine(actividad.ToString());
            }
            return str.ToString();
        }
    }
}
