using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Usuario
    {
        public string codigo;
        public string dni;
        public string nombres;
        public string correo;
        public string celular;
        public string contraseña;

        public static List<Usuario> listaUsuarios = new List<Usuario>();
        public static Usuario usuarioActual;

        private static string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.txt");

        static Usuario()
        {
            CargarUsuarios();
        }

        public static void GuardarUsuarios()
        {
            List<string> lineas = new List<string>();

            foreach (Usuario u in listaUsuarios)
            {
                string linea = u.codigo + "|" + u.dni + "|" + u.nombres + "|" + u.correo + "|" + u.celular + "|" + u.contraseña;
                lineas.Add(linea);
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }

        public static void CargarUsuarios()
        {
            if (!File.Exists(rutaArchivo))
            {
                return;
            }

            listaUsuarios.Clear();
            string[] lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                if (linea != "")
                {
                    string[] datos = linea.Split('|');

                    if (datos.Length == 6)
                    {
                        Usuario usuarioCargado = new Usuario();
                        usuarioCargado.codigo = datos[0];
                        usuarioCargado.dni = datos[1];
                        usuarioCargado.nombres = datos[2];
                        usuarioCargado.correo = datos[3];
                        usuarioCargado.celular = datos[4];
                        usuarioCargado.contraseña = datos[5];

                        listaUsuarios.Add(usuarioCargado);
                    }
                }
            }
        }
    }
}