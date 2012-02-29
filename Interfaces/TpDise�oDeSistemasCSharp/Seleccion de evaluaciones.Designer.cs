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
            this.todos = new System.Windows.Forms.Button();
            this.ninguno = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.selecciondatagridW = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.selecciondatagridW)).BeginInit();
            this.SuspendLayout();
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
            this.aceptar.Location = new System.Drawing.Point(993, 460);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(113, 62);
            this.aceptar.TabIndex = 3;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // selecciondatagridW
            // 
            this.selecciondatagridW.AllowUserToAddRows = false;
            this.selecciondatagridW.AllowUserToDeleteRows = false;
            this.selecciondatagridW.AllowUserToOrderColumns = true;
            this.selecciondatagridW.AllowUserToResizeColumns = false;
            this.selecciondatagridW.AllowUserToResizeRows = false;
            this.selecciondatagridW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.selecciondatagridW.BackgroundColor = System.Drawing.SystemColors.Control;
            this.selecciondatagridW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selecciondatagridW.Location = new System.Drawing.Point(21, 21);
            this.selecciondatagridW.Name = "selecciondatagridW";
            this.selecciondatagridW.ReadOnly = true;
            this.selecciondatagridW.RowTemplate.Height = 24;
            this.selecciondatagridW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.selecciondatagridW.Size = new System.Drawing.Size(685, 601);
            this.selecciondatagridW.TabIndex = 4;
            // 
            // Seleccion_de_evaluaciones
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1291, 646);
            this.Controls.Add(this.selecciondatagridW);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.ninguno);
            this.Controls.Add(this.todos);
            this.Name = "Seleccion_de_evaluaciones";
            this.Text = "Elija las evaluaciones para las que desea emitir un Reporte de Meritos";
            this.Load += new System.EventHandler(this.Seleccion_de_evaluaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selecciondatagridW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button todos;
        private System.Windows.Forms.Button ninguno;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.DataGridView selecciondatagridW;

    }
}