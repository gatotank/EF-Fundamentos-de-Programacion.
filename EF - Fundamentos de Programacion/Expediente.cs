
using System;
using System.Collections.Generic;
using System.IO;

public struct Expediente
{
    // Datos que identifican y describen cada expediente.
    public string codigo;
    public string dni;
    public string tipoTramite;
    public string descripcion;
    public string fecha;
    public string hora;
    public string estado;
    public string codigoUsuario;

    // Lista estática que almacena todos los expedientes.
    // Al ser static, puede utilizarse desde otros formularios sin crear un objeto.
    public static List<Expediente> listaExpedientes = new List<Expediente>();

    // Ruta donde se guardará el archivo binario de los expedientes.
    private static string rutaArchivo = "expedientes.dat";

    // Constructor estático: se ejecuta automáticamente la primera vez
    // que se utiliza algún miembro estático de esta estructura.
    // Su función es cargar los expedientes guardados en el archivo.
    static Expediente()
    {
        CargarExpedientes();
    }

    // Guarda todos los expedientes de la lista en un archivo binario.
    public static void GuardarExpedientes()
    {
        // FileStream permite crear o abrir el archivo para escribir información.
        // FileMode.Create crea el archivo o reemplaza su contenido si ya existe.
        using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
        using (BinaryWriter bw = new BinaryWriter(fs))
        {
            // Primero guarda la cantidad de expedientes registrados.
            bw.Write(listaExpedientes.Count);

            // Recorre la lista para guardar los datos de cada expediente.
            foreach (Expediente e in listaExpedientes)
            {
                bw.Write(e.codigo ?? "");
                bw.Write(e.dni ?? "");
                bw.Write(e.tipoTramite ?? "");
                bw.Write(e.descripcion ?? "");
                bw.Write(e.fecha ?? "");
                bw.Write(e.hora ?? "");
                bw.Write(e.estado ?? "");
                bw.Write(e.codigoUsuario ?? "");
            }
        }
    }

    // Carga los expedientes almacenados en el archivo binario.
    public static void CargarExpedientes()
    {
        // Comprueba si el archivo existe antes de intentar leerlo.
        if (!File.Exists(rutaArchivo))
            return;

        // Limpia la lista para evitar duplicar los expedientes al cargarlos.
        listaExpedientes.Clear();

        // FileStream abre el archivo para lectura.
        // BinaryReader permite leer los datos guardados en formato binario.
        using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open))
        using (BinaryReader br = new BinaryReader(fs))
        {
            // Lee la cantidad de expedientes que fueron guardados.
            int cantidad = br.ReadInt32();

            // Repite el proceso según la cantidad de expedientes registrados.
            for (int i = 0; i < cantidad; i++)
            {
                // Crea un nuevo expediente para almacenar los datos leídos.
                Expediente e = new Expediente();

                // Recupera cada dato del archivo en el mismo orden en que se guardó.
                e.codigo = br.ReadString();
                e.dni = br.ReadString();
                e.tipoTramite = br.ReadString();
                e.descripcion = br.ReadString();
                e.fecha = br.ReadString();
                e.hora = br.ReadString();
                e.estado = br.ReadString();
                e.codigoUsuario = br.ReadString();

                // Agrega el expediente recuperado a la lista.
                listaExpedientes.Add(e);
            }
        }
    }

    // Genera un nuevo código para el siguiente expediente.
    public static string GenerarNuevoCodigo()
    {
        // Variable que almacena el número de código más alto encontrado.
        int max = 0;

        // Recorre todos los expedientes registrados.
        foreach (Expediente e in listaExpedientes)
        {
            // Intenta convertir el código de texto a un número entero.
            // Si la conversión funciona y el número es mayor que max, lo actualiza.
            if (int.TryParse(e.codigo, out int n) && n > max)
                max = n;
        }

        // Devuelve el siguiente número disponible con cinco dígitos.
        // Por ejemplo: 00001, 00002, 00003.
        return (max + 1).ToString("D5");
    }
}
