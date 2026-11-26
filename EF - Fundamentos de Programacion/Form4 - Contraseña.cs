
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
    public partial class Form4 : Form
    {
        // Se ejecuta cuando el formulario está a punto de cerrarse.
        // Si no se está regresando al inicio de sesión, cierra toda la aplicación.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Ejecuta el comportamiento original de cierre del formulario.
            base.OnFormClosed(e);

            // Comprueba si el usuario está cerrando el formulario sin regresar al login.
            if (!volverAlLogin)
            {
                Application.Exit(); // Cierra toda la aplicación.
            }
        }

        // Variable que indica si el usuario está regresando al formulario de inicio de sesión.
        // Su valor inicial es false.
        bool volverAlLogin = false;

        public Form4()
        {
            InitializeComponent(); // Inicializa los controles y componentes del formulario.

            // Permite ejecutar el botón Guardar al presionar la tecla Enter.
            this.AcceptButton = btnGuardar;

            // Permite ejecutar el botón Volver al presionar la tecla Escape.
            this.CancelButton = btnVolver;
        }

        // Evento que se ejecuta al hacer clic en el botón para mostrar u ocultar la contraseña.
        private void btnVer1_Click(object sender, EventArgs e)
        {
            // Comprueba si la contraseña está oculta.
            if (txtContraseña.UseSystemPasswordChar)
            {
                txtContraseña.UseSystemPasswordChar = false; // Muestra la contraseña.
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true; // Oculta la contraseña.
            }

            // Mantiene el cursor dentro del campo de contraseña.
            txtContraseña.Focus();
        }

        // Evento que se ejecuta al hacer clic en el botón para mostrar u ocultar la confirmación.
        private void btnVer2_Click(object sender, EventArgs e)
        {
            // Comprueba si la confirmación de contraseña está oculta.
            if (txtConfirmar.UseSystemPasswordChar)
            {
                txtConfirmar.UseSystemPasswordChar = false; // Muestra la contraseña.
            }
            else
            {
                txtConfirmar.UseSystemPasswordChar = true; // Oculta la contraseña.
            }

            // Mantiene el cursor dentro del campo de confirmación.
            txtConfirmar.Focus();
        }

        // Evento principal: se ejecuta cuando el usuario presiona el botón Guardar.
        // Su función es validar los datos y restablecer la contraseña.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Comprueba que el DNI tenga exactamente 8 caracteres.
            if (txtDNI.Text.Length != 8)
            {
                MessageBox.Show("Ingrese un DNI válido de 8 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus(); // Devuelve el cursor al campo DNI.
                return; // Detiene el proceso si la validación no se cumple.
            }

            // Inicializa el índice en -1 para indicar que todavía no se encontró al usuario.
            int indiceUsuario = -1;

            // Recorre la lista de usuarios para buscar una cuenta que coincida con el DNI ingresado.
            for (int i = 0; i < Usuario.listaUsuarios.Count; i++)
            {
                // Compara el DNI ingresado con el DNI de cada usuario registrado.
                if (Usuario.listaUsuarios[i].dni == txtDNI.Text)
                {
                    indiceUsuario = i; // Guarda la posición del usuario encontrado.
                    break; // Detiene el recorrido porque ya encontró al usuario.
                }
            }

            // Si el índice sigue siendo -1, significa que no se encontró ninguna cuenta.
            if (indiceUsuario == -1)
            {
                MessageBox.Show("No existe ninguna cuenta registrada con ese DNI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus(); // Devuelve el cursor al campo DNI.
                return; // Detiene el proceso.
            }

            // Comprueba que la nueva contraseña tenga como mínimo 6 caracteres.
            if (txtContraseña.Text.Length < 6)
            {
                MessageBox.Show("La nueva contraseña debe tener mínimo 6 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus(); // Devuelve el cursor al campo de contraseña.
                return; // Detiene el proceso.
            }

            // Variables que permiten comprobar si la contraseña contiene letras y números.
            bool tieneLetra = false;
            bool tieneNumero = false;

            // Recorre cada carácter de la nueva contraseña.
            foreach (char c in txtContraseña.Text)
            {
                // Comprueba si el carácter actual es una letra.
                if (char.IsLetter(c)) tieneLetra = true;

                // Comprueba si el carácter actual es un número.
                if (char.IsDigit(c)) tieneNumero = true;
            }

            // Verifica que se haya encontrado al menos una letra y un número.
            if (!tieneLetra || !tieneNumero)
            {
                MessageBox.Show("La contraseña debe incluir letras y números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus(); // Devuelve el cursor al campo de contraseña.
                return; // Detiene el proceso.
            }

            // Compara la nueva contraseña con la contraseña ingresada en el campo de confirmación.
            if (txtContraseña.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmar.Focus(); // Devuelve el cursor al campo de confirmación.
                return; // Detiene el proceso.
            }

            // Obtiene el usuario encontrado utilizando la posición guardada en indiceUsuario.
            Usuario temp = Usuario.listaUsuarios[indiceUsuario];

            // Actualiza la contraseña del usuario con la nueva contraseña ingresada.
            temp.contraseña = txtContraseña.Text;

            // Reemplaza el registro del usuario en la lista con los datos actualizados.
            Usuario.listaUsuarios[indiceUsuario] = temp;

            // Guarda los cambios para que la nueva contraseña quede almacenada.
            Usuario.GuardarUsuarios();

            // Construye el mensaje que se mostrará después de actualizar la contraseña.
            string mensaje = "Contraseña restablecida correctamente." + Environment.NewLine + Environment.NewLine +
                             "Usuario reconocido: " + temp.codigo + " (" + temp.nombres + ")" + Environment.NewLine + Environment.NewLine +
                             "Ya puede iniciar sesión con su nueva contraseña.";

            // Muestra el mensaje de confirmación de la operación.
            MessageBox.Show(mensaje, "Contraseña actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Indica que el formulario se está cerrando para regresar al inicio de sesión.
            volverAlLogin = true;

            // Crea una nueva instancia del formulario de inicio de sesión.
            Form1 login = new Form1();

            // Muestra el formulario de inicio de sesión.
            login.Show();

            // Cierra el formulario actual.
            this.Close();
        }

        // Evento que se ejecuta cuando el usuario presiona el botón Volver.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Indica que el cierre del formulario es para regresar al login.
            volverAlLogin = true;

            // Crea una nueva instancia del formulario de inicio de sesión.
            Form1 login = new Form1();

            // Muestra el formulario de inicio de sesión.
            login.Show();

            // Cierra el formulario de recuperación de contraseña.
            this.Close();
        }

        // Evento que se ejecuta al presionar una tecla dentro del campo DNI.
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite escribir únicamente números y teclas de control, como Retroceso.
            // Si se ingresa otro carácter, se bloquea su escritura.
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Evento que se ejecuta cuando se cierra el formulario.
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Si el usuario no está regresando al login, se cierra toda la aplicación.
            if (!volverAlLogin)
            {
                Application.Exit();
            }
        }

        // Evento que se ejecuta cada vez que cambia el contenido del campo DNI.
        // Permite mostrar si el usuario está registrado antes de guardar la contraseña.
        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            // Comprueba si el DNI ingresado ya tiene 8 caracteres.
            if (txtDNI.Text.Length == 8)
            {
                // Recorre la lista de usuarios registrados.
                foreach (Usuario u in Usuario.listaUsuarios)
                {
                    // Compara el DNI ingresado con el DNI de cada usuario.
                    if (u.dni == txtDNI.Text)
                    {
                        // Cambia el color de la etiqueta a azul para indicar que se encontró al usuario.
                        lblUsuarioEncontrado.ForeColor = Color.DodgerBlue;

                        // Muestra el código y los nombres del usuario encontrado.
                        lblUsuarioEncontrado.Text = "Usuario encontrado: " + u.codigo + " - " + u.nombres;

                        return; // Finaliza el método porque el usuario ya fue encontrado.
                    }
                }

                // Si termina el recorrido sin encontrar coincidencias, muestra un aviso en rojo.
                lblUsuarioEncontrado.ForeColor = Color.Firebrick;
                lblUsuarioEncontrado.Text = "DNI no registrado.";
            }
            else
            {
                // Si el DNI todavía no tiene 8 caracteres, limpia el mensaje de la etiqueta.
                lblUsuarioEncontrado.Text = "";
            }
        }
    }
}
