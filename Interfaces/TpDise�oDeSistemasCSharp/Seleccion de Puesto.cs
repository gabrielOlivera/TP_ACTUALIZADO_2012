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
    public partial class Seleccion_de_Puesto : Form
    {
        //private List<Candidato> listaCandidatos_A_Evaluar;
        private Evaluar_Candidatos___Ventana_2 pantallaAnterior_;

        private List<Caracteristica> Seleccion_puesto_check;

        public Seleccion_de_Puesto(List<Puesto> listaDePuestos, Evaluar_Candidatos___Ventana_2 pantallaEvaluar)
        {
            InitializeComponent();
            pantallaAnterior_ = pantallaEvaluar;

            paraSeleccion = mostrarPuestos(listaDePuestos);
        }

        /*
       * El metodo mostrarPreguntas hace la construccion en pantalla del bloque con las preguntas que se deberan responder
       */
        public Panel mostrarPuestos(List<Puesto> listPuestos)
        {
            Seleccion_puesto_check = new List<Caracteristica>();
            string nombrePuesto;

            for (int i = 0; i < listPuestos.Count; i++)
            {
                nombrePuesto = listPuestos[i].Codigo + "                      " + listPuestos[i].Nombre;
                RadioButton chequinPuesto = ubicarOpcion(paraSeleccion, nombrePuesto, i);

                Caracteristica elemento = new Caracteristica();
                elemento.dato1 = listPuestos[i];
                elemento.dato2 = chequinPuesto;
                Seleccion_puesto_check.Add(elemento);
            }

            return paraSeleccion;
        }

        private RadioButton ubicarOpcion(Panel espacioPuestos, string opcion, int distanciaMaxima)
        {
            RadioButton checkPregunta = new RadioButton();

            if (opcion != "")
            {
                checkPregunta.Text = opcion;
                checkPregunta.AutoSize = true;
                checkPregunta.Location = new Point(labelCodigo.Width, (distanciaMaxima * 20));

                espacioPuestos.Controls.Add(checkPregunta);

            }
            return checkPregunta;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            AdministradorBD admBD = new AdministradorBD();
            Puesto puestoSeleccionado = null;
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

                    pantallaAnterior_.PuestoSeleccionado = puestoSeleccionado;
                }
                else
                {
                    puestoSeleccionado = null;

                    pantallaAnterior_.PuestoSeleccionado = puestoSeleccionado;
                }
                Close();
            }
            else
                MessageBox.Show("Debe seleccionar un puesto para evaluar los candidatos");
        }
    }
}
