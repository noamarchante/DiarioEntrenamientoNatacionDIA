using Proyecto2.Core;
using Proyecto2.View.Actividad;
using Proyecto2.View.DiarioEntrenamiento;
using System;
using System.Windows.Forms;

namespace Proyecto2
{
    static class Program
    {
        public static DiarioEntrenamientoPorDia actividades = new DiarioEntrenamientoPorDia();

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DiarioEntrenamientoView());
        }
    }
}
