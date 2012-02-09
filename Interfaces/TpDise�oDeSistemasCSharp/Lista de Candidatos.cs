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

        public Lista_de_Candidatos(List<Candidato> listaParametro)
        {
            InitializeComponent();
            listaCandidatoAgregados = listaParametro;
            dataGridView1.DataSource = listaCandidatoAgregados;
        }

        private void Quitar_Click(object sender, EventArgs e)
        {

            int fila_seleccionada = dataGridView1.CurrentRow.Index;

            List<Candidato> lista_cand_ = (List<Candidato>)dataGridView1.DataSource;
            //MessageBox.Show("candidato seleccionado " + lista_cand_[fila_seleccionada].Apellido +" "+ lista_cand_[fila_seleccionada].Nombre);
            
            try
            {
                listaCandidatoAgregados.Remove(lista_cand_[fila_seleccionada]);
                //dataGridView1.Refresh();
            }
            catch (DataException) 
            {
                MessageBox.Show("paso un error");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
