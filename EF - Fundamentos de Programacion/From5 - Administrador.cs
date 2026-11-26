
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        // Variable que indica si el administrador está cerrando sesión.
        // Su valor inicial es false.
        bool cerrarSesion = false;

        // Constructor del formulario administrativo.
        public Form5()
        {
            InitializeComponent(); // Inicializa los controles y componentes del formulario.
        }

        // Método que se ejecuta cuando el formulario está a punto de cerrarse.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e); // Ejecuta el comportamiento original de cierre del formulario.

            // Comprueba si el formulario se está cerrando sin realizar un cierre de sesión.
            if (!cerrarSesion)
            {
                Application.Exit(); // Cierra toda la aplicación.
            }
        }

        // Evento que se ejecuta cuando se carga el formulario administrativo.
        // Configura la interfaz, muestra los datos del administrador y carga las tablas.
        private void Form5_Load(object sender, EventArgs e)
        {
            // Detecta cuando el administrador cambia de pestaña.
            tabControlAdmin.SelectedIndexChanged += (s, ev) =>
            {
                // Si está en la primera pestaña, Enter ejecuta el botón Eliminar trabajador.
                if (tabControlAdmin.SelectedIndex == 0) this.AcceptButton = btnEliminarTrabajador;

                // Si está en la segunda pestaña, Enter ejecuta el botón Buscar por DNI.
                else if (tabControlAdmin.SelectedIndex == 1) this.AcceptButton = btnBuscarDniAdmin;

                // Si está en la tercera pestaña, Enter ejecuta el botón Aprobar.
                else if (tabControlAdmin.SelectedIndex == 2) this.AcceptButton = btnAprobar;
            };

            // Muestra el mensaje de bienvenida al administrador.
            lblBienvenida.Text = "Bienvenido, Administrador";

            // Muestra el código, DNI y rol del usuario que inició sesión.
            lblDatosUsuario.Text = "Código: " + Usuario.usuarioActual.codigo + "  |  DNI: " + Usuario.usuarioActual.dni + "  |  ROL: ADMINISTRADOR";

            // Limpia las columnas anteriores de la tabla de trabajadores.
            lvAdminTrabajadores.Columns.Clear();

            // Agrega las columnas que mostrarán la información de los trabajadores.
            lvAdminTrabajadores.Columns.Add("Código", 85);
            lvAdminTrabajadores.Columns.Add("Nombre Completo", 260);
            lvAdminTrabajadores.Columns.Add("DNI", 105);
            lvAdminTrabajadores.Columns.Add("Correo Electrónico", 260);
            lvAdminTrabajadores.Columns.Add("Celular / Teléfono", 145);
            lvAdminTrabajadores.Columns.Add("Total Expedientes", 140);

            // Llama al método que carga los trabajadores registrados en la tabla.
            CargarTrabajadores();

            // Limpia las columnas anteriores de la tabla de solicitudes.
            lvSolicitudesAdmin.Columns.Clear();

            // Agrega las columnas que mostrarán la información de los expedientes.
            lvSolicitudesAdmin.Columns.Add("Código", 85);
            lvSolicitudesAdmin.Columns.Add("DNI", 95);
            lvSolicitudesAdmin.Columns.Add("Trabajador / Titular", 210);
            lvSolicitudesAdmin.Columns.Add("Trámite Solicitado", 320);
            lvSolicitudesAdmin.Columns.Add("Fecha Cita", 190);
            lvSolicitudesAdmin.Columns.Add("Estado", 120);

            // Limpia las opciones anteriores del ComboBox de ordenamiento.
            cmbOrdenarAdmin.Items.Clear();

            // Agrega los criterios disponibles para ordenar las solicitudes.
            cmbOrdenarAdmin.Items.Add("Código (Ascendente)");
            cmbOrdenarAdmin.Items.Add("Trámite (A - Z)");
            cmbOrdenarAdmin.Items.Add("Estado");

            // Selecciona inicialmente el primer criterio de ordenamiento.
            cmbOrdenarAdmin.SelectedIndex = 0;

            // Carga todos los expedientes registrados en la tabla administrativa.
            CargarSolicitudes(Expediente.listaExpedientes);
        }

        // Método auxiliar que carga los trabajadores registrados en el sistema.
        // También calcula cuántos expedientes tiene cada trabajador.
        private void CargarTrabajadores()
        {
            // Limpia los registros anteriores de la tabla de trabajadores.
            lvAdminTrabajadores.Items.Clear();

            // Recorre todos los usuarios registrados en la lista.
            foreach (Usuario u in Usuario.listaUsuarios)
            {
                // Comprueba que el usuario no sea administrador.
                // Solo se mostrarán los trabajadores.
                if (!u.esAdmin)
                {
                    // Inicializa el contador de expedientes del trabajador.
                    int totalExp = 0;

                    // Recorre todos los expedientes registrados.
                    foreach (Expediente exp in Expediente.listaExpedientes)
                    {
                        // Compara el DNI del expediente con el DNI del trabajador.
                        // Si coinciden, aumenta el contador en uno.
                        if (exp.dni == u.dni) totalExp++;
                    }

                    // Crea una nueva fila utilizando el código del trabajador.
                    ListViewItem item = new ListViewItem(u.codigo);

                    // Agrega los datos restantes del trabajador a la fila.
                    item.SubItems.Add(u.nombres);
                    item.SubItems.Add(u.dni);
                    item.SubItems.Add(u.correo);
                    item.SubItems.Add(u.celular);

                    // Convierte el total de expedientes a texto y lo agrega a la fila.
                    item.SubItems.Add(totalExp.ToString());

                    // Agrega la fila completa a la tabla de trabajadores.
                    lvAdminTrabajadores.Items.Add(item);
                }
            }
        }

        // Evento que se ejecuta cuando el administrador presiona el botón Eliminar trabajador.
        private void btnEliminarTrabajador_Click(object sender, EventArgs e)
        {
            // Comprueba si no se ha seleccionado ningún trabajador de la tabla.
            if (lvAdminTrabajadores.SelectedItems.Count == 0)
            {
                // Muestra una advertencia solicitando seleccionar un trabajador.
                MessageBox.Show("Seleccione un trabajador de la tabla para eliminarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return; // Detiene el método si no hay una selección.
            }

            // Obtiene el DNI del trabajador seleccionado.
            // SubItems[2] corresponde a la tercera columna de la tabla.
            string dniSel = lvAdminTrabajadores.SelectedItems[0].SubItems[2].Text;

            // Obtiene el nombre del trabajador seleccionado.
            // SubItems[1] corresponde a la segunda columna.
            string nombreSel = lvAdminTrabajadores.SelectedItems[0].SubItems[1].Text;

            // Comprueba si el trabajador seleccionado es el administrador actual.
            if (dniSel == Usuario.usuarioActual.dni)
            {
                // Impide que el administrador elimine su propia cuenta.
                MessageBox.Show("No puede eliminar su propia cuenta de Administrador.", "Operación denegada", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return; // Detiene el proceso.
            }

            // Solicita confirmación antes de eliminar permanentemente al trabajador.
            // La respuesta se almacena en la variable r.
            DialogResult r = MessageBox.Show("¿Eliminar permanentemente al trabajador " + nombreSel + " (DNI: " + dniSel + ")?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Comprueba si el administrador seleccionó la opción Sí.
            if (r == DialogResult.Yes)
            {
                // Recorre la lista de usuarios para encontrar al trabajador seleccionado.
                for (int i = 0; i < Usuario.listaUsuarios.Count; i++)
                {
                    // Compara el DNI de cada usuario con el DNI seleccionado.
                    if (Usuario.listaUsuarios[i].dni == dniSel)
                    {
                        // Elimina al trabajador de la lista utilizando su posición.
                        Usuario.listaUsuarios.RemoveAt(i);

                        break; // Detiene el recorrido porque el trabajador ya fue eliminado.
                    }
                }

                // Guarda los cambios realizados en la lista de usuarios.
                Usuario.GuardarUsuarios();

                // Actualiza la tabla para que el trabajador eliminado ya no aparezca.
                CargarTrabajadores();

                // Muestra un mensaje confirmando que la eliminación fue realizada.
                MessageBox.Show("Trabajador eliminado correctamente.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento que controla los caracteres que se pueden ingresar en el campo DNI.
        private void txtBuscarDniAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite únicamente números y teclas de control, como Retroceso.
            // Si el carácter no cumple ninguna de estas condiciones, se bloquea.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Evento que se ejecuta cuando el administrador presiona el botón Buscar por DNI.
        // Permite consultar todos los expedientes asociados a un trabajador.
        private void btnBuscarDniAdmin_Click(object sender, EventArgs e)
        {
            // Obtiene el DNI ingresado y elimina los espacios al inicio y al final.
            string dni = txtBuscarDniAdmin.Text.Trim();

            // Comprueba que el DNI tenga exactamente 8 caracteres.
            if (dni.Length != 8)
            {
                // Muestra una advertencia si el DNI no tiene la longitud correcta.
                MessageBox.Show("Ingrese un DNI válido de 8 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return; // Detiene la búsqueda si el DNI no es válido.
            }

            // Crea el texto inicial que aparecerá en los resultados de la búsqueda.
            string texto = "EXPEDIENTES DEL TRABAJADOR CON DNI: " + dni + Environment.NewLine;

            // Agrega una línea divisoria y espacios para organizar la presentación.
            texto += "======================================================================" + Environment.NewLine + Environment.NewLine;

            // Inicializa el contador de expedientes encontrados.
            int count = 0;

            // Recorre todos los expedientes registrados en el sistema.
            foreach (Expediente exp in Expediente.listaExpedientes)
            {
                // Comprueba si el DNI del expediente coincide con el DNI ingresado.
                if (exp.dni == dni)
                {
                    // Aumenta el contador porque se encontró un expediente.
                    count++;

                    // Agrega el código del expediente al resultado.
                    texto += "Código Expediente : " + exp.codigo + Environment.NewLine;

                    // Agrega el nombre del trabajador o titular.
                    texto += "Trabajador        : " + exp.titular + Environment.NewLine;

                    // Agrega el trámite solicitado.
                    texto += "Trámite           : " + exp.asunto + Environment.NewLine;

                    // Agrega la fecha y hora de la cita programada.
                    texto += "Cita Programada   : " + exp.fechaCita + Environment.NewLine;

                    // Agrega la fecha en que se registró el expediente.
                    texto += "Fecha Registro    : " + exp.fechaRegistro + Environment.NewLine;

                    // Agrega el estado actual del expediente.
                    texto += "Estado            : " + exp.estado + Environment.NewLine;

                    // Agrega una línea divisoria entre los expedientes encontrados.
                    texto += "----------------------------------------------------------------------" + Environment.NewLine;
                }
            }

            // Comprueba si no se encontró ningún expediente.
            // Si count es cero, muestra un mensaje indicando que no existen resultados.
            // Si count es mayor que cero, muestra los expedientes y el total encontrado.
            txtResultadoDniAdmin.Text = count == 0
                ? "No se encontraron expedientes registrados para el DNI " + dni + "."
                : texto + Environment.NewLine + "Total de expedientes encontrados: " + count;
        }

        // Método auxiliar que recibe una lista de expedientes y los muestra en la tabla.
        // También actualiza el contador total de solicitudes.
        private void CargarSolicitudes(List<Expediente> lista)
        {
            // Limpia los registros anteriores de la tabla de solicitudes.
            lvSolicitudesAdmin.Items.Clear();

            // Recorre todos los expedientes de la lista recibida.
            foreach (Expediente exp in lista)
            {
                // Crea una nueva fila utilizando el código del expediente.
                ListViewItem item = new ListViewItem(exp.codigo);

                // Agrega los demás datos del expediente a la fila.
                item.SubItems.Add(exp.dni);
                item.SubItems.Add(exp.titular);
                item.SubItems.Add(exp.asunto);
                item.SubItems.Add(exp.fechaCita);
                item.SubItems.Add(exp.estado);

                // Agrega la fila completa a la tabla de solicitudes.
                lvSolicitudesAdmin.Items.Add(item);
            }

            // Actualiza la etiqueta mostrando la cantidad de solicitudes recibidas.
            lblTotalSolicitudes.Text = lista.Count + " solicitud(es) total(es)";
        }

        // Método auxiliar que permite cambiar el estado de un expediente.
        // Recibe como parámetro el nuevo estado que se desea asignar.
        private void CambiarEstado(string nuevoEstado)
        {
            // Comprueba si el administrador ha seleccionado alguna solicitud.
            if (lvSolicitudesAdmin.SelectedItems.Count == 0)
            {
                // Muestra una advertencia si no hay ninguna solicitud seleccionada.
                MessageBox.Show("Seleccione una solicitud de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return; // Detiene el proceso si no hay una selección.
            }

            // Obtiene el código del expediente seleccionado en la tabla.
            string codigoExp = lvSolicitudesAdmin.SelectedItems[0].Text;

            // Recorre la lista principal de expedientes para encontrar el seleccionado.
            for (int i = 0; i < Expediente.listaExpedientes.Count; i++)
            {
                // Compara el código del expediente con el código seleccionado.
                if (Expediente.listaExpedientes[i].codigo == codigoExp)
                {
                    // Obtiene temporalmente el expediente encontrado.
                    Expediente temp = Expediente.listaExpedientes[i];

                    // Modifica su estado utilizando el valor recibido como parámetro.
                    // Puede ser APROBADO, POSPUESTO o DENEGADO.
                    temp.estado = nuevoEstado;

                    // Actualiza el expediente en la lista con el nuevo estado.
                    Expediente.listaExpedientes[i] = temp;

                    break; // Detiene el recorrido porque el expediente ya fue encontrado.
                }
            }

            // Guarda los cambios realizados en la lista de expedientes.
            Expediente.GuardarExpedientes();

            // Recarga la tabla para mostrar el estado actualizado.
            CargarSolicitudes(Expediente.listaExpedientes);

            // Muestra un mensaje indicando el código del expediente y su nuevo estado.
            MessageBox.Show("Expediente " + codigoExp + " actualizado a: " + nuevoEstado, "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento que se ejecuta cuando el administrador presiona el botón Aprobar.
        // Llama al método CambiarEstado y le envía el estado APROBADO.
        private void btnAprobar_Click(object sender, EventArgs e) { CambiarEstado("APROBADO"); }

        // Evento que se ejecuta cuando el administrador presiona el botón Posponer.
        // Llama al método CambiarEstado y le envía el estado POSPUESTO.
        private void btnPosponer_Click(object sender, EventArgs e) { CambiarEstado("POSPUESTO"); }

        // Evento que se ejecuta cuando el administrador presiona el botón Denegar.
        // Llama al método CambiarEstado y le envía el estado DENEGADO.
        private void btnDenegar_Click(object sender, EventArgs e) { CambiarEstado("DENEGADO"); }

        // Evento que se ejecuta cuando el administrador presiona el botón Ordenar.
        // Organiza los expedientes según el criterio seleccionado en el ComboBox.
        private void btnOrdenarAdmin_Click(object sender, EventArgs e)
        {
            // Crea una copia de la lista original de expedientes.
            // Esto permite ordenar los datos sin modificar el orden de la lista principal.
            List<Expediente> copia = new List<Expediente>(Expediente.listaExpedientes);

            // Primer bucle del algoritmo Bubble Sort.
            // Controla la cantidad de recorridos necesarios para ordenar la lista.
            for (int i = 0; i < copia.Count - 1; i++)
            {
                // Segundo bucle: compara los elementos consecutivos de la lista.
                for (int j = 0; j < copia.Count - i - 1; j++)
                {
                    // Variable que indica si se deben intercambiar dos expedientes.
                    bool swap = false;

                    // Si se seleccionó Código (índice 0), compara los códigos.
                    // Si el primero es mayor que el segundo, se necesita intercambiarlos.
                    if (cmbOrdenarAdmin.SelectedIndex == 0 && string.Compare(copia[j].codigo, copia[j + 1].codigo) > 0) swap = true;

                    // Si se seleccionó Trámite (índice 1), compara los nombres de los trámites.
                    else if (cmbOrdenarAdmin.SelectedIndex == 1 && string.Compare(copia[j].asunto, copia[j + 1].asunto) > 0) swap = true;

                    // Si se seleccionó Estado (índice 2), compara los estados de los expedientes.
                    else if (cmbOrdenarAdmin.SelectedIndex == 2 && string.Compare(copia[j].estado, copia[j + 1].estado) > 0) swap = true;

                    // Comprueba si las comparaciones indicaron que se necesita un intercambio.
                    if (swap)
                    {
                        // Guarda temporalmente el primer expediente.
                        Expediente aux = copia[j];

                        // Coloca el segundo expediente en la primera posición.
                        copia[j] = copia[j + 1];

                        // Coloca el expediente guardado en la segunda posición.
                        // De esta manera se intercambian ambos elementos sin perder información.
                        copia[j + 1] = aux;
                    }
                }
            }

            // Envía la lista ordenada al método CargarSolicitudes para actualizar la tabla.
            CargarSolicitudes(copia);
        }

        // Evento que se ejecuta cuando el administrador presiona el botón Cerrar sesión.
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Indica que el formulario se está cerrando por una acción de cierre de sesión.
            cerrarSesion = true;

            // Crea una nueva instancia del formulario de inicio de sesión.
            Form1 login = new Form1();

            // Muestra nuevamente la pantalla de inicio de sesión.
            login.Show();

            // Cierra el panel administrativo actual.
            this.Close();
        }
    }
}
