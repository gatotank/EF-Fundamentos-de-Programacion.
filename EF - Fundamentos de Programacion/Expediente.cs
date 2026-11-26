using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp2
{
    public struct Expediente
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
        private static string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "expedientes.dat");

        static Expediente()
        {
            CargarExpedientes();
        }

        public static void GuardarExpedientes()
        {
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(listaExpedientes.Count);
                foreach (Expediente exp in listaExpedientes)
                {
                    bw.Write(exp.codigo ?? "");
                    bw.Write(exp.codigoUsuario ?? "");
                    bw.Write(exp.dni ?? "");
                    bw.Write(exp.titular ?? "");
                    bw.Write(exp.asunto ?? "");
                    bw.Write(exp.fechaCita ?? "");
                    bw.Write(exp.fechaRegistro ?? "");
                    bw.Write(exp.estado ?? "");
                }
            }
        }

        public static void CargarExpedientes()
        {
            if (!File.Exists(rutaArchivo))
            {
                return;
            }

            listaExpedientes.Clear();
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                int cantidad = br.ReadInt32();
                for (int i = 0; i < cantidad; i++)
                {
                    Expediente exp = new Expediente();
                    exp.codigo = br.ReadString();
                    exp.codigoUsuario = br.ReadString();
                    exp.dni = br.ReadString();
                    exp.titular = br.ReadString();
                    exp.asunto = br.ReadString();
                    exp.fechaCita = br.ReadString();
                    exp.fechaRegistro = br.ReadString();
                    exp.estado = br.ReadString();
                    listaExpedientes.Add(exp);
                }
            }
        }

        public static string GenerarNuevoCodigo()
        {
            int maxNum = 0;
            foreach (Expediente exp in listaExpedientes)
            {
                int num;
                if (int.TryParse(exp.codigo, out num) && num > maxNum)
                {
                    maxNum = num;
                }
            }
            return (maxNum + 1).ToString("D5"); // Genera 00001, 00002, 00003...
        }
    }
}