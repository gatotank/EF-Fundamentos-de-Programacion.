
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    // Clase principal que inicia la aplicación.
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        // Indica que la aplicación utilizará un modelo de interfaz
        // compatible con Windows Forms y el manejo STA.
        [STAThread]

        // Método principal que se ejecuta al iniciar el programa.
        static void Main()
        {
            // Activa los estilos visuales de Windows para los formularios
            // y controles de la aplicación.
            Application.EnableVisualStyles();

            // Configura la compatibilidad de representación de texto
            // de los controles de Windows Forms.
            Application.SetCompatibleTextRenderingDefault(false);

            // Carga los usuarios almacenados en el archivo binario.
            Usuario.CargarUsuarios();

            // Carga los expedientes almacenados en el archivo binario.
            Expediente.CargarExpedientes();

            // Inicia la aplicación y muestra el formulario de inicio de sesión.
            // La aplicación permanece activa mientras se ejecuta este formulario
            // y los demás formularios de la aplicación.
            Application.Run(new Form1());
        }
    }
}
