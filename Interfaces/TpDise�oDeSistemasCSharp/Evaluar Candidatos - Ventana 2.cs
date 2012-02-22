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
    public partial class Evaluar_Candidatos___Ventana_2 : Form
    {
        private Form ventanaMenuPrincipal, ventanaEvCandidatos;
        private List<Candidato> listaCandidatos_A_Evaluar;
        private Puesto puestoSeleccionado;

        private List<Caracteristica> Seleccion_puesto_check;
        private Form mensajePuesto;

        public Evaluar_Candidatos___Ventana_2(string user, List<Candidato> listaCandidatos, Form ventanaAnterior, Form pantallaPrincipal_parametro)
        {
            InitializeComponent();
            ventanaEvCandidatos=ventanaAnterior;
           
            ventanaMenuPrincipal = pantallaPrincipal_parametro;
            listaCandidatos_A_Evaluar = listaCandidatos;
            this.Fecha.Text = DateTime.Now.ToLongDateString();
 
            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion
            this.Consultor.Text = user;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);

            FormClosed += menuConsultor_Click;
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            Evaluar_Candidatos___Ventana_3 evCandidatos3 = new Evaluar_Candidatos___Ventana_3(this.Consultor.Text, puestoSeleccionado
                , listaCandidatos_A_Evaluar, ventanaMenuPrincipal, this);
            this.Visible = false;
            evCandidatos3.ShowDialog();
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            Evaluar_Candidato evaluar_Candidato_1 = new Evaluar_Candidato(this.Consultor.Text, ventanaMenuPrincipal, this);
            ventanaEvCandidatos.Visible = true;
            this.Visible = false;
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            CaracteristicasDel_puesto.Visible = false;
            CaracteristicasDel_puesto.Controls.Clear();
            Siguiente.Visible = false;
            puestoSeleccionado = null;

            GestorPuesto gestorPuesto = new GestorPuesto();

            if ((FuncionesVarias.validarCamposAlfanum(nombrePuesto.Text))
                   || (FuncionesVarias.validarCamposAlfanum(nombreEmpresa.Text)))
            {
                MessageBox.Show("Los campos solo aceptan letras y/o números");

            }
            else
            {
                List<Puesto> listaPuesto = gestorPuesto.listarPuestos(null, this.nombrePuesto.Text.ToString(), this.nombreEmpresa.Text.ToString());

                if (listaPuesto != null)
                {
                    Panel paraSeleccion = mostrarPuestos(listaPuesto);
                    paraSeleccion.AutoScroll = true;
                    mensajePuesto = new Form();
                    mensajePuesto.MaximizeBox = false;
                    mensajePuesto.MinimizeBox = false;
                    mensajePuesto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

                    Button Aceptar = new Button();
                    Aceptar.Text = "Aceptar";
                    Aceptar.Location = new Point(paraSeleccion.Right - 40, paraSeleccion.Height + 90);
                    Aceptar.Click += Aceptar_click;

                    mensajePuesto.Controls.Add(paraSeleccion);
                    mensajePuesto.Controls.Add(Aceptar);
                    mensajePuesto.Text = "Evaluar Candidato";
                    mensajePuesto.AutoSize = true;

                    mensajePuesto.ShowDialog();
                }

                if (puestoSeleccionado != null)
                {
                    if (Equals(puestoSeleccionado.Caracteristicas[0].dato1.GetType(), "stringEJEMPLO".GetType()) == false)
                    {
                        int cadenaMasLarga = 0;
                        for (int i = 0; i < puestoSeleccionado.Caracteristicas.Count; i++)
                        {
                            Competencia comp_ = (Competencia)puestoSeleccionado.Caracteristicas[i].dato1;
                            if (cadenaMasLarga < comp_.Nombre.Count())
                                cadenaMasLarga = comp_.Nombre.Count();
                        }

                        Label label_competencia = new Label();
                        Label label_ponderacion = new Label();
                        label_competencia.Text = "COMPETENCIAS"; label_competencia.AutoSize = true;
                        label_competencia.Location = new Point(50, 30);

                        label_ponderacion.Text = "PONDERACIÓNES"; label_ponderacion.AutoSize = true;
                        label_ponderacion.Location = new Point(label_competencia.Right + (cadenaMasLarga * 6), 30);

                        CaracteristicasDel_puesto.Controls.Add(label_competencia);
                        CaracteristicasDel_puesto.Controls.Add(label_ponderacion);

                        for (int i = 0; i < puestoSeleccionado.Caracteristicas.Count; i++)
                        {
                            Competencia comp_ = (Competencia)puestoSeleccionado.Caracteristicas[i].dato1;
                            Ponderacion pond_ = (Ponderacion)puestoSeleccionado.Caracteristicas[i].dato2;

                            Label label_comp_ = new Label();
                            Label label_pond_ = new Label();

                            label_comp_.Text = comp_.Nombre; label_comp_.AutoSize = true;
                            label_comp_.Location = new Point(50, label_competencia.Bottom + (i * 20));

                            label_pond_.Text = pond_.Valor.ToString(); label_pond_.AutoSize = true;
                            label_pond_.Location = new Point(label_comp_.Right + (cadenaMasLarga * 6), label_ponderacion.Bottom + (i * 20));

                            CaracteristicasDel_puesto.Controls.Add(label_comp_);
                            CaracteristicasDel_puesto.Controls.Add(label_pond_);
                        }

                        CaracteristicasDel_puesto.Text = "Competencias asociadas al puesto: " + puestoSeleccionado.Nombre;
                        CaracteristicasDel_puesto.Visible = true;
                        Siguiente.Visible = true;
                    }
                    else
                        MessageBox.Show(puestoSeleccionado.Caracteristicas[0].dato1.ToString());
                }
            }

        }

        public void Aceptar_click(object sender, EventArgs e)
        {
            AdministradorBD admBD = new AdministradorBD();
            int contador = 0;

            for (int i = 0; i < Seleccion_puesto_check.Count; i++)
            {
                RadioButton check_ = (RadioButton)Seleccion_puesto_check[i].dato2;

                if (check_.Checked == true)
                {
                    contador++;
                    puestoSeleccionado = (Puesto)Seleccion_puesto_check[i].dato1;
                }
            }

            if (contador == 1)
            {
                List<Caracteristica> caracteristicas_del_puesto = admBD.reconstruir_CaracteristicasPuesto(puestoSeleccionado);
                if (caracteristicas_del_puesto != null)
                {
                    puestoSeleccionado.Caracteristicas = caracteristicas_del_puesto;
                }
                else
                {
                    puestoSeleccionado = null;
                }
                mensajePuesto.Close();
            }
            else
                MessageBox.Show("Debe seleccionar un puesto para evaluar los candidatos");
        }

        /*
       * El metodo mostrarPreguntas hace la construccion en pantalla del bloque con las preguntas que se deberan responder
       */
        public Panel mostrarPuestos(List<Puesto> listPuestos)
        {
            Seleccion_puesto_check = new List<Caracteristica>();
            Panel espacioDe_Puestos = new Panel();
            espacioDe_Puestos.Text = "Elija un puesto para evaluar a los candidatos";
            espacioDe_Puestos.Width = espacioDe_Puestos.Text.Length * 10;
            espacioDe_Puestos.Location = new Point(50, 20);
            espacioDe_Puestos.AutoSize = true;
            Label codigo_nombre = new Label();
            codigo_nombre.AutoSize = true;
            codigo_nombre.Text = "    CODIGO       NOMBRE DEL PUESTO";
            codigo_nombre.Location = new Point(espacioDe_Puestos.Height, 20);

            espacioDe_Puestos.Controls.Add(codigo_nombre);

            string nombrePuesto;

            for (int i = 0; i < listPuestos.Count; i++)
            {
                nombrePuesto = listPuestos[i].Codigo + "             " + listPuestos[i].Nombre;
                RadioButton chequinPuesto = ubicarOpcion(espacioDe_Puestos, nombrePuesto, i);

                Caracteristica elemento = new Caracteristica();
                elemento.dato1 = listPuestos[i];
                elemento.dato2 = chequinPuesto;
                Seleccion_puesto_check.Add(elemento);
            }

            return espacioDe_Puestos;
        }

        /*
         * Metodo ubicarOpcion: es complemetentario al mostrarPreguntas, su finalidad es ubicar en la pantalla los groupBox
         * que agruparan las opciones de respuestas posibles para una pregunta, añadiendoles un checkBox para señalar la respuesta
         * seleccionada por el usuario o candidato
         */
        private RadioButton ubicarOpcion(Panel espacioPuestos, string opcion, int distanciaMaxima)
        {
            RadioButton checkPregunta = new RadioButton();

            if (opcion != "")
            {
                checkPregunta.Text = opcion;
                checkPregunta.AutoSize = true;
                checkPregunta.Location = new Point(espacioPuestos.Height, 40 + (distanciaMaxima * 20));

                espacioPuestos.Controls.Add(checkPregunta);

            }
            return checkPregunta;
        }

        private void menuConsultor_Click(object sender, EventArgs e)
        {
            if (ventanaMenuPrincipal.Created)
            {
                ventanaMenuPrincipal.Visible = true;
                ventanaEvCandidatos.Close();
                Close();
            }
        }

        private void CerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea CerrarSesion?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ventanaEvCandidatos.Close();
                ventanaMenuPrincipal.Close();
                Close();
            }
        }
    }
}
