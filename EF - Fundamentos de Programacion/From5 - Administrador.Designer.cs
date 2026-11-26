namespace WindowsFormsApp2
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblDatosUsuario = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabAdminTrabajadores = new System.Windows.Forms.TabPage();
            this.btnEliminarTrabajador = new System.Windows.Forms.Button();
            this.lvAdminTrabajadores = new System.Windows.Forms.ListView();
            this.lblTituloTab1 = new System.Windows.Forms.Label();
            this.tabAdminConsultaDni = new System.Windows.Forms.TabPage();
            this.txtResultadoDniAdmin = new System.Windows.Forms.TextBox();
            this.btnBuscarDniAdmin = new System.Windows.Forms.Button();
            this.txtBuscarDniAdmin = new System.Windows.Forms.TextBox();
            this.lblInstruccionDni = new System.Windows.Forms.Label();
            this.tabAdminSolicitudes = new System.Windows.Forms.TabPage();
            this.lvSolicitudesAdmin = new System.Windows.Forms.ListView();
            this.btnDenegar = new System.Windows.Forms.Button();
            this.btnPosponer = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.lblTotalSolicitudes = new System.Windows.Forms.Label();
            this.btnOrdenarAdmin = new System.Windows.Forms.Button();
            this.cmbOrdenarAdmin = new System.Windows.Forms.ComboBox();
            this.lblOrdenarAdmin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControlAdmin.SuspendLayout();
            this.tabAdminTrabajadores.SuspendLayout();
            this.tabAdminConsultaDni.SuspendLayout();
            this.tabAdminSolicitudes.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1180, 82);
            this.panel1.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.White;
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Location = new System.Drawing.Point(1020, 22);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(130, 36);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblDatosUsuario
            // 
            this.lblDatosUsuario.AutoSize = true;
            this.lblDatosUsuario.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblDatosUsuario.Location = new System.Drawing.Point(20, 44);
            this.lblDatosUsuario.Name = "lblDatosUsuario";
            this.lblDatosUsuario.Size = new System.Drawing.Size(445, 23);
            this.lblDatosUsuario.TabIndex = 1;
            this.lblDatosUsuario.Text = "Código: 0001  |  DNI: 00000000  |  ROL: ADMINISTRADOR";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.Location = new System.Drawing.Point(20, 14);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(235, 25);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido, Administrador";
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabAdminTrabajadores);
            this.tabControlAdmin.Controls.Add(this.tabAdminConsultaDni);
            this.tabControlAdmin.Controls.Add(this.tabAdminSolicitudes);
            this.tabControlAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdmin.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControlAdmin.Location = new System.Drawing.Point(0, 82);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(1180, 560);
            this.tabControlAdmin.TabIndex = 1;
            // 
            // tabAdminTrabajadores
            // 
            this.tabAdminTrabajadores.Controls.Add(this.btnEliminarTrabajador);
            this.tabAdminTrabajadores.Controls.Add(this.lvAdminTrabajadores);
            this.tabAdminTrabajadores.Controls.Add(this.lblTituloTab1);
            this.tabAdminTrabajadores.Location = new System.Drawing.Point(4, 30);
            this.tabAdminTrabajadores.Name = "tabAdminTrabajadores";
            this.tabAdminTrabajadores.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdminTrabajadores.Size = new System.Drawing.Size(1172, 526);
            this.tabAdminTrabajadores.TabIndex = 0;
            this.tabAdminTrabajadores.Text = "1. Trabajadores registrados";
            this.tabAdminTrabajadores.UseVisualStyleBackColor = true;
            // 
            // lblTituloTab1
            // 
            this.lblTituloTab1.AutoSize = true;
            this.lblTituloTab1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloTab1.Location = new System.Drawing.Point(20, 16);
            this.lblTituloTab1.Name = "lblTituloTab1";
            this.lblTituloTab1.Size = new System.Drawing.Size(415, 23);
            this.lblTituloTab1.TabIndex = 0;
            this.lblTituloTab1.Text = "Listado completo de trabajadores registrados:";
            // 
            // lvAdminTrabajadores
            // 
            this.lvAdminTrabajadores.FullRowSelect = true;
            this.lvAdminTrabajadores.GridLines = true;
            this.lvAdminTrabajadores.HideSelection = false;
            this.lvAdminTrabajadores.Location = new System.Drawing.Point(20, 50);
            this.lvAdminTrabajadores.Name = "lvAdminTrabajadores";
            this.lvAdminTrabajadores.Size = new System.Drawing.Size(1130, 405);
            this.lvAdminTrabajadores.TabIndex = 1;
            this.lvAdminTrabajadores.UseCompatibleStateImageBehavior = false;
            this.lvAdminTrabajadores.View = System.Windows.Forms.View.Details;
            // 
            // btnEliminarTrabajador
            // 
            this.btnEliminarTrabajador.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminarTrabajador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTrabajador.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarTrabajador.ForeColor = System.Drawing.Color.White;
            this.btnEliminarTrabajador.Location = new System.Drawing.Point(20, 470);
            this.btnEliminarTrabajador.Name = "btnEliminarTrabajador";
            this.btnEliminarTrabajador.Size = new System.Drawing.Size(270, 38);
            this.btnEliminarTrabajador.TabIndex = 2;
            this.btnEliminarTrabajador.Text = "Eliminar trabajador seleccionado";
            this.btnEliminarTrabajador.UseVisualStyleBackColor = false;
            this.btnEliminarTrabajador.Click += new System.EventHandler(this.btnEliminarTrabajador_Click);
            // 
            // tabAdminConsultaDni
            // 
            this.tabAdminConsultaDni.Controls.Add(this.txtResultadoDniAdmin);
            this.tabAdminConsultaDni.Controls.Add(this.btnBuscarDniAdmin);
            this.tabAdminConsultaDni.Controls.Add(this.txtBuscarDniAdmin);
            this.tabAdminConsultaDni.Controls.Add(this.lblInstruccionDni);
            this.tabAdminConsultaDni.Location = new System.Drawing.Point(4, 30);
            this.tabAdminConsultaDni.Name = "tabAdminConsultaDni";
            this.tabAdminConsultaDni.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdminConsultaDni.Size = new System.Drawing.Size(1172, 526);
            this.tabAdminConsultaDni.TabIndex = 1;
            this.tabAdminConsultaDni.Text = "2. Consultar por DNI";
            this.tabAdminConsultaDni.UseVisualStyleBackColor = true;
            // 
            // lblInstruccionDni
            // 
            this.lblInstruccionDni.AutoSize = true;
            this.lblInstruccionDni.Location = new System.Drawing.Point(20, 18);
            this.lblInstruccionDni.Name = "lblInstruccionDni";
            this.lblInstruccionDni.Size = new System.Drawing.Size(485, 21);
            this.lblInstruccionDni.TabIndex = 0;
            this.lblInstruccionDni.Text = "Ingrese el DNI del trabajador (8 dígitos) para ver todos sus expedientes:";
            // 
            // txtBuscarDniAdmin
            // 
            this.txtBuscarDniAdmin.Location = new System.Drawing.Point(20, 48);
            this.txtBuscarDniAdmin.MaxLength = 8;
            this.txtBuscarDniAdmin.Name = "txtBuscarDniAdmin";
            this.txtBuscarDniAdmin.Size = new System.Drawing.Size(230, 29);
            this.txtBuscarDniAdmin.TabIndex = 1;
            this.txtBuscarDniAdmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarDniAdmin_KeyPress);
            // 
            // btnBuscarDniAdmin
            // 
            this.btnBuscarDniAdmin.BackColor = System.Drawing.Color.White;
            this.btnBuscarDniAdmin.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarDniAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDniAdmin.Location = new System.Drawing.Point(265, 47);
            this.btnBuscarDniAdmin.Name = "btnBuscarDniAdmin";
            this.btnBuscarDniAdmin.Size = new System.Drawing.Size(130, 31);
            this.btnBuscarDniAdmin.TabIndex = 2;
            this.btnBuscarDniAdmin.Text = "Consultar";
            this.btnBuscarDniAdmin.UseVisualStyleBackColor = false;
            this.btnBuscarDniAdmin.Click += new System.EventHandler(this.btnBuscarDniAdmin_Click);
            // 
            // txtResultadoDniAdmin
            // 
            this.txtResultadoDniAdmin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResultadoDniAdmin.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtResultadoDniAdmin.Location = new System.Drawing.Point(20, 95);
            this.txtResultadoDniAdmin.Multiline = true;
            this.txtResultadoDniAdmin.Name = "txtResultadoDniAdmin";
            this.txtResultadoDniAdmin.ReadOnly = true;
            this.txtResultadoDniAdmin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultadoDniAdmin.Size = new System.Drawing.Size(1130, 410);
            this.txtResultadoDniAdmin.TabIndex = 3;
            // 
            // tabAdminSolicitudes
            // 
            this.tabAdminSolicitudes.Controls.Add(this.lvSolicitudesAdmin);
            this.tabAdminSolicitudes.Controls.Add(this.btnDenegar);
            this.tabAdminSolicitudes.Controls.Add(this.btnPosponer);
            this.tabAdminSolicitudes.Controls.Add(this.btnAprobar);
            this.tabAdminSolicitudes.Controls.Add(this.lblTotalSolicitudes);
            this.tabAdminSolicitudes.Controls.Add(this.btnOrdenarAdmin);
            this.tabAdminSolicitudes.Controls.Add(this.cmbOrdenarAdmin);
            this.tabAdminSolicitudes.Controls.Add(this.lblOrdenarAdmin);
            this.tabAdminSolicitudes.Location = new System.Drawing.Point(4, 30);
            this.tabAdminSolicitudes.Name = "tabAdminSolicitudes";
            this.tabAdminSolicitudes.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdminSolicitudes.Size = new System.Drawing.Size(1172, 526);
            this.tabAdminSolicitudes.TabIndex = 2;
            this.tabAdminSolicitudes.Text = "3. Gestionar solicitudes";
            this.tabAdminSolicitudes.UseVisualStyleBackColor = true;
            // 
            // lblOrdenarAdmin
            // 
            this.lblOrdenarAdmin.AutoSize = true;
            this.lblOrdenarAdmin.Location = new System.Drawing.Point(18, 18);
            this.lblOrdenarAdmin.Name = "lblOrdenarAdmin";
            this.lblOrdenarAdmin.Size = new System.Drawing.Size(96, 21);
            this.lblOrdenarAdmin.TabIndex = 0;
            this.lblOrdenarAdmin.Text = "Ordenar por:";
            // 
            // cmbOrdenarAdmin
            // 
            this.cmbOrdenarAdmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenarAdmin.FormattingEnabled = true;
            this.cmbOrdenarAdmin.Location = new System.Drawing.Point(120, 15);
            this.cmbOrdenarAdmin.Name = "cmbOrdenarAdmin";
            this.cmbOrdenarAdmin.Size = new System.Drawing.Size(185, 29);
            this.cmbOrdenarAdmin.TabIndex = 1;
            // 
            // btnOrdenarAdmin
            // 
            this.btnOrdenarAdmin.BackColor = System.Drawing.Color.White;
            this.btnOrdenarAdmin.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOrdenarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarAdmin.Location = new System.Drawing.Point(315, 14);
            this.btnOrdenarAdmin.Name = "btnOrdenarAdmin";
            this.btnOrdenarAdmin.Size = new System.Drawing.Size(100, 30);
            this.btnOrdenarAdmin.TabIndex = 2;
            this.btnOrdenarAdmin.Text = "Ordenar";
            this.btnOrdenarAdmin.UseVisualStyleBackColor = false;
            this.btnOrdenarAdmin.Click += new System.EventHandler(this.btnOrdenarAdmin_Click);
            // 
            // lblTotalSolicitudes
            // 
            this.lblTotalSolicitudes.AutoSize = true;
            this.lblTotalSolicitudes.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalSolicitudes.Location = new System.Drawing.Point(430, 18);
            this.lblTotalSolicitudes.Name = "lblTotalSolicitudes";
            this.lblTotalSolicitudes.Size = new System.Drawing.Size(150, 21);
            this.lblTotalSolicitudes.TabIndex = 3;
            this.lblTotalSolicitudes.Text = "0 solicitud(es) total(es)";
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAprobar.ForeColor = System.Drawing.Color.White;
            this.btnAprobar.Location = new System.Drawing.Point(760, 12);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(120, 34);
            this.btnAprobar.TabIndex = 4;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnPosponer
            // 
            this.btnPosponer.BackColor = System.Drawing.Color.DarkOrange;
            this.btnPosponer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosponer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPosponer.ForeColor = System.Drawing.Color.White;
            this.btnPosponer.Location = new System.Drawing.Point(890, 12);
            this.btnPosponer.Name = "btnPosponer";
            this.btnPosponer.Size = new System.Drawing.Size(120, 34);
            this.btnPosponer.TabIndex = 5;
            this.btnPosponer.Text = "Posponer";
            this.btnPosponer.UseVisualStyleBackColor = false;
            this.btnPosponer.Click += new System.EventHandler(this.btnPosponer_Click);
            // 
            // btnDenegar
            // 
            this.btnDenegar.BackColor = System.Drawing.Color.Firebrick;
            this.btnDenegar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenegar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDenegar.ForeColor = System.Drawing.Color.White;
            this.btnDenegar.Location = new System.Drawing.Point(1020, 12);
            this.btnDenegar.Name = "btnDenegar";
            this.btnDenegar.Size = new System.Drawing.Size(120, 34);
            this.btnDenegar.TabIndex = 6;
            this.btnDenegar.Text = "Denegar";
            this.btnDenegar.UseVisualStyleBackColor = false;
            this.btnDenegar.Click += new System.EventHandler(this.btnDenegar_Click);
            // 
            // lvSolicitudesAdmin
            // 
            this.lvSolicitudesAdmin.FullRowSelect = true;
            this.lvSolicitudesAdmin.GridLines = true;
            this.lvSolicitudesAdmin.HideSelection = false;
            this.lvSolicitudesAdmin.Location = new System.Drawing.Point(15, 56);
            this.lvSolicitudesAdmin.Name = "lvSolicitudesAdmin";
            this.lvSolicitudesAdmin.Size = new System.Drawing.Size(1140, 455);
            this.lvSolicitudesAdmin.TabIndex = 7;
            this.lvSolicitudesAdmin.UseCompatibleStateImageBehavior = false;
            this.lvSolicitudesAdmin.View = System.Windows.Forms.View.Details;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 642);
            this.Controls.Add(this.tabControlAdmin);
            this.Controls.Add(this.panel1);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesa de Partes Digital - Panel de Administrador";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlAdmin.ResumeLayout(false);
            this.tabAdminTrabajadores.ResumeLayout(false);
            this.tabAdminTrabajadores.PerformLayout();
            this.tabAdminConsultaDni.ResumeLayout(false);
            this.tabAdminConsultaDni.PerformLayout();
            this.tabAdminSolicitudes.ResumeLayout(false);
            this.tabAdminSolicitudes.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblDatosUsuario;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabAdminTrabajadores;
        private System.Windows.Forms.Label lblTituloTab1;
        private System.Windows.Forms.ListView lvAdminTrabajadores;
        private System.Windows.Forms.Button btnEliminarTrabajador;
        private System.Windows.Forms.TabPage tabAdminConsultaDni;
        private System.Windows.Forms.Label lblInstruccionDni;
        private System.Windows.Forms.TextBox txtBuscarDniAdmin;
        private System.Windows.Forms.Button btnBuscarDniAdmin;
        private System.Windows.Forms.TextBox txtResultadoDniAdmin;
        private System.Windows.Forms.TabPage tabAdminSolicitudes;
        private System.Windows.Forms.Label lblOrdenarAdmin;
        private System.Windows.Forms.ComboBox cmbOrdenarAdmin;
        private System.Windows.Forms.Button btnOrdenarAdmin;
        private System.Windows.Forms.Label lblTotalSolicitudes;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnPosponer;
        private System.Windows.Forms.Button btnDenegar;
        private System.Windows.Forms.ListView lvSolicitudesAdmin;
    }
}