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
    public partial class Evaluar_Candidatos___Ventana_2 : Form
    {
        private List<Candidato> listaCandidatos_A_Evaluar;
        public Evaluar_Candidatos___Ventana_2(string user, List<Candidato> listaCandidatos)
        {
            InitializeComponent();
            listaCandidatos_A_Evaluar = listaCandidatos;
            this.Consultor.Text = user;
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            Evaluar_Candidatos___Ventana_3 evCandidatos3 = new Evaluar_Candidatos___Ventana_3(this.Consultor.Text);
            evCandidatos3.ShowDialog();
        }
    }
}
