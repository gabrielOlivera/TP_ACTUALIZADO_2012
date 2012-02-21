namespace TpDiseñoCSharp
{
    partial class Alta_De_Puesto
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.TituloEmpresa = new System.Windows.Forms.Label();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.Fecha = new System.Windows.Forms.LinkLabel();
            this.SeleccionDeAcceso = new System.Windows.Forms.GroupBox();
            this.labelPond = new System.Windows.Forms.Label();
            this.labelComp = new System.Windows.Forms.Label();
            this.Quitar = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.panelCaracteristicas = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Empresa = new System.Windows.Forms.TextBox();
            this.Descripcion = new System.Windows.Forms.TextBox();
            this.NombreDePuesto = new System.Windows.Forms.TextBox();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.menuConsultor = new System.Windows.Forms.Button();
            this.Consultor = new System.Windows.Forms.Label();
            this.CerrarSesion = new System.Windows.Forms.LinkLabel();
            this.Aceptar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.PanelInferior.SuspendLayout();
            this.SeleccionDeAcceso.SuspendLayout();
            this.PanelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 636);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 37);
            this.panel2.TabIndex = 8;
            // 
            // TituloEmpresa
            // 
            this.TituloEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloEmpresa.AutoSize = true;
            this.TituloEmpresa.Font = new System.Drawing.Font("Viner Hand ITC", 15.75F, System.Drawing.FontStyle.Bold);
            this.TituloEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TituloEmpresa.Location = new System.Drawing.Point(351, 18);
            this.TituloEmpresa.Name = "TituloEmpresa";
            this.TituloEmpresa.Size = new System.Drawing.Size(157, 34);
            this.TituloEmpresa.TabIndex = 0;
            this.TituloEmpresa.Text = "Human TIC\'s";
            // 
            // PanelInferior
            // 
            this.PanelInferior.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelInferior.Controls.Add(this.Fecha);
            this.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferior.Location = new System.Drawing.Point(0, 676);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(885, 58);
            this.PanelInferior.TabIndex = 5;
            // 
            // Fecha
            // 
            this.Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Fecha.AutoSize = true;
            this.Fecha.CausesValidation = false;
            this.Fecha.DisabledLinkColor = System.Drawing.Color.Black;
            this.Fecha.Enabled = false;
            this.Fecha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Fecha.Location = new System.Drawing.Point(723, 24);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(151, 13);
            this.Fecha.TabIndex = 0;
            this.Fecha.TabStop = true;
            this.Fecha.Text = "Thursday, November 24, 2011";
            this.Fecha.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // SeleccionDeAcceso
            // 
            this.SeleccionDeAcceso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SeleccionDeAcceso.Controls.Add(this.labelPond);
            this.SeleccionDeAcceso.Controls.Add(this.labelComp);
            this.SeleccionDeAcceso.Controls.Add(this.Quitar);
            this.SeleccionDeAcceso.Controls.Add(this.Agregar);
            this.SeleccionDeAcceso.Controls.Add(this.panelCaracteristicas);
            this.SeleccionDeAcceso.Controls.Add(this.label5);
            this.SeleccionDeAcceso.Controls.Add(this.Empresa);
            this.SeleccionDeAcceso.Controls.Add(this.Descripcion);
            this.SeleccionDeAcceso.Controls.Add(this.NombreDePuesto);
            this.SeleccionDeAcceso.Controls.Add(this.Codigo);
            this.SeleccionDeAcceso.Controls.Add(this.label4);
            this.SeleccionDeAcceso.Controls.Add(this.label3);
            this.SeleccionDeAcceso.Controls.Add(this.label2);
            this.SeleccionDeAcceso.Controls.Add(this.label1);
            this.SeleccionDeAcceso.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SeleccionDeAcceso.Location = new System.Drawing.Point(172, 108);
            this.SeleccionDeAcceso.Name = "SeleccionDeAcceso";
            this.SeleccionDeAcceso.Size = new System.Drawing.Size(500, 473);
            this.SeleccionDeAcceso.TabIndex = 9;
            this.SeleccionDeAcceso.TabStop = false;
            this.SeleccionDeAcceso.Text = "Ingrese los datos del puesto que desea dar de alta";
            // 
            // labelPond
            // 
            this.labelPond.AutoSize = true;
            this.labelPond.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPond.Location = new System.Drawing.Point(313, 354);
            this.labelPond.Name = "labelPond";
            this.labelPond.Size = new System.Drawing.Size(67, 13);
            this.labelPond.TabIndex = 13;
            this.labelPond.Text = "Ponderacion";
            // 
            // labelComp
            // 
            this.labelComp.AutoSize = true;
            this.labelComp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelComp.Location = new System.Drawing.Point(47, 354);
            this.labelComp.Name = "labelComp";
            this.labelComp.Size = new System.Drawing.Size(69, 13);
            this.labelComp.TabIndex = 12;
            this.labelComp.Text = "Competencia";
            // 
            // Quitar
            // 
            this.Quitar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.Quitar.ForeColor = System.Drawing.Color.Red;
            this.Quitar.Location = new System.Drawing.Point(437, 310);
            this.Quitar.Name = "Quitar";
            this.Quitar.Size = new System.Drawing.Size(37, 33);
            this.Quitar.TabIndex = 11;
            this.Quitar.Text = "-";
            this.Quitar.UseVisualStyleBackColor = true;
            this.Quitar.Click += new System.EventHandler(this.Quitar_Click);
            // 
            // Agregar
            // 
            this.Agregar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.Agregar.ForeColor = System.Drawing.Color.Green;
            this.Agregar.Location = new System.Drawing.Point(394, 310);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(37, 33);
            this.Agregar.TabIndex = 10;
            this.Agregar.Text = "+";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // panelCaracteristicas
            // 
            this.panelCaracteristicas.AutoScroll = true;
            this.panelCaracteristicas.Location = new System.Drawing.Point(38, 370);
            this.panelCaracteristicas.Name = "panelCaracteristicas";
            this.panelCaracteristicas.Size = new System.Drawing.Size(436, 88);
            this.panelCaracteristicas.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(35, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Características del Puesto";
            // 
            // Empresa
            // 
            this.Empresa.Location = new System.Drawing.Point(202, 265);
            this.Empresa.MaxLength = 20;
            this.Empresa.Name = "Empresa";
            this.Empresa.Size = new System.Drawing.Size(100, 20);
            this.Empresa.TabIndex = 7;
            // 
            // Descripcion
            // 
            this.Descripcion.Location = new System.Drawing.Point(202, 140);
            this.Descripcion.MaxLength = 255;
            this.Descripcion.Multiline = true;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(178, 94);
            this.Descripcion.TabIndex = 6;
            // 
            // NombreDePuesto
            // 
            this.NombreDePuesto.Location = new System.Drawing.Point(202, 79);
            this.NombreDePuesto.MaxLength = 20;
            this.NombreDePuesto.Name = "NombreDePuesto";
            this.NombreDePuesto.Size = new System.Drawing.Size(100, 20);
            this.NombreDePuesto.TabIndex = 5;
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(202, 39);
            this.Codigo.MaxLength = 20;
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(100, 20);
            this.Codigo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(118, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Empresa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(103, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(71, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre de Puesto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(126, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-8, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 22);
            this.panel1.TabIndex = 7;
            // 
            // PanelSuperior
            // 
            this.PanelSuperior.BackColor = System.Drawing.Color.DarkGray;
            this.PanelSuperior.Controls.Add(this.menuConsultor);
            this.PanelSuperior.Controls.Add(this.Consultor);
            this.PanelSuperior.Controls.Add(this.CerrarSesion);
            this.PanelSuperior.Controls.Add(this.TituloEmpresa);
            this.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSuperior.Enabled = false;
            this.PanelSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanelSuperior.Name = "PanelSuperior";
            this.PanelSuperior.Size = new System.Drawing.Size(885, 62);
            this.PanelSuperior.TabIndex = 6;
            // 
            // menuConsultor
            // 
            this.menuConsultor.Location = new System.Drawing.Point(12, 29);
            this.menuConsultor.Name = "menuConsultor";
            this.menuConsultor.Size = new System.Drawing.Size(128, 23);
            this.menuConsultor.TabIndex = 15;
            this.menuConsultor.Text = "Volver al menú principal";
            this.menuConsultor.UseVisualStyleBackColor = true;
            // 
            // Consultor
            // 
            this.Consultor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Consultor.AutoSize = true;
            this.Consultor.Location = new System.Drawing.Point(723, 39);
            this.Consultor.Name = "Consultor";
            this.Consultor.Size = new System.Drawing.Size(51, 13);
            this.Consultor.TabIndex = 14;
            this.Consultor.Text = "Consultor";
            // 
            // CerrarSesion
            // 
            this.CerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CerrarSesion.AutoSize = true;
            this.CerrarSesion.Location = new System.Drawing.Point(812, 39);
            this.CerrarSesion.Name = "CerrarSesion";
            this.CerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.CerrarSesion.TabIndex = 13;
            this.CerrarSesion.TabStop = true;
            this.CerrarSesion.Text = "Cerrar Sesión";
            // 
            // Aceptar
            // 
            this.Aceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Aceptar.Location = new System.Drawing.Point(329, 587);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 10;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            // 
            // Cancelar
            // 
            this.Cancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancelar.Location = new System.Drawing.Point(514, 587);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 11;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Alta_De_Puesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(885, 734);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelInferior);
            this.Controls.Add(this.SeleccionDeAcceso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelSuperior);
            this.Name = "Alta_De_Puesto";
            this.Text = "Alta de Puesto o Función";
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.SeleccionDeAcceso.ResumeLayout(false);
            this.SeleccionDeAcceso.PerformLayout();
            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TituloEmpresa;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.LinkLabel Fecha;
        private System.Windows.Forms.GroupBox SeleccionDeAcceso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelSuperior;
        private System.Windows.Forms.TextBox Descripcion;
        private System.Windows.Forms.TextBox NombreDePuesto;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Empresa;
        private System.Windows.Forms.Button Quitar;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Panel panelCaracteristicas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Label labelPond;
        private System.Windows.Forms.Label labelComp;
        private System.Windows.Forms.Label Consultor;
        private System.Windows.Forms.LinkLabel CerrarSesion;
        private System.Windows.Forms.Button menuConsultor;
    }
}