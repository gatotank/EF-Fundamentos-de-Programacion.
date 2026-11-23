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
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!volverAlLogin)
            {
                Application.Exit();
            }
        }

        bool volverAlLogin = false;

        public Form4()
        {
            InitializeComponent();
        }

        private void btnVer1_Click(object sender, EventArgs e)
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

        private void btnVer2_Click(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length != 8)
            {
                MessageBox.Show("Ingrese un DNI válido de 8 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return;
            }

            Usuario usuarioEncontrado = null;

            foreach (Usuario u in Usuario.listaUsuarios)
            {
                if (u.dni == txtDNI.Text)
                {
                    usuarioEncontrado = u;
                    break;
                }
            }

            if (usuarioEncontrado == null)
            {
                MessageBox.Show("No existe ninguna cuenta registrada con ese DNI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return;
            }

            if (txtContraseña.Text.Length < 6)
            {
                MessageBox.Show("La nueva contraseña debe tener mínimo 6 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            usuarioEncontrado.contraseña = txtContraseña.Text;
            Usuario.GuardarUsuarios();

            string mensaje = "Contraseña restablecida correctamente." + Environment.NewLine + Environment.NewLine +
                             "Usuario reconocido: " + usuarioEncontrado.codigo + " (" + usuarioEncontrado.nombres + ")" + Environment.NewLine + Environment.NewLine +
                             "Ya puede iniciar sesión con su nueva contraseña.";

            MessageBox.Show(mensaje, "Contraseña actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!volverAlLogin)
            {
                Application.Exit();
            }
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length == 8)
            {
                foreach (Usuario u in Usuario.listaUsuarios)
                {
                    if (u.dni == txtDNI.Text)
                    {
                        lblUsuarioEncontrado.ForeColor = Color.DodgerBlue;
                        lblUsuarioEncontrado.Text = "Usuario encontrado: " + u.codigo + " - " + u.nombres;
                        return;
                    }
                }

                lblUsuarioEncontrado.ForeColor = Color.Firebrick;
                lblUsuarioEncontrado.Text = "DNI no registrado.";
            }
            else
            {
                lblUsuarioEncontrado.Text = "";
            }
        }
    }
}