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
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!volverAlLogin)
            {
                Application.Exit();
            }
        }

        bool volverAlLogin = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return;
            }

            if (txtNombres.Text == "" || txtCorreo.Text == "" || txtCelular.Text.Length != 9)
            {
                MessageBox.Show("Complete todos sus datos correctamente (celular de 9 dígitos).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show("Debe ingresar un correo electrónico válido con @.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (txtContraseña.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener mínimo 6 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return;
            }

            bool tieneLetra = false;
            bool tieneNumero = false;

            foreach (char c in txtContraseña.Text)
            {
                if (char.IsLetter(c)) tieneLetra = true;
                if (char.IsDigit(c)) tieneNumero = true;
            }

            if (!tieneLetra || !tieneNumero)
            {
                MessageBox.Show("La contraseña debe incluir letras y números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return;
            }

            if (txtContraseña.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmar.Focus();
                return;
            }

            foreach (Usuario u in Usuario.listaUsuarios)
            {
                if (u.dni == txtDNI.Text)
                {
                    MessageBox.Show("Este DNI ya se encuentra registrado. Ya existe una cuenta creada con este número.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDNI.Focus();
                    return;
                }
            }

            int numeroCorrelativo = Usuario.listaUsuarios.Count + 1;
            string codigoGenerado = "USR-" + numeroCorrelativo.ToString("D4");

            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.codigo = codigoGenerado;
            nuevoUsuario.dni = txtDNI.Text;
            nuevoUsuario.nombres = txtNombres.Text;
            nuevoUsuario.correo = txtCorreo.Text;
            nuevoUsuario.celular = txtCelular.Text;
            nuevoUsuario.contraseña = txtContraseña.Text;

            Usuario.listaUsuarios.Add(nuevoUsuario);
            Usuario.GuardarUsuarios();

            string mensajeExito = "Usuario creado correctamente." + Environment.NewLine + Environment.NewLine +
                                  "Su código de usuario es: " + codigoGenerado + Environment.NewLine + Environment.NewLine +
                                  "Ya puede registrar y consultar sus trámites.";

            MessageBox.Show(mensajeExito, "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            volverAlLogin = true;
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            volverAlLogin = true;
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text != "" && !txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show("El correo electrónico debe contener el símbolo @.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVerContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseña.UseSystemPasswordChar)
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
            }

            txtContraseña.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!volverAlLogin)
            {
                Application.Exit();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtConfirmar.UseSystemPasswordChar)
            {
                txtConfirmar.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmar.UseSystemPasswordChar = true;
            }

            txtConfirmar.Focus();
        }
    }
}