using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp2
{
    // Estructura que representa un trámite o expediente registrado en el sistema.
    public struct Expediente
    {
        // Campos que describen los datos de cada expediente (compatibles con Form3 y Form5):
        public string codigo;         // Identificador correlativo de 5 dígitos (ej. "00001")
        public string dni;            // Documento de identidad del trabajador que registró el trámite
        public string titular;        // Nombres y apellidos completos del trabajador/titular
        public string asunto;         // Nombre del trámite seleccionado
        public string fechaCita;      // Fecha y franja horaria agendada para la cita
        public string fechaRegistro;  // Fecha y hora exacta en que se creó el expediente
        public string estado;         // Estado actual: "PENDIENTE", "APROBADO", "POSPUESTO" o "DENEGADO"

        // Lista estática compartida en memoria RAM por todos los formularios:
        public static List<Expediente> listaExpedientes = new List<Expediente>();

        // Ruta y nombre del archivo binario donde se almacenan los expedientes:
        private static string rutaArchivo = "expedientes.dat";

        // Guarda toda la lista de expedientes en el archivo binario expedientes.dat:
        public static void GuardarExpedientes()
        {
            // Crea o reemplaza el archivo binario y abre un flujo de escritura:
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                // Escribe primero la cantidad total de expedientes para saber cuántos leer después:
                bw.Write(listaExpedientes.Count);

                // Recorre cada expediente de la lista y escribe sus 7 campos en orden fijo:
                foreach (Expediente exp in listaExpedientes)
                {
                    bw.Write(exp.codigo ?? "");
                    bw.Write(exp.dni ?? "");
                    bw.Write(exp.titular ?? "");
                    bw.Write(exp.asunto ?? "");
                    bw.Write(exp.fechaCita ?? "");
                    bw.Write(exp.fechaRegistro ?? "");
                    bw.Write(exp.estado ?? "PENDIENTE");
                }
            }
        }

        // Lee los expedientes desde el archivo binario expedientes.dat al iniciar el sistema:
        public static void CargarExpedientes()
        {
            // Limpia la lista en memoria para evitar registros duplicados:
            listaExpedientes.Clear();

            // Si el archivo binario aún no existe en el disco, sale sin error:
            if (!File.Exists(rutaArchivo)) return;

            // Abre el archivo binario existente en modo lectura:
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                // Lee primero la cantidad total de registros almacenados:
                int cantidad = br.ReadInt32();

                // Reconstruye cada expediente leyendo sus 7 campos en el mismo orden en que se escribieron:
                for (int i = 0; i < cantidad; i++)
                {
                    Expediente exp = new Expediente();
                    exp.codigo = br.ReadString();
                    exp.dni = br.ReadString();
                    exp.titular = br.ReadString();
                    exp.asunto = br.ReadString();
                    exp.fechaCita = br.ReadString();
                    exp.fechaRegistro = br.ReadString();
                    exp.estado = br.ReadString();

                    // Añade el expediente reconstruido a la lista global en memoria:
                    listaExpedientes.Add(exp);
                }
            }
        }

        // Genera el siguiente código correlativo de 5 dígitos (00001, 00002...):
        public static string GenerarNuevoCodigo()
        {
            int maxCodigo = 0;

            // Recorre todos los expedientes existentes para encontrar el número más alto:
            foreach (Expediente exp in listaExpedientes)
            {
                int num;
                if (int.TryParse(exp.codigo, out num) && num > maxCodigo)
                {
                    maxCodigo = num;
                }
            }

            // Suma 1 al mayor encontrado y lo formatea con 5 dígitos rellenando ceros a la izquierda:
            return (maxCodigo + 1).ToString("D5");
        }
    }
}