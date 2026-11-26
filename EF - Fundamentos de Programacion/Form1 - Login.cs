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
        int intentosFallidos = 0;

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnIniciarSeccion;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            lineaDNI.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            lineaDNI.BackColor = Color.Silver;
        }

        private void txtContraseña_Enter_1(object sender, EventArgs e)
        {
            lineaContraseña.BackColor = Color.DodgerBlue;
            VerificarMayusculas();
        }

        private void txtContraseña_Leave_1(object sender, EventArgs e)
        {
            lineaContraseña.BackColor = Color.Silver;
            toolTip1.Hide(txtContraseña);
        }

        private void txtContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            VerificarMayusculas();
        }

        private void VerificarMayusculas()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                toolTip1.Show("Si la tecla Bloq Mayús está activada es posible que escriba incorrectamente la contraseña." + Environment.NewLine + Environment.NewLine + "Presione la tecla Bloq Mayús para desactivarla antes de escribir la contraseña.", txtContraseña, 10, 25, 4000);
            }
            else
            {
                toolTip1.Hide(txtContraseña);
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

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            Form2 ventanaRegistro = new Form2();
            ventanaRegistro.Show();
            this.Hide();
        }

        private void btnIniciarSeccion_Click(object sender, EventArgs e)
        {
            string usuarioInput = txtDNI.Text.Trim();

            bool esAliasAdmin = usuarioInput.Equals("admin", StringComparison.OrdinalIgnoreCase) ||
                    usuarioInput.Equals("admin123", StringComparison.OrdinalIgnoreCase) ||
                    usuarioInput.Equals("administrador", StringComparison.OrdinalIgnoreCase) ||
                    usuarioInput.Equals("administrador123", StringComparison.OrdinalIgnoreCase);

            if (esAliasAdmin)
            {
                usuarioInput = "00000000";
            }
            else if (usuarioInput.Length != 8)
            {
                MessageBox.Show("Ingrese un usuario válido (DNI de 8 dígitos).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return;
            }

            if (txtContraseña.Text == "")
            {
                MessageBox.Show("Ingrese su contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return;
            }

            Usuario usuarioEncontrado = new Usuario();
            bool encontrado = false;

            foreach (Usuario u in Usuario.listaUsuarios)
            {
                if (u.dni == usuarioInput && u.contraseña == txtContraseña.Text)
                {
                    usuarioEncontrado = u;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                intentosFallidos++;

                if (intentosFallidos >= 3)
                {
                    MessageBox.Show("Has fallado " + intentosFallidos + " veces. Presiona el botón 'Restablecer contraseña' de abajo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("DNI o contraseña incorrectos, o el usuario aún no está registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            intentosFallidos = 0;
            Usuario.usuarioActual = usuarioEncontrado;

            intentosFallidos = 0;
            Usuario.usuarioActual = usuarioEncontrado;

            if (usuarioEncontrado.esAdmin)
            {
                Form5 panelAdmin = new Form5();
                panelAdmin.Show();
            }
            else
            {
                Form3 panelTrabajador = new Form3();
                panelTrabajador.Show();
            }
            this.Hide();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            Form4 recuperar = new Form4();
            recuperar.Show();
            this.Hide();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

    }
}