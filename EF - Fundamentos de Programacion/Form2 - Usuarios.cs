
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
    public partial class Form2 : Form
    {
        // Método que se ejecuta cuando se cierra el formulario.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Ejecuta el comportamiento original del cierre del formulario.
            base.OnFormClosed(e);

            // Comprueba si el usuario no está regresando al inicio de sesión.
            if (!volverAlLogin)
            {
                // Si no regresa al login, cierra toda la aplicación.
                Application.Exit();
            }
        }

        // Variable que indica si el usuario está regresando al inicio de sesión.
        // Inicialmente es false porque todavía no ha regresado.
        bool volverAlLogin = false;

        // Constructor del formulario de registro.
        public Form2()
        {
            InitializeComponent();

            // Permite ejecutar el botón Crear Usuario al presionar Enter.
            this.AcceptButton = btnCrearUsuario;

            // Permite ejecutar el botón Volver al presionar Escape.
            this.CancelButton = btnVolver;
        }

        // Evento que se ejecuta cuando el usuario hace clic en label1.
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Evento que se ejecuta cuando el usuario hace clic en label4.
        private void label4_Click(object sender, EventArgs e)
        {

        }

        // Evento que se ejecuta cuando se carga el formulario de registro.
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        // Evento principal que permite validar y registrar un nuevo usuario.
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Comprueba que el DNI tenga exactamente 8 caracteres.
            if (txtDNI.Text.Length != 8)
            {
                // Muestra una advertencia si el DNI no tiene 8 dígitos.
                MessageBox.Show("El DNI debe tener 8 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Coloca el cursor en el campo DNI.
                txtDNI.Focus();

                // Detiene la ejecución del método.
                return;
            }

            // Comprueba que los nombres y el correo no estén vacíos
            // y que el celular tenga exactamente 9 caracteres.
            if (txtNombres.Text == "" || txtCorreo.Text == "" || txtCelular.Text.Length != 9)
            {
                // Muestra una advertencia solicitando completar correctamente los datos.
                MessageBox.Show("Complete todos sus datos correctamente (celular de 9 dígitos).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Detiene la ejecución del método.
                return;
            }

            // Comprueba que el correo electrónico contenga el símbolo @.
            if (!txtCorreo.Text.Contains("@"))
            {
                // Muestra una advertencia si el correo no contiene @.
                MessageBox.Show("Debe ingresar un correo electrónico válido con @.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Coloca el cursor en el campo correo.
                txtCorreo.Focus();

                // Detiene la ejecución del método.
                return;
            }

            // Comprueba que la contraseña tenga como mínimo 6 caracteres.
            if (txtContraseña.Text.Length < 6)
            {
                // Muestra una advertencia si la contraseña es demasiado corta.
                MessageBox.Show("La contraseña debe tener mínimo 6 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Coloca el cursor en el campo contraseña.
                txtContraseña.Focus();

                // Detiene la ejecución del método.
                return;
            }

            // Variables booleanas para comprobar si la contraseña
            // contiene al menos una letra y un número.
            bool tieneLetra = false;
            bool tieneNumero = false;

            // Recorre cada carácter de la contraseña ingresada.
            foreach (char c in txtContraseña.Text)
            {
                // Comprueba si el carácter actual es una letra.
                if (char.IsLetter(c)) tieneLetra = true;

                // Comprueba si el carácter actual es un número.
                if (char.IsDigit(c)) tieneNumero = true;
            }

            // Comprueba que la contraseña tenga al menos una letra y un número.
            if (!tieneLetra || !tieneNumero)
            {
                // Muestra una advertencia si falta una letra o un número.
                MessageBox.Show("La contraseña debe incluir letras y números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Coloca el cursor en el campo contraseña.
                txtContraseña.Focus();

                // Detiene la ejecución del método.
                return;
            }

            // Compara la contraseña con el campo de confirmación.
            if (txtContraseña.Text != txtConfirmar.Text)
            {
                // Muestra una advertencia si las contraseñas son diferentes.
                MessageBox.Show("Las contraseñas no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Coloca el cursor en el campo de confirmación.
                txtConfirmar.Focus();

                // Detiene la ejecución del método.
                return;
            }

            // Recorre la lista de usuarios registrados para comprobar
            // si el DNI ingresado ya pertenece a otra cuenta.
            foreach (Usuario u in Usuario.listaUsuarios)
            {
                // Compara el DNI ingresado con el DNI de cada usuario registrado.
                if (u.dni == txtDNI.Text)
                {
                    // Muestra una advertencia si el DNI ya está registrado.
                    MessageBox.Show("Este DNI ya se encuentra registrado. Ya existe una cuenta creada con este número.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Coloca el cursor en el campo DNI.
                    txtDNI.Focus();

                    // Detiene el procedimiento para evitar un registro duplicado.
                    return;
                }
            }

            // Genera un código único para identificar al nuevo usuario.
            // Agrega el prefijo USR- al código generado.
            string codigoGenerado = "USR-" + Usuario.GenerarNuevoCodigo();

            // Crea un nuevo objeto de tipo Usuario.
            Usuario nuevoUsuario = new Usuario();

            // Asigna los datos ingresados en el formulario al nuevo usuario.
            nuevoUsuario.codigo = codigoGenerado;
            nuevoUsuario.dni = txtDNI.Text;
            nuevoUsuario.nombres = txtNombres.Text;
            nuevoUsuario.correo = txtCorreo.Text;
            nuevoUsuario.celular = txtCelular.Text;
            nuevoUsuario.contraseña = txtContraseña.Text;

            // Establece que el usuario registrado no tendrá permisos de administrador.
            nuevoUsuario.esAdmin = false;

            // Agrega el nuevo usuario a la lista de usuarios registrados.
            Usuario.listaUsuarios.Add(nuevoUsuario);

            // Ejecuta el método encargado de guardar los usuarios.
            Usuario.GuardarUsuarios();

            // Construye el mensaje que se mostrará cuando el registro sea exitoso.
            // Environment.NewLine permite insertar saltos de línea.
            string mensajeExito = "Usuario creado correctamente." + Environment.NewLine + Environment.NewLine +
                                  "Su código de usuario es: " + codigoGenerado + Environment.NewLine + Environment.NewLine +
                                  "Ya puede registrar y consultar sus trámites.";

            // Muestra el mensaje de confirmación del registro exitoso.
            MessageBox.Show(mensajeExito, "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Indica que el formulario se está cerrando para regresar al login.
            volverAlLogin = true;

            // Crea una nueva instancia del formulario de inicio de sesión.
            Form1 login = new Form1();

            // Muestra el formulario de inicio de sesión.
            login.Show();

            // Cierra el formulario de registro.
            this.Close();
        }

        // Evento que se ejecuta cuando el usuario presiona el botón Volver.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Indica que el usuario está regresando al inicio de sesión.
            volverAlLogin = true;

            // Crea una nueva instancia del formulario de inicio de sesión.
            Form1 login = new Form1();

            // Muestra la ventana de inicio de sesión.
            login.Show();

            // Cierra el formulario de registro.
            this.Close();
        }

        // Controla los caracteres que se pueden escribir en el campo DNI.
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite únicamente números y teclas de control, como Retroceso.
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Bloquea cualquier carácter que no cumpla las condiciones.
                e.Handled = true;
            }
        }

        // Controla los caracteres que se pueden escribir en el campo celular.
        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite únicamente números y teclas de control, como Retroceso.
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Bloquea cualquier carácter que no cumpla las condiciones.
                e.Handled = true;
            }
        }

        // Se ejecuta cuando el usuario sale del campo correo electrónico.
        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            // Comprueba que el campo no esté vacío y que contenga el símbolo @.
            if (txtCorreo.Text != "" && !txtCorreo.Text.Contains("@"))
            {
                // Muestra una advertencia si el correo no contiene @.
                MessageBox.Show("El correo electrónico debe contener el símbolo @.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento que se ejecuta cuando el usuario presiona el botón para ver la contraseña.
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

        // Evento de clic asociado a un botón.
        // Actualmente está vacío y no realiza ninguna acción.
        private void button1_Click(object sender, EventArgs e)
        {

        }

        // Evento que se ejecuta cuando se cierra el formulario de registro.
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Comprueba si el usuario no está regresando al inicio de sesión.
            if (!volverAlLogin)
            {
                // Si el formulario se cierra directamente, termina toda la aplicación.
                Application.Exit();
            }
        }

        // Evento que permite mostrar u ocultar la contraseña de confirmación.
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Comprueba si la contraseña de confirmación está oculta.
            if (txtConfirmar.UseSystemPasswordChar)
            {
                // Si está oculta, permite visualizar los caracteres.
                txtConfirmar.UseSystemPasswordChar = false;
            }
            else
            {
                // Si está visible, vuelve a ocultar los caracteres.
                txtConfirmar.UseSystemPasswordChar = true;
            }

            // Mantiene el cursor en el campo de confirmación.
            txtConfirmar.Focus();
        }
    }
}
