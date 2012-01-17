using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TpDiseñoCSharp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PantallaPrincipal());
            //Application.Run(new Emitir_Orden_de_Mérito("niko121"));
            //Application.Run(new Gestionar_Puestos("niko121"));
        }
    }
}
