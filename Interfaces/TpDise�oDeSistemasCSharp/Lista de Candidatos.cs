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
    public partial class Lista_de_Candidatos : Form
    {
        private List<Candidato> listaCandidatoAgregados;
        private List<Candidato> listaCandidatoEliminados;

        public Lista_de_Candidatos(List<Candidato> listaParametro)
        {
            InitializeComponent();
            this.Fecha.Text = DateTime.Now.ToLongDateString();
            listaCandidatoEliminados = new List<Candidato>();
            listaCandidatoAgregados = listaParametro;
            dataGridView1.DataSource = listaCandidatoAgregados;
        }

        private void Quitar_Click_1(object sender, EventArgs e)
        {
            if (listaCandidatoAgregados.Count > 0)
            {
                int fila_seleccionada = dataGridView1.CurrentRow.Index;

                List<Candidato> lista_cand_ = (List<Candidato>)dataGridView1.DataSource;

                listaCandidatoEliminados.Add(lista_cand_[fila_seleccionada]);
                listaCandidatoAgregados.Remove(lista_cand_[fila_seleccionada]);
                dataGridView1.DataSource = "";
                dataGridView1.DataSource = listaCandidatoAgregados;
                dataGridView1.Refresh();
            }
        }

        private void Cancelar_Click_1(object sender, EventArgs e)
        {
            if (listaCandidatoEliminados.Count > 0)
            {
                listaCandidatoAgregados.Add(listaCandidatoEliminados.Last());
                listaCandidatoEliminados.Remove(listaCandidatoEliminados.Last());
                dataGridView1.DataSource = "";
                dataGridView1.DataSource = listaCandidatoAgregados;
                dataGridView1.Refresh();
            }
        }
    }
}
