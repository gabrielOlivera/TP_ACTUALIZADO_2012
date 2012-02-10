namespace TpDiseñoCSharp
{
    partial class Orden_de_merito
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
            this.completosCON_minimos_dgv = new System.Windows.Forms.DataGridView();
            this.sin_completar_dgv = new System.Windows.Forms.DataGridView();
            this.incompletos_dgv = new System.Windows.Forms.DataGridView();
            this.completosSIN_minimos_dgv = new System.Windows.Forms.DataGridView();
            this.completosCON = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.completosCON_minimos_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sin_completar_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incompletos_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.completosSIN_minimos_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // completosCON_minimos_dgv
            // 
            this.completosCON_minimos_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.completosCON_minimos_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.completosCON_minimos_dgv.Location = new System.Drawing.Point(22, 53);
            this.completosCON_minimos_dgv.Name = "completosCON_minimos_dgv";
            this.completosCON_minimos_dgv.Size = new System.Drawing.Size(738, 238);
            this.completosCON_minimos_dgv.TabIndex = 0;
            // 
            // sin_completar_dgv
            // 
            this.sin_completar_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sin_completar_dgv.Location = new System.Drawing.Point(766, 341);
            this.sin_completar_dgv.Name = "sin_completar_dgv";
            this.sin_completar_dgv.Size = new System.Drawing.Size(421, 238);
            this.sin_completar_dgv.TabIndex = 1;
            // 
            // incompletos_dgv
            // 
            this.incompletos_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incompletos_dgv.Location = new System.Drawing.Point(766, 53);
            this.incompletos_dgv.Name = "incompletos_dgv";
            this.incompletos_dgv.Size = new System.Drawing.Size(421, 238);
            this.incompletos_dgv.TabIndex = 2;
            // 
            // completosSIN_minimos_dgv
            // 
            this.completosSIN_minimos_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.completosSIN_minimos_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.completosSIN_minimos_dgv.Location = new System.Drawing.Point(22, 341);
            this.completosSIN_minimos_dgv.Name = "completosSIN_minimos_dgv";
            this.completosSIN_minimos_dgv.Size = new System.Drawing.Size(738, 238);
            this.completosSIN_minimos_dgv.TabIndex = 3;
            // 
            // completosCON
            // 
            this.completosCON.AutoSize = true;
            this.completosCON.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.completosCON.Location = new System.Drawing.Point(25, 24);
            this.completosCON.Name = "completosCON";
            this.completosCON.Size = new System.Drawing.Size(623, 17);
            this.completosCON.TabIndex = 4;
            this.completosCON.Text = "Candidatos que completaron el cuestionario y cumplieron con los minimos exigidos " +
    "para el puesto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(25, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(674, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Candidatos que completaron el cuestionario, pero NO cumplieron con los minimos ex" +
    "igidos para el puesto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(763, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Candidatos que no finalizaron su cuestionario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(763, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Candidatos que nunca accedieron a su cuestionario";
            // 
            // Orden_de_merito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 630);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.completosCON);
            this.Controls.Add(this.completosSIN_minimos_dgv);
            this.Controls.Add(this.incompletos_dgv);
            this.Controls.Add(this.sin_completar_dgv);
            this.Controls.Add(this.completosCON_minimos_dgv);
            this.Name = "Orden_de_merito";
            this.Text = "Orden_de_merito";
            ((System.ComponentModel.ISupportInitialize)(this.completosCON_minimos_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sin_completar_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incompletos_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.completosSIN_minimos_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView completosCON_minimos_dgv;
        private System.Windows.Forms.DataGridView sin_completar_dgv;
        private System.Windows.Forms.DataGridView incompletos_dgv;
        private System.Windows.Forms.DataGridView completosSIN_minimos_dgv;
        private System.Windows.Forms.Label completosCON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}