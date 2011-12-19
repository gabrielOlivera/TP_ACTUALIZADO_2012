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
    public partial class Evaluar_Candidato : Form
    {
        public Evaluar_Candidato(string user)
        {
            InitializeComponent();
            this.Consultor.Text = user;
        }

        private void VerAgregados_Click(object sender, EventArgs e)
        {
            Lista_de_Candidatos listCandidatos = new Lista_de_Candidatos();
            listCandidatos.ShowDialog();
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            Evaluar_Candidatos___Ventana_2 evCandidatos2 = new Evaluar_Candidatos___Ventana_2(this.Consultor.Text);
            evCandidatos2.ShowDialog();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            resultadosDeBusqueda.Visible = true;

        }
    }
}
