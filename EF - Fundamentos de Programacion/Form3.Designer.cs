namespace WindowsFormsApp2
{
    partial class Form3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblDatosUsuario = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTramites = new System.Windows.Forms.ComboBox();
            this.lblDetalleTramite = new System.Windows.Forms.Label();
            this.lblOtroTramite = new System.Windows.Forms.Label();
            this.txtOtroTramite = new System.Windows.Forms.TextBox();
            this.btnRegistrarTramite = new System.Windows.Forms.Button();
            this.panelCita = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.calCita = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbHoraCita = new System.Windows.Forms.ComboBox();
            this.lblCitaSeleccionada = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConsultaDni = new System.Windows.Forms.TextBox();
            this.btnConsultarDni = new System.Windows.Forms.Button();
            this.txtResultadoConsulta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.lblCantidadExpedientes = new System.Windows.Forms.Label();
            this.lvExpedientes = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panelCita.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.btnCerrarSesion);
            this.panel1.Controls.Add(this.lblDatosUsuario);
            this.panel1.Controls.Add(this.lblBienvenida);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 82);
            this.panel1.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(20, 16);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(207, 25);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido(a), Usuario";
            // 
            // lblDatosUsuario
            // 
            this.lblDatosUsuario.AutoSize = true;
            this.lblDatosUsuario.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosUsuario.Location = new System.Drawing.Point(20, 42);
            this.lblDatosUsuario.Name = "lblDatosUsuario";
            this.lblDatosUsuario.Size = new System.Drawing.Size(393, 23);
            this.lblDatosUsuario.TabIndex = 1;
            this.lblDatosUsuario.Text = "Código de usuario: USR-0001  |  DNI: 00000000";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.White;
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Location = new System.Drawing.Point(840, 22);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 34);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1082, 541);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelCita);
            this.tabPage1.Controls.Add(this.btnRegistrarTramite);
            this.tabPage1.Controls.Add(this.txtOtroTramite);
            this.tabPage1.Controls.Add(this.lblOtroTramite);
            this.tabPage1.Controls.Add(this.lblDetalleTramite);
            this.tabPage1.Controls.Add(this.cmbTramites);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1074, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. Registrar trámite";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtResultadoConsulta);
            this.tabPage2.Controls.Add(this.btnConsultarDni);
            this.tabPage2.Controls.Add(this.txtConsultaDni);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1074, 508);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2. Consultar por DNI";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvExpedientes);
            this.tabPage3.Controls.Add(this.lblCantidadExpedientes);
            this.tabPage3.Controls.Add(this.btnOrdenar);
            this.tabPage3.Controls.Add(this.cmbOrdenar);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1074, 508);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3. Mis expedientes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el trámite virtual RENIEC y programe su cita de atención:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trámite a realizar:";
            // 
            // cmbTramites
            // 
            this.cmbTramites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTramites.FormattingEnabled = true;
            this.cmbTramites.Location = new System.Drawing.Point(25, 76);
            this.cmbTramites.Name = "cmbTramites";
            this.cmbTramites.Size = new System.Drawing.Size(510, 28);
            this.cmbTramites.TabIndex = 2;
            this.cmbTramites.SelectedIndexChanged += new System.EventHandler(this.cmbTramites_SelectedIndexChanged);
            // 
            // lblDetalleTramite
            // 
            this.lblDetalleTramite.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleTramite.ForeColor = System.Drawing.Color.DimGray;
            this.lblDetalleTramite.Location = new System.Drawing.Point(25, 110);
            this.lblDetalleTramite.Name = "lblDetalleTramite";
            this.lblDetalleTramite.Size = new System.Drawing.Size(510, 65);
            this.lblDetalleTramite.TabIndex = 3;
            // 
            // lblOtroTramite
            // 
            this.lblOtroTramite.AutoSize = true;
            this.lblOtroTramite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtroTramite.Location = new System.Drawing.Point(25, 182);
            this.lblOtroTramite.Name = "lblOtroTramite";
            this.lblOtroTramite.Size = new System.Drawing.Size(294, 20);
            this.lblOtroTramite.TabIndex = 4;
            this.lblOtroTramite.Text = "Especifique el trámite que desea realizar:";
            this.lblOtroTramite.Visible = false;
            // 
            // txtOtroTramite
            // 
            this.txtOtroTramite.Location = new System.Drawing.Point(25, 205);
            this.txtOtroTramite.Name = "txtOtroTramite";
            this.txtOtroTramite.Size = new System.Drawing.Size(510, 27);
            this.txtOtroTramite.TabIndex = 5;
            this.txtOtroTramite.Visible = false;
            // 
            // btnRegistrarTramite
            // 
            this.btnRegistrarTramite.BackColor = System.Drawing.Color.White;
            this.btnRegistrarTramite.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnRegistrarTramite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarTramite.Location = new System.Drawing.Point(25, 250);
            this.btnRegistrarTramite.Name = "btnRegistrarTramite";
            this.btnRegistrarTramite.Size = new System.Drawing.Size(180, 38);
            this.btnRegistrarTramite.TabIndex = 6;
            this.btnRegistrarTramite.Text = "Registrar trámite";
            this.btnRegistrarTramite.UseVisualStyleBackColor = false;
            this.btnRegistrarTramite.Click += new System.EventHandler(this.btnRegistrarTramite_Click);
            // 
            // panelCita
            // 
            this.panelCita.BackColor = System.Drawing.Color.White;
            this.panelCita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCita.Controls.Add(this.lblCitaSeleccionada);
            this.panelCita.Controls.Add(this.cmbHoraCita);
            this.panelCita.Controls.Add(this.label4);
            this.panelCita.Controls.Add(this.calCita);
            this.panelCita.Controls.Add(this.label3);
            this.panelCita.Location = new System.Drawing.Point(580, 52);
            this.panelCita.Name = "panelCita";
            this.panelCita.Size = new System.Drawing.Size(470, 400);
            this.panelCita.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Agendar Cita (A partir de mañana)";
            // 
            // calCita
            // 
            this.calCita.Location = new System.Drawing.Point(70, 57);
            this.calCita.MaxSelectionCount = 1;
            this.calCita.Name = "calCita";
            this.calCita.TabIndex = 1;
            this.calCita.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calCita_DateChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(373, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Horario (9:00 AM - 4:00 PM | Almuerzo 1-2 PM bloqueado):";
            // 
            // cmbHoraCita
            // 
            this.cmbHoraCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraCita.FormattingEnabled = true;
            this.cmbHoraCita.Location = new System.Drawing.Point(20, 314);
            this.cmbHoraCita.Name = "cmbHoraCita";
            this.cmbHoraCita.Size = new System.Drawing.Size(210, 28);
            this.cmbHoraCita.TabIndex = 3;
            this.cmbHoraCita.SelectedIndexChanged += new System.EventHandler(this.cmbHoraCita_SelectedIndexChanged);
            // 
            // lblCitaSeleccionada
            // 
            this.lblCitaSeleccionada.AutoSize = true;
            this.lblCitaSeleccionada.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCitaSeleccionada.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCitaSeleccionada.Location = new System.Drawing.Point(20, 354);
            this.lblCitaSeleccionada.Name = "lblCitaSeleccionada";
            this.lblCitaSeleccionada.Size = new System.Drawing.Size(152, 17);
            this.lblCitaSeleccionada.TabIndex = 4;
            this.lblCitaSeleccionada.Text = "Seleccione fecha y hora";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(402, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ingrese su DNI (8 dígitos) para consultar todos sus trámites:";
            // 
            // txtConsultaDni
            // 
            this.txtConsultaDni.Location = new System.Drawing.Point(25, 52);
            this.txtConsultaDni.MaxLength = 8;
            this.txtConsultaDni.Name = "txtConsultaDni";
            this.txtConsultaDni.Size = new System.Drawing.Size(240, 27);
            this.txtConsultaDni.TabIndex = 1;
            this.txtConsultaDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultaDni_KeyPress);
            // 
            // btnConsultarDni
            // 
            this.btnConsultarDni.BackColor = System.Drawing.Color.White;
            this.btnConsultarDni.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnConsultarDni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarDni.Location = new System.Drawing.Point(280, 50);
            this.btnConsultarDni.Name = "btnConsultarDni";
            this.btnConsultarDni.Size = new System.Drawing.Size(120, 30);
            this.btnConsultarDni.TabIndex = 2;
            this.btnConsultarDni.Text = "Consultar";
            this.btnConsultarDni.UseVisualStyleBackColor = false;
            this.btnConsultarDni.Click += new System.EventHandler(this.btnConsultarDni_Click);
            // 
            // txtResultadoConsulta
            // 
            this.txtResultadoConsulta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResultadoConsulta.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultadoConsulta.Location = new System.Drawing.Point(25, 98);
            this.txtResultadoConsulta.Multiline = true;
            this.txtResultadoConsulta.Name = "txtResultadoConsulta";
            this.txtResultadoConsulta.ReadOnly = true;
            this.txtResultadoConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultadoConsulta.Size = new System.Drawing.Size(1010, 410);
            this.txtResultadoConsulta.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ordenar por:";
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.Location = new System.Drawing.Point(115, 14);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(180, 28);
            this.cmbOrdenar.TabIndex = 1;
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.BackColor = System.Drawing.Color.White;
            this.btnOrdenar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOrdenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenar.Location = new System.Drawing.Point(308, 13);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(100, 29);
            this.btnOrdenar.TabIndex = 2;
            this.btnOrdenar.Text = "Ordenar";
            this.btnOrdenar.UseVisualStyleBackColor = false;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // lblCantidadExpedientes
            // 
            this.lblCantidadExpedientes.AutoSize = true;
            this.lblCantidadExpedientes.ForeColor = System.Drawing.Color.DimGray;
            this.lblCantidadExpedientes.Location = new System.Drawing.Point(425, 18);
            this.lblCantidadExpedientes.Name = "lblCantidadExpedientes";
            this.lblCantidadExpedientes.Size = new System.Drawing.Size(111, 20);
            this.lblCantidadExpedientes.TabIndex = 3;
            this.lblCantidadExpedientes.Text = "0 expediente(s)";
            // 
            // lvExpedientes
            // 
            this.lvExpedientes.FullRowSelect = true;
            this.lvExpedientes.GridLines = true;
            this.lvExpedientes.HideSelection = false;
            this.lvExpedientes.Location = new System.Drawing.Point(0, 52);
            this.lvExpedientes.Name = "lvExpedientes";
            this.lvExpedientes.Size = new System.Drawing.Size(1075, 480);
            this.lvExpedientes.TabIndex = 4;
            this.lvExpedientes.UseCompatibleStateImageBehavior = false;
            this.lvExpedientes.View = System.Windows.Forms.View.Details;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 623);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Votaciones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panelCita.ResumeLayout(false);
            this.panelCita.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDatosUsuario;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblOtroTramite;
        private System.Windows.Forms.Label lblDetalleTramite;
        private System.Windows.Forms.ComboBox cmbTramites;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panelCita;
        private System.Windows.Forms.Button btnRegistrarTramite;
        private System.Windows.Forms.TextBox txtOtroTramite;
        private System.Windows.Forms.Label lblCitaSeleccionada;
        private System.Windows.Forms.ComboBox cmbHoraCita;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MonthCalendar calCita;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConsultarDni;
        private System.Windows.Forms.TextBox txtConsultaDni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResultadoConsulta;
        private System.Windows.Forms.Label lblCantidadExpedientes;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvExpedientes;
    }
}