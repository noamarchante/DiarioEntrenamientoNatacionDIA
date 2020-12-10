using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Core
{
    public class DiarioEntrenamientoPorDia
    {

        public Dictionary<DiaEntrenamiento, Medidas> Diario { get; set; }
        public DiaEntrenamiento DiaActual { get; set; }


        public DiarioEntrenamientoPorDia()
        {
            Diario = new Dictionary<DiaEntrenamiento, Medidas>();
           
        }


        public DiarioEntrenamientoPorDia(DiaEntrenamiento dia, Medidas medidas)
        {
            Diario = new Dictionary<DiaEntrenamiento, Medidas>();
            Diario.Add(dia, medidas);
            this.DiaActual = dia;

        }


        public DiarioEntrenamientoPorDia(DiaEntrenamiento dia)
        {
            Diario = new Dictionary<DiaEntrenamiento,Medidas>();
            Diario.Add(dia,null);
            this.DiaActual = dia;
        }

        public bool comprobarActividadesVacio()
        {
            bool resultado = true;
            foreach (var actividad in Diario.Keys)
            {
                if (!actividad.SinActividades())
                {
                    resultado = false;
                }
            }
            return resultado;
        }

        public void AñadirDia(DiaEntrenamiento dia)
        {
            if (!this.Diario.ContainsKey(dia))
            {
                this.Diario.Add(dia, null);
            }
            else
            {
                Console.WriteLine("El dia ya existe");
            }
        }



        public void AñadirMedidas(Medidas medida)
        {
            if (this.DiaActual != null)
            {

                if (this.Diario.ContainsKey(this.DiaActual))
                {
                    this.Diario.Remove(this.DiaActual);
                    this.Diario.Add(this.DiaActual, medida);
                }
                else
                {
                    if (this.DiaActual != null)
                    {
                        this.Diario.Add(this.DiaActual, medida);
                    }
                    else
                    {
                        Console.WriteLine("Primero añade el día actual antes de añadir medidas");
                    }
                }
            }
        }


        public void AñadirDiaMedidas(DiaEntrenamiento dia,Medidas medida)
        {

            if (this.Diario.ContainsKey(dia))
            {
                this.Diario.Remove(dia);
                this.Diario.Add(dia, medida);
            }
            else
            {
               
               this.Diario.Add(dia, medida);
               
            }

        }


        public void EliminarDia(DiaEntrenamiento dia)
        {
            if (!this.Diario.Remove(dia))
            {
                Console.WriteLine("No había entrenamientos ese día");
            }
        }

        public List<string[]> getInfoActividadArray()
        {
            List<string[]> resultado = new List<string[]>();
            
            foreach (KeyValuePair<DiaEntrenamiento, Medidas> celda in this.Diario)
            {
                foreach (var actividad in celda.Key.actividades) { 
                    resultado.Add(new string[] {actividad.Distancia.ToString(),actividad.Tiempo.ToString(), actividad.Notas, celda.Key.Dia.Date.ToString(), actividad.Circuito.Lugar});
                }

            }
            return resultado;
        }


        public KeyValuePair<DiaEntrenamiento,Medidas>  getTuplaDesdeFecha(DateTime dia)
        {
            KeyValuePair<DiaEntrenamiento, Medidas> toret = new KeyValuePair<DiaEntrenamiento, Medidas>();
            foreach (KeyValuePair<DiaEntrenamiento, Medidas> celda in this.Diario)
            {
                if (celda.Key.Dia.ToString().Equals(dia.ToString()))
                {
                    toret = celda;
                }

            }

            return toret;

        }


        public override String ToString()
        {
            StringBuilder str = new StringBuilder();

            
            foreach (KeyValuePair<DiaEntrenamiento, Medidas> celda in this.Diario)
            {
                str.Append(celda.Key.ToString() + "\n");

                if (celda.Value != null)
                {
                    str.Append(celda.Value.ToString() + "\n");
                }

               
            }
            return str.ToString();
        }


    }
}
