using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        bool cerrarSesion = false;

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

        public Form3()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!cerrarSesion)
            {
                Application.Exit();
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!cerrarSesion)
            {
                Application.Exit();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnRegistrarTramite;

            tabControl1.SelectedIndexChanged += (s, ev) =>
            {
                if (tabControl1.SelectedIndex == 0) this.AcceptButton = btnRegistrarTramite;
                else if (tabControl1.SelectedIndex == 1) this.AcceptButton = btnConsultarDni;
                else if (tabControl1.SelectedIndex == 2) this.AcceptButton = btnOrdenar;
            };

            this.Text = "Mesa de Partes Digital - Trabajador";
            lblBienvenida.Text = "Bienvenido, " + Usuario.usuarioActual.nombres;
            lblDatosUsuario.Text = "Código: " + Usuario.usuarioActual.codigo + "  |  DNI: " + Usuario.usuarioActual.dni;

            tabPage1.Text = "1. Registrar trámite";
            tabPage2.Text = "2. Consultar por código";
            tabPage3.Text = "3. Mis expedientes";

            CargarOpcionesTramites();
            ConfigurarCalendarioYHoras();

            label5.Text = "Ingrese el código del expediente (ej. 00001) para ver su detalle:";
            txtConsultaDni.MaxLength = 10;
            txtConsultaDni.Text = "";
            txtResultadoConsulta.Text = "";

            ConfigurarColumnasExpedientes();
            CargarComboOrdenar();
            MostrarExpedientesTrabajador(Expediente.listaExpedientes);
        }

        private void CargarOpcionesTramites()
        {
            cmbTramites.Items.Clear();
            foreach (string t in listaTramites) cmbTramites.Items.Add(t);
            cmbTramites.SelectedIndex = 0;
        }

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

        private void ActualizarTextoCita()
        {
            if (cmbHoraCita.SelectedItem != null)
            {
                lblCitaSeleccionada.Text = "Cita: " + calCita.SelectionStart.ToString("dd/MM/yyyy") + " | " + cmbHoraCita.SelectedItem.ToString();
            }
        }

        private void cmbTramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cmbTramites.SelectedIndex;
            if (idx >= 0 && idx < descripcionesTramites.Length) lblDetalleTramite.Text = descripcionesTramites[idx];

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

        private void calCita_DateChanged(object sender, DateRangeEventArgs e) { ActualizarTextoCita(); }
        private void cmbHoraCita_SelectedIndexChanged(object sender, EventArgs e) { ActualizarTextoCita(); }

        private void btnRegistrarTramite_Click(object sender, EventArgs e)
        {
            if (cmbTramites.SelectedItem == null || cmbHoraCita.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un trámite y un horario de atención.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string asuntoFinal = cmbTramites.SelectedItem.ToString();
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

            Expediente nuevo = new Expediente();
            nuevo.codigo = Expediente.GenerarNuevoCodigo();
            nuevo.dni = Usuario.usuarioActual.dni;
            nuevo.titular = Usuario.usuarioActual.nombres;
            nuevo.asunto = asuntoFinal;
            nuevo.fechaCita = calCita.SelectionStart.ToString("dd/MM/yyyy") + " (" + cmbHoraCita.SelectedItem.ToString() + ")";
            nuevo.fechaRegistro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            nuevo.estado = "PENDIENTE";

            Expediente.listaExpedientes.Add(nuevo);
            Expediente.GuardarExpedientes();

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

        private void txtConsultaDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnConsultarDni_Click(object sender, EventArgs e)
        {
            string criterio = txtConsultaDni.Text.Trim();
            if (string.IsNullOrWhiteSpace(criterio))
            {
                MessageBox.Show("Ingrese el código de expediente (ejemplo: 00001).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConsultaDni.Focus();
                return;
            }

            int numCodigo;
            if (int.TryParse(criterio, out numCodigo))
            {
                criterio = numCodigo.ToString("D5");
                txtConsultaDni.Text = criterio;
            }

            bool hallado = false;
            foreach (Expediente exp in Expediente.listaExpedientes)
            {
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

        private void CargarComboOrdenar()
        {
            cmbOrdenar.Items.Clear();
            cmbOrdenar.Items.Add("Código (Ascendente)");
            cmbOrdenar.Items.Add("Trámite (A - Z)");
            cmbOrdenar.Items.Add("Estado");
            cmbOrdenar.SelectedIndex = 0;
        }

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

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            List<Expediente> copia = new List<Expediente>(Expediente.listaExpedientes);
            for (int i = 0; i < copia.Count - 1; i++)
            {
                for (int j = 0; j < copia.Count - i - 1; j++)
                {
                    bool intercambiar = false;
                    if (cmbOrdenar.SelectedIndex == 0 && string.Compare(copia[j].codigo, copia[j + 1].codigo) > 0) intercambiar = true;
                    else if (cmbOrdenar.SelectedIndex == 1 && string.Compare(copia[j].asunto, copia[j + 1].asunto) > 0) intercambiar = true;
                    else if (cmbOrdenar.SelectedIndex == 2 && string.Compare(copia[j].estado, copia[j + 1].estado) > 0) intercambiar = true;

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

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            cerrarSesion = true;
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    }
}