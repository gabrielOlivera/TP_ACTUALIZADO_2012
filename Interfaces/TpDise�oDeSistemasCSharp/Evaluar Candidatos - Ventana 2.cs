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
        private List<Candidato> listaCandidatos_A_Evaluar;

        private List<Caracteristica> Seleccion_puesto_check;
        private Form mensajePuesto;
        private Puesto puestoSeleccionado;

        public Evaluar_Candidatos___Ventana_2(string user, List<Candidato> listaCandidatos)
        {
            InitializeComponent();
            listaCandidatos_A_Evaluar = listaCandidatos;
           
            //Este codigo se utiliza para setear el nombre del usuario conectado y su ubicacion
            this.Consultor.Text = user;
            int largoTextoConsultor = Consultor.Width;
            int ubicacionCerrarSesion = CerrarSesion.Location.X;
            Consultor.Location = new Point(ubicacionCerrarSesion - largoTextoConsultor - 2, CerrarSesion.Top);
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            Evaluar_Candidatos___Ventana_3 evCandidatos3 = new Evaluar_Candidatos___Ventana_3(this.Consultor.Text);
            evCandidatos3.ShowDialog();
        }

        private void Atras_Click(object sender, EventArgs e)
        {

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if ((FuncionesVarias.validarCamposAlfanum(nombrePuesto.Text))
                   || (FuncionesVarias.validarCamposAlfanum(nombreEmpresa.Text)))
            {
                MessageBox.Show("Los campos solo aceptan letras y/o números");

            }
            else
            {
                GestorPuesto gestorPuesto = new GestorPuesto();

                List<Puesto> listaPuesto = gestorPuesto.listarPuestos(null, this.nombrePuesto.Text.ToString(), this.nombreEmpresa.Text.ToString());

                if (listaPuesto != null)
                {
                    GroupBox paraSeleccion = mostrarPuestos(listaPuesto);
                    mensajePuesto = new Form();

                    Button Aceptar = new Button();
                    Aceptar.Text = "Aceptar";
                    Aceptar.Location = new Point(paraSeleccion.Right - 50, paraSeleccion.Height + 90);
                    Aceptar.Click += Aceptar_click;

                    mensajePuesto.Controls.Add(paraSeleccion);
                    mensajePuesto.Controls.Add(Aceptar);
                    mensajePuesto.Text = "Evaluar Candidato";
                    mensajePuesto.AutoSize = true;

                    mensajePuesto.ShowDialog();
                }

                Label caracteristicas = new Label();
                caracteristicas.Text = "Competencias        Ponderacion";
                caracteristicas.AutoSize = true;
                caracteristicas.Location = new Point(50, 30);
                CaracteristicasDel_puesto.Controls.Add(caracteristicas);

                for (int i = 0; i < puestoSeleccionado.Caracteristicas.Count; i++)
                {
                    
                    Competencia comp_ = (Competencia)puestoSeleccionado.Caracteristicas[i].dato1;
                    Ponderacion pond_ = (Ponderacion)puestoSeleccionado.Caracteristicas[i].dato2;
                    caracteristicas.Text = comp_.Nombre + "        " + pond_.Valor;

                    caracteristicas.AutoSize = true;
                    caracteristicas.Location = new Point(50, 30 + (i * 10));
                    CaracteristicasDel_puesto.Controls.Add(caracteristicas);
                }

                CaracteristicasDel_puesto.Text += puestoSeleccionado.Nombre;
                CaracteristicasDel_puesto.Visible = true;
            }
        }
        public void Aceptar_click(object sender, EventArgs e)
        {
            int contador = 0;

            for (int i = 0; i < Seleccion_puesto_check.Count; i++)
            {
                CheckBox check_ = (CheckBox)Seleccion_puesto_check[i].dato2;

                if (check_.Checked == true)
                {
                    contador++;
                    puestoSeleccionado = (Puesto)Seleccion_puesto_check[i].dato1;
                }
            }

            if (contador == 1)
                mensajePuesto.Close();
            else
                MessageBox.Show("Solo puede seleccionar un solo puesto para evaluar los candidatos");
        }

        /*
       * El metodo mostrarPreguntas hace la construccion en pantalla del bloque con las preguntas que se deberan responder
       */
        public GroupBox mostrarPuestos(List<Puesto> listPuestos)
        {
            Seleccion_puesto_check = new List<Caracteristica>();
            GroupBox espacioDe_Puestos = new GroupBox();
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
                CheckBox chequinPuesto = ubicarOpcion(espacioDe_Puestos, nombrePuesto, i);

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
        private CheckBox ubicarOpcion(GroupBox espacioPuestos, string opcion, int distanciaMaxima)
        {
            CheckBox checkPregunta = new CheckBox();

            if (opcion != "")
            {
                checkPregunta.Text = opcion;
                checkPregunta.AutoSize = true;
                checkPregunta.Location = new Point(espacioPuestos.Height, 40 + (distanciaMaxima * 20));

                espacioPuestos.Controls.Add(checkPregunta);

            }
            return checkPregunta;
        }
    }
}
