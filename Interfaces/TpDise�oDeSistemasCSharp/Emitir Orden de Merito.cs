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
    public partial class Emitir_Orden_de_Mérito : Form
    {
        public Emitir_Orden_de_Mérito(string user)
        {
            InitializeComponent();
            this.Consultor.Text = user;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            AdministradorBD AdminBD = new AdministradorBD();
            
            List<Puesto> Lista_de_puestos;

            Lista_de_puestos = AdminBD.recuperarPuestos(this.codigo.Text.ToString(), this.nombre.Text.ToString(), this.empresa.Text.ToString());

            ResultadosDeBusqueda.DataSource = Lista_de_puestos;

            ResultadosDeBusqueda.Visible = true;
        }

        private void EmitirOrdenDeMerito_Click(object sender, EventArgs e)
        {
            AdministradorBD AdminBD = new AdministradorBD();
            if (ResultadosDeBusqueda.Visible == false)
            {
                MessageBox.Show("Por favor, realize antes la busqueda del puesto deseado");
                return;
            }

            int numero_fila_seleccionada = ResultadosDeBusqueda.CurrentRow.Index;
            
            string codigo_puesto_seleccionado = ResultadosDeBusqueda[0, numero_fila_seleccionada].Value.ToString();

            List<Puesto> Lista_puestos = (List<Puesto>) ResultadosDeBusqueda.DataSource;
            
            Puesto puesto_seleccionado = Lista_puestos.Find(delegate(Puesto p) { return p.Codigo == codigo_puesto_seleccionado; });

            List<PuestoEvaluado> Lista_puestos_ev = AdminBD.recuperarPuestos_ev(puesto_seleccionado.Codigo);

            //ResultadosDeBusqueda.DataSource = Lista_puestos_ev;
            
            Seleccion_de_evaluaciones SelEvaluaciones = new Seleccion_de_evaluaciones(Lista_puestos_ev);
            SelEvaluaciones.ShowDialog();
        }

    }
}
