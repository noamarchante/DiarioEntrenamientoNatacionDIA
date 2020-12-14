using Proyecto2.Core;
using Proyecto2.View.DiarioEntrenamiento;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
internal static class NativeMethods
{
    [DllImport("kernel32.dll")]
    internal static extern Boolean AllocConsole();
}
namespace Proyecto2
{
    static class Program
    {
        public static DiarioEntrenamiento diarioEntrenamiento = new DiarioEntrenamiento();
  
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            diarioEntrenamiento.cargarBaseUsandoXML("DiarioEntrenamiento.xml");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DiarioEntrenamientoView());
            NativeMethods.AllocConsole();
            diarioEntrenamiento.crearXML("DiarioEntrenamiento.xml");
        }
    }
}
