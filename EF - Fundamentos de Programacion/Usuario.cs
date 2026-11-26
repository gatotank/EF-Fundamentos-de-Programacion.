
using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp2
{
    // Estructura que almacena la información de cada usuario del sistema.
    public struct Usuario
    {
        // Datos personales y de acceso del usuario.
        public string codigo;
        public string dni;
        public string nombres;
        public string correo;
        public string celular;
        public string contraseña;

        // Indica si el usuario tiene permisos de administrador.
        // true = Administrador, false = Trabajador.
        public bool esAdmin;

        // Lista estática que almacena a todos los usuarios registrados.
        // Al ser static, puede utilizarse desde otras clases sin crear un objeto Usuario.
        public static List<Usuario> listaUsuarios = new List<Usuario>();

        // Almacena los datos del usuario que inició sesión actualmente.
        public static Usuario usuarioActual;

        // Ruta del archivo donde se guardan los usuarios.
        private static string rutaArchivo = "usuarios.dat";

        // Carga los usuarios almacenados en el archivo binario.
        public static void CargarUsuarios()
        {
            // Limpia la lista para evitar que se repitan los usuarios al volver a cargarla.
            listaUsuarios.Clear();

            // Comprueba si el archivo de usuarios existe.
            if (File.Exists(rutaArchivo))
            {
                // Abre el archivo en modo lectura.
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))

                // Permite leer los datos almacenados en formato binario.
                using (BinaryReader br = new BinaryReader(fs))
                {
                    // Lee la cantidad de usuarios almacenados en el archivo.
                    int cantidad = br.ReadInt32();

                    // Recorre la cantidad de usuarios registrados.
                    for (int i = 0; i < cantidad; i++)
                    {
                        // Crea una nueva estructura Usuario para almacenar los datos leídos.
                        Usuario u = new Usuario();

                        // Lee cada dato en el mismo orden en que fue guardado.
                        u.codigo = br.ReadString();
                        u.dni = br.ReadString();
                        u.nombres = br.ReadString();
                        u.correo = br.ReadString();
                        u.celular = br.ReadString();
                        u.contraseña = br.ReadString();
                        u.esAdmin = br.ReadBoolean();

                        // Agrega el usuario leído a la lista.
                        listaUsuarios.Add(u);
                    }
                }
            }

            // Verificar que siempre exista la cuenta predefinida de Administrador.
            bool existeAdmin = false;

            // Recorre la lista para comprobar si ya existe un administrador.
            foreach (Usuario u in listaUsuarios)
            {
                if (u.esAdmin)
                {
                    // Si encuentra un administrador, cambia el valor a true.
                    existeAdmin = true;

                    // Detiene el recorrido porque ya encontró uno.
                    break;
                }
            }

            // Si no existe ningún administrador, crea una cuenta predeterminada.
            if (!existeAdmin)
            {
                Usuario admin = new Usuario();

                // Asigna los datos de la cuenta de administrador.
                admin.codigo = "ADMIN-01";
                admin.dni = "00000000";
                admin.nombres = "Administrador";
                admin.correo = "admin@sistema.gob.pe";
                admin.celular = "999999999";
                admin.contraseña = "123456";
                admin.esAdmin = true;

                // Inserta al administrador en la primera posición de la lista.
                listaUsuarios.Insert(0, admin);

                // Guarda la lista actualizada en el archivo.
                GuardarUsuarios();
            }
        }

        // Guarda todos los usuarios de la lista en el archivo binario.
        public static void GuardarUsuarios()
        {
            // Abre o crea el archivo en modo escritura.
            // FileMode.Create reemplaza el contenido anterior del archivo.
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))

            // Permite escribir los datos en formato binario.
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                // Primero guarda la cantidad de usuarios que contiene la lista.
                bw.Write(listaUsuarios.Count);

                // Recorre todos los usuarios registrados.
                foreach (Usuario u in listaUsuarios)
                {
                    // Guarda los datos de cada usuario en un orden determinado.
                    // Si algún campo de texto es null, se guarda como una cadena vacía.
                    bw.Write(u.codigo ?? "");
                    bw.Write(u.dni ?? "");
                    bw.Write(u.nombres ?? "");
                    bw.Write(u.correo ?? "");
                    bw.Write(u.celular ?? "");
                    bw.Write(u.contraseña ?? "");

                    // Guarda el valor booleano que indica si es administrador.
                    bw.Write(u.esAdmin);
                }
            }
        }

        // Genera un nuevo código para el siguiente trabajador registrado.
        public static string GenerarNuevoCodigo()
        {
            // Variable que almacena el número más alto de los códigos existentes.
            int maxTrabajador = 0;

            // Recorre todos los usuarios registrados.
            foreach (Usuario u in listaUsuarios)
            {
                // Comprueba que el usuario no sea administrador y que tenga un código.
                if (!u.esAdmin && !string.IsNullOrEmpty(u.codigo))
                {
                    // Elimina el prefijo "USR-" y los espacios adicionales del código.
                    string soloNumeros = u.codigo.Replace("USR-", "").Trim();

                    // Variable donde se intentará convertir el código a un número.
                    int num;

                    // Comprueba si el código restante puede convertirse a un número.
                    // Si es mayor que el máximo encontrado, actualiza maxTrabajador.
                    if (int.TryParse(soloNumeros, out num) && num > maxTrabajador)
                    {
                        maxTrabajador = num;
                    }
                }
            }

            // Devuelve el siguiente número disponible con cuatro dígitos.
            // Ejemplo: 0001, 0002, 0003...
            return (maxTrabajador + 1).ToString("D4");
        }
    }
}
