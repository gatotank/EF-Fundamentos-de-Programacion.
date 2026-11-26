using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        // Bandera que distingue entre cerrar sesión y cerrar toda la aplicación:
        bool cerrarSesion = false;

        // Constructor del panel administrativo:
        public Form5()
        {
            InitializeComponent();
        }

        // Si el administrador cierra la ventana con la X roja sin cerrar sesión, finaliza todo el programa:
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!cerrarSesion)
            {
                Application.Exit();
            }
        }

        // Inicializa las columnas, pestañas, atajos de teclado y datos al cargar el panel de administrador:
        private void Form5_Load(object sender, EventArgs e)
        {
            this.Text = "Mesa de Partes - Panel de Administrador";
            this.AcceptButton = btnEliminarTrabajador;

            // Asigna la tecla Enter al botón principal de cada pestaña administrativa:
            tabControlAdmin.SelectedIndexChanged += (s, ev) =>
            {
                if (tabControlAdmin.SelectedIndex == 0) this.AcceptButton = btnEliminarTrabajador;
                else if (tabControlAdmin.SelectedIndex == 1) this.AcceptButton = btnBuscarDniAdmin;
                else if (tabControlAdmin.SelectedIndex == 2) this.AcceptButton = btnAprobar;
            };

            // Muestra los datos de identificación del administrador activo:
            lblBienvenida.Text = "Bienvenido, Administrador";
            lblDatosUsuario.Text = "Código: " + Usuario.usuarioActual.codigo + "  |  DNI: " + Usuario.usuarioActual.dni + "  |  ROL: ADMINISTRADOR";

            // Configura las columnas de la tabla de trabajadores registrados:
            lvAdminTrabajadores.Columns.Clear();
            lvAdminTrabajadores.Columns.Add("Código", 85);
            lvAdminTrabajadores.Columns.Add("Nombre Completo", 260);
            lvAdminTrabajadores.Columns.Add("DNI", 105);
            lvAdminTrabajadores.Columns.Add("Correo Electrónico", 260);
            lvAdminTrabajadores.Columns.Add("Celular / Teléfono", 145);
            lvAdminTrabajadores.Columns.Add("Total Expedientes", 140);

            CargarTrabajadores();

            // Configura las columnas de la tabla global de solicitudes:
            lvSolicitudesAdmin.Columns.Clear();
            lvSolicitudesAdmin.Columns.Add("Código", 85);
            lvSolicitudesAdmin.Columns.Add("DNI", 95);
            lvSolicitudesAdmin.Columns.Add("Trabajador / Titular", 210);
            lvSolicitudesAdmin.Columns.Add("Trámite Solicitado", 320);
            lvSolicitudesAdmin.Columns.Add("Fecha Cita", 190);
            lvSolicitudesAdmin.Columns.Add("Estado", 120);

            // Carga los criterios de ordenamiento para el administrador:
            cmbOrdenarAdmin.Items.Clear();
            cmbOrdenarAdmin.Items.Add("Código (Ascendente)");
            cmbOrdenarAdmin.Items.Add("Trámite (A - Z)");
            cmbOrdenarAdmin.Items.Add("Estado");
            cmbOrdenarAdmin.SelectedIndex = 0;

            CargarSolicitudes(Expediente.listaExpedientes);
        }

        // Lista todos los trabajadores no administradores y calcula cuántos expedientes tiene cada uno:
        private void CargarTrabajadores()
        {
            lvAdminTrabajadores.Items.Clear();

            foreach (Usuario u in Usuario.listaUsuarios)
            {
                if (!u.esAdmin)
                {
                    int totalExp = 0;
                    foreach (Expediente exp in Expediente.listaExpedientes)
                    {
                        if (exp.dni == u.dni) totalExp++;
                    }

                    ListViewItem item = new ListViewItem(u.codigo);
                    item.SubItems.Add(u.nombres);
                    item.SubItems.Add(u.dni);
                    item.SubItems.Add(u.correo);
                    item.SubItems.Add(u.celular);
                    item.SubItems.Add(totalExp.ToString());
                    lvAdminTrabajadores.Items.Add(item);
                }
            }
        }

        // Elimina la cuenta del trabajador seleccionado (protegiendo la cuenta del administrador):
        private void btnEliminarTrabajador_Click(object sender, EventArgs e)
        {
            if (lvAdminTrabajadores.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un trabajador de la tabla para eliminarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dniSel = lvAdminTrabajadores.SelectedItems[0].SubItems[2].Text;
            string nombreSel = lvAdminTrabajadores.SelectedItems[0].SubItems[1].Text;

            if (dniSel == Usuario.usuarioActual.dni)
            {
                MessageBox.Show("No puede eliminar su propia cuenta de Administrador.", "Operación denegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult r = MessageBox.Show("¿Eliminar permanentemente al trabajador " + nombreSel + " (DNI: " + dniSel + ")?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                for (int i = 0; i < Usuario.listaUsuarios.Count; i++)
                {
                    if (Usuario.listaUsuarios[i].dni == dniSel)
                    {
                        Usuario.listaUsuarios.RemoveAt(i);
                        break;
                    }
                }

                Usuario.GuardarUsuarios();
                CargarTrabajadores();
                MessageBox.Show("Trabajador eliminado correctamente.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Permite ingresar únicamente dígitos numéricos en el buscador por DNI:
        private void txtBuscarDniAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Filtra y muestra todos los expedientes registrados por un número de DNI de 8 dígitos:
        private void btnBuscarDniAdmin_Click(object sender, EventArgs e)
        {
            string dni = txtBuscarDniAdmin.Text.Trim();

            if (dni.Length != 8)
            {
                MessageBox.Show("Ingrese un DNI válido de 8 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string texto = "EXPEDIENTES DEL TRABAJADOR CON DNI: " + dni + Environment.NewLine;
            texto += "======================================================================" + Environment.NewLine + Environment.NewLine;

            int count = 0;
            foreach (Expediente exp in Expediente.listaExpedientes)
            {
                if (exp.dni == dni)
                {
                    count++;
                    texto += "Código Expediente : " + exp.codigo + Environment.NewLine;
                    texto += "Trabajador        : " + exp.titular + Environment.NewLine;
                    texto += "Trámite           : " + exp.asunto + Environment.NewLine;
                    texto += "Cita Programada   : " + exp.fechaCita + Environment.NewLine;
                    texto += "Fecha Registro    : " + exp.fechaRegistro + Environment.NewLine;
                    texto += "Estado            : " + exp.estado + Environment.NewLine;
                    texto += "----------------------------------------------------------------------" + Environment.NewLine;
                }
            }

            txtResultadoDniAdmin.Text = count == 0
                ? "No se encontraron expedientes registrados para el DNI " + dni + "."
                : texto + Environment.NewLine + "Total de expedientes encontrados: " + count;
        }

        // Llena la tabla de gestión de solicitudes con los expedientes recibidos:
        private void CargarSolicitudes(List<Expediente> lista)
        {
            lvSolicitudesAdmin.Items.Clear();

            foreach (Expediente exp in lista)
            {
                ListViewItem item = new ListViewItem(exp.codigo);
                item.SubItems.Add(exp.dni);
                item.SubItems.Add(exp.titular);
                item.SubItems.Add(exp.asunto);
                item.SubItems.Add(exp.fechaCita);
                item.SubItems.Add(exp.estado);
                lvSolicitudesAdmin.Items.Add(item);
            }

            lblTotalSolicitudes.Text = lista.Count + " solicitud(es) total(es)";
        }

        // Cambia el estado del expediente seleccionado y actualiza el archivo binario expedientes.dat:
        private void CambiarEstado(string nuevoEstado)
        {
            if (lvSolicitudesAdmin.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione una solicitud de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigoExp = lvSolicitudesAdmin.SelectedItems[0].Text;

            for (int i = 0; i < Expediente.listaExpedientes.Count; i++)
            {
                if (Expediente.listaExpedientes[i].codigo == codigoExp)
                {
                    // Se copia a una variable temporal para modificar el campo del struct:
                    Expediente temp = Expediente.listaExpedientes[i];
                    temp.estado = nuevoEstado;
                    Expediente.listaExpedientes[i] = temp;
                    break;
                }
            }

            Expediente.GuardarExpedientes();
            CargarSolicitudes(Expediente.listaExpedientes);
            MessageBox.Show("Expediente " + codigoExp + " actualizado a: " + nuevoEstado, "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Botones de acción rápida que delegan el cambio de estado al método CambiarEstado:
        private void btnAprobar_Click(object sender, EventArgs e) { CambiarEstado("APROBADO"); }
        private void btnPosponer_Click(object sender, EventArgs e) { CambiarEstado("POSPUESTO"); }
        private void btnDenegar_Click(object sender, EventArgs e) { CambiarEstado("DENEGADO"); }

        // Ordena todas las solicitudes mediante el algoritmo Burbuja (Bubble Sort):
        private void btnOrdenarAdmin_Click(object sender, EventArgs e)
        {
            List<Expediente> copia = new List<Expediente>(Expediente.listaExpedientes);

            for (int i = 0; i < copia.Count - 1; i++)
            {
                for (int j = 0; j < copia.Count - i - 1; j++)
                {
                    bool swap = false;

                    if (cmbOrdenarAdmin.SelectedIndex == 0 && string.Compare(copia[j].codigo, copia[j + 1].codigo) > 0) swap = true;
                    else if (cmbOrdenarAdmin.SelectedIndex == 1 && string.Compare(copia[j].asunto, copia[j + 1].asunto) > 0) swap = true;
                    else if (cmbOrdenarAdmin.SelectedIndex == 2 && string.Compare(copia[j].estado, copia[j + 1].estado) > 0) swap = true;

                    if (swap)
                    {
                        Expediente aux = copia[j];
                        copia[j] = copia[j + 1];
                        copia[j + 1] = aux;
                    }
                }
            }

            CargarSolicitudes(copia);
        }

        // Cierra la sesión del administrador y vuelve a mostrar el inicio de sesión (Form1):
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            cerrarSesion = true;
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    }
}