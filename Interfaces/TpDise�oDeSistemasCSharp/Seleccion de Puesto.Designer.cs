namespace TpDiseñoCSharp
{
    partial class Seleccion_de_Puesto
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
            this.Aceptar = new System.Windows.Forms.Button();
            this.paraSeleccion = new System.Windows.Forms.Panel();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.labelNombreDelPuesto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Aceptar
            // 
            this.Aceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Aceptar.Location = new System.Drawing.Point(411, 241);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 0;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // paraSeleccion
            // 
            this.paraSeleccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.paraSeleccion.AutoScroll = true;
            this.paraSeleccion.Location = new System.Drawing.Point(24, 45);
            this.paraSeleccion.Name = "paraSeleccion";
            this.paraSeleccion.Size = new System.Drawing.Size(422, 174);
            this.paraSeleccion.TabIndex = 1;
            // 
            // labelCodigo
            // 
            this.labelCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(55, 26);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(49, 13);
            this.labelCodigo.TabIndex = 2;
            this.labelCodigo.Text = "CODIGO";
            // 
            // labelNombreDelPuesto
            // 
            this.labelNombreDelPuesto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNombreDelPuesto.AutoSize = true;
            this.labelNombreDelPuesto.Location = new System.Drawing.Point(207, 26);
            this.labelNombreDelPuesto.Name = "labelNombreDelPuesto";
            this.labelNombreDelPuesto.Size = new System.Drawing.Size(125, 13);
            this.labelNombreDelPuesto.TabIndex = 3;
            this.labelNombreDelPuesto.Text = "NOMBRE DEL PUESTO";
            // 
            // Seleccion_de_Puesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 291);
            this.Controls.Add(this.labelNombreDelPuesto);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.paraSeleccion);
            this.Controls.Add(this.Aceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Seleccion_de_Puesto";
            this.Text = "Seleccion de Puesto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Panel paraSeleccion;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Label labelNombreDelPuesto;
    }
}