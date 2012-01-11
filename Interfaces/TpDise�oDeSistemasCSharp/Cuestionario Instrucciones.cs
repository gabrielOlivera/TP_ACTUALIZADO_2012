using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestores;
using Entidades;

namespace TpDiseñoCSharp
{
    public partial class Cuestionario_Instrucciones : Form
    {
        AdministradorBD administradorBD = new AdministradorBD();

        private Cuestionario cuestionarioAmostrar;

        public Cuestionario Cuestionario_A_mostrar
        {
            get { return cuestionarioAmostrar; }
            set { cuestionarioAmostrar = value; }

        }

        public Cuestionario_Instrucciones()
        {
            InitializeComponent();
            InstruccionesCuestionario.Text = administradorBD.retornarInstruccionesDelcuestionario();
            InstruccionesCuestionario.Text = InstruccionesCuestionario.Text.Replace("@", "\n");
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            GestorCuestionario gestorCuestionarios = new GestorCuestionario();

            Bloque bloqueA_Mostrar = gestorCuestionarios.inicializarCuestionario(this.Cuestionario_A_mostrar);
            if (bloqueA_Mostrar != null)
            {
                Completar_Cuestionario completarCuestionario = new Completar_Cuestionario(bloqueA_Mostrar);
                completarCuestionario.ShowDialog();
            }
        }
        
    }
}
