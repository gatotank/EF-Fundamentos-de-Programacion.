
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
    public partial class Form1 : Form
    {
        // Variable que almacena la cantidad de intentos fallidos al iniciar sesión.
        int intentosFallidos = 0;

        // Constructor del formulario principal.
        public Form1()
        {
            InitializeComponent();

            // Permite iniciar sesión al presionar Enter.
            this.AcceptButton = btnIniciarSeccion;
        }

        // Evento que se ejecuta cuando se hace clic en el label3.
        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Controla los caracteres que se pueden escribir en el campo DNI.
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite teclas de control, letras y números.
            // Bloquea cualquier otro carácter especial.
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Evento que se ejecuta cuando Windows Forms dibuja el panel2.
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Evento que se ejecuta cuando se hace clic en el label4.
        private void label4_Click(object sender, EventArgs e)
        {

        }

        // Detecta cuando cambia el contenido del campo contraseña.
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        // Segundo evento de clic asociado al label4.
        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        // Evento que se ejecuta cuando Windows Forms dibuja el panel1.
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Detecta cuando cambia el contenido del textBox1.
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        // Se ejecuta cuando el usuario selecciona el campo DNI.
        private void txtDNI_Enter(object sender, EventArgs e)
        {
            // Cambia la línea inferior del DNI a color azul.
            lineaDNI.BackColor = Color.FromArgb(0, 120, 212);
        }

        // Se ejecuta cuando el usuario sale del campo DNI.
        private void txtDNI_Leave(object sender, EventArgs e)
        {
            // Devuelve la línea inferior del DNI a color gris.
            lineaDNI.BackColor = Color.Silver;
        }

        // Se ejecuta cuando el usuario selecciona el campo contraseña.
        private void txtContraseña_Enter_1(object sender, EventArgs e)
        {
            // Cambia la línea inferior de la contraseña a azul.
            lineaContraseña.BackColor = Color.DodgerBlue;

            // Comprueba si la tecla Bloq Mayús está activada.
            VerificarMayusculas();
        }

        // Se ejecuta cuando el usuario sale del campo contraseña.
        private void txtContraseña_Leave_1(object sender, EventArgs e)
        {
            // Devuelve la línea inferior a color gris.
            lineaContraseña.BackColor = Color.Silver;

            // Oculta el mensaje de advertencia de Bloq Mayús.
            toolTip1.Hide(txtContraseña);
        }

        // Detecta cuando el usuario suelta una tecla al escribir la contraseña.
        private void txtContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            // Vuelve a comprobar si Bloq Mayús está activada.
            VerificarMayusculas();
        }

        // Método auxiliar que comprueba el estado de la tecla Bloq Mayús.
        private void VerificarMayusculas()
        {
            // Comprueba si la tecla Bloq Mayús está activada.
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                // Muestra una advertencia durante 4 segundos.
                // También indica que se debe desactivar Bloq Mayús.
                toolTip1.Show("Si la tecla Bloq Mayús está activada es posible que escriba incorrectamente la contraseña." + Environment.NewLine + Environment.NewLine + "Presione la tecla Bloq Mayús para desactivarla antes de escribir la contraseña.", txtContraseña, 10, 25, 4000);
            }
            else
            {
                // Si Bloq Mayús está desactivada, oculta la advertencia.
                toolTip1.Hide(txtContraseña);
            }
        }

        // Evento que se ejecuta al presionar el botón para ver la contraseña.
        private void btnVerContraseña_Click(object sender, EventArgs e)
        {
            // Comprueba si la contraseña está oculta.
            if (txtContraseña.UseSystemPasswordChar)
            {
                // Si está oculta, permite visualizar los caracteres.
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                // Si está visible, vuelve a ocultar los caracteres.
                txtContraseña.UseSystemPasswordChar = true;
            }

            // Mantiene el cursor en el campo contraseña.
            txtContraseña.Focus();
        }

        // Detecta cuando cambia el contenido del campo DNI.
        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        // Evento que se ejecuta al presionar el botón Crear Usuario.
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario de registro.
            Form2 ventanaRegistro = new Form2();

            // Abre la ventana de registro.
            ventanaRegistro.Show();

            // Oculta el formulario de inicio de sesión.
            this.Hide();
        }

        // Evento principal que permite validar e iniciar sesión.
        private void btnIniciarSeccion_Click(object sender, EventArgs e)
        {
            // Obtiene el DNI o alias ingresado y elimina espacios al inicio y al final.
            string usuarioInput = txtDNI.Text.Trim();

            // Comprueba si el usuario ingresó alguno de los alias del administrador.
            // OrdinalIgnoreCase permite comparar sin distinguir mayúsculas y minúsculas.
            bool esAliasAdmin = usuarioInput.Equals("admin", StringComparison.OrdinalIgnoreCase) ||
                    usuarioInput.Equals("admin123", StringComparison.OrdinalIgnoreCase) ||
                    usuarioInput.Equals("administrador", StringComparison.OrdinalIgnoreCase) ||
                    usuarioInput.Equals("administrador123", StringComparison.OrdinalIgnoreCase);

            // Si ingresó un alias de administrador, lo reemplaza por su DNI asignado.
            if (esAliasAdmin)
            {
                usuarioInput = "00000000";
            }
            // Si no es administrador, comprueba que el DNI tenga 8 caracteres.
            else if (usuarioInput.Length != 8)
            {
                // Muestra un mensaje indicando que el DNI no es válido.
                MessageBox.Show("Ingrese un usuario válido (DNI de 8 dígitos).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Devuelve el cursor al campo DNI.
                txtDNI.Focus();

                // Detiene la ejecución del método.
                return;
            }

            // Comprueba que el campo contraseña no esté vacío.
            if (txtContraseña.Text == "")
            {
                // Muestra una advertencia solicitando la contraseña.
                MessageBox.Show("Ingrese su contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Coloca el cursor en el campo contraseña.
                txtContraseña.Focus();

                // Detiene la ejecución del método.
                return;
            }

            // Crea una variable para almacenar los datos del usuario encontrado.
            Usuario usuarioEncontrado = new Usuario();

            // Variable que indica si se encontró una coincidencia.
            bool encontrado = false;

            // Recorre todos los usuarios registrados en la lista.
            foreach (Usuario u in Usuario.listaUsuarios)
            {
                // Compara el DNI y la contraseña ingresados con los datos registrados.
                if (u.dni == usuarioInput && u.contraseña == txtContraseña.Text)
                {
                    // Guarda los datos del usuario que coincide.
                    usuarioEncontrado = u;

                    // Indica que el usuario fue encontrado.
                    encontrado = true;

                    // Finaliza la búsqueda al encontrar una coincidencia.
                    break;
                }
            }

            // Comprueba si no se encontró al usuario.
            if (!encontrado)
            {
                // Aumenta el contador de intentos fallidos.
                intentosFallidos++;

                // Comprueba si el usuario llegó a 3 intentos fallidos.
                if (intentosFallidos >= 3)
                {
                    // Muestra una advertencia para restablecer la contraseña.
                    MessageBox.Show("Has fallado " + intentosFallidos + " veces. Presiona el botón 'Restablecer contraseña' de abajo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Muestra un mensaje de credenciales incorrectas.
                    MessageBox.Show("DNI o contraseña incorrectos, o el usuario aún no está registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Detiene el método porque las credenciales no son correctas.
                return;
            }

            // Reinicia el contador cuando el inicio de sesión es correcto.
            intentosFallidos = 0;

            // Guarda los datos del usuario que inició sesión.
            Usuario.usuarioActual = usuarioEncontrado;

            // Comprueba si el usuario tiene permisos de administrador.
            if (usuarioEncontrado.esAdmin)
            {
                // Crea una instancia del panel de administración.
                Form5 panelAdmin = new Form5();

                // Abre el panel de administración.
                panelAdmin.Show();
            }
            else
            {
                // Crea una instancia del panel de trabajadores.
                Form3 panelTrabajador = new Form3();

                // Abre el panel de trabajadores.
                panelTrabajador.Show();
            }

            // Oculta el formulario de inicio de sesión después de ingresar.
            this.Hide();
        }

        // Evento que se ejecuta al presionar el botón Restablecer contraseña.
        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario de recuperación de contraseña.
            Form4 recuperar = new Form4();

            // Abre el formulario de recuperación.
            recuperar.Show();

            // Oculta el formulario de inicio de sesión.
            this.Hide();
        }

        // Sobrescribe el evento que se ejecuta cuando se cierra el formulario.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Ejecuta primero el comportamiento original de cierre del formulario.
            base.OnFormClosed(e);

            // Cierra toda la aplicación.
            Application.Exit();
        }

    }
}
