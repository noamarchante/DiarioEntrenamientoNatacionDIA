using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Linq;


namespace Proyecto2.Core
{
    public class DiarioEntrenamiento
    {
        public Dictionary<DiaEntrenamiento, Medida> DiarioEntrenamientos { get; set; }
        public List<Core.Circuito> Circuitos { get; set; }

        public DiaEntrenamiento DiaEntrenamiento { get; set; }

        public DiarioEntrenamiento()
        {
            DiarioEntrenamientos = new Dictionary<DiaEntrenamiento, Medida>();
            Circuitos = new List<Circuito>();
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
        public void AñadirCircuito(Circuito circuito)
        {
            if (!this.Circuitos.Contains(circuito))
            {
                this.Circuitos.Add(circuito);
            }
            else
            {
                Console.WriteLine("El circuito ya existe");
            }
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
                    atributos.Add(new string[] { actividad.Distancia.ToString() + " Km", actividad.Tiempo.ToString(), actividad.Notas, celda.Key.Fecha.Date.ToString("dd-MM-yyyy tt"), actividad.Circuito.Lugar + " - " + actividad.Circuito.Distancia + " Km", actividad.Id.ToString() });
                }

            }
            return atributos;
        }
        
        //OBTIENE LOS ATRIBUTOS DE ACTIVIDAD EN FORMA DE ARRAY
        public List<string[]> ObtenerAtributosMedida()
        {
            List<string[]> atributosMedida = new List<string[]>();

            foreach (KeyValuePair<DiaEntrenamiento, Medida> celda in this.DiarioEntrenamientos)
            {
                Medida medida = celda.Value;

                if (medida != null)
                {
                    atributosMedida.Add(new string[] { medida.Peso.ToString() + " Kg", medida.CircunferenciaAbdominal.ToString() + " cms", medida.Notas, celda.Key.Fecha.Date.ToString("dd-MM-yyyy tt") });
                }

            }
            return atributosMedida;
        }

        //OBTIENE LOS ATRIBUTOS DE CIRCUITO EN FORMA DE ARRAY
        public List<string[]> ObtenerAtributosCircuito()
        {
            List<string[]> atributos = new List<string[]>();

            foreach (var circuito in this.Circuitos)
            {
                atributos.Add(new string[] { circuito.Lugar.ToString(), circuito.Distancia.ToString() + " Km", circuito.Notas.ToString(), circuito.Url.ToString(), circuito.Id.ToString() });

            }
            return atributos;

        }

        //OBTIENE LOS ATRIBUTOS DE CIRCUITO DE LO0S CIRCUITOS SELECCIONADOS
        public List<string[]> ObtenerAtributosCircuito(List<Core.Circuito> circuitos)
        {
            List<string[]> atributos = new List<string[]>();

            foreach (var circuito in circuitos)
            {
                atributos.Add(new string[] { circuito.Lugar.ToString(), circuito.Distancia.ToString() + " Km", circuito.Notas.ToString(), circuito.Url.ToString(), circuito.Id.ToString() });

            }
            return atributos;

        }

        //OBTIENE LOS ATRIBUTOS EN FUNCION DE LA FECHA DEL DIA DE ENTRENAMIENTO
        public List<string[]> ObtenerAtributosActividad(DateTime fecha)
        {
            List<string[]> atributos = new List<string[]>();
         
            foreach (KeyValuePair<DiaEntrenamiento, Medida> celda in this.DiarioEntrenamientos)
            {
                if (celda.Key.Fecha.Date.Equals(fecha.Date)) {
                    foreach (var actividad in celda.Key.actividades)
                    {
                        atributos.Add(new string[] { actividad.Distancia.ToString() + " Km", actividad.Tiempo.ToString(), actividad.Notas, celda.Key.Fecha.Date.ToString("dd-MM-yyyy tt"), actividad.Circuito.Lugar + " - " + actividad.Circuito.Distancia + " Km", actividad.Id.ToString() });
                    }
                }
            }
            return atributos;
        }

