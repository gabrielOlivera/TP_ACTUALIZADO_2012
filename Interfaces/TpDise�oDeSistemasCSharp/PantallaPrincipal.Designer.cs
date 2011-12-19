using System;
using System.Windows.Forms;

namespace TpDiseñoCSharp
{
    partial class PantallaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaPrincipal));
            this.Fecha = new System.Windows.Forms.LinkLabel();
            this.TituloEmpresa = new System.Windows.Forms.Label();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SeleccionDeAcceso = new System.Windows.Forms.GroupBox();
            this.LoginCandidato = new System.Windows.Forms.Button();
            this.LoginConsultor = new System.Windows.Forms.Button();
            this.PanelSuperior.SuspendLayout();
            this.PanelInferior.SuspendLayout();
            this.SeleccionDeAcceso.SuspendLayout();
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
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
  
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
 
            // 
            // SeleccionDeAcceso
            // 
            resources.ApplyResources(this.SeleccionDeAcceso, "SeleccionDeAcceso");
            this.SeleccionDeAcceso.Controls.Add(this.LoginCandidato);
            this.SeleccionDeAcceso.Controls.Add(this.LoginConsultor);
            this.SeleccionDeAcceso.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SeleccionDeAcceso.Name = "SeleccionDeAcceso";
            this.SeleccionDeAcceso.TabStop = false;

            // 
            // LoginCandidato
            // 
            this.LoginCandidato.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.LoginCandidato, "LoginCandidato");
            this.LoginCandidato.Name = "LoginCandidato";
            this.LoginCandidato.UseVisualStyleBackColor = true;
            this.LoginCandidato.Click += new System.EventHandler(this.LoginCandidato_Click);
            // 
            // LoginConsultor
            // 
            this.LoginConsultor.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.LoginConsultor, "LoginConsultor");
            this.LoginConsultor.Name = "LoginConsultor";
            this.LoginConsultor.UseVisualStyleBackColor = true;
            this.LoginConsultor.Click += new System.EventHandler(this.LoginConsultor_Click);
            // 
            // PantallaPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.SeleccionDeAcceso);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelInferior);
            this.Controls.Add(this.PanelSuperior);
            this.Name = "PantallaPrincipal";

            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.SeleccionDeAcceso.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LinkLabel Fecha;
        private Label TituloEmpresa;
        private Panel PanelSuperior;
        private Panel PanelInferior;
        private Panel panel1;
        private Panel panel2;
        private GroupBox SeleccionDeAcceso;
        private Button LoginCandidato;
        private Button LoginConsultor;
    }

}

