using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!cerrarSesion)
            {
                Application.Exit();
            }
        }

        bool cerrarSesion = false;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (Usuario.usuarioActual != null)
            {
                lblBienvenida.Text = "Bienvenido(a), " + Usuario.usuarioActual.nombres;
                lblDatosUsuario.Text = "Código de usuario: " + Usuario.usuarioActual.codigo + "  |  DNI: " + Usuario.usuarioActual.dni;
            }

            CargarOpcionesTramites();
            ConfigurarCalendarioYHoras();
            ConfigurarTablaExpedientes();

            cmbOrdenar.Items.Clear();
            cmbOrdenar.Items.Add("Código");
            cmbOrdenar.Items.Add("Asunto (A-Z)");
            cmbOrdenar.Items.Add("Cita programada");
            cmbOrdenar.Items.Add("Estado");
            cmbOrdenar.SelectedIndex = 0;

            MostrarMisExpedientes("Código");
        }

        private void CargarOpcionesTramites()
        {
            cmbTramites.Items.Clear();

            cmbTramites.Items.Add("Identificación y DNI - Renovación por caducidad del DNIe");
            cmbTramites.Items.Add("Identificación y DNI - Duplicado de DNI electrónico (DNIe)");
            cmbTramites.Items.Add("Identificación y DNI - Duplicado de DNI azul a electrónico");
            cmbTramites.Items.Add("Identificación y DNI - Actualización de domicilio y estado civil");
            cmbTramites.Items.Add("Identificación y DNI - Actualización de PIN del DNIe");
            cmbTramites.Items.Add("Identificación y DNI - Consulta del estado de trámite");

            cmbTramites.Items.Add("Registros Civiles - Copias certificadas de actas o partidas");
            cmbTramites.Items.Add("Registros Civiles - Validación de copias certificadas");
            cmbTramites.Items.Add("Registros Civiles - Certificado de Inscripción (C4)");

            cmbTramites.Items.Add("Mesa de Partes Virtual - Rectificación administrativa de actas");
            cmbTramites.Items.Add("Mesa de Partes Virtual - Inscripción de nacimientos");
            cmbTramites.Items.Add("Mesa de Partes Virtual - Devolución de pago de tasas");
            cmbTramites.Items.Add("Mesa de Partes Virtual - Certificación de nombres iguales");
            cmbTramites.Items.Add("Mesa de Partes Virtual - Habilitación de DNI e información registral");

            cmbTramites.Items.Add("Otros (Especificar trámite)");

            cmbTramites.SelectedIndex = 0;
        }

        private void ConfigurarCalendarioYHoras()
        {
            DateTime manana = DateTime.Today.AddDays(1);
            calCita.MinDate = manana;
            calCita.SetDate(manana);

            cmbHoraCita.Items.Clear();
            cmbHoraCita.Items.Add("09:00 AM");
            cmbHoraCita.Items.Add("10:00 AM");
            cmbHoraCita.Items.Add("11:00 AM");
            cmbHoraCita.Items.Add("12:00 PM");
            cmbHoraCita.Items.Add("03:00 PM");
            cmbHoraCita.Items.Add("04:00 PM");
            cmbHoraCita.SelectedIndex = 0;

            ActualizarResumenCita();
        }

        private void ActualizarResumenCita()
        {
            if (cmbHoraCita.SelectedItem != null)
            {
                string fechaTexto = calCita.SelectionStart.ToString("dd/MM/yyyy");
                string horaTexto = cmbHoraCita.SelectedItem.ToString();
                lblCitaSeleccionada.Text = "Cita elegida: " + fechaTexto + " a las " + horaTexto;
            }
        }

        private void ConfigurarTablaExpedientes()
        {
            lvExpedientes.Columns.Clear();
            lvExpedientes.Columns.Add("Código", 120);
            lvExpedientes.Columns.Add("Asunto", 310);
            lvExpedientes.Columns.Add("Cita programada", 165);
            lvExpedientes.Columns.Add("Fecha registro", 135);
            lvExpedientes.Columns.Add("Estado", 95);
        }

        private void cmbTramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbTramites.SelectedIndex;

            if (indice == 14)
            {
                lblDetalleTramite.Text = "Escriba en el cuadro inferior el trámite específico que desea solicitar.";
                lblOtroTramite.Visible = true;
                txtOtroTramite.Visible = true;
                txtOtroTramite.Focus();
                return;
            }

            lblOtroTramite.Visible = false;
            txtOtroTramite.Visible = false;
            txtOtroTramite.Text = "";

            string[] descripciones = new string[]
            {
                "Para mayores de edad con DNI vencido o dentro de los 60 días previos a su vencimiento (requiere validar identidad y foto en la app DNI BioFacial).",
                "Solicitud en caso de pérdida o robo, manteniendo exactamente los mismos datos y fotografía de tu último documento.",
                "Permite migrar de tu documento convencional al DNIe conservando tus datos actuales.",
                "Modificación de dirección o cambio de estado civil (de soltero a casado, si el matrimonio está registrado en Reniec).",
                "Cambio o restablecimiento de la clave de seguridad de tu documento electrónico.",
                "Seguimiento en tiempo real del avance de tu DNI usando el número de documento o de solicitud en el Servicio en Línea.",
                "Descarga de copias digitales (nacimiento, matrimonio o defunción) incorporadas en la base de datos del Reniec.",
                "Verificación en línea para comprobar la autenticidad de un acta emitida digitalmente.",
                "Emisión del documento digital que acredita los datos registrados en el archivo único de identificación.",
                "Corrección de errores materiales en actas de nacimiento, matrimonio o defunción.",
                "Registro virtual bajo los supuestos habilitados por la entidad.",
                "Solicitud de reembolso por pagos realizados que no llegaron a utilizarse.",
                "Constancia de homonimia o validación de identidad.",
                "Solicitudes administrativas sobre el estado de registro ciudadano."
            };

            if (indice >= 0 && indice < descripciones.Length)
            {
                lblDetalleTramite.Text = descripciones[indice];
            }
        }

        private void calCita_DateChanged(object sender, DateRangeEventArgs e)
        {
            ActualizarResumenCita();
        }

        private void cmbHoraCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarResumenCita();
        }

        private void btnRegistrarTramite_Click(object sender, EventArgs e)
        {
            string asuntoFinal = cmbTramites.SelectedItem.ToString();

            if (cmbTramites.SelectedIndex == 14)
            {
                if (txtOtroTramite.Text.Trim() == "")
                {
                    MessageBox.Show("Por favor, escriba el trámite específico que desea realizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOtroTramite.Focus();
                    return;
                }
                asuntoFinal = "Otros - " + txtOtroTramite.Text.Trim().Replace("|", "-");
            }

            if (calCita.SelectionStart.Date <= DateTime.Today)
            {
                MessageBox.Show("No puede agendar una cita para el mismo día. Seleccione a partir de mañana.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numeroCorrelativo = Expediente.listaExpedientes.Count + 1;
            string codigoGenerado = "EXP-" + DateTime.Now.Year + "-" + numeroCorrelativo.ToString("D4");
            string citaProgramada = calCita.SelectionStart.ToString("dd/MM/yyyy") + " - " + cmbHoraCita.SelectedItem.ToString();
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            Expediente nuevoExp = new Expediente();
            nuevoExp.codigo = codigoGenerado;
            nuevoExp.codigoUsuario = Usuario.usuarioActual.codigo;
            nuevoExp.dni = Usuario.usuarioActual.dni;
            nuevoExp.titular = Usuario.usuarioActual.nombres;
            nuevoExp.asunto = asuntoFinal;
            nuevoExp.fechaCita = citaProgramada;
            nuevoExp.fechaRegistro = fechaActual;
            nuevoExp.estado = "RECIBIDO";

            Expediente.listaExpedientes.Add(nuevoExp);
            Expediente.GuardarExpedientes();

            string mensajeConfirmacion = "Su cita para el trámite ya está lista y registrada." + Environment.NewLine + Environment.NewLine +
                                         "Código de expediente : " + codigoGenerado + Environment.NewLine +
                                         "Titular              : " + nuevoExp.titular + Environment.NewLine +
                                         "DNI                  : " + nuevoExp.dni + Environment.NewLine +
                                         "Trámite              : " + nuevoExp.asunto + Environment.NewLine +
                                         "Cita agendada        : " + nuevoExp.fechaCita + Environment.NewLine +
                                         "Estado               : RECIBIDO";

            MessageBox.Show(mensajeConfirmacion, "Cita agendada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtOtroTramite.Text = "";
            MostrarMisExpedientes(cmbOrdenar.SelectedItem.ToString());
            tabControl1.SelectedIndex = 2;
        }

        private void MostrarMisExpedientes(string criterioOrden)
        {
            List<Expediente> misTramites = new List<Expediente>();

            foreach (Expediente exp in Expediente.listaExpedientes)
            {
                if (Usuario.usuarioActual != null && exp.dni == Usuario.usuarioActual.dni)
                {
                    misTramites.Add(exp);
                }
            }

            int i = 0;
            while (i < misTramites.Count - 1)
            {
                int j = i + 1;
                while (j < misTramites.Count)
                {
                    bool intercambiar = false;

                    if (criterioOrden == "Asunto (A-Z)")
                    {
                        if (string.Compare(misTramites[i].asunto, misTramites[j].asunto, StringComparison.OrdinalIgnoreCase) > 0)
                        {
                            intercambiar = true;
                        }
                    }
                    else if (criterioOrden == "Cita programada")
                    {
                        if (string.Compare(misTramites[i].fechaCita, misTramites[j].fechaCita, StringComparison.OrdinalIgnoreCase) > 0)
                        {
                            intercambiar = true;
                        }
                    }
                    else if (criterioOrden == "Estado")
                    {
                        if (string.Compare(misTramites[i].estado, misTramites[j].estado, StringComparison.OrdinalIgnoreCase) > 0)
                        {
                            intercambiar = true;
                        }
                    }
                    else
                    {
                        if (string.Compare(misTramites[i].codigo, misTramites[j].codigo, StringComparison.OrdinalIgnoreCase) > 0)
                        {
                            intercambiar = true;
                        }
                    }

                    if (intercambiar)
                    {
                        Expediente temporal = misTramites[i];
                        misTramites[i] = misTramites[j];
                        misTramites[j] = temporal;
                    }

                    j++;
                }
                i++;
            }

            lvExpedientes.Items.Clear();

            foreach (Expediente exp in misTramites)
            {
                ListViewItem fila = new ListViewItem(exp.codigo);
                fila.SubItems.Add(exp.asunto);
                fila.SubItems.Add(exp.fechaCita);
                fila.SubItems.Add(exp.fechaRegistro);
                fila.SubItems.Add(exp.estado);

                lvExpedientes.Items.Add(fila);
            }

            lblCantidadExpedientes.Text = misTramites.Count + " expediente(s)";
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (cmbOrdenar.SelectedItem != null)
            {
                MostrarMisExpedientes(cmbOrdenar.SelectedItem.ToString());
            }
        }

        private void txtConsultaDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnConsultarDni_Click(object sender, EventArgs e)
        {
            if (txtConsultaDni.Text.Length != 8)
            {
                MessageBox.Show("Ingrese un DNI válido de 8 dígitos para consultar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConsultaDni.Focus();
                return;
            }

            List<Expediente> encontrados = new List<Expediente>();

            foreach (Expediente exp in Expediente.listaExpedientes)
            {
                if (exp.dni == txtConsultaDni.Text)
                {
                    encontrados.Add(exp);
                }
            }

            if (encontrados.Count == 0)
            {
                txtResultadoConsulta.Text = "No se encontraron trámites registrados para el DNI " + txtConsultaDni.Text + ".";
                return;
            }

            string resultado = "SE ENCONTRARON " + encontrados.Count + " TRÁMITE(S) PARA EL DNI: " + txtConsultaDni.Text + Environment.NewLine;
            resultado = resultado + "======================================================================" + Environment.NewLine;

            foreach (Expediente exp in encontrados)
            {
                resultado = resultado + "EXPEDIENTE      : " + exp.codigo + Environment.NewLine;
                resultado = resultado + "TITULAR         : " + exp.titular + Environment.NewLine;
                resultado = resultado + "DNI             : " + exp.dni + Environment.NewLine;
                resultado = resultado + "TRÁMITE         : " + exp.asunto + Environment.NewLine;
                resultado = resultado + "CITA AGENDADA   : " + exp.fechaCita + Environment.NewLine;
                resultado = resultado + "FECHA REGISTRO  : " + exp.fechaRegistro + Environment.NewLine;
                resultado = resultado + "ESTADO          : " + exp.estado + Environment.NewLine;
                resultado = resultado + "----------------------------------------------------------------------" + Environment.NewLine;
            }

            txtResultadoConsulta.Text = resultado;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            cerrarSesion = true;
            Usuario.usuarioActual = null;
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!cerrarSesion)
            {
                Application.Exit();
            }
        }
    }
}