        //OBTIENE LOS ATRIBUTOS EN FUNCION DE LA FECHA DE LA MEDIDA (VALUE)
        public string[] ObtenerAtributosMedida(DateTime fecha)
        {
            string[] atributos = null;
            
            foreach (KeyValuePair<DiaEntrenamiento, Medida> celda in this.DiarioEntrenamientos)
            {
                if (celda.Key.Fecha.Date.Equals(fecha.Date) && celda.Value != null)
                {
                    Medida medida = celda.Value;
                    atributos = new string[] { medida.Peso.ToString() + "Kg", medida.CircunferenciaAbdominal.ToString() + " cms", medida.Notas, celda.Key.Fecha.Date.ToString("dd-MM-yyyy tt")};
                   
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
                if (celda.Key.Fecha.Date.ToString().Equals(fecha.Date.ToString()))
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
        
        //SE USA AL FINAL DE LA EJECUCIÓN DEL PROGRAMA. VUELCA LOS VALORES EN LAS VARIABLES Y LISTAS DEL PROGRAMA EN UN
        //XML CUYO PATH SE PASA COMO ARGUMENTO. LLAMA A LOS DISTINTOD MÉTODOS QUE AGREGAN LOS XML DE LAS DISTINTAS 
        //CLASES DEL PROGRAMA 
        public void crearXML(string nombreArchivo)
        {
            var raiz = new XElement("DiarioEntrenamiento");
            
            foreach (var x in DiarioEntrenamientos)
            {
                DateTime diaActual = x.Key.Fecha.Date;
                raiz.Add(new XElement("Dia",
                    new XElement("dia",diaActual.Day),
                    new XElement("mes", diaActual.Month),
                    new XElement("año", diaActual.Year)));

                if (x.Key != null)
                {
                    raiz.Elements("Dia").Last().Add(x.Key.toXML());
                }
                
                if (x.Value != null)
                {
                    raiz.Elements("Dia").Last().Add(x.Value.toXML());
                }
                else
                {
                    raiz.Elements("Dia").Last().Add(new XElement("Medida"));
                }
            }
            raiz.Add(new XElement("Circuitos"));
            foreach (var circ in Circuitos)
            {
                raiz.Element("Circuitos").Add(circ.toXML());
            }
            
            raiz.Save(nombreArchivo);
            
        }
        
        //SE USA AL INICIAR EL PROGRAMA. CARGA LOS DATOS DEL XML PASADO POR PARÁMETRO Y LOS VUELCA EN EL PROGRAMA PARA
        //PODER TRABAJAR CON ELLOS DE FORMA NORMAL
        public void cargarBaseUsandoXML(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                XElement leer = XElement.Load(nombreArchivo);
                
                foreach (var dia in leer.Elements("Dia"))
                {

                    DiaEntrenamiento diaEntrenam = new DiaEntrenamiento(
                        (int) dia.Element("dia"),
                        (int) dia.Element("mes"), (int) dia.Element("año"));

                    foreach (var act in dia.Element("Actividades").Elements("Actividad"))
                    {
                        Tiempo tempAñadir = new Tiempo(
                            int.Parse(act.Element("Tiempo").Element("Minutos").Value),
                            int.Parse(act.Element("Tiempo").Element("Segundos").Value)
                            );
                        Circuito circAñadir = new Circuito(
                            int.Parse(act.Element("Circuito").Element("Id").Value),
                            double.Parse(act.Element("Circuito").Element("Distancia").Value),
                            act.Element("Circuito").Element("Lugar").Value,
                            act.Element("Circuito").Element("Url").Value,
                            act.Element("Circuito").Element("Nota").Value);
                        
                        Actividad actAñadir = new Actividad(
                            int.Parse(act.Element("Id").Value),
                            tempAñadir,
                            double.Parse(act.Element("Distancia").Value),
                            circAñadir,
                            act.Element("Nota").Value
                            );
                        diaEntrenam.AñadirActividad(actAñadir);
                    }

                    if (dia.Element("Medida").HasElements)
                    {
                        XElement med = dia.Element("Medida");
                        
                        Medida medidas = new Medida(
                            Double.Parse((string) med.Element("Peso")),
                            Double.Parse((string) med.Element("Circunferencia")),
                            (string) med.Element("Nota"));

                        DiarioEntrenamientos.Add(diaEntrenam, medidas);

                    }
                    else
                    {
                        DiarioEntrenamientos.Add(diaEntrenam, null);
                    }

                }

                foreach (var circ in leer.Element("Circuitos").Elements("Circuito"))
                {
                    Circuito circAñadir = new Circuito(
                        int.Parse(circ.Element("Id").Value),
                        double.Parse(circ.Element("Distancia").Value),
                        circ.Element("Lugar").Value,
                        circ.Element("Url").Value,
                        circ.Element("Nota").Value);
                    
                    Circuitos.Add(circAñadir);
                }
            }
        }
    }
}
