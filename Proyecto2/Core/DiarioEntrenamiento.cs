using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Core
{
    public class DiarioEntrenamiento
    {
        public Dictionary<DiaEntrenamiento, Medida> DiarioEntrenamientos { get; set; }
        public DiaEntrenamiento DiaEntrenamiento { get; set; }

        public DiarioEntrenamiento()
        {
            DiarioEntrenamientos = new Dictionary<DiaEntrenamiento, Medida>();  
        }

        public DiarioEntrenamiento(DiaEntrenamiento diaEntrenamiento, Medida medidas)
        {
            DiarioEntrenamientos = new Dictionary<DiaEntrenamiento, Medida>();
            DiarioEntrenamientos.Add(diaEntrenamiento, medidas);
            this.DiaEntrenamiento = diaEntrenamiento;
        }

        public DiarioEntrenamiento(DiaEntrenamiento diaEntrenamiento)
        {
            DiarioEntrenamientos = new Dictionary<DiaEntrenamiento,Medida>();
            DiarioEntrenamientos.Add(diaEntrenamiento,null);
            this.DiaEntrenamiento = diaEntrenamiento;
        }

        //COMPRUEBA SI HAY ACTIVIDADES EN EL DIARIO DE ENTRENAMIENTO
        public bool HayActividadesDiarioEntrenamiento()
        {
            bool resultado = true;
            foreach (var actividad in DiarioEntrenamientos.Keys)
            {
                if (!actividad.HayActividadesDia())
                {
                    resultado = false;
                }
            }
            return resultado;
        }

        //AÑADE UN DIA DE ENTRENAMIENTO AL DIARIO DE ENTRENAMIENTOS
        public void AñadirDiaEntrenamiento(DiaEntrenamiento diaEntrenamiento)
        {
            if (!this.DiarioEntrenamientos.ContainsKey(diaEntrenamiento))
            {
                this.DiarioEntrenamientos.Add(diaEntrenamiento, null);
            }
            else
            {
                Console.WriteLine("El dia ya existe");
            }
        }

        //AÑADE UNA MEDIDA AL DIARIO ENTRENAMIENTO
        public void AñadirMedida(Medida medida)
        {
            if (this.DiaEntrenamiento != null)
            {

                if (this.DiarioEntrenamientos.ContainsKey(this.DiaEntrenamiento))
                {
                    this.DiarioEntrenamientos.Remove(this.DiaEntrenamiento);
                    this.DiarioEntrenamientos.Add(this.DiaEntrenamiento, medida);
                }
                else
                {
                    if (this.DiaEntrenamiento != null)
                    {
                        this.DiarioEntrenamientos.Add(this.DiaEntrenamiento, medida);
                    }
                    else
                    {
                        Console.WriteLine("Primero añade el día actual antes de añadir medidas");
                    }
                }
            }
        }

        //AÑADE DIA DE ENTRENAMIENTO Y MEDIDA AL DIARIO DE ENTRENAMIENTO
        public void AñadirDiaYMedida(DiaEntrenamiento dia,Medida medida)
        {
            if (this.DiarioEntrenamientos.ContainsKey(dia))
            {
                this.DiarioEntrenamientos.Remove(dia);
                this.DiarioEntrenamientos.Add(dia, medida);
            }
            else
            {
               
               this.DiarioEntrenamientos.Add(dia, medida);
            }
        }

        //ELIMINAR DIA DE ENTRENAMIENTO EN DIARIO DE ENTRENAMIENTO
        public void EliminarDia(DiaEntrenamiento dia)
        {
            if (!this.DiarioEntrenamientos.Remove(dia))
            {
                Console.WriteLine("No había entrenamientos ese día");
            }
        }

        //DEVUELVE EL DIA DE ENTRENAMIENTO CON LA FECHA DEL ENTRENAMIENTO
        public KeyValuePair<DiaEntrenamiento,Medida> ObtenerDiaEntrenamientoDesdeFecha(DateTime fecha)
        {
            KeyValuePair<DiaEntrenamiento, Medida> resultado = new KeyValuePair<DiaEntrenamiento, Medida>();
            foreach (var diaEntrenamiento in this.DiarioEntrenamientos)
            {
                if (diaEntrenamiento.Key.Fecha.Date.Equals(fecha.Date)) {
                resultado = diaEntrenamiento;
                }
            }
            return resultado;
        }

        //DEVUELVE EL DIA DE ENTRENAMIENTO EN UN AÑO
        public Dictionary<DiaEntrenamiento, Medida> ObtenerDiaEntrenamientoDesdeAnho(DateTime fecha)
        {
            
            Dictionary<DiaEntrenamiento, Medida> resultado = new Dictionary<DiaEntrenamiento, Medida>();
            foreach (var diaEntrenamiento in this.DiarioEntrenamientos)
            {
                if (diaEntrenamiento.Key.Fecha.Year.Equals(fecha.Year))
                {
                    resultado.Add(diaEntrenamiento.Key, diaEntrenamiento.Value);
                }
            }
            return resultado;
        }

        //OBTIENE LOS ATRIBUTOS DE ACTIVIDAD EN FORMA DE ARRAY
        public List<string[]> ObtenerAtributosActividad()
        {
            List<string[]> atributos = new List<string[]>();
            
            foreach (KeyValuePair<DiaEntrenamiento, Medida> celda in this.DiarioEntrenamientos)
            {
                foreach (var actividad in celda.Key.actividades) { 
                    atributos.Add(new string[] {actividad.Distancia.ToString(),actividad.Tiempo.ToString(), actividad.Notas, celda.Key.Fecha.Date.ToString("dd-MM-yyyy tt"), actividad.Circuito.Lugar + "\n" + actividad.Circuito.Distancia + " m", actividad.Id.ToString()});
                }

            }
            return atributos;
        }
        /*
        //OBTIENE LOS ATRIBUTOS DE ACTIVIDAD EN FORMA DE ARRAY
        public List<string[]> ObtenerAtributosMedida()
        {
            List<string[]> atributosMedida = new List<string[]>();

            foreach (KeyValuePair<DiaEntrenamiento, Medida> celda in this.DiarioEntrenamientos)
            {
                foreach (var medida in celda.Key.medidas)
                {
                    atributosMedida.Add(new string[] { medida.Peso.ToString(), medida.CircunferenciaAbdominal.ToString(), medida.Notas, celda.Key.Fecha.Date.ToString("dd-MM-yyyy tt") });
                }

            }
            return atributosMedida;
        }
        */

        //OBTIENE LOS ATRIBUTOS EN FUNCION DE LA FECHA DEL DIA DE ENTRENAMIENTO
        public List<string[]> ObtenerAtributosActividad(DateTime fecha)
        {
            List<string[]> atributos = new List<string[]>();
         
            foreach (KeyValuePair<DiaEntrenamiento, Medida> celda in this.DiarioEntrenamientos)
            {
                if (celda.Key.Fecha.Date.Equals(fecha)) {
                    foreach (var actividad in celda.Key.actividades)
                    {
                        atributos.Add(new string[] { actividad.Distancia.ToString(), actividad.Tiempo.ToString(), actividad.Notas, celda.Key.Fecha.Date.ToString("dd-MM-yyyy tt"), actividad.Circuito.Lugar + "\n" + actividad.Circuito.Distancia + " m", actividad.Id.ToString() });
                    }
                }
            }
            return atributos;
        }

        //OBTIENE UN DIA DE ENTRENAMIENTO A PARTIR DE LA FECHA
        public KeyValuePair<DiaEntrenamiento,Medida> ObtenerDiaEntrenamientoPorFecha(DateTime fecha)
        {
            KeyValuePair<DiaEntrenamiento, Medida> diaEntrenamiento = new KeyValuePair<DiaEntrenamiento, Medida>();
            foreach (KeyValuePair<DiaEntrenamiento, Medida> celda in this.DiarioEntrenamientos)
            {
                if (celda.Key.Fecha.ToString().Equals(fecha.ToString()))
                {
                    diaEntrenamiento = celda;
                }
            }
            return diaEntrenamiento;
        }

    
        public override String ToString()
        {
            StringBuilder str = new StringBuilder();
 
            foreach (KeyValuePair<DiaEntrenamiento, Medida> celda in this.DiarioEntrenamientos)
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
