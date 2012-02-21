namespace TpDiseñoCSharp
{
    partial class Lista_de_Candidatos
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
            this.Fecha = new System.Windows.Forms.LinkLabel();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.SeleccionDeAcceso = new System.Windows.Forms.GroupBox();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Quitar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PanelInferior.SuspendLayout();
            this.SeleccionDeAcceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Fecha
            // 
            this.Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Fecha.AutoSize = true;
            this.Fecha.CausesValidation = false;
            this.Fecha.DisabledLinkColor = System.Drawing.Color.Black;
            this.Fecha.Enabled = false;
            this.Fecha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Fecha.Location = new System.Drawing.Point(399, 24);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(151, 13);
            this.Fecha.TabIndex = 0;
            this.Fecha.TabStop = true;
            this.Fecha.Text = "Thursday, November 24, 2011";
            this.Fecha.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // PanelInferior
            // 
            this.PanelInferior.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelInferior.Controls.Add(this.Fecha);
            this.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferior.Location = new System.Drawing.Point(0, 384);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(561, 58);
            this.PanelInferior.TabIndex = 11;
            // 
            // SeleccionDeAcceso
            // 
            this.SeleccionDeAcceso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SeleccionDeAcceso.Controls.Add(this.Cancelar);
            this.SeleccionDeAcceso.Controls.Add(this.Quitar);
            this.SeleccionDeAcceso.Controls.Add(this.dataGridView1);
            this.SeleccionDeAcceso.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SeleccionDeAcceso.Location = new System.Drawing.Point(54, 12);
            this.SeleccionDeAcceso.Name = "SeleccionDeAcceso";
            this.SeleccionDeAcceso.Size = new System.Drawing.Size(469, 357);
            this.SeleccionDeAcceso.TabIndex = 12;
            this.SeleccionDeAcceso.TabStop = false;
            this.SeleccionDeAcceso.Text = "Si desea quitar un candidato seleccione una fila y presione el botón quitar";
            // 
            // Cancelar
            // 
            this.Cancelar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Cancelar.Location = new System.Drawing.Point(251, 321);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 4;
            this.Cancelar.Text = "Deshacer";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click_1);
            // 
            // Quitar
            // 
            this.Quitar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Quitar.Location = new System.Drawing.Point(153, 321);
            this.Quitar.Name = "Quitar";
            this.Quitar.Size = new System.Drawing.Size(75, 23);
            this.Quitar.TabIndex = 3;
            this.Quitar.Text = "Quitar";
            this.Quitar.UseVisualStyleBackColor = true;
            this.Quitar.Click += new System.EventHandler(this.Quitar_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(463, 289);
            this.dataGridView1.TabIndex = 0;
            // 
            // Lista_de_Candidatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 442);
            this.Controls.Add(this.SeleccionDeAcceso);
            this.Controls.Add(this.PanelInferior);
            this.Name = "Lista_de_Candidatos";
            this.Text = "Lista de Candidatos";
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.SeleccionDeAcceso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel Fecha;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.GroupBox SeleccionDeAcceso;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Quitar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}