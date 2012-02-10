namespace TpDiseñoCSharp
{
    partial class Evaluar_Candidatos___Ventana_3
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
            this.Consultor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.Fecha = new System.Windows.Forms.LinkLabel();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.menuConsultor = new System.Windows.Forms.Button();
            this.CerrarSesion = new System.Windows.Forms.LinkLabel();
            this.TituloEmpresa = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.candidatos_claves = new System.Windows.Forms.DataGridView();
            this.Atras = new System.Windows.Forms.Button();
            this.Finalizar = new System.Windows.Forms.Button();
            this.PanelInferior.SuspendLayout();
            this.PanelSuperior.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candidatos_claves)).BeginInit();
            this.SuspendLayout();
            // 
            // Consultor
            // 
            this.Consultor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Consultor.AutoSize = true;
            this.Consultor.Location = new System.Drawing.Point(558, 39);
            this.Consultor.Name = "Consultor";
            this.Consultor.Size = new System.Drawing.Size(51, 13);
            this.Consultor.TabIndex = 2;
            this.Consultor.Text = "Consultor";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(25, 37);
            this.panel2.TabIndex = 16;
            // 
            // PanelInferior
            // 
            this.PanelInferior.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelInferior.Controls.Add(this.Fecha);
            this.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferior.Location = new System.Drawing.Point(0, 543);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(720, 58);
            this.PanelInferior.TabIndex = 13;
            // 
            // Fecha
            // 
            this.Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Fecha.AutoSize = true;
            this.Fecha.CausesValidation = false;
            this.Fecha.DisabledLinkColor = System.Drawing.Color.Black;
            this.Fecha.Enabled = false;
            this.Fecha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Fecha.Location = new System.Drawing.Point(558, 24);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(151, 13);
            this.Fecha.TabIndex = 0;
            this.Fecha.TabStop = true;
            this.Fecha.Text = "Thursday, November 24, 2011";
            this.Fecha.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.PanelSuperior.Size = new System.Drawing.Size(720, 62);
            this.PanelSuperior.TabIndex = 14;
            // 
            // menuConsultor
            // 
            this.menuConsultor.Location = new System.Drawing.Point(12, 34);
            this.menuConsultor.Name = "menuConsultor";
            this.menuConsultor.Size = new System.Drawing.Size(128, 23);
            this.menuConsultor.TabIndex = 20;
            this.menuConsultor.Text = "Volver al menú principal";
            this.menuConsultor.UseVisualStyleBackColor = true;
            this.menuConsultor.Click += new System.EventHandler(this.menuConsultor_Click);
            // 
            // CerrarSesion
            // 
            this.CerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CerrarSesion.AutoSize = true;
            this.CerrarSesion.Location = new System.Drawing.Point(645, 38);
            this.CerrarSesion.Name = "CerrarSesion";
            this.CerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.CerrarSesion.TabIndex = 1;
            this.CerrarSesion.TabStop = true;
            this.CerrarSesion.Text = "Cerrar Sesión";
            // 
            // TituloEmpresa
            // 
            this.TituloEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloEmpresa.AutoSize = true;
            this.TituloEmpresa.Font = new System.Drawing.Font("Viner Hand ITC", 15.75F, System.Drawing.FontStyle.Bold);
            this.TituloEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TituloEmpresa.Location = new System.Drawing.Point(269, 18);
            this.TituloEmpresa.Name = "TituloEmpresa";
            this.TituloEmpresa.Size = new System.Drawing.Size(157, 34);
            this.TituloEmpresa.TabIndex = 0;
            this.TituloEmpresa.Text = "Human TIC\'s";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 22);
            this.panel1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.candidatos_claves);
            this.groupBox1.Location = new System.Drawing.Point(100, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 323);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presione finalizar para resguardar los datos de la busqueda";
            // 
            // candidatos_claves
            // 
            this.candidatos_claves.AllowUserToAddRows = false;
            this.candidatos_claves.AllowUserToDeleteRows = false;
            this.candidatos_claves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.candidatos_claves.Location = new System.Drawing.Point(6, 30);
            this.candidatos_claves.Name = "candidatos_claves";
            this.candidatos_claves.ReadOnly = true;
            this.candidatos_claves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.candidatos_claves.Size = new System.Drawing.Size(497, 277);
            this.candidatos_claves.TabIndex = 0;
            // 
            // Atras
            // 
            this.Atras.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Atras.Location = new System.Drawing.Point(236, 458);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(75, 23);
            this.Atras.TabIndex = 18;
            this.Atras.Text = "<< Atrás";
            this.Atras.UseVisualStyleBackColor = true;
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            // 
            // Finalizar
            // 
            this.Finalizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Finalizar.Location = new System.Drawing.Point(385, 458);
            this.Finalizar.Name = "Finalizar";
            this.Finalizar.Size = new System.Drawing.Size(75, 23);
            this.Finalizar.TabIndex = 19;
            this.Finalizar.Text = "Finalizar";
            this.Finalizar.UseVisualStyleBackColor = true;
            this.Finalizar.Click += new System.EventHandler(this.Finalizar_Click);
            // 
            // Evaluar_Candidatos___Ventana_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(720, 601);
            this.Controls.Add(this.Finalizar);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelInferior);
            this.Controls.Add(this.PanelSuperior);
            this.Controls.Add(this.panel1);
            this.Name = "Evaluar_Candidatos___Ventana_3";
            this.Text = "Evaluar Candidatos";
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.candidatos_claves)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Consultor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.LinkLabel Fecha;
        private System.Windows.Forms.Panel PanelSuperior;
        private System.Windows.Forms.LinkLabel CerrarSesion;
        private System.Windows.Forms.Label TituloEmpresa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView candidatos_claves;
        private System.Windows.Forms.Button Atras;
        private System.Windows.Forms.Button Finalizar;
        private System.Windows.Forms.Button menuConsultor;
    }
}