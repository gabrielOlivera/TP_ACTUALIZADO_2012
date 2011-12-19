namespace TpDiseñoCSharp
{
    partial class Gestionar_Puestos
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
            this.TituloEmpresa = new System.Windows.Forms.Label();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.Fecha = new System.Windows.Forms.LinkLabel();
            this.SeleccionDeAcceso = new System.Windows.Forms.GroupBox();
            this.Nuevo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.menuConsultor = new System.Windows.Forms.Button();
            this.Consultor = new System.Windows.Forms.Label();
            this.CerrarSesion = new System.Windows.Forms.LinkLabel();
            this.DatosParaBusqueda = new System.Windows.Forms.GroupBox();
            this.BuscarPuestos = new System.Windows.Forms.Button();
            this.Empresa = new System.Windows.Forms.TextBox();
            this.NombreDePuesto = new System.Windows.Forms.TextBox();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Modificar = new System.Windows.Forms.Button();
            this.listaDePuesto = new System.Windows.Forms.DataGridView();
            this.PanelInferior.SuspendLayout();
            this.SeleccionDeAcceso.SuspendLayout();
            this.PanelSuperior.SuspendLayout();
            this.DatosParaBusqueda.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaDePuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 757);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 37);
            this.panel2.TabIndex = 8;
            // 
            // TituloEmpresa
            // 
            this.TituloEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloEmpresa.AutoSize = true;
            this.TituloEmpresa.Font = new System.Drawing.Font("Viner Hand ITC", 15.75F, System.Drawing.FontStyle.Bold);
            this.TituloEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TituloEmpresa.Location = new System.Drawing.Point(306, 18);
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
            this.PanelInferior.Location = new System.Drawing.Point(0, 800);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(795, 58);
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
            this.Fecha.Location = new System.Drawing.Point(633, 24);
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
            this.SeleccionDeAcceso.Controls.Add(this.Nuevo);
            this.SeleccionDeAcceso.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SeleccionDeAcceso.Location = new System.Drawing.Point(131, 90);
            this.SeleccionDeAcceso.Name = "SeleccionDeAcceso";
            this.SeleccionDeAcceso.Size = new System.Drawing.Size(430, 56);
            this.SeleccionDeAcceso.TabIndex = 9;
            this.SeleccionDeAcceso.TabStop = false;
            this.SeleccionDeAcceso.Text = "Crear nuevo puesto o función";
            // 
            // Nuevo
            // 
            this.Nuevo.Location = new System.Drawing.Point(233, 20);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(75, 23);
            this.Nuevo.TabIndex = 0;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = true;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 22);
            this.panel1.TabIndex = 7;
            // 
            // PanelSuperior
            // 
            this.PanelSuperior.BackColor = System.Drawing.Color.DarkGray;
            this.PanelSuperior.Controls.Add(this.menuConsultor);
            this.PanelSuperior.Controls.Add(this.Consultor);
            this.PanelSuperior.Controls.Add(this.CerrarSesion);
            this.PanelSuperior.Controls.Add(this.TituloEmpresa);
            this.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSuperior.Enabled = false;
            this.PanelSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanelSuperior.Name = "PanelSuperior";
            this.PanelSuperior.Size = new System.Drawing.Size(795, 62);
            this.PanelSuperior.TabIndex = 6;
            // 
            // menuConsultor
            // 
            this.menuConsultor.Location = new System.Drawing.Point(13, 28);
            this.menuConsultor.Name = "menuConsultor";
            this.menuConsultor.Size = new System.Drawing.Size(128, 23);
            this.menuConsultor.TabIndex = 13;
            this.menuConsultor.Text = "Volver al menú principal";
            this.menuConsultor.UseVisualStyleBackColor = true;
            // 
            // Consultor
            // 
            this.Consultor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Consultor.AutoSize = true;
            this.Consultor.Location = new System.Drawing.Point(633, 39);
            this.Consultor.Name = "Consultor";
            this.Consultor.Size = new System.Drawing.Size(51, 13);
            this.Consultor.TabIndex = 12;
            this.Consultor.Text = "Consultor";
            // 
            // CerrarSesion
            // 
            this.CerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CerrarSesion.AutoSize = true;
            this.CerrarSesion.Location = new System.Drawing.Point(722, 39);
            this.CerrarSesion.Name = "CerrarSesion";
            this.CerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.CerrarSesion.TabIndex = 2;
            this.CerrarSesion.TabStop = true;
            this.CerrarSesion.Text = "Cerrar Sesión";
            // 
            // DatosParaBusqueda
            // 
            this.DatosParaBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DatosParaBusqueda.Controls.Add(this.BuscarPuestos);
            this.DatosParaBusqueda.Controls.Add(this.Empresa);
            this.DatosParaBusqueda.Controls.Add(this.NombreDePuesto);
            this.DatosParaBusqueda.Controls.Add(this.Codigo);
            this.DatosParaBusqueda.Controls.Add(this.label3);
            this.DatosParaBusqueda.Controls.Add(this.label2);
            this.DatosParaBusqueda.Controls.Add(this.label1);
            this.DatosParaBusqueda.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.DatosParaBusqueda.Location = new System.Drawing.Point(131, 162);
            this.DatosParaBusqueda.Name = "DatosParaBusqueda";
            this.DatosParaBusqueda.Size = new System.Drawing.Size(430, 206);
            this.DatosParaBusqueda.TabIndex = 10;
            this.DatosParaBusqueda.TabStop = false;
            this.DatosParaBusqueda.Text = "Ingrese los datos para realizar una búsqueda";
            // 
            // BuscarPuestos
            // 
            this.BuscarPuestos.Location = new System.Drawing.Point(261, 166);
            this.BuscarPuestos.Name = "BuscarPuestos";
            this.BuscarPuestos.Size = new System.Drawing.Size(75, 23);
            this.BuscarPuestos.TabIndex = 6;
            this.BuscarPuestos.Text = "Buscar";
            this.BuscarPuestos.UseVisualStyleBackColor = true;
            this.BuscarPuestos.Click += new System.EventHandler(this.BuscarPuesots_Click);
            // 
            // Empresa
            // 
            this.Empresa.Location = new System.Drawing.Point(223, 120);
            this.Empresa.MaxLength = 20;
            this.Empresa.Name = "Empresa";
            this.Empresa.Size = new System.Drawing.Size(143, 20);
            this.Empresa.TabIndex = 5;
            // 
            // NombreDePuesto
            // 
            this.NombreDePuesto.Location = new System.Drawing.Point(223, 75);
            this.NombreDePuesto.MaxLength = 20;
            this.NombreDePuesto.Name = "NombreDePuesto";
            this.NombreDePuesto.Size = new System.Drawing.Size(143, 20);
            this.NombreDePuesto.TabIndex = 4;
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(223, 34);
            this.Codigo.MaxLength = 20;
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(143, 20);
            this.Codigo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Empresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre de Puesto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Eliminar);
            this.groupBox1.Controls.Add(this.Modificar);
            this.groupBox1.Controls.Add(this.listaDePuesto);
            this.groupBox1.Location = new System.Drawing.Point(133, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 359);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados de la búsqueda";
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(444, 222);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(75, 23);
            this.Eliminar.TabIndex = 2;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Modificar
            // 
            this.Modificar.Location = new System.Drawing.Point(444, 148);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(75, 23);
            this.Modificar.TabIndex = 1;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = true;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // listaDePuesto
            // 
            this.listaDePuesto.AllowUserToAddRows = false;
            this.listaDePuesto.AllowUserToDeleteRows = false;
            this.listaDePuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaDePuesto.Location = new System.Drawing.Point(83, 41);
            this.listaDePuesto.Name = "listaDePuesto";
            this.listaDePuesto.ReadOnly = true;
            this.listaDePuesto.Size = new System.Drawing.Size(320, 294);
            this.listaDePuesto.TabIndex = 0;
            this.listaDePuesto.Visible = false;
            // 
            // Gestionar_Puestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(795, 858);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DatosParaBusqueda);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelInferior);
            this.Controls.Add(this.SeleccionDeAcceso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelSuperior);
            this.Name = "Gestionar_Puestos";
            this.Text = "Gestionar Puestos o Funciones";
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.SeleccionDeAcceso.ResumeLayout(false);
            this.PanelSuperior.ResumeLayout(false);
            this.PanelSuperior.PerformLayout();
            this.DatosParaBusqueda.ResumeLayout(false);
            this.DatosParaBusqueda.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaDePuesto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TituloEmpresa;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.LinkLabel Fecha;
        private System.Windows.Forms.GroupBox SeleccionDeAcceso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelSuperior;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.GroupBox DatosParaBusqueda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Empresa;
        private System.Windows.Forms.TextBox NombreDePuesto;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Button BuscarPuestos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView listaDePuesto;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.LinkLabel CerrarSesion;
        private System.Windows.Forms.Label Consultor;
        private System.Windows.Forms.Button menuConsultor;
    }
}