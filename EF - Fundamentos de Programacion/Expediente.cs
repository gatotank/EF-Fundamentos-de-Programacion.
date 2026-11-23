using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Expediente
    {
        public string codigo;
        public string codigoUsuario;
        public string dni;
        public string titular;
        public string asunto;
        public string fechaCita;
        public string fechaRegistro;
        public string estado;

        public static List<Expediente> listaExpedientes = new List<Expediente>();

        private static string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "expedientes.txt");

        static Expediente()
        {
            CargarExpedientes();
        }

        public static void GuardarExpedientes()
        {
            List<string> lineas = new List<string>();

            foreach (Expediente exp in listaExpedientes)
            {
                string linea = exp.codigo + "|" + exp.codigoUsuario + "|" + exp.dni + "|" + exp.titular + "|" + exp.asunto + "|" + exp.fechaCita + "|" + exp.fechaRegistro + "|" + exp.estado;
                lineas.Add(linea);
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }

        public static void CargarExpedientes()
        {
            if (!File.Exists(rutaArchivo))
            {
                return;
            }

            listaExpedientes.Clear();
            string[] lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                if (linea != "")
                {
                    string[] datos = linea.Split('|');

                    if (datos.Length == 8)
                    {
                        Expediente exp = new Expediente();
                        exp.codigo = datos[0];
                        exp.codigoUsuario = datos[1];
                        exp.dni = datos[2];
                        exp.titular = datos[3];
                        exp.asunto = datos[4];
                        exp.fechaCita = datos[5];
                        exp.fechaRegistro = datos[6];
                        exp.estado = datos[7];

                        listaExpedientes.Add(exp);
                    }
                }
            }
        }
    }
}