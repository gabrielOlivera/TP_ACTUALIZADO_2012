namespace TpDiseñoCSharp
{
    partial class LoginCandidato
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
            this.TituloEmpresa = new System.Windows.Forms.Label();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.Fecha = new System.Windows.Forms.LinkLabel();
            this.SeleccionDeAcceso = new System.Windows.Forms.GroupBox();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Entrar = new System.Windows.Forms.Button();
            this.Clave = new System.Windows.Forms.TextBox();
            this.NroDoc = new System.Windows.Forms.TextBox();
            this.Tipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PanelInferior.SuspendLayout();
            this.SeleccionDeAcceso.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // TituloEmpresa
            // 
            this.TituloEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloEmpresa.AutoSize = true;
            this.TituloEmpresa.Font = new System.Drawing.Font("Viner Hand ITC", 15.75F, System.Drawing.FontStyle.Bold);
            this.TituloEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TituloEmpresa.Location = new System.Drawing.Point(258, 18);
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
            this.PanelInferior.Location = new System.Drawing.Point(0, 429);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(698, 58);
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
            this.Fecha.Location = new System.Drawing.Point(536, 24);
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
            this.SeleccionDeAcceso.Controls.Add(this.Cancelar);
            this.SeleccionDeAcceso.Controls.Add(this.Entrar);
            this.SeleccionDeAcceso.Controls.Add(this.Clave);
            this.SeleccionDeAcceso.Controls.Add(this.NroDoc);
            this.SeleccionDeAcceso.Controls.Add(this.Tipo);
            this.SeleccionDeAcceso.Controls.Add(this.label3);
            this.SeleccionDeAcceso.Controls.Add(this.label2);
            this.SeleccionDeAcceso.Controls.Add(this.label1);
            this.SeleccionDeAcceso.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SeleccionDeAcceso.Location = new System.Drawing.Point(137, 107);
            this.SeleccionDeAcceso.Name = "SeleccionDeAcceso";
            this.SeleccionDeAcceso.Size = new System.Drawing.Size(402, 268);
            this.SeleccionDeAcceso.TabIndex = 9;
            this.SeleccionDeAcceso.TabStop = false;
            this.SeleccionDeAcceso.Text = "Login Candidato";
            // 
            // Cancelar
            // 
            this.Cancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Cancelar.Location = new System.Drawing.Point(248, 184);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 7;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Entrar
            // 
            this.Entrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Entrar.Location = new System.Drawing.Point(114, 184);
            this.Entrar.Name = "Entrar";
            this.Entrar.Size = new System.Drawing.Size(75, 23);
            this.Entrar.TabIndex = 6;
            this.Entrar.Text = "Entrar";
            this.Entrar.UseVisualStyleBackColor = true;
            this.Entrar.Click += new System.EventHandler(this.Entrar_Click);
            // 
            // Clave
            // 
            this.Clave.Location = new System.Drawing.Point(105, 131);
            this.Clave.MaxLength = 20;
            this.Clave.Name = "Clave";
            this.Clave.PasswordChar = '*';
            this.Clave.Size = new System.Drawing.Size(216, 20);
            this.Clave.TabIndex = 5;
            // 
            // NroDoc
            // 
            this.NroDoc.Location = new System.Drawing.Point(248, 47);
            this.NroDoc.MaxLength = 10;
            this.NroDoc.Name = "NroDoc";
            this.NroDoc.Size = new System.Drawing.Size(126, 20);
            this.NroDoc.TabIndex = 4;
            // 
            // Tipo
            // 
            this.Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tipo.FormattingEnabled = true;
            this.Tipo.Items.AddRange(new object[] {
            "DNI",
            "LE",
            "LC",
            "PP"});
            this.Tipo.Location = new System.Drawing.Point(84, 50);
            this.Tipo.MaxDropDownItems = 4;
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(57, 21);
            this.Tipo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(52, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(165, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "N° Documento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(49, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 22);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(698, 22);
            this.panel3.TabIndex = 7;
            // 
            // PanelSuperior
            // 
            this.PanelSuperior.BackColor = System.Drawing.Color.DarkGray;
            this.PanelSuperior.Controls.Add(this.TituloEmpresa);
            this.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSuperior.Enabled = false;
            this.PanelSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanelSuperior.Name = "PanelSuperior";
            this.PanelSuperior.Size = new System.Drawing.Size(698, 62);
            this.PanelSuperior.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Location = new System.Drawing.Point(0, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(41, 22);
            this.panel2.TabIndex = 3;
            // 
            // LoginCandidato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(698, 487);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelInferior);
            this.Controls.Add(this.SeleccionDeAcceso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelSuperior);
            this.Name = "LoginCandidato";
            this.Text = "LoginCandidato";
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.SeleccionDeAcceso.ResumeLayout(false);
            this.SeleccionDeAcceso.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TituloEmpresa;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.LinkLabel Fecha;
        private System.Windows.Forms.GroupBox SeleccionDeAcceso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelSuperior;
        private System.Windows.Forms.ComboBox Tipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Clave;
        private System.Windows.Forms.TextBox NroDoc;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Entrar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;

    }
}