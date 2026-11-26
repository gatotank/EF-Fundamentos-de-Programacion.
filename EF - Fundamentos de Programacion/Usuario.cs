using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp2
{
    public struct Usuario
    {
        public string codigo;
        public string dni;
        public string nombres;
        public string correo;
        public string celular;
        public string contraseña;
        public bool esAdmin;

        public static List<Usuario> listaUsuarios = new List<Usuario>();
        public static Usuario usuarioActual;
        private static string rutaArchivo = "usuarios.dat";

        public static void CargarUsuarios()
        {
            listaUsuarios.Clear();

            if (File.Exists(rutaArchivo))
            {
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    int cantidad = br.ReadInt32();
                    for (int i = 0; i < cantidad; i++)
                    {
                        Usuario u = new Usuario();
                        u.codigo = br.ReadString();
                        u.dni = br.ReadString();
                        u.nombres = br.ReadString();
                        u.correo = br.ReadString();
                        u.celular = br.ReadString();
                        u.contraseña = br.ReadString();
                        u.esAdmin = br.ReadBoolean();
                        listaUsuarios.Add(u);
                    }
                }
            }

            // Verificar que siempre exista la cuenta predefinida de Administrador
            bool existeAdmin = false;
            foreach (Usuario u in listaUsuarios)
            {
                if (u.esAdmin)
                {
                    existeAdmin = true;
                    break;
                }
            }

            if (!existeAdmin)
            {
                Usuario admin = new Usuario();
                admin.codigo = "ADMIN-01";
                admin.dni = "00000000";
                admin.nombres = "Administrador";
                admin.correo = "admin@sistema.gob.pe";
                admin.celular = "999999999";
                admin.contraseña = "123456";
                admin.esAdmin = true;
                listaUsuarios.Insert(0, admin);
                GuardarUsuarios();
            }
        }

        public static void GuardarUsuarios()
        {
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(listaUsuarios.Count);
                foreach (Usuario u in listaUsuarios)
                {
                    bw.Write(u.codigo ?? "");
                    bw.Write(u.dni ?? "");
                    bw.Write(u.nombres ?? "");
                    bw.Write(u.correo ?? "");
                    bw.Write(u.celular ?? "");
                    bw.Write(u.contraseña ?? "");
                    bw.Write(u.esAdmin);
                }
            }
        }

        public static string GenerarNuevoCodigo()
        {
            // El primer trabajador registrado recibe 0001 (o USR-0001 si Form2 agrega el prefijo)
            int maxTrabajador = 0;
            foreach (Usuario u in listaUsuarios)
            {
                if (!u.esAdmin && !string.IsNullOrEmpty(u.codigo))
                {
                    string soloNumeros = u.codigo.Replace("USR-", "").Trim();
                    int num;
                    if (int.TryParse(soloNumeros, out num) && num > maxTrabajador)
                    {
                        maxTrabajador = num;
                    }
                }
            }
            return (maxTrabajador + 1).ToString("D4");
        }
    }
}