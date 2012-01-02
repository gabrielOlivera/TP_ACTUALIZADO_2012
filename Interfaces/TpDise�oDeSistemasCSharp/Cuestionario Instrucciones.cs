using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Gestores;

namespace TpDiseñoCSharp
{
    public partial class Cuestionario_Instrucciones : Form
    {
        AdministradorBD administradorBD = new AdministradorBD();
        GestorCuestionario gestorCuestionario = new GestorCuestionario();
        private Bloque bloque_a_mostrar;

        public Cuestionario_Instrucciones()
        {
            InitializeComponent();
            InstruccionesCuestionario.Text = administradorBD.retornarInstruccionesDelcuestionario();
            InstruccionesCuestionario.Text = InstruccionesCuestionario.Text.Replace("@", "\n");
        }

        public Bloque Bloque_a_mostrar
        {
            get { return bloque_a_mostrar; }
            set { bloque_a_mostrar = value; }

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            Completar_Cuestionario completarCuestionario = new Completar_Cuestionario();
            
            completarCuestionario.ShowDialog();
        }

        private void Cuestionario_Instrucciones_Load(object sender, EventArgs e)
        {

        }
        
    }
}
