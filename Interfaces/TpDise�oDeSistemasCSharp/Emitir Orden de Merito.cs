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
using Validacion;

namespace TpDiseñoCSharp
{
    public partial class Emitir_Orden_de_Mérito : Form
    {
        Form ventanaMenuPrincipal;
        public Emitir_Orden_de_Mérito(Form menuPrincipalConsultor, string user)
        {
            InitializeComponent();
            ventanaMenuPrincipal = menuPrincipalConsultor;
            this.Fecha.Text = DateTime.Now.ToLongDateString();
            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion
            this.Consultor.Text = user;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);

            FormClosed += menuConsultor_Click;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            ventanaMenuPrincipal.Visible = true;
            Close();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if ((FuncionesVarias.validarCamposAlfanum(Codigo.Text)) || (FuncionesVarias.validarCamposAlfanum(NombreDePuesto.Text))
                    || (FuncionesVarias.validarCamposAlfanum(Empresa.Text)))
            {
                MessageBox.Show("Los campos solo aceptan letras y/o números");

            }
            else
            {
                AdministradorBD AdminBD = new AdministradorBD();

                List<Puesto> Lista_de_puestos;

                Lista_de_puestos = AdminBD.recuperarPuestos(this.Codigo.Text.ToString(), this.NombreDePuesto.Text.ToString(), this.Empresa.Text.ToString());

                ResultadosDeBusqueda.DataSource = Lista_de_puestos;

                ResultadosDeBusqueda.Visible = true;
            }
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

        private void menuConsultor_Click(object sender, EventArgs e)
        {
            if (ventanaMenuPrincipal.Created)
            {
                ventanaMenuPrincipal.Visible = true;
                Close();
            }
        }

        private void CerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea CerrarSesion?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                ventanaMenuPrincipal.Close();
                Close();
            }
        }

    }
}
