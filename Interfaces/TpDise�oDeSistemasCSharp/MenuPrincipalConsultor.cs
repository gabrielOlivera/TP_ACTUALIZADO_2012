using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TpDiseñoCSharp
{
    public partial class MenuPrincipalConsultor : Form
    {
        private Form pantalla_Principal;

        public MenuPrincipalConsultor(string User, Form pantallaPricipal_parametro, Form pantallaAnterior)
        {
            InitializeComponent();
            pantalla_Principal = pantallaPricipal_parametro;
            pantallaAnterior.Close();
            this.Consultor.Text = User;
            FormClosing += CerrarVentana;
        }

        private void EmitirOrdenDeMerito_Click(object sender, EventArgs e)
        {
            Emitir_Orden_de_Mérito ordenDeMerito = new Emitir_Orden_de_Mérito(this.Consultor.Text);
            this.Visible = false;
            ordenDeMerito.ShowDialog();
        }

        private void EvaluarCandidatos_Click(object sender, EventArgs e)
        {
            Evaluar_Candidato evCandidato = new Evaluar_Candidato(this.Consultor.Text, pantalla_Principal, this);
            this.Visible = false;
            evCandidato.ShowDialog();

        }

        private void PuestoFunciones_Click(object sender, EventArgs e)
        {
            Gestionar_Puestos gestPuesto = new Gestionar_Puestos(this.Consultor.Text);
            gestPuesto.ShowDialog();
        }

        private void CerrarVentana(object sender, EventArgs e)
        {
            pantalla_Principal.Visible = true;
        }

        /*=====================================================
          ESTAS FUNCIONALIDADES NO SON IMPLEMENTADAS EN EL TP
          =====================================================*/

        private void ImportarCandidatos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no ha sido implementada");
        }

        private void ExportarResultados_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no ha sido implementada");
        }

        private void EmitirReporteComparativo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no ha sido implementada");
        }

        private void Competencias_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no ha sido implementada");
        }

        private void Factores_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no ha sido implementada");
        }

        private void Preguntas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no ha sido implementada");
        }

        private void OpcionesDeRespuesta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no ha sido implementada");
        }

        /*=====================================================
              FIN DE FUNCIONALIDADES QUE NO SON IMPLEMENTADAS
          =====================================================*/
    }
}
