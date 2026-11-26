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

        // Arreglo que almacena los nombres de los 15 trámites disponibles.
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

        // Arreglo paralelo que contiene las descripciones de cada trámite.
        // Cada posición coincide exactamente con la posición en listaTramites.
        string[] descripcionesTramites = new string[]
        {
            "Emisión de una copia idéntica del DNI vigente por pérdida, robo o deterioro. Conserva la misma fecha de caducidad y datos actuales.",
            "Actualización del documento de identidad próximo a vencer (desde 60 días antes) o ya caducado. Permite renovar fotografía.",
            "Actualización de la dirección de residencia habitual en el DNI. Requiere recibo de servicios públicos reciente.",
            "Modificación de estado civil de soltero a casado, divorciado o viudo mediante presentación de acta sustentatoria.",
            "Corrección de errores ortográficos o datos registrados en el acta de nacimiento dentro del documento de identidad.",
            "Registro oficial de nacimiento en la base de datos civil para obtener la partida original y generar el CUI.",
            "Expedición de copia autenticada de partida de nacimiento registrada en las oficinas incorporadas.",
            "Expedición de copia autenticada de partida de matrimonio civil para trámites legales o administrativos.",
            "Expedición de copia autenticada de acta de defunción inscrita en el registro civil.",
            "Documento oficial que acredita los datos biográficos y biométricos inscritos en el Registro Único de Identificación.",
            "Obtención del DNIe con chip criptográfico y certificados digitales para firma electrónica y trámites en línea.",
            "Renovación de imagen facial y firma manuscrita cuando los rasgos físicos o rúbrica han cambiado significativamente.",
            "Solicitud de traslado del documento ya tramitado hacia una agencia u oficina registral distinta a la elegida inicialmente.",
            "Anulación formal de una solicitud en proceso antes de la impresión del documento.",
            "Trámite administrativo especial no contemplado en el listado estándar. Especifique el detalle en el cuadro inferior."
        };

        // Constructor del formulario: inicializa los componentes visuales diseñados.
        public Form3()
        {
            InitializeComponent();
        }

        // Método sobrescrito que se ejecuta al cerrar la ventana:
        // Si no fue por botón "Cerrar sesión", termina toda la aplicación.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!cerrarSesion)
            {
                Application.Exit();
            }
        }

        // Evento de cierre del formulario Form3:
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!cerrarSesion)
            {
                Application.Exit();
            }
        }

        // Evento que se ejecuta al cargar Form3: configura textos, controles y tablas iniciales.
        private void Form3_Load(object sender, EventArgs e)
        {
            // Asigna la tecla Enter al botón Registrar trámite al abrir la ventana:
            this.AcceptButton = btnRegistrarTramite;

            // Cambia dinámicamente el botón asociado a Enter según la pestaña seleccionada:
            tabControl1.SelectedIndexChanged += (s, ev) =>
            {
                if (tabControl1.SelectedIndex == 0) this.AcceptButton = btnRegistrarTramite;
                else if (tabControl1.SelectedIndex == 1) this.AcceptButton = btnConsultarDni;
                else if (tabControl1.SelectedIndex == 2) this.AcceptButton = btnOrdenar;
            };

            // Configura el título de la ventana y los datos del trabajador autenticado:
            this.Text = "Mesa de Partes - Trabajador";
            lblBienvenida.Text = "Bienvenido, " + Usuario.usuarioActual.nombres;
            lblDatosUsuario.Text = "Código: " + Usuario.usuarioActual.codigo + "  |  DNI: " + Usuario.usuarioActual.dni;

            // Asigna títulos a las tres pestañas principales:
            tabPage1.Text = "1. Registrar trámite";
            tabPage2.Text = "2. Consultar por código";
            tabPage3.Text = "3. Mis expedientes";

            // Carga el listado de trámites y configura el calendario/horarios:
            CargarOpcionesTramites();
            ConfigurarCalendarioYHoras();

            // Prepara los controles de la pestaña de consulta por código:
            label5.Text = "Ingrese el código del expediente (ej. 00001) para ver su detalle:";
            txtConsultaDni.MaxLength = 10;
            txtConsultaDni.Text = "";
            txtResultadoConsulta.Text = "";

            // Configura columnas de la tabla, opciones de ordenamiento y carga expedientes propios:
            ConfigurarColumnasExpedientes();
            CargarComboOrdenar();
            MostrarExpedientesTrabajador(Expediente.listaExpedientes);
        }

        // Llena el ComboBox con los 15 trámites definidos en el arreglo listaTramites:
        private void CargarOpcionesTramites()
        {
            cmbTramites.Items.Clear();
            foreach (string t in listaTramites)
                cmbTramites.Items.Add(t);
            cmbTramites.SelectedIndex = 0;
        }

        // Configura el calendario desde mañana y las franjas horarias (excluyendo refrigerio 1-2 PM):
        private void ConfigurarCalendarioYHoras()
        {
            DateTime manana = DateTime.Today.AddDays(1);
            calCita.MinDate = manana;
            calCita.SelectionStart = manana;
            calCita.SelectionEnd = manana;

            cmbHoraCita.Items.Clear();
            cmbHoraCita.Items.Add("09:00 AM - 10:00 AM");
            cmbHoraCita.Items.Add("10:00 AM - 11:00 AM");
            cmbHoraCita.Items.Add("11:00 AM - 12:00 PM");
            cmbHoraCita.Items.Add("12:00 PM - 01:00 PM");
            cmbHoraCita.Items.Add("02:00 PM - 03:00 PM");
            cmbHoraCita.Items.Add("03:00 PM - 04:00 PM");
            cmbHoraCita.SelectedIndex = 0;

            ActualizarTextoCita();
        }

        // Actualiza la etiqueta resumen con la fecha y horario elegidos por el trabajador:
        private void ActualizarTextoCita()
        {
            if (cmbHoraCita.SelectedItem != null)
            {
                lblCitaSeleccionada.Text = "Cita: " + calCita.SelectionStart.ToString("dd/MM/yyyy") + " | " + cmbHoraCita.SelectedItem.ToString();
            }
        }

        // Muestra la descripción del trámite elegido y habilita el cuadro extra si elige "15. Otros":
        private void cmbTramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cmbTramites.SelectedIndex;
            if (idx >= 0 && idx < descripcionesTramites.Length)
                lblDetalleTramite.Text = descripcionesTramites[idx];

            // Si selecciona la opción 15 ("Otros"), muestra el campo de texto adicional:
            if (cmbTramites.SelectedItem != null && cmbTramites.SelectedItem.ToString().StartsWith("15."))
            {
                lblOtroTramite.Visible = true;
                txtOtroTramite.Visible = true;
                txtOtroTramite.Focus();
            }
            else
            {
                lblOtroTramite.Visible = false;
                txtOtroTramite.Visible = false;
                txtOtroTramite.Text = "";
            }
        }

        // Actualiza el texto de la cita cuando cambia la fecha en el calendario:
        private void calCita_DateChanged(object sender, DateRangeEventArgs e)
        {
            ActualizarTextoCita();
        }

        // Actualiza el texto de la cita cuando cambia la hora en el ComboBox:
        private void cmbHoraCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTextoCita();
        }

        // Valida y registra un nuevo expediente en memoria y en el archivo binario expedientes.dat:
        private void btnRegistrarTramite_Click(object sender, EventArgs e)
        {
            if (cmbTramites.SelectedItem == null || cmbHoraCita.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un trámite y un horario de atención.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string asuntoFinal = cmbTramites.SelectedItem.ToString();

            // Si eligió "15. Otros", verifica que haya escrito el detalle del trámite:
            if (asuntoFinal.StartsWith("15."))
            {
                if (string.IsNullOrWhiteSpace(txtOtroTramite.Text))
                {
                    MessageBox.Show("Por favor, especifique el trámite que desea realizar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOtroTramite.Focus();
                    return;
                }
                asuntoFinal = "Otros: " + txtOtroTramite.Text.Trim();
            }

            // Crea la estructura Expediente y completa todos sus campos:
            Expediente nuevo = new Expediente();
            nuevo.codigo = Expediente.GenerarNuevoCodigo();
            nuevo.dni = Usuario.usuarioActual.dni;
            nuevo.titular = Usuario.usuarioActual.nombres;
            nuevo.asunto = asuntoFinal;
            nuevo.fechaCita = calCita.SelectionStart.ToString("dd/MM/yyyy") + " (" + cmbHoraCita.SelectedItem.ToString() + ")";
            nuevo.fechaRegistro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            nuevo.estado = "PENDIENTE";

            // Añade a la lista estática y guarda en disco binario:
            Expediente.listaExpedientes.Add(nuevo);
            Expediente.GuardarExpedientes();

            // Muestra comprobante de registro al usuario:
            MessageBox.Show(
                "Expediente registrado exitosamente." + Environment.NewLine + Environment.NewLine +
                "Código de expediente: " + nuevo.codigo + Environment.NewLine +
                "Trámite: " + nuevo.asunto + Environment.NewLine +
                "Cita: " + nuevo.fechaCita + Environment.NewLine +
                "Estado: " + nuevo.estado,
                "Registro completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtOtroTramite.Text = "";
            MostrarExpedientesTrabajador(Expediente.listaExpedientes);
        }

        // Restringe la entrada de teclado en la consulta para permitir solo números:
        private void txtConsultaDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Busca un expediente por código de 5 dígitos perteneciente al trabajador actual:
        private void btnConsultarDni_Click(object sender, EventArgs e)
        {
            string criterio = txtConsultaDni.Text.Trim();
            if (string.IsNullOrWhiteSpace(criterio))
            {
                MessageBox.Show("Ingrese el código de expediente (ejemplo: 00001).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConsultaDni.Focus();
                return;
            }

            // Normaliza números cortos a formato de 5 dígitos (ej. "1" -> "00001"):
            int numCodigo;
            if (int.TryParse(criterio, out numCodigo))
            {
                criterio = numCodigo.ToString("D5");
                txtConsultaDni.Text = criterio;
            }

            bool hallado = false;
            foreach (Expediente exp in Expediente.listaExpedientes)
            {
                // Verifica que el código coincida Y pertenezca al DNI del usuario actual:
                if (exp.codigo == criterio && exp.dni == Usuario.usuarioActual.dni)
                {
                    hallado = true;
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
                    break;
                }
            }

            if (!hallado)
            {
                txtResultadoConsulta.Text = "No se encontró ningún expediente suyo con el código '" + criterio + "'.";
            }
        }

        // Define las columnas y anchos del ListView de expedientes:
        private void ConfigurarColumnasExpedientes()
        {
            lvExpedientes.Columns.Clear();
            lvExpedientes.Columns.Add("Código", 95);
            lvExpedientes.Columns.Add("DNI", 95);
            lvExpedientes.Columns.Add("Trabajador / Titular", 210);
            lvExpedientes.Columns.Add("Trámite Solicitado", 280);
            lvExpedientes.Columns.Add("Fecha Cita", 185);
            lvExpedientes.Columns.Add("Estado", 120);
        }

        // Carga los criterios de ordenamiento en el ComboBox:
        private void CargarComboOrdenar()
        {
            cmbOrdenar.Items.Clear();
            cmbOrdenar.Items.Add("Código (Ascendente)");
            cmbOrdenar.Items.Add("Trámite (A - Z)");
            cmbOrdenar.Items.Add("Estado");
            cmbOrdenar.SelectedIndex = 0;
        }

        // Filtra y muestra en la tabla únicamente los expedientes del trabajador logueado:
        private void MostrarExpedientesTrabajador(List<Expediente> origen)
        {
            lvExpedientes.Items.Clear();
            int contador = 0;

            foreach (Expediente exp in origen)
            {
                if (exp.dni == Usuario.usuarioActual.dni)
                {
                    contador++;
                    ListViewItem item = new ListViewItem(exp.codigo);
                    item.SubItems.Add(exp.dni);
                    item.SubItems.Add(exp.titular);
                    item.SubItems.Add(exp.asunto);
                    item.SubItems.Add(exp.fechaCita);
                    item.SubItems.Add(exp.estado);
                    lvExpedientes.Items.Add(item);
                }
            }

            lblCantidadExpedientes.Text = contador + " expediente(s) en total";
        }

        // Ordena los expedientes usando el algoritmo Burbuja (Bubble Sort) sobre una copia de la lista:
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            List<Expediente> copia = new List<Expediente>(Expediente.listaExpedientes);

            for (int i = 0; i < copia.Count - 1; i++)
            {
                for (int j = 0; j < copia.Count - i - 1; j++)
                {
                    bool intercambiar = false;

                    if (cmbOrdenar.SelectedIndex == 0 && string.Compare(copia[j].codigo, copia[j + 1].codigo) > 0)
                        intercambiar = true;
                    else if (cmbOrdenar.SelectedIndex == 1 && string.Compare(copia[j].asunto, copia[j + 1].asunto) > 0)
                        intercambiar = true;
                    else if (cmbOrdenar.SelectedIndex == 2 && string.Compare(copia[j].estado, copia[j + 1].estado) > 0)
                        intercambiar = true;

                    if (intercambiar)
                    {
                        Expediente aux = copia[j];
                        copia[j] = copia[j + 1];
                        copia[j + 1] = aux;
                    }
                }
            }

            MostrarExpedientesTrabajador(copia);
        }

        // Cierra la sesión actual y regresa a la pantalla de inicio de sesión (Form1):
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            cerrarSesion = true;
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    }
}