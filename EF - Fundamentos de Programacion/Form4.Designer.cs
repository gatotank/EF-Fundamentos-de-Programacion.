namespace WindowsFormsApp2
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnVer2 = new System.Windows.Forms.Button();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnVer1 = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lineaContraseña = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lineaDNI = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblUsuarioEncontrado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(485, 497);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(200, 38);
            this.btnVolver.TabIndex = 60;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(257, 497);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 38);
            this.btnGuardar.TabIndex = 59;
            this.btnGuardar.Text = "Guardar Contraseña";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Window;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(247, 456);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(460, 20);
            this.label9.TabIndex = 58;
            this.label9.Text = "La contraseña debe tener mínimo 6 caracteres, con letras y números.";
            // 
            // btnVer2
            // 
            this.btnVer2.BackColor = System.Drawing.Color.White;
            this.btnVer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVer2.FlatAppearance.BorderSize = 0;
            this.btnVer2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnVer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer2.Location = new System.Drawing.Point(678, 385);
            this.btnVer2.Name = "btnVer2";
            this.btnVer2.Size = new System.Drawing.Size(35, 30);
            this.btnVer2.TabIndex = 57;
            this.btnVer2.Text = "👁";
            this.btnVer2.UseVisualStyleBackColor = false;
            this.btnVer2.Click += new System.EventHandler(this.btnVer2_Click);
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmar.Location = new System.Drawing.Point(367, 385);
            this.txtConfirmar.MaxLength = 20000;
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.Size = new System.Drawing.Size(305, 31);
            this.txtConfirmar.TabIndex = 55;
            this.txtConfirmar.UseSystemPasswordChar = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Location = new System.Drawing.Point(367, 408);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(305, 10);
            this.panel4.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(177, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 20);
            this.label8.TabIndex = 54;
            this.label8.Text = "Confirmar Contraseña:";
            // 
            // btnVer1
            // 
            this.btnVer1.BackColor = System.Drawing.Color.White;
            this.btnVer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVer1.FlatAppearance.BorderSize = 0;
            this.btnVer1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnVer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer1.Location = new System.Drawing.Point(678, 308);
            this.btnVer1.Name = "btnVer1";
            this.btnVer1.Size = new System.Drawing.Size(35, 30);
            this.btnVer1.TabIndex = 53;
            this.btnVer1.Text = "👁";
            this.btnVer1.UseVisualStyleBackColor = false;
            this.btnVer1.Click += new System.EventHandler(this.btnVer1_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(367, 308);
            this.txtContraseña.MaxLength = 20000;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(305, 31);
            this.txtContraseña.TabIndex = 51;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // lineaContraseña
            // 
            this.lineaContraseña.BackColor = System.Drawing.Color.Silver;
            this.lineaContraseña.Location = new System.Drawing.Point(367, 331);
            this.lineaContraseña.Name = "lineaContraseña";
            this.lineaContraseña.Size = new System.Drawing.Size(305, 10);
            this.lineaContraseña.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(247, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "Contraseña:";
            // 
            // txtDNI
            // 
            this.txtDNI.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.Location = new System.Drawing.Point(277, 164);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(340, 31);
            this.txtDNI.TabIndex = 39;
            this.txtDNI.TextChanged += new System.EventHandler(this.txtDNI_TextChanged);
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // lineaDNI
            // 
            this.lineaDNI.BackColor = System.Drawing.Color.Silver;
            this.lineaDNI.Location = new System.Drawing.Point(277, 195);
            this.lineaDNI.Name = "lineaDNI";
            this.lineaDNI.Size = new System.Drawing.Size(340, 2);
            this.lineaDNI.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(158, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(636, 23);
            this.label2.TabIndex = 37;
            this.label2.Text = "Ingrese su DNI para identificar su código de usuario y crear una nueva contraseña" +
    "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(293, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 35);
            this.label1.TabIndex = 36;
            this.label1.Text = "RESTABLECER CONTRASEÑA";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(658, 169);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 26);
            this.btnBuscar.TabIndex = 61;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // lblUsuarioEncontrado
            // 
            this.lblUsuarioEncontrado.AutoSize = true;
            this.lblUsuarioEncontrado.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioEncontrado.ForeColor = System.Drawing.Color.DimGray;
            this.lblUsuarioEncontrado.Location = new System.Drawing.Point(247, 230);
            this.lblUsuarioEncontrado.Name = "lblUsuarioEncontrado";
            this.lblUsuarioEncontrado.Size = new System.Drawing.Size(274, 23);
            this.lblUsuarioEncontrado.TabIndex = 62;
            this.lblUsuarioEncontrado.Text = "Ingrese su DNI y presione Buscar.";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 623);
            this.Controls.Add(this.lblUsuarioEncontrado);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnVer2);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnVer1);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.lineaContraseña);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.lineaDNI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Votaciones - Restablecer Contraseña";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnVer2;
        private System.Windows.Forms.TextBox txtConfirmar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnVer1;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Panel lineaContraseña;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Panel lineaDNI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblUsuarioEncontrado;
    }
}