namespace TpDiseñoCSharp
{
    partial class Seleccion_de_evaluaciones
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
            this.panel_evaluaciones = new System.Windows.Forms.Panel();
            this.todos = new System.Windows.Forms.Button();
            this.ninguno = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.puesto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel_evaluaciones
            // 
            this.panel_evaluaciones.AutoSize = true;
            this.panel_evaluaciones.Location = new System.Drawing.Point(12, 38);
            this.panel_evaluaciones.Name = "panel_evaluaciones";
            this.panel_evaluaciones.Size = new System.Drawing.Size(975, 509);
            this.panel_evaluaciones.TabIndex = 0;
            // 
            // todos
            // 
            this.todos.Location = new System.Drawing.Point(993, 42);
            this.todos.Name = "todos";
            this.todos.Size = new System.Drawing.Size(75, 26);
            this.todos.TabIndex = 1;
            this.todos.Text = "Todos";
            this.todos.UseVisualStyleBackColor = true;
            this.todos.Click += new System.EventHandler(this.todos_Click);
            // 
            // ninguno
            // 
            this.ninguno.Location = new System.Drawing.Point(993, 88);
            this.ninguno.Name = "ninguno";
            this.ninguno.Size = new System.Drawing.Size(75, 27);
            this.ninguno.TabIndex = 2;
            this.ninguno.Text = "Ninguno";
            this.ninguno.UseVisualStyleBackColor = true;
            this.ninguno.Click += new System.EventHandler(this.ninguno_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(993, 453);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(113, 62);
            this.aceptar.TabIndex = 3;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            // 
            // puesto
            // 
            this.puesto.AutoSize = true;
            this.puesto.Location = new System.Drawing.Point(39, 9);
            this.puesto.Name = "puesto";
            this.puesto.Size = new System.Drawing.Size(65, 17);
            this.puesto.TabIndex = 4;
            this.puesto.Text = "PUESTO";
            // 
            // Seleccion_de_evaluaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1291, 646);
            this.Controls.Add(this.puesto);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.ninguno);
            this.Controls.Add(this.todos);
            this.Controls.Add(this.panel_evaluaciones);
            this.Name = "Seleccion_de_evaluaciones";
            this.Text = "Elija las evaluaciones para las que desea emitir un Reporte de Meritos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_evaluaciones;
        private System.Windows.Forms.Button todos;
        private System.Windows.Forms.Button ninguno;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label puesto;

    }
}