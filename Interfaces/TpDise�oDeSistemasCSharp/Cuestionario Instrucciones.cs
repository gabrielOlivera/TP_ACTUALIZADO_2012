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

        public Cuestionario_Instrucciones()
        {
            InitializeComponent();
            InstruccionesCuestionario.Text = administradorBD.retornarInstruccionesDelcuestionario();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            Cuestionario cuestionario = (Cuestionario)sender;
            Completar_Cuestionario completarCuestionario = new Completar_Cuestionario();
            completarCuestionario.ShowDialog();
        }
        
    }
}
