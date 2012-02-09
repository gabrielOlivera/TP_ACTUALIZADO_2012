namespace TpDiseñoCSharp
{
    partial class Emitir_Orden_de_Mérito
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.Fecha = new System.Windows.Forms.LinkLabel();
            this.TituloEmpresa = new System.Windows.Forms.Label();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.Consultor = new System.Windows.Forms.Label();
            this.CerrarSesion = new System.Windows.Forms.LinkLabel();
            this.SeleccionDeAcceso = new System.Windows.Forms.GroupBox();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Buscar = new System.Windows.Forms.Button();
            this.Empresa = new System.Windows.Forms.TextBox();
            this.NombreDePuesto = new System.Windows.Forms.TextBox();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ResultadosDeBusqueda = new System.Windows.Forms.DataGridView();
            this.EmitirOrdenDeMerito = new System.Windows.Forms.Button();
            this.PanelInferior.SuspendLayout();
            this.PanelSuperior.SuspendLayout();
            this.SeleccionDeAcceso.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultadosDeBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 669);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(29, 36);
            this.panel2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 22);
            this.panel1.TabIndex = 6;
            // 
            // PanelInferior
            // 
            this.PanelInferior.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelInferior.Controls.Add(this.Fecha);
            this.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferior.Location = new System.Drawing.Point(0, 710);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(714, 58);
            this.PanelInferior.TabIndex = 4;
            // 
            // Fecha
            // 
            this.Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Fecha.AutoSize = true;
            this.Fecha.CausesValidation = false;
            this.Fecha.DisabledLinkColor = System.Drawing.Color.Black;
            this.Fecha.Enabled = false;
            this.Fecha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Fecha.Location = new System.Drawing.Point(552, 24);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(151, 13);
            this.Fecha.TabIndex = 0;
            this.Fecha.TabStop = true;
            this.Fecha.Text = "Thursday, November 24, 2011";
            this.Fecha.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TituloEmpresa
            // 
            this.TituloEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloEmpresa.AutoSize = true;
            this.TituloEmpresa.Font = new System.Drawing.Font("Viner Hand ITC", 15.75F, System.Drawing.FontStyle.Bold);
            this.TituloEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TituloEmpresa.Location = new System.Drawing.Point(265, 18);
            this.TituloEmpresa.Name = "TituloEmpresa";
            this.TituloEmpresa.Size = new System.Drawing.Size(157, 34);
            this.TituloEmpresa.TabIndex = 0;
            this.TituloEmpresa.Text = "Human TIC\'s";
            // 
            // PanelSuperior
            // 
            this.PanelSuperior.BackColor = System.Drawing.Color.DarkGray;
            this.PanelSuperior.Controls.Add(this.Consultor);
            this.PanelSuperior.Controls.Add(this.CerrarSesion);
            this.PanelSuperior.Controls.Add(this.TituloEmpresa);
            this.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSuperior.Enabled = false;
            this.PanelSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanelSuperior.Name = "PanelSuperior";
            this.PanelSuperior.Size = new System.Drawing.Size(714, 62);
            this.PanelSuperior.TabIndex = 5;
            // 
            // Consultor
            // 
            this.Consultor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Consultor.AutoSize = true;
            this.Consultor.Location = new System.Drawing.Point(552, 39);
            this.Consultor.Name = "Consultor";
            this.Consultor.Size = new System.Drawing.Size(51, 13);
            this.Consultor.TabIndex = 12;
            this.Consultor.Text = "Consultor";
            // 
            // CerrarSesion
            // 
            this.CerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CerrarSesion.AutoSize = true;
            this.CerrarSesion.Location = new System.Drawing.Point(639, 38);
            this.CerrarSesion.Name = "CerrarSesion";
            this.CerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.CerrarSesion.TabIndex = 11;
            this.CerrarSesion.TabStop = true;
            this.CerrarSesion.Text = "Cerrar Sesión";
            // 
            // SeleccionDeAcceso
            // 
            this.SeleccionDeAcceso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeleccionDeAcceso.Controls.Add(this.Cancelar);
            this.SeleccionDeAcceso.Controls.Add(this.Buscar);
            this.SeleccionDeAcceso.Controls.Add(this.Empresa);
            this.SeleccionDeAcceso.Controls.Add(this.NombreDePuesto);
            this.SeleccionDeAcceso.Controls.Add(this.Codigo);
            this.SeleccionDeAcceso.Controls.Add(this.label3);
            this.SeleccionDeAcceso.Controls.Add(this.label2);
            this.SeleccionDeAcceso.Controls.Add(this.label1);
            this.SeleccionDeAcceso.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SeleccionDeAcceso.Location = new System.Drawing.Point(157, 90);
            this.SeleccionDeAcceso.Name = "SeleccionDeAcceso";
            this.SeleccionDeAcceso.Size = new System.Drawing.Size(421, 400);
            this.SeleccionDeAcceso.TabIndex = 8;
            this.SeleccionDeAcceso.TabStop = false;
            this.SeleccionDeAcceso.Text = "Ingrese los datos para realizar su búsqueda";
            // 
            // Cancelar
            // 
            this.Cancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Cancelar.Location = new System.Drawing.Point(254, 191);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 7;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Buscar
            // 
            this.Buscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Buscar.Location = new System.Drawing.Point(115, 191);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 6;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // Empresa
            // 
            this.Empresa.Location = new System.Drawing.Point(179, 133);
            this.Empresa.Name = "Empresa";
            this.Empresa.Size = new System.Drawing.Size(100, 20);
            this.Empresa.TabIndex = 5;
            // 
            // NombreDePuesto
            // 
            this.NombreDePuesto.Location = new System.Drawing.Point(179, 86);
            this.NombreDePuesto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NombreDePuesto.Name = "NombreDePuesto";
            this.NombreDePuesto.Size = new System.Drawing.Size(100, 20);
            this.NombreDePuesto.TabIndex = 9;
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(179, 37);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(100, 20);
            this.Codigo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(58, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Empresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(58, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre de Puesto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(55, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ResultadosDeBusqueda);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(157, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 275);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resúltados de la búsqueda";
            // 
            // ResultadosDeBusqueda
            // 
            this.ResultadosDeBusqueda.AllowUserToAddRows = false;
            this.ResultadosDeBusqueda.AllowUserToDeleteRows = false;
            this.ResultadosDeBusqueda.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ResultadosDeBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultadosDeBusqueda.Location = new System.Drawing.Point(17, 29);
            this.ResultadosDeBusqueda.MultiSelect = false;
            this.ResultadosDeBusqueda.Name = "ResultadosDeBusqueda";
            this.ResultadosDeBusqueda.ReadOnly = true;
            this.ResultadosDeBusqueda.RowTemplate.Height = 24;
            this.ResultadosDeBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultadosDeBusqueda.Size = new System.Drawing.Size(390, 232);
            this.ResultadosDeBusqueda.TabIndex = 0;
            this.ResultadosDeBusqueda.Visible = false;
            // 
            // EmitirOrdenDeMerito
            // 
            this.EmitirOrdenDeMerito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmitirOrdenDeMerito.Location = new System.Drawing.Point(315, 618);
            this.EmitirOrdenDeMerito.Name = "EmitirOrdenDeMerito";
            this.EmitirOrdenDeMerito.Size = new System.Drawing.Size(107, 52);
            this.EmitirOrdenDeMerito.TabIndex = 10;
            this.EmitirOrdenDeMerito.Text = "Emitir orden de mérito";
            this.EmitirOrdenDeMerito.UseVisualStyleBackColor = true;
            this.EmitirOrdenDeMerito.Click += new System.EventHandler(this.EmitirOrdenDeMerito_Click);
            // 
            // Emitir_Orden_de_Mérito
            // 
            this.AcceptButton = this.Buscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(714, 768);
            this.Controls.Add(this.EmitirOrdenDeMerito);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SeleccionDeAcceso);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelInferior);
            this.Controls.Add(this.PanelSuperior);
            this.Name = "Emitir_Orden_de_Mérito";
            this.Text = "Emitir Orden de Mérito";
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            this.SeleccionDeAcceso.ResumeLayout(false);
            this.SeleccionDeAcceso.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultadosDeBusqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.LinkLabel Fecha;
        private System.Windows.Forms.Label TituloEmpresa;
        private System.Windows.Forms.Panel PanelSuperior;
        private System.Windows.Forms.GroupBox SeleccionDeAcceso;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.TextBox Empresa;
        private System.Windows.Forms.TextBox NombreDePuesto;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ResultadosDeBusqueda;
        private System.Windows.Forms.Button EmitirOrdenDeMerito;
        private System.Windows.Forms.Label Consultor;
        private System.Windows.Forms.LinkLabel CerrarSesion;
    }
}