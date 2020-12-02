using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Core
{
    public class DiaEntrenamiento
    {
        
        public List<Actividad> actividades{get; set;}
        public DateTime Dia { get; set; }

        public DiaEntrenamiento()
        {
            this.actividades = new List<Actividad>();
        }

        public DiaEntrenamiento(int dia,int mes,int anho)
        {
            
            this.actividades = new List<Actividad>();
           
            this.Dia = new DateTime(anho, mes, dia);

        }

        //COMPROBAR CUAL NO USAMOS
        public DiaEntrenamiento(DateTime dia)
        {

            this.actividades = new List<Actividad>();
            this.Dia = dia;

        }


        public void AñadirActividadesDia(Actividad c)
        {
            this.actividades.Add(c);

        }

     
        public void EliminarActividadesDia(Actividad c)
        {
            if (!this.actividades.Remove(c))
            {
                Console.WriteLine("La actividad no estaba añadida");
            }

        }

        public bool SinActividades()
        {
            return actividades.Count == 0;
        }

        public override String ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Dia.Date);
            foreach(Actividad actividad in this.actividades)
            {
                str.AppendLine(actividad.ToString());
            }

            return str.ToString();
        }




    }
}
