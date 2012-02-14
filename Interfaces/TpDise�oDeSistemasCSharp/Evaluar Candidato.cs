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
    public partial class Evaluar_Candidato : Form
    {
        private List<Candidato> listaCandidatos_agregados;
        Form pantallaPrincipal, ventanaMenuPrincipal;

        public Evaluar_Candidato(string user, Form pantallaPrincipal_parametro, Form pantallaAnterior)
        {
            InitializeComponent();
            pantallaPrincipal = pantallaPrincipal_parametro;
            ventanaMenuPrincipal = pantallaAnterior;
            listaCandidatos_agregados = new List<Candidato>();

            this.Fecha.Text = DateTime.Now.ToLongDateString();

            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion

            this.Consultor.Text = user;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);

            FormClosed += menuConsultor_Click;
        }

        private void VerAgregados_Click(object sender, EventArgs e)
        {
            Lista_de_Candidatos listCandidatos = new Lista_de_Candidatos(listaCandidatos_agregados);
            listCandidatos.ShowDialog();
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            AdministradorBD admBD = new AdministradorBD();
            List<Candidato> lista_Candidatos_EnEvaluaciones = new List<Candidato>();

            for (int i = 0; i < listaCandidatos_agregados.Count; i++)
            {
                List<Cuestionario> lista_cuest_Asociados = admBD.recuperarCuestionarioActivo(listaCandidatos_agregados[i]);
                if (lista_cuest_Asociados[0].Clave != "NO POSEE")
                {
                    if ((lista_cuest_Asociados[0].Estado.Estado_ == "ACTIVO") || (lista_cuest_Asociados[0].Estado.Estado_ == "EN PROCESO"))
                    {
                        lista_Candidatos_EnEvaluaciones.Add(listaCandidatos_agregados[i]);
                        listaCandidatos_agregados.Remove(listaCandidatos_agregados[i]);
                    }
                }
            }

            if (lista_Candidatos_EnEvaluaciones.Count != 0)
            {
                string mensaje_ = "";
                for (int i = 0; i < lista_Candidatos_EnEvaluaciones.Count; i++)
                {
                    mensaje_ += "\n\n\t " + lista_Candidatos_EnEvaluaciones[i].TipoDoc + " " + lista_Candidatos_EnEvaluaciones[i].NroDoc + " " + lista_Candidatos_EnEvaluaciones[i].Apellido + " " + lista_Candidatos_EnEvaluaciones[i].Nombre;
                }

                MessageBox.Show("Los siguientes candidatos estan siendo evaluados:" + mensaje_ + "\n\nNO PUEDEN SER NUEVAMENTE EVALUADOS");
                resultadosDeBusqueda.Visible = false;
            }
            if(listaCandidatos_agregados.Count != 0)
            {
                Evaluar_Candidatos___Ventana_2 evCandidatos2 = new Evaluar_Candidatos___Ventana_2(this.Consultor.Text,
                    listaCandidatos_agregados, this, ventanaMenuPrincipal);
                this.Visible = false;
                evCandidatos2.ShowDialog();
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if ((FuncionesVarias.validarCamposAlfa(apellido.Text)) || (FuncionesVarias.validarCamposAlfa(nombre.Text)))
            {
                MessageBox.Show("Los campos Nombre y Apellido sólo aceptan letras");
            }
            else if ((FuncionesVarias.validarCamposNumericos(nroEmpleado.Text)) || (FuncionesVarias.validarCamposNumericos(nroCandidato.Text)))
            {
                MessageBox.Show("Los campos N° de Empleado y N° de Candidato sólo aceptan números");
            }
            else
            {
                GestorCandidatos gestorCandidatos = new GestorCandidatos();

                int nroDeCandidato;
                if (this.nroEmpleado.Text.ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                    nroDeCandidato = 0;
                else
                    nroDeCandidato = Int32.Parse(this.nroEmpleado.Text.ToString());//Se lo transforma a un numero entero

                int nroDeEmpleado;
                if (this.nroCandidato.Text.ToString() == "")//Se contempla la posibilidad de que este número sea nulo
                    nroDeEmpleado = 0;
                else
                    nroDeEmpleado = Int32.Parse(this.nroCandidato.Text.ToString());//Se lo transforma a un numero entero

                List<Candidato> listaCandidatos = gestorCandidatos.listarCandidatos(apellido.Text.ToString(), nombre.Text.ToString(), nroDeEmpleado, nroDeCandidato);
                if (listaCandidatos != null)
                {
                    resultadosDeBusqueda.Visible = true;
                    resultadosDeBusqueda.DataSource = listaCandidatos;
                    resultadosDeBusqueda.Columns.Remove("Clave");
                    resultadosDeBusqueda.Columns.Remove("TipoDoc");
                    resultadosDeBusqueda.Columns.Remove("NroDoc");
                }
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            int fila_seleccionada = resultadosDeBusqueda.CurrentRow.Index;
            bool noAgregado = true;

            List<Candidato> lista_cand_ = (List<Candidato>)resultadosDeBusqueda.DataSource;
            //MessageBox.Show("candidato seleccionado " + lista_cand_[fila_seleccionada].Apellido +" "+ lista_cand_[fila_seleccionada].Nombre);

            if(listaCandidatos_agregados.Exists(delegate(Candidato c) { return c.NroDoc == lista_cand_[fila_seleccionada].NroDoc; }))
                noAgregado = false;

            //MessageBox.Show("NO fue agregado ?? " + noAgregado);
            if(noAgregado == true)
                listaCandidatos_agregados.Add(lista_cand_[fila_seleccionada]);

        }

        private void menuConsultor_Click(object sender, EventArgs e)
        {
            ventanaMenuPrincipal.Visible = true;
            Close();
        }
    }
}
