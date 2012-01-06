using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestores;

namespace TpDiseñoCSharp
{
    public partial class Cuestionario_Instrucciones : Form
    {
        AdministradorBD administradorBD = new AdministradorBD();

        public Cuestionario_Instrucciones()
        {
            InitializeComponent();
            InstruccionesCuestionario.Text = administradorBD.retornarInstruccionesDelcuestionario();
            InstruccionesCuestionario.Text = InstruccionesCuestionario.Text.Replace("@", "\n");
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {

            Completar_Cuestionario completarCuestionario = new Completar_Cuestionario();
            completarCuestionario.ShowDialog();
        }
        
    }
}
