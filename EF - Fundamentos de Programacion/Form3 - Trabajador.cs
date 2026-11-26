
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        // Variable que indica si el usuario está cerrando sesión.
        // Permite diferenciar entre cerrar sesión y cerrar toda la aplicación.
        bool cerrarSesion = false;

        // Arreglo que almacena los nombres de los trámites disponibles.
        string[] listaTramites = new string[]
        {
            "1. Duplicado de DNI (Azul / Electrónico)",
            "2. Renovación de DNI por Caducidad",
            "3. Rectificación de Domicilio",
            "4. Rectificación de Estado Civil",
            "5. Rectificación de Nombres o Apellidos",
            "6. Inscripción de Acta de Nacimiento",
            "7. Copia Certificada de Acta de Nacimiento",
            "8. Copia Certificada de Acta de Matrimonio",
            "9. Copia Certificada de Acta de Defunción",
            "10. Certificado de Inscripción (C4)",
            "11. Emisión de DNI Electrónico por Primera Vez",
            "12. Actualización de Fotografía y Firma",
            "13. Cambio de Lugar de Entrega de DNI",
            "14. Cancelación de Trámite en Curso",
            "15. Otros"
        };

        // Arreglo que contiene las descripciones de cada trámite.
        // Cada descripción corresponde a la misma posición de listaTramites.
        string[] descripcionesTramites = new string[]
        {
            "Emisión de una copia idéntica del DNI vigente por pérdida, robo o deterioro. Conserva la misma fecha de caducidad y datos actuales.",
            "Actualización del documento de identidad próximo a vencer (desde 60 días antes) o ya caducado. Permite renovar fotografía.",
            "Actualización de la dirección de residencia habitual en el DNI. Requiere recibo de servicios públicos reciente.",
            "Modificación de estado civil de soltero a casado, divorciado o viudo mediante presentación de acta sustentatoria.",
            "Corrección de errores ortográficos o datos registrados en el acta de nacimiento dentro del documento de identidad.",
            "Registro oficial de nacimiento en la base de datos civil para obtener la partida original y generar el CUI.",
            "Expedición de copia autenticada de partida de nacimiento registrada en las oficinas incorporadas a RENIEC.",
            "Expedición de copia autenticada de partida de matrimonio civil para trámites legales o administrativos.",
            "Expedición de copia autenticada de acta de defunción inscrita en el registro civil.",
            "Documento oficial que acredita los datos biográficos y biométricos inscritos en el Registro Único de Identificación.",
            "Obtención del DNIe con chip criptográfico y certificados digitales para firma electrónica y trámites en línea.",
            "Renovación de imagen facial y firma manuscrita cuando los rasgos físicos o rúbrica han cambiado significativamente.",
            "Solicitud de traslado del documento ya tramitado hacia una agencia u oficina registral distinta a la elegida inicialmente.",
            "Anulación formal de una solicitud en proceso antes de la impresión del documento.",
            "Trámite administrativo especial no contemplado en el listado estándar. Especifique el detalle en el cuadro inferior."
        };

        // Constructor del formulario.
        // Se ejecuta cuando se crea una nueva instancia de Form3.
        public Form3()
        {
            // Inicializa los controles visuales del formulario.
            InitializeComponent();
        }

        // Método sobrescrito que se ejecuta cuando se cierra el formulario.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Ejecuta el comportamiento original de cierre del formulario.
            base.OnFormClosed(e);

            // Si el usuario no cerró sesión mediante el botón correspondiente,
            // se cierra toda la aplicación.
            if (!cerrarSesion)
            {
                Application.Exit();
            }
        }

        // Evento que se ejecuta cuando se cierra el formulario Form3.
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Comprueba si el cierre no fue realizado mediante el botón de cerrar sesión.
            if (!cerrarSesion)
            {
                // Finaliza toda la aplicación.
                Application.Exit();
            }
        }

        // Evento que se ejecuta cuando se carga el formulario.
        // Configura los controles y muestra la información inicial.
        private void Form3_Load(object sender, EventArgs e)
        {
            // Establece que al presionar Enter se ejecute el botón Registrar trámite.
            this.AcceptButton = btnRegistrarTramite;

            // Detecta cuando el usuario cambia de pestaña.
            // Cambia el botón que se ejecutará al presionar Enter según la pestaña.
            tabControl1.SelectedIndexChanged += (s, ev) =>
            {
                // Índice 0: pestaña Registrar trámite.
                if (tabControl1.SelectedIndex == 0) this.AcceptButton = btnRegistrarTramite;

                // Índice 1: pestaña Consultar por código.
                else if (tabControl1.SelectedIndex == 1) this.AcceptButton = btnConsultarDni;

                // Índice 2: pestaña Mis expedientes.
                else if (tabControl1.SelectedIndex == 2) this.AcceptButton = btnOrdenar;
            };

            // Establece el título de la ventana.
            this.Text = "Mesa de Partes Digital - Trabajador";

            // Muestra el nombre del usuario que inició sesión.
            lblBienvenida.Text = "Bienvenido, " + Usuario.usuarioActual.nombres;

            // Muestra el código y DNI del usuario actual.
            lblDatosUsuario.Text = "Código: " + Usuario.usuarioActual.codigo + "  |  DNI: " + Usuario.usuarioActual.dni;

            // Establece los nombres de las tres pestañas del formulario.
            tabPage1.Text = "1. Registrar trámite";
            tabPage2.Text = "2. Consultar por código";
            tabPage3.Text = "3. Mis expedientes";

            // Carga las opciones de trámites en el ComboBox.
            CargarOpcionesTramites();

            // Configura el calendario y los horarios para programar una cita.
            ConfigurarCalendarioYHoras();

            // Establece el mensaje de indicación para consultar un expediente.
            label5.Text = "Ingrese el código del expediente (ej. 00001) para ver su detalle:";

            // Limita a 10 la cantidad máxima de caracteres del campo de consulta.
            txtConsultaDni.MaxLength = 10;

            // Limpia el campo donde se ingresa el código del expediente.
            txtConsultaDni.Text = "";

            // Limpia el cuadro donde se muestran los resultados de la consulta.
            txtResultadoConsulta.Text = "";

            // Configura las columnas de la tabla de expedientes.
            ConfigurarColumnasExpedientes();

            // Carga las opciones disponibles para ordenar los expedientes.
            CargarComboOrdenar();

            // Muestra los expedientes correspondientes al usuario actual.
            MostrarExpedientesTrabajador(Expediente.listaExpedientes);
        }

        // Carga los tipos de trámites disponibles en el ComboBox.
        private void CargarOpcionesTramites()
        {
            // Elimina las opciones anteriores del ComboBox.
            cmbTramites.Items.Clear();

            // Recorre el arreglo que contiene los nombres de los trámites.
            foreach (string t in listaTramites)

                // Agrega cada trámite al ComboBox.
                cmbTramites.Items.Add(t);

            // Selecciona automáticamente la primera opción.
            cmbTramites.SelectedIndex = 0;
        }

        // Configura el calendario y los horarios disponibles para las citas.
        private void ConfigurarCalendarioYHoras()
        {
            // Obtiene la fecha actual y le suma un día.
            DateTime manana = DateTime.Today.AddDays(1);

            // Establece mañana como la fecha mínima que se puede seleccionar.
            calCita.MinDate = manana;

            // Selecciona mañana como fecha inicial del calendario.
            calCita.SelectionStart = manana;
            calCita.SelectionEnd = manana;

            // Limpia los horarios que pudiera tener anteriormente el ComboBox.
            cmbHoraCita.Items.Clear();

            // Agrega los horarios disponibles para programar una cita.
            cmbHoraCita.Items.Add("09:00 AM - 10:00 AM");
            cmbHoraCita.Items.Add("10:00 AM - 11:00 AM");
            cmbHoraCita.Items.Add("11:00 AM - 12:00 PM");
            cmbHoraCita.Items.Add("12:00 PM - 01:00 PM");
            cmbHoraCita.Items.Add("02:00 PM - 03:00 PM");
            cmbHoraCita.Items.Add("03:00 PM - 04:00 PM");

            // Selecciona automáticamente el primer horario disponible.
            cmbHoraCita.SelectedIndex = 0;

            // Actualiza la etiqueta que muestra la fecha y el horario de la cita.
            ActualizarTextoCita();
        }

        // Actualiza el texto que muestra la fecha y hora seleccionadas para la cita.
        private void ActualizarTextoCita()
        {
            // Comprueba que exista un horario seleccionado.
            if (cmbHoraCita.SelectedItem != null)
            {
                // Muestra la fecha seleccionada y el horario elegido por el usuario.
                // El formato dd/MM/yyyy representa día, mes y año.
                lblCitaSeleccionada.Text = "Cita: " + calCita.SelectionStart.ToString("dd/MM/yyyy") + " | " + cmbHoraCita.SelectedItem.ToString();
            }
        }

        // Evento que se ejecuta cuando el usuario cambia el trámite seleccionado.
        private void cmbTramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtiene la posición de la opción seleccionada en el ComboBox.
            int idx = cmbTramites.SelectedIndex;

            // Comprueba que el índice sea válido y muestra la descripción correspondiente.
            if (idx >= 0 && idx < descripcionesTramites.Length)
                lblDetalleTramite.Text = descripcionesTramites[idx];

            // Comprueba si el usuario seleccionó la opción número 15: Otros.
            if (cmbTramites.SelectedItem != null && cmbTramites.SelectedItem.ToString().StartsWith("15."))
            {
                // Hace visible la etiqueta para especificar otro trámite.
                lblOtroTramite.Visible = true;

                // Muestra el campo de texto donde se escribirá el trámite.
                txtOtroTramite.Visible = true;

                // Coloca el cursor en el campo de texto.
                txtOtroTramite.Focus();
            }
            else
            {
                // Oculta la etiqueta cuando no se selecciona la opción Otros.
                lblOtroTramite.Visible = false;

                // Oculta el campo de texto.
                txtOtroTramite.Visible = false;

                // Limpia cualquier descripción ingresada anteriormente.
                txtOtroTramite.Text = "";
            }
        }

        // Evento que se ejecuta cuando el usuario cambia la fecha del calendario.
        private void calCita_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Actualiza la etiqueta con la nueva fecha y el horario seleccionado.
            ActualizarTextoCita();
        }

        // Evento que se ejecuta cuando el usuario cambia el horario de la cita.
        private void cmbHoraCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualiza la etiqueta para mostrar el nuevo horario seleccionado.
            ActualizarTextoCita();
        }

        // Evento que se ejecuta cuando el usuario presiona el botón Registrar trámite.
        private void btnRegistrarTramite_Click(object sender, EventArgs e)
        {
            // Comprueba que el usuario haya seleccionado un trámite y un horario.
            if (cmbTramites.SelectedItem == null || cmbHoraCita.SelectedItem == null)
            {
                // Muestra una advertencia si falta seleccionar algún dato.
                MessageBox.Show("Seleccione un trámite y un horario de atención.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Detiene la ejecución del método.
                return;
            }

            // Guarda en una variable el nombre del trámite seleccionado.
            string asuntoFinal = cmbTramites.SelectedItem.ToString();

            // Comprueba si el trámite seleccionado corresponde a la opción Otros.
            if (asuntoFinal.StartsWith("15."))
            {
                // Verifica que el usuario haya escrito una descripción.
                // IsNullOrWhiteSpace comprueba si el texto está vacío o contiene espacios.
                if (string.IsNullOrWhiteSpace(txtOtroTramite.Text))
                {
                    // Muestra una advertencia si no se especificó el trámite.
                    MessageBox.Show("Por favor, especifique el trámite que desea realizar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Coloca el cursor en el campo que debe completarse.
                    txtOtroTramite.Focus();

                    // Detiene la ejecución del método.
                    return;
                }

                // Guarda el trámite personalizado eliminando espacios al inicio y al final.
                asuntoFinal = "Otros: " + txtOtroTramite.Text.Trim();
            }

            // Crea un nuevo objeto de tipo Expediente.
            Expediente nuevo = new Expediente();

            // Genera un código único para identificar el expediente.
            nuevo.codigo = Expediente.GenerarNuevoCodigo();

            // Asigna el DNI del usuario que inició sesión.
            nuevo.dni = Usuario.usuarioActual.dni;

            // Asigna los nombres del titular del expediente.
            nuevo.titular = Usuario.usuarioActual.nombres;

            // Guarda el trámite que el usuario desea realizar.
            nuevo.asunto = asuntoFinal;

            // Guarda la fecha y el horario seleccionados para la cita.
            nuevo.fechaCita = calCita.SelectionStart.ToString("dd/MM/yyyy") + " (" + cmbHoraCita.SelectedItem.ToString() + ")";

            // Registra la fecha y hora exactas en que se creó el expediente.
            nuevo.fechaRegistro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Establece el estado inicial del expediente como PENDIENTE.
            nuevo.estado = "PENDIENTE";

            // Agrega el nuevo expediente a la lista general de expedientes.
            Expediente.listaExpedientes.Add(nuevo);

            // Guarda los expedientes utilizando el método de almacenamiento de la clase Expediente.
            Expediente.GuardarExpedientes();

            // Muestra un mensaje de confirmación con los datos del expediente registrado.
            MessageBox.Show(
                "Expediente registrado exitosamente." + Environment.NewLine + Environment.NewLine +
                "Código de expediente: " + nuevo.codigo + Environment.NewLine +
                "Trámite: " + nuevo.asunto + Environment.NewLine +
                "Cita: " + nuevo.fechaCita + Environment.NewLine +
                "Estado: " + nuevo.estado,
                "Registro completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpia el campo utilizado para especificar otros trámites.
            txtOtroTramite.Text = "";

            // Actualiza la tabla para mostrar el expediente recién registrado.
            MostrarExpedientesTrabajador(Expediente.listaExpedientes);
        }

        // Evento que controla los caracteres que se pueden escribir en el campo de consulta.
        private void txtConsultaDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite escribir números y utilizar teclas de control, como Retroceso.
            // Bloquea cualquier otro carácter.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Evento que se ejecuta cuando el usuario presiona el botón Consultar.
        private void btnConsultarDni_Click(object sender, EventArgs e)
        {
            // Obtiene el código ingresado y elimina los espacios innecesarios.
            string criterio = txtConsultaDni.Text.Trim();

            // Comprueba que el campo no esté vacío.
            if (string.IsNullOrWhiteSpace(criterio))
            {
                // Muestra un mensaje indicando que debe ingresar un código.
                MessageBox.Show("Ingrese el código de expediente (ejemplo: 00001).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Coloca el cursor en el campo de consulta.
                txtConsultaDni.Focus();

                // Detiene la ejecución del método.
                return;
            }

            // Variable que almacenará el código convertido a número entero.
            int numCodigo;

            // Intenta convertir el código ingresado de texto a número.
            if (int.TryParse(criterio, out numCodigo))
            {
                // Convierte el número a un texto de cinco dígitos.
                // D5 agrega ceros a la izquierda cuando sea necesario.
                criterio = numCodigo.ToString("D5");

                // Actualiza el campo de consulta con el código normalizado.
                txtConsultaDni.Text = criterio;
            }

            // Variable que indica si se encontró el expediente.
            // Inicialmente se establece en false.
            bool hallado = false;

            // Recorre todos los expedientes almacenados en la lista general.
            foreach (Expediente exp in Expediente.listaExpedientes)
            {
                // Comprueba que coincidan el código del expediente y el DNI del usuario actual.
                if (exp.codigo == criterio && exp.dni == Usuario.usuarioActual.dni)
                {
                    // Indica que el expediente fue encontrado.
                    hallado = true;

                    // Muestra los datos completos del expediente en el cuadro de resultados.
                    txtResultadoConsulta.Text =
                        "DETALLE DEL EXPEDIENTE N° " + exp.codigo + Environment.NewLine +
                        "======================================================================" + Environment.NewLine + Environment.NewLine +
                        "Código de Expediente : " + exp.codigo + Environment.NewLine +
                        "Titular              : " + exp.titular + Environment.NewLine +
                        "DNI                  : " + exp.dni + Environment.NewLine +
                        "Trámite Solicitado   : " + exp.asunto + Environment.NewLine +
                        "Cita Programada      : " + exp.fechaCita + Environment.NewLine +
                        "Fecha de Registro    : " + exp.fechaRegistro + Environment.NewLine +
                        "Estado Actual        : " + exp.estado + Environment.NewLine +
                        "======================================================================";

                    // Detiene el recorrido porque el expediente ya fue encontrado.
                    break;
                }
            }

            // Comprueba si no se encontró ningún expediente que cumpla las condiciones.
            if (!hallado)
            {
                // Muestra un mensaje indicando que no existe un expediente con ese código asociado al usuario.
                txtResultadoConsulta.Text = "No se encontró ningún expediente suyo con el código '" + criterio + "'.";
            }
        }

        // Configura las columnas que tendrá la tabla de expedientes.
        private void ConfigurarColumnasExpedientes()
        {
            // Elimina las columnas anteriores para evitar duplicados.
            lvExpedientes.Columns.Clear();

            // Agrega las columnas y establece sus respectivos anchos.
            lvExpedientes.Columns.Add("Código", 95);
            lvExpedientes.Columns.Add("DNI", 95);
            lvExpedientes.Columns.Add("Trabajador / Titular", 210);
            lvExpedientes.Columns.Add("Trámite Solicitado", 280);
            lvExpedientes.Columns.Add("Fecha Cita", 185);
            lvExpedientes.Columns.Add("Estado", 120);
        }

        // Carga las opciones disponibles para ordenar los expedientes.
        private void CargarComboOrdenar()
        {
            // Limpia las opciones anteriores del ComboBox.
            cmbOrdenar.Items.Clear();

            // Agrega los criterios de ordenamiento.
            cmbOrdenar.Items.Add("Código (Ascendente)");
            cmbOrdenar.Items.Add("Trámite (A - Z)");
            cmbOrdenar.Items.Add("Estado");

            // Selecciona por defecto el ordenamiento por código ascendente.
            cmbOrdenar.SelectedIndex = 0;
        }

        // Muestra los expedientes pertenecientes al usuario actual.
        // Recibe una lista de expedientes como parámetro.
        private void MostrarExpedientesTrabajador(List<Expediente> origen)
        {
            // Limpia los elementos que se muestran actualmente en la tabla.
            lvExpedientes.Items.Clear();

            // Inicializa el contador de expedientes del usuario.
            int contador = 0;

            // Recorre todos los expedientes recibidos.
            foreach (Expediente exp in origen)
            {
                // Comprueba que el expediente pertenezca al usuario que inició sesión.
                if (exp.dni == Usuario.usuarioActual.dni)
                {
                    // Aumenta en uno la cantidad de expedientes encontrados.
                    contador++;

                    // Crea una nueva fila utilizando el código como primer dato.
                    ListViewItem item = new ListViewItem(exp.codigo);

                    // Agrega los demás datos como columnas de la misma fila.
                    item.SubItems.Add(exp.dni);
                    item.SubItems.Add(exp.titular);
                    item.SubItems.Add(exp.asunto);
                    item.SubItems.Add(exp.fechaCita);
                    item.SubItems.Add(exp.estado);

                    // Agrega la fila completa a la tabla.
                    lvExpedientes.Items.Add(item);
                }
            }

            // Muestra la cantidad total de expedientes que pertenecen al usuario.
            lblCantidadExpedientes.Text = contador + " expediente(s) en total";
        }

        // Evento que se ejecuta cuando el usuario presiona el botón Ordenar.
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            // Crea una copia de la lista original para ordenar sin modificarla directamente.
            List<Expediente> copia = new List<Expediente>(Expediente.listaExpedientes);

            // Primer ciclo: controla las pasadas del algoritmo de ordenamiento burbuja.
            for (int i = 0; i < copia.Count - 1; i++)
            {
                // Segundo ciclo: compara los elementos que están uno al lado del otro.
                for (int j = 0; j < copia.Count - i - 1; j++)
                {
                    // Variable que indica si los dos expedientes deben intercambiarse.
                    bool intercambiar = false;

                    // Si se seleccionó Código ascendente, compara los códigos.
                    if (cmbOrdenar.SelectedIndex == 0 && string.Compare(copia[j].codigo, copia[j + 1].codigo) > 0)
                        intercambiar = true;

                    // Si se seleccionó Trámite, compara los nombres de los trámites alfabéticamente.
                    else if (cmbOrdenar.SelectedIndex == 1 && string.Compare(copia[j].asunto, copia[j + 1].asunto) > 0)
                        intercambiar = true;

                    // Si se seleccionó Estado, compara los estados de los expedientes.
                    else if (cmbOrdenar.SelectedIndex == 2 && string.Compare(copia[j].estado, copia[j + 1].estado) > 0)
                        intercambiar = true;

                    // Comprueba si es necesario intercambiar los dos expedientes.
                    if (intercambiar)
                    {
                        // Guarda temporalmente el primer expediente.
                        Expediente aux = copia[j];

                        // Coloca el segundo expediente en la posición del primero.
                        copia[j] = copia[j + 1];

                        // Coloca el expediente guardado en la posición del segundo.
                        copia[j + 1] = aux;
                    }
                }
            }

            // Muestra los expedientes utilizando la lista que ya fue ordenada.
            MostrarExpedientesTrabajador(copia);
        }

        // Evento que se ejecuta cuando el usuario presiona el botón Cerrar sesión.
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Indica que el formulario se está cerrando por una solicitud de cierre de sesión.
            cerrarSesion = true;

            // Crea una nueva instancia del formulario de inicio de sesión.
            Form1 login = new Form1();

            // Muestra nuevamente la pantalla de inicio de sesión.
            login.Show();

            // Cierra el formulario actual.
            this.Close();
        }
    }
}
