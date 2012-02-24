﻿namespace TpDiseñoCSharp
{
    partial class Evaluar_Candidato
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
            this.Buscar = new System.Windows.Forms.Button();
            this.nroCandidato = new System.Windows.Forms.TextBox();
            this.nroEmpleado = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.menuConsultor = new System.Windows.Forms.Button();
            this.Consultor = new System.Windows.Forms.Label();
            this.CerrarSesion = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VerAgregados = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.resultadosDeBusqueda = new System.Windows.Forms.DataGridView();
            this.Siguiente = new System.Windows.Forms.Button();
            this.PanelInferior.SuspendLayout();
            this.SeleccionDeAcceso.SuspendLayout();
            this.PanelSuperior.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosDeBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 649);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(28, 37);
            this.panel2.TabIndex = 8;
            // 
            // TituloEmpresa
            // 
            this.TituloEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloEmpresa.AutoSize = true;
            this.TituloEmpresa.Font = new System.Drawing.Font("Viner Hand ITC", 15.75F, System.Drawing.FontStyle.Bold);
            this.TituloEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TituloEmpresa.Location = new System.Drawing.Point(304, 18);
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
            this.PanelInferior.Location = new System.Drawing.Point(0, 692);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(790, 58);
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
            this.Fecha.Location = new System.Drawing.Point(628, 24);
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
            this.SeleccionDeAcceso.Controls.Add(this.Buscar);
            this.SeleccionDeAcceso.Controls.Add(this.nroCandidato);
            this.SeleccionDeAcceso.Controls.Add(this.nroEmpleado);
            this.SeleccionDeAcceso.Controls.Add(this.nombre);
            this.SeleccionDeAcceso.Controls.Add(this.apellido);
            this.SeleccionDeAcceso.Controls.Add(this.label4);
            this.SeleccionDeAcceso.Controls.Add(this.label3);
            this.SeleccionDeAcceso.Controls.Add(this.label2);
            this.SeleccionDeAcceso.Controls.Add(this.label1);
            this.SeleccionDeAcceso.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SeleccionDeAcceso.Location = new System.Drawing.Point(116, 117);
            this.SeleccionDeAcceso.Name = "SeleccionDeAcceso";
            this.SeleccionDeAcceso.Size = new System.Drawing.Size(517, 183);
            this.SeleccionDeAcceso.TabIndex = 9;
            this.SeleccionDeAcceso.TabStop = false;
            this.SeleccionDeAcceso.Text = "Ingrese los datos para realizar su búsqueda";
            // 
            // Buscar
            // 
            this.Buscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Buscar.Location = new System.Drawing.Point(215, 142);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 8;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // nroCandidato
            // 
            this.nroCandidato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nroCandidato.Location = new System.Drawing.Point(359, 97);
            this.nroCandidato.MaxLength = 4;
            this.nroCandidato.Name = "nroCandidato";
            this.nroCandidato.Size = new System.Drawing.Size(100, 20);
            this.nroCandidato.TabIndex = 7;
            // 
            // nroEmpleado
            // 
            this.nroEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nroEmpleado.Location = new System.Drawing.Point(118, 90);
            this.nroEmpleado.MaxLength = 4;
            this.nroEmpleado.Name = "nroEmpleado";
            this.nroEmpleado.Size = new System.Drawing.Size(100, 20);
            this.nroEmpleado.TabIndex = 6;
            // 
            // nombre
            // 
            this.nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombre.Location = new System.Drawing.Point(359, 44);
            this.nombre.MaxLength = 20;
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(100, 20);
            this.nombre.TabIndex = 5;
            // 
            // apellido
            // 
            this.apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.apellido.Location = new System.Drawing.Point(118, 44);
            this.apellido.MaxLength = 20;
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(100, 20);
            this.apellido.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(241, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "N° de candidato";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(281, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(11, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "N° de empleado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(50, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apellido";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 62);
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
            this.PanelSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanelSuperior.Name = "PanelSuperior";
            this.PanelSuperior.Size = new System.Drawing.Size(790, 62);
            this.PanelSuperior.TabIndex = 6;
            // 
            // menuConsultor
            // 
            this.menuConsultor.Location = new System.Drawing.Point(12, 29);
            this.menuConsultor.Name = "menuConsultor";
            this.menuConsultor.Size = new System.Drawing.Size(128, 23);
            this.menuConsultor.TabIndex = 16;
            this.menuConsultor.Text = "Volver al menú principal";
            this.menuConsultor.UseVisualStyleBackColor = true;
            this.menuConsultor.Click += new System.EventHandler(this.menuConsultor_Click);
            // 
            // Consultor
            // 
            this.Consultor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Consultor.AutoSize = true;
            this.Consultor.Location = new System.Drawing.Point(619, 39);
            this.Consultor.Name = "Consultor";
            this.Consultor.Size = new System.Drawing.Size(51, 13);
            this.Consultor.TabIndex = 4;
            this.Consultor.Text = "Consultor";
            // 
            // CerrarSesion
            // 
            this.CerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CerrarSesion.AutoSize = true;
            this.CerrarSesion.Location = new System.Drawing.Point(706, 38);
            this.CerrarSesion.Name = "CerrarSesion";
            this.CerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.CerrarSesion.TabIndex = 3;
            this.CerrarSesion.TabStop = true;
            this.CerrarSesion.Text = "Cerrar Sesión";
            this.CerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CerrarSesion_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.VerAgregados);
            this.groupBox1.Controls.Add(this.Agregar);
            this.groupBox1.Controls.Add(this.resultadosDeBusqueda);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(73, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 285);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados de la búsqueda";
            // 
            // VerAgregados
            // 
            this.VerAgregados.ForeColor = System.Drawing.SystemColors.ControlText;
            this.VerAgregados.Location = new System.Drawing.Point(473, 167);
            this.VerAgregados.Name = "VerAgregados";
            this.VerAgregados.Size = new System.Drawing.Size(87, 23);
            this.VerAgregados.TabIndex = 2;
            this.VerAgregados.Text = "Ver Agregados";
            this.VerAgregados.UseVisualStyleBackColor = true;
            this.VerAgregados.Click += new System.EventHandler(this.VerAgregados_Click);
            // 
            // Agregar
            // 
            this.Agregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Agregar.Location = new System.Drawing.Point(473, 89);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(87, 23);
            this.Agregar.TabIndex = 1;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // resultadosDeBusqueda
            // 
            this.resultadosDeBusqueda.AllowUserToAddRows = false;
            this.resultadosDeBusqueda.AllowUserToDeleteRows = false;
            this.resultadosDeBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultadosDeBusqueda.Location = new System.Drawing.Point(6, 23);
            this.resultadosDeBusqueda.Name = "resultadosDeBusqueda";
            this.resultadosDeBusqueda.ReadOnly = true;
            this.resultadosDeBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultadosDeBusqueda.Size = new System.Drawing.Size(421, 256);
            this.resultadosDeBusqueda.TabIndex = 0;
            this.resultadosDeBusqueda.Visible = false;
            // 
            // Siguiente
            // 
            this.Siguiente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Siguiente.Location = new System.Drawing.Point(548, 619);
            this.Siguiente.Name = "Siguiente";
            this.Siguiente.Size = new System.Drawing.Size(85, 23);
            this.Siguiente.TabIndex = 11;
            this.Siguiente.Text = "Siguiente >>";
            this.Siguiente.UseVisualStyleBackColor = true;
            this.Siguiente.Click += new System.EventHandler(this.Siguiente_Click);
            // 
            // Evaluar_Candidato
            // 
            this.AcceptButton = this.Buscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 750);
            this.Controls.Add(this.Siguiente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelInferior);
            this.Controls.Add(this.SeleccionDeAcceso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelSuperior);
            this.Name = "Evaluar_Candidato";
            this.Text = "Evaluar Candidato";
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.SeleccionDeAcceso.ResumeLayout(false);
            this.SeleccionDeAcceso.PerformLayout();
            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultadosDeBusqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TituloEmpresa;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.LinkLabel Fecha;
        private System.Windows.Forms.GroupBox SeleccionDeAcceso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelSuperior;
        private System.Windows.Forms.TextBox nroCandidato;
        private System.Windows.Forms.TextBox nroEmpleado;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView resultadosDeBusqueda;
        private System.Windows.Forms.Label Consultor;
        private System.Windows.Forms.LinkLabel CerrarSesion;
        private System.Windows.Forms.Button menuConsultor;
        private System.Windows.Forms.Button VerAgregados;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button Siguiente;
    }
}