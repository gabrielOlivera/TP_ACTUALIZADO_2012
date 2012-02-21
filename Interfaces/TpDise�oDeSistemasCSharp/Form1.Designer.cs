using System;
using System.Windows.Forms;

namespace VentanaGeneralTpDiseño
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Fecha = new System.Windows.Forms.LinkLabel();
            this.TituloEmpresa = new System.Windows.Forms.Label();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.PanelSuperior.SuspendLayout();
            this.PanelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fecha
            // 
            resources.ApplyResources(this.Fecha, "Fecha");
            this.Fecha.CausesValidation = false;
            this.Fecha.DisabledLinkColor = System.Drawing.Color.Black;
            this.Fecha.Name = "Fecha";
            this.Fecha.TabStop = true;
            // 
            // TituloEmpresa
            // 
            resources.ApplyResources(this.TituloEmpresa, "TituloEmpresa");
            this.TituloEmpresa.Name = "TituloEmpresa";
            // 
            // PanelSuperior
            // 
            this.PanelSuperior.BackColor = System.Drawing.Color.DarkGray;
            this.PanelSuperior.Controls.Add(this.TituloEmpresa);
            resources.ApplyResources(this.PanelSuperior, "PanelSuperior");
            this.PanelSuperior.Name = "PanelSuperior";
            // 
            // PanelInferior
            // 
            this.PanelInferior.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelInferior.Controls.Add(this.Fecha);
            resources.ApplyResources(this.PanelInferior, "PanelInferior");
            this.PanelInferior.Name = "PanelInferior";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.PanelSuperior);
            this.Controls.Add(this.PanelInferior);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LinkLabel Fecha;
        private Label TituloEmpresa;
        private Panel PanelSuperior;
        private Panel PanelInferior;
    }
}